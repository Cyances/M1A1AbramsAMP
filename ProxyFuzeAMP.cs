using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using GHPC.Weapons;
using HarmonyLib;
using MelonLoader;
using static MelonLoader.MelonLogger;
using GHPC.Camera;
using GHPC.Equipment.Optics;
using GHPC.Player;
using M1A1AMP;

namespace M1A1AMP
{
    public class ProxySwitchAMP : MonoBehaviour
    {
        public bool activated = false;
        private float cd = 0f;
        private WeaponSystem weapon = null;
        private PlayerInput player_manager;

        void Awake()
        {
            weapon = GetComponent<WeaponsManager>().Weapons[0].Weapon;
            player_manager = GameObject.Find("_APP_GHPC_").GetComponent<PlayerInput>();
        }

        void Update()
        {
            cd -= Time.deltaTime;

            if (player_manager.CurrentPlayerUnit.gameObject.GetInstanceID() != gameObject.GetInstanceID()) return;

            M1A1AbramsAMPMod.clip_xm1147.Name = activated ? "XM1147 AMP-T [Proximity]" : "XM1147 AMP-T";

            if (Input.GetKey(KeyCode.Mouse2) && cd <= 0f && weapon.CurrentAmmoType == M1A1AbramsAMPMod.ammo_xm1147)
            {
                cd = 0.2f;

                activated = !activated;
            }
        }
    }

    public class ProxyFuzeAMP : MonoBehaviour
    {
        private GHPC.Weapons.LiveRound live_round;
        private static GameObject prox_fuse;
        private static HashSet<string> prox_ammos = new HashSet<string>();
        private bool detonated = false;

        // must be called at least once 
        public static void Init()
        {
            if (prox_fuse) return;
            prox_fuse = new GameObject("amp prox fuse");
            prox_fuse.layer = 8;
            prox_fuse.SetActive(false);
            prox_fuse.AddComponent<ProxyFuzeAMP>();
        }

        public static void AddFuzeAMP(AmmoType ammo_type)
        {
            if (prox_ammos.Contains(ammo_type.Name)) return;
            prox_ammos.Add(ammo_type.Name);
        }

        void Detonate()
        {
            if (detonated) return;
            live_round._rangedFuseActive = true;
            live_round._rangedFuseCountdown = 0f;
            detonated = true;
        }

        void Update()
        {
            if (!live_round) return;

            RaycastHit hit;
            Vector3 pos = live_round.transform.position;

            if (Physics.Raycast(pos, live_round.transform.forward, out hit, 10f, 1 << 8))
                if (hit.collider.CompareTag("Penetrable"))
                    Detonate();

            RaycastHit hit2;
            if (Physics.Raycast(pos, Vector3.down, out hit2, 30f, 1 << 8))
                if (hit2.collider.CompareTag("Penetrable"))
                    Detonate();

            RaycastHit hit3;
            if (Physics.SphereCast(pos, M1A1AbramsAMPMod.proxyDistance.Value, live_round.transform.forward, out hit3, 0.1f, 1 << 8))
            //if (Physics.SphereCast(pos, 3f, live_round.transform.forward, out hit3, 0.1f, 1 << 8))
                if (hit3.collider.CompareTag("Penetrable"))
                    Detonate();

        }

        [HarmonyPatch(typeof(GHPC.Weapons.LiveRound), "Start")]
        public static class SpawnProximityFuse
        {
            private static void Prefix(GHPC.Weapons.LiveRound __instance)
            {
                if (prox_ammos.Contains(__instance.Info.Name) && __instance.gameObject.transform.Find("amp prox fuse(Clone)") == null)
                {
                    GameObject p = GameObject.Instantiate(prox_fuse, __instance.transform);
                    p.GetComponent<ProxyFuzeAMP>().live_round = __instance;
                    p.SetActive(__instance.Shooter.gameObject.GetComponent<ProxySwitchAMP>().activated);
                }
                else if (__instance.gameObject.transform.Find("amp prox fuse(Clone)"))
                {
                    GameObject.DestroyImmediate(__instance.gameObject.transform.Find("amp prox fuse(Clone)").gameObject);
                }
            }
        }

        //[HarmonyPatch(typeof(GHPC.Weapons.LiveRound), "createExplosion")]
        /*public class ForwardBurst
        {
            private static bool Prefix(GHPC.Weapons.LiveRound __instance)
            {
                if (__instance.Info.Name != "XM1147 AMP-T") return true;
                if (!__instance.gameObject.GetComponentInChildren<ProxyFuzeAMP>()) return true;
                if (!__instance.gameObject.GetComponentInChildren<ProxyFuzeAMP>().detonated) return true;

                int fragCount = M1A1AbramsAMPMod.ampFragments.Value / 6;

                for (int i = 0; i < fragCount; i++)
                {
                    GHPC.Weapons.LiveRound component;
                    component = LiveRoundMarshaller.Instance.GetRoundOfVisualType(LiveRoundMarshaller.LiveRoundVisualType.Invisible)
                        .GetComponent<GHPC.Weapons.LiveRound>();

                    component.Info = M1A1AbramsAMPMod.xm1147_forward_frag;
                    component.CurrentSpeed = 600f;
                    component.MaxSpeed = 600f;
                    component.IsSpall = false;
                    component.Shooter = __instance.Shooter;
                    component.transform.position = __instance.transform.position;
                    component.transform.forward = Quaternion.Euler(
                        UnityEngine.Random.Range(-30f, 30f),
                        UnityEngine.Random.Range(-30f, 30f),
                        UnityEngine.Random.Range(-30f, 30f)) * __instance.transform.forward;
                    component.Init(__instance, null);
                    component.name = "AMP forward frag " + i;
                }

                return true;
            }
        }*/
    }
}