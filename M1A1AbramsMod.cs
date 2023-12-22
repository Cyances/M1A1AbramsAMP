using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GHPC.Camera;
using GHPC.Equipment.Optics;
using GHPC.Player;
using GHPC.Vehicle;
using GHPC.Weapons;
using HarmonyLib;
using MelonLoader;
using UnityEngine;


namespace M1A1Abrams
{
    public class M1A1AbramsMod : MelonMod
    {
        MelonPreferences_Category cfg;
        MelonPreferences_Entry<int> m829Count;
        MelonPreferences_Entry<int> m830Count;
        MelonPreferences_Entry<bool> rotateAzimuth;
        MelonPreferences_Entry<bool> m1e1;
        MelonPreferences_Entry<int> randomChanceNum;
        MelonPreferences_Entry<bool> randomChance;
        MelonPreferences_Entry<bool> useSuperSabot;
        MelonPreferences_Entry<bool> useAMPShell;
        MelonPreferences_Entry<int> ampFragments;

        GameObject[] vic_gos;
        GameObject gameManager;
        CameraManager cameraManager;
        PlayerInput playerManager;

        WeaponSystemCodexScriptable gun_m256;

        AmmoClipCodexScriptable clip_codex_m829;
        AmmoType.AmmoClip clip_m829;
        AmmoCodexScriptable ammo_codex_m829;
        AmmoType ammo_m829;

        AmmoClipCodexScriptable clip_codex_m829a4;
        AmmoType.AmmoClip clip_m829a4;
        AmmoCodexScriptable ammo_codex_m829a4;
        AmmoType ammo_m829a4;

        AmmoClipCodexScriptable clip_codex_m830;
        AmmoType.AmmoClip clip_m830;
        AmmoCodexScriptable ammo_codex_m830;
        AmmoType ammo_m830;

        AmmoClipCodexScriptable clip_codex_XM1147;
        AmmoType.AmmoClip clip_XM1147;
        AmmoCodexScriptable ammo_codex_XM1147;
        static AmmoType ammo_xm1147;

        AmmoType ammo_m833;
        AmmoType ammo_m456;

        public static void ShallowCopy(System.Object dest, System.Object src)
        {
            BindingFlags flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
            FieldInfo[] destFields = dest.GetType().GetFields(flags);
            FieldInfo[] srcFields = src.GetType().GetFields(flags);

            foreach (FieldInfo srcField in srcFields)
            {
                FieldInfo destField = destFields.FirstOrDefault(field => field.Name == srcField.Name);

                if (destField != null && !destField.IsLiteral)
                {
                    if (srcField.FieldType == destField.FieldType)
                        destField.SetValue(dest, srcField.GetValue(src));
                }
            }
        }

        public static void EmptyRack(GHPC.Weapons.AmmoRack rack)
        {
            MethodInfo removeVis = typeof(GHPC.Weapons.AmmoRack).GetMethod("RemoveAmmoVisualFromSlot", BindingFlags.Instance | BindingFlags.NonPublic);

            PropertyInfo stored_clips = typeof(GHPC.Weapons.AmmoRack).GetProperty("StoredClips");
            stored_clips.SetValue(rack, new List<AmmoType.AmmoClip>());

            rack.SlotIndicesByAmmoType = new Dictionary<AmmoType, List<byte>>();

            foreach (Transform transform in rack.VisualSlots)
            {
                AmmoStoredVisual vis = transform.GetComponentInChildren<AmmoStoredVisual>();

                if (vis != null && vis.AmmoType != null)
                {
                    removeVis.Invoke(rack, new object[] { transform });
                }
            }
        }

        public override void OnInitializeMelon()
        {
            cfg = MelonPreferences.CreateCategory("M1A1AMPConfig");
            m829Count = cfg.CreateEntry<int>("M829/A4", 20);
            m829Count.Description = "How many rounds of M829/A4 (APFSDS) or M830/XM1147 (HEAT) each M1A1 should carry. Maximum of 44 rounds total. Bring in at least one M829 round.";
            m830Count = cfg.CreateEntry<int>("M830/XM1147", 24);

            useSuperSabot = cfg.CreateEntry<bool>("UseM829A4", true);
            useSuperSabot.Description = "In case 600mm of RHA penetration is not working out for you, then 1000mm for when you want to penetrate 2 T-72s in a row with a frontal shot :)";

            useAMPShell = cfg.CreateEntry<bool>("UseXM1147", true);
            useAMPShell.Description = "Replaces M830 HEAT with XM1147 AMP (point-detonate/airburst [timed fuze])";

            ampFragments = cfg.CreateEntry<int>("AMP Fragments", 600);
            ampFragments.Description = "How many fragments are generated when the AMP round explodes (in point-detonate/airburst mode). NOTE: Higher number, means higher performance hit.";

            rotateAzimuth = cfg.CreateEntry<bool>("RotateAzimuth", false);
            rotateAzimuth.Description = "Horizontal stabilization of M1A1 sights when applying lead.";

            m1e1 = cfg.CreateEntry<bool>("M1E1", true);
            m1e1.Description = "Convert M1s to M1E1s (i.e: they get the 120mm gun).";

            randomChance = cfg.CreateEntry<bool>("Random", true);
            randomChance.Description = "M1IPs/M1s will have a random chance of being converted to M1A1s/M1E1s.";
            randomChanceNum = cfg.CreateEntry<int>("ConversionChance", 100);
        }

        // the GAS reticles seem to be assigned to specific ammo types and I can't figure out how it's done
        public override void OnUpdate()
        {
            if (gameManager == null) return;

            FieldInfo currentCamSlot = typeof(CameraManager).GetField("_currentCamSlot", BindingFlags.Instance | BindingFlags.NonPublic);
            CameraSlot cam = (CameraSlot)currentCamSlot.GetValue(cameraManager);

            if (cam == null) return;
            if (cam.name != "Aux sight (GAS)") return;
            if (playerManager.CurrentPlayerWeapon.Name != "120mm gun M256") return;

            AmmoType currentAmmo = playerManager.CurrentPlayerWeapon.FCS.CurrentAmmoType;
            int reticleId = (currentAmmo.Name == "M829 APFSDS-T" || currentAmmo.Name == "M829A4 APFSDS-T") ? 0 : 2;

            GameObject reticle = cam.transform.GetChild(reticleId).gameObject;

            if (!reticle.activeSelf)
            {
                reticle.SetActive(true);
            }
        }

        public override async void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (sceneName == "LOADER_INITIAL" || sceneName == "MainMenu2_Scene" || sceneName == "t64_menu") return;

            vic_gos = GameObject.FindGameObjectsWithTag("Vehicle");

            while (vic_gos.Length == 0)
            {
                vic_gos = GameObject.FindGameObjectsWithTag("Vehicle");
                await Task.Delay(3000);
            }

            if (gun_m256 == null)
            {

                foreach (AmmoCodexScriptable s in Resources.FindObjectsOfTypeAll(typeof(AmmoCodexScriptable)))
                {
                    if (s.AmmoType.Name == "M833 APFSDS-T")
                    {
                        ammo_m833 = s.AmmoType;
                    }

                    if (s.AmmoType.Name == "M456 HEAT-FS-T")
                    {
                        ammo_m456 = s.AmmoType;
                    }
                }

                // m256
                gun_m256 = ScriptableObject.CreateInstance<WeaponSystemCodexScriptable>();
                gun_m256.name = "gun_m256";
                gun_m256.CaliberMm = 120;
                gun_m256.FriendlyName = "120mm Gun M256";
                gun_m256.Type = WeaponSystemCodexScriptable.WeaponType.LargeCannon;

                // m829 
                ammo_m829 = new AmmoType();
                ShallowCopy(ammo_m829, ammo_m833);
                ammo_m829.Name = "M829 APFSDS-T";
                ammo_m829.Caliber = 120;
                ammo_m829.RhaPenetration = 600;
                ammo_m829.MuzzleVelocity = 1670f;
                ammo_m829.Mass = 3.9f;

                ammo_codex_m829 = ScriptableObject.CreateInstance<AmmoCodexScriptable>();
                ammo_codex_m829.AmmoType = ammo_m829;
                ammo_codex_m829.name = "ammo_m829";

                clip_m829 = new AmmoType.AmmoClip();
                clip_m829.Capacity = 1;
                clip_m829.Name = "M829 APFSDS-T";
                clip_m829.MinimalPattern = new AmmoCodexScriptable[1];
                clip_m829.MinimalPattern[0] = ammo_codex_m829;

                clip_codex_m829 = ScriptableObject.CreateInstance<AmmoClipCodexScriptable>();
                clip_codex_m829.name = "clip_m829";
                clip_codex_m829.CompatibleWeaponSystems = new WeaponSystemCodexScriptable[1];
                clip_codex_m829.CompatibleWeaponSystems[0] = gun_m256;
                clip_codex_m829.ClipType = clip_m829;

                // m829a4
                ammo_m829a4 = new AmmoType();
                ShallowCopy(ammo_m829a4, ammo_m833);
                ammo_m829a4.Name = "M829A4 APFSDS-T";
                ammo_m829a4.Caliber = 120;
                ammo_m829a4.RhaPenetration = 1000;
                ammo_m829a4.MuzzleVelocity = 1670;
                ammo_m829a4.Mass = 4.6f;
                ammo_m829a4.SpallMultiplier = 1.5f;

                ammo_codex_m829a4 = ScriptableObject.CreateInstance<AmmoCodexScriptable>();
                ammo_codex_m829a4.AmmoType = ammo_m829a4;
                ammo_codex_m829a4.name = "ammo_m829a4";

                clip_m829a4 = new AmmoType.AmmoClip();
                clip_m829a4.Capacity = 1;
                clip_m829a4.Name = "M829A4 APFSDS-T";
                clip_m829a4.MinimalPattern = new AmmoCodexScriptable[1];
                clip_m829a4.MinimalPattern[0] = ammo_codex_m829a4;

                clip_codex_m829a4 = ScriptableObject.CreateInstance<AmmoClipCodexScriptable>();
                clip_codex_m829a4.name = "clip_m829a4";
                clip_codex_m829a4.CompatibleWeaponSystems = new WeaponSystemCodexScriptable[1];
                clip_codex_m829a4.CompatibleWeaponSystems[0] = gun_m256;
                clip_codex_m829a4.ClipType = clip_m829a4;

                // M830
                ammo_m830 = new AmmoType();
                ShallowCopy(ammo_m830, ammo_m456);
                ammo_m830.Name = "M830 HEAT-MP-T";
                ammo_m830.Caliber = 120;
                ammo_m830.RhaPenetration = 480;
                ammo_m830.TntEquivalentKg = 1.814f;
                ammo_m830.MuzzleVelocity = 1140f;
                ammo_m830.Mass = 13.5f;
                ammo_m830.CertainRicochetAngle = 8.0f;
                ammo_m830.ShatterOnRicochet = false;

                ammo_codex_m830 = ScriptableObject.CreateInstance<AmmoCodexScriptable>();
                ammo_codex_m830.AmmoType = ammo_m830;
                ammo_codex_m830.name = "ammo_m830";

                clip_m830 = new AmmoType.AmmoClip();
                clip_m830.Capacity = 1;
                clip_m830.Name = "M830 HEAT-MP-T";
                clip_m830.MinimalPattern = new AmmoCodexScriptable[1];
                clip_m830.MinimalPattern[0] = ammo_codex_m830;

                clip_codex_m830 = ScriptableObject.CreateInstance<AmmoClipCodexScriptable>();
                clip_codex_m830.name = "clip_m830";
                clip_codex_m830.CompatibleWeaponSystems = new WeaponSystemCodexScriptable[1];
                clip_codex_m830.CompatibleWeaponSystems[0] = gun_m256;
                clip_codex_m830.ClipType = clip_m830;

                // XM1147
                ammo_xm1147 = new AmmoType();
                ShallowCopy(ammo_xm1147, ammo_m456);
                ammo_xm1147.Name = "XM1147 AMP-T";
                ammo_xm1147.Caliber = 120;
                ammo_xm1147.RhaPenetration = 480;
                ammo_xm1147.TntEquivalentKg = 3.324f;
                ammo_xm1147.MaxSpallRha = 160f;
                ammo_xm1147.MinSpallRha = 45f;
                ammo_xm1147.MuzzleVelocity = 1140f;
                ammo_xm1147.Mass = 13.5f;
                ammo_xm1147.CertainRicochetAngle = 8.0f;
                ammo_xm1147.ShatterOnRicochet = false;
                ammo_xm1147.SpallMultiplier = 2f;
                ammo_xm1147.DetonateSpallCount = ampFragments.Value; //Number of fragments generated when detonated (PD/AB). Higher value means higher performance hit.

                ammo_codex_XM1147 = ScriptableObject.CreateInstance<AmmoCodexScriptable>();
                ammo_codex_XM1147.AmmoType = ammo_xm1147;
                ammo_codex_XM1147.name = "ammo_xm1147";

                clip_XM1147 = new AmmoType.AmmoClip();
                clip_XM1147.Capacity = 1;
                clip_XM1147.Name = "XM1147 AMP-T";
                clip_XM1147.MinimalPattern = new AmmoCodexScriptable[1];
                clip_XM1147.MinimalPattern[0] = ammo_codex_XM1147;

                clip_codex_XM1147 = ScriptableObject.CreateInstance<AmmoClipCodexScriptable>();
                clip_codex_XM1147.name = "clip_XM1147";
                clip_codex_XM1147.CompatibleWeaponSystems = new WeaponSystemCodexScriptable[1];
                clip_codex_XM1147.CompatibleWeaponSystems[0] = gun_m256;
                clip_codex_XM1147.ClipType = clip_XM1147;
            }

            foreach (GameObject vic_go in vic_gos)
            {
                Vehicle vic = vic_go.GetComponent<Vehicle>();

                if (vic == null) continue;

                if (vic.FriendlyName == "M1IP" || (m1e1.Value && vic.FriendlyName == "M1"))
                {
                    gameManager = GameObject.Find("_APP_GHPC_");
                    cameraManager = gameManager.GetComponent<CameraManager>();
                    playerManager = gameManager.GetComponent<PlayerInput>();

                    GameObject ammo_m829_vis = null;
                    GameObject ammo_m829a4_vis = null;
                    GameObject ammo_m830_vis = null;
                    GameObject ammo_xm1147_vis = null;

                    // generate visual models 
                    if (ammo_m829_vis == null)
                    {
                        ammo_m829_vis = GameObject.Instantiate(ammo_m833.VisualModel);
                        ammo_m829_vis.name = "M829 visual";
                        ammo_m829.VisualModel = ammo_m829_vis;
                        ammo_m829.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_m829;
                        ammo_m829.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_m829;

                        ammo_m829a4_vis = GameObject.Instantiate(ammo_m833.VisualModel);
                        ammo_m829a4_vis.name = "m829a4 visual";
                        ammo_m829a4.VisualModel = ammo_m829a4_vis;
                        ammo_m829a4.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_m829a4;
                        ammo_m829a4.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_m829a4;

                        ammo_m830_vis = GameObject.Instantiate(ammo_m456.VisualModel);
                        ammo_m830_vis.name = "M830 visual";
                        ammo_m830.VisualModel = ammo_m830_vis;
                        ammo_m830.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_m830;
                        ammo_m830.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_m830;

                        ammo_xm1147_vis = GameObject.Instantiate(ammo_m456.VisualModel);
                        ammo_xm1147_vis.name = "XM1147 visual";
                        ammo_xm1147.VisualModel = ammo_xm1147_vis;
                        ammo_xm1147.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_xm1147;
                        ammo_xm1147.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_XM1147;
                    }

                    int rand = 0;
                    if (randomChance.Value) rand = UnityEngine.Random.Range(1, 100);


                    if (rand < randomChanceNum.Value)
                    {
                        MelonLogger.Msg(rand + " triggered");
                        // rename to m1a1
                        string name = (vic.FriendlyName == "M1IP") ? "M1A1" : "M1E1";

                        FieldInfo friendlyName = typeof(GHPC.Unit).GetField("_friendlyName", BindingFlags.NonPublic | BindingFlags.Instance);
                        friendlyName.SetValue(vic, name);

                        FieldInfo uniqueName = typeof(GHPC.Unit).GetField("_uniqueName", BindingFlags.NonPublic | BindingFlags.Instance);
                        uniqueName.SetValue(vic, name);

                        // convert to m256 gun
                        WeaponsManager weaponsManager = vic.GetComponent<WeaponsManager>();
                        WeaponSystemInfo mainGunInfo = weaponsManager.Weapons[0];
                        WeaponSystem mainGun = mainGunInfo.Weapon;

                        if (rotateAzimuth.Value)
                        {
                            UsableOptic primaryOptic = vic_go.transform.Find("IPM1_rig/HULL/TURRET/Turret Scripts/GPS/Optic").gameObject.GetComponent<UsableOptic>();
                            primaryOptic.RotateAzimuth = true;
                            primaryOptic.slot.LinkedNightSight.PairedOptic.RotateAzimuth = true;
                        }

                        mainGunInfo.Name = "120mm gun M256";
                        mainGun.Impulse = 68000;
                        FieldInfo codex = typeof(WeaponSystem).GetField("CodexEntry", BindingFlags.NonPublic | BindingFlags.Instance);
                        codex.SetValue(mainGun, gun_m256);

                        GameObject gunTube = vic_go.transform.Find("IPM1_rig/HULL/TURRET/GUN/gun_recoil").gameObject;
                        gunTube.transform.localScale = new Vector3(1.4f, 1.4f, 0.98f);

                        // convert ammo
                        LoadoutManager loadoutManager = vic.GetComponent<LoadoutManager>();

                        loadoutManager.TotalAmmoCounts = new int[] { m829Count.Value, m830Count.Value };

                        AmmoClipCodexScriptable sabotClipCodex = (useSuperSabot.Value) ? clip_codex_m829a4 : clip_codex_m829;
                        AmmoClipCodexScriptable heatClipCodex = (useAMPShell.Value) ? clip_codex_XM1147 : clip_codex_m830;

                        loadoutManager.LoadedAmmoTypes = new AmmoClipCodexScriptable[] { sabotClipCodex, heatClipCodex };

                        FieldInfo totalAmmoCount = typeof(LoadoutManager).GetField("_totalAmmoCount", BindingFlags.NonPublic | BindingFlags.Instance);
                        totalAmmoCount.SetValue(loadoutManager, 44);

                        for (int i = 0; i <= 2; i++)
                        {
                            GHPC.Weapons.AmmoRack rack = loadoutManager.RackLoadouts[i].Rack;
                            rack.ClipCapacity = i == 2 ? 4 : 18;
                            rack.ClipTypes = new AmmoType.AmmoClip[] { sabotClipCodex.ClipType, heatClipCodex.ClipType };
                            EmptyRack(rack);
                        }

                        loadoutManager.SpawnCurrentLoadout();

                        PropertyInfo roundInBreech = typeof(AmmoFeed).GetProperty("AmmoTypeInBreech"); // clear preloaded M833 from breech
                        roundInBreech.SetValue(mainGun.Feed, null);

                        MethodInfo refreshBreech = typeof(AmmoFeed).GetMethod("Start", BindingFlags.Instance | BindingFlags.NonPublic); // silently load M829
                        refreshBreech.Invoke(mainGun.Feed, new object[] { });

                        // update ballistics computer
                        MethodInfo registerAllBallistics = typeof(LoadoutManager).GetMethod("RegisterAllBallistics", BindingFlags.Instance | BindingFlags.NonPublic);
                        registerAllBallistics.Invoke(loadoutManager, new object[] { });
                    }
                }
            }
        }

        [HarmonyPatch(typeof(GHPC.Weapons.LiveRound), "Start")]
        public static class Airburst
        {
            private static void Postfix(GHPC.Weapons.LiveRound __instance)
            {
                if (__instance.Info.Name != "XM1147 AMP-T") return;

                FieldInfo rangedFuseTimeField = typeof(GHPC.Weapons.LiveRound).GetField("_rangedFuseCountdown", BindingFlags.Instance | BindingFlags.NonPublic);
                FieldInfo rangedFuseTimeActiveField = typeof(GHPC.Weapons.LiveRound).GetField("_rangedFuseActive", BindingFlags.Instance | BindingFlags.NonPublic);
                FieldInfo ballisticsComputerField = typeof(FireControlSystem).GetField("_bc", BindingFlags.Instance | BindingFlags.NonPublic);

                FireControlSystem FCS = __instance.Shooter.WeaponsManager.Weapons[0].FCS;
                BallisticComputerRepository bc = ballisticsComputerField.GetValue(FCS) as BallisticComputerRepository;
                float range = FCS.CurrentRange;
                float fallOff = bc.GetFallOfShot(ammo_xm1147, range);
                float extra_distance = range > 2000 ? 19f + 3.5f : 17f;

                //funky math 
                rangedFuseTimeField.SetValue(__instance, bc.GetFlightTime(ammo_xm1147, range + range / ammo_xm1147.MuzzleVelocity * 2 + (range + fallOff) / 2000f + extra_distance));
                rangedFuseTimeActiveField.SetValue(__instance, true);
            }
        }
    }
}
