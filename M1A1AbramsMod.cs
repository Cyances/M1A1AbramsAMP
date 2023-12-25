using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MelonLoader;
using UnityEngine;
using GHPC.Weapons;
using GHPC.Vehicle;
using GHPC.Camera;
using GHPC.Player;
using GHPC.Equipment.Optics;
using System.Collections;
using System.Threading.Tasks;
using HarmonyLib;
using M1A1Abrams;
using GHPC.Equipment;
using GHPC;

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

        ArmorType armor_compositeskirt;
        ArmorCodexScriptable armor_codex_superCompositeskirt;
        ArmorType armor_superCompositeskirt;

        ArmorType armor_cheeksnera;
        ArmorCodexScriptable armor_codex_cheeksDUarmor;
        ArmorType armor_cheeksDUarmor;

        ArmorType armor_fronthullnera;
        ArmorCodexScriptable armor_codex_fronthullDUarmor;
        ArmorType armor_fronthullDUarmor;

        ArmorType armor_mantletnera;
        ArmorCodexScriptable armor_codex_mantletlDUarmor;
        ArmorType armor_mantletDUarmor;

        ArmorType armor_turretsidesnera;
        ArmorCodexScriptable armor_codex_turretsidesDUarmor;
        ArmorType armor_turretsidesDUarmor;

        ArmorType armor_turretroofarmor;
        ArmorCodexScriptable armor_codex_turretroofCompositearmor;
        ArmorType armor_turretroofCompositearmor;

        ArmorType armor_upperglacisarmor;
        ArmorCodexScriptable armor_codex_upperglacisCompositearmor;
        ArmorType armor_upperglacisCompositearmor;

        //ArmorType armor_hullsidearmor; //Commented out hull side and hull floor armors because current implementation is not working
        //ArmorCodexScriptable armor_codex_hullsideCompositearmor;
        //ArmorType armor_hullsideCompositearmor;

        //ArmorType armor_hullfloorarmor;
        //ArmorCodexScriptable armor_codex_hullfloorCompositearmor;
        //ArmorType armor_hullfloorCompositearmor;

        ArmorType armor_commmandershatcharmor;
        ArmorCodexScriptable armor_codex_commmandershatchCompositearmor;
        ArmorType armor_commmandershatchCompositearmor;

        ArmorType armor_loadershatcharmor;
        ArmorCodexScriptable armor_codex_loadershatchCompositearmor;
        ArmorType armor_loadershatchCompositearmor;

        ArmorType armor_drivershatcharmor;
        ArmorCodexScriptable armor_codex_drivershatchCompositearmor;
        ArmorType armor_drivershatchCompositearmor;

        ArmorType armor_turretringarmor;
        ArmorCodexScriptable armor_codex_turretringCompositearmor;
        ArmorType armor_turretringCompositearmor;

        ArmorType armor_gunmantletfacearmor;
        ArmorCodexScriptable armor_codex_gunmantletfaceCompositearmor;
        ArmorType armor_gunmantletfaceCompositearmor;

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
            ampFragments.Description = "How many fragments are generated when the AMP round explodes (in point-detonate/airburst mode). NOTE: Higher number, means higher performance hit. Be careful in using higher number.";

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
                    if (s.AmmoType.Name == "M833 APFSDS-T") ammo_m833 = s.AmmoType;
                    if (s.AmmoType.Name == "M456 HEAT-FS-T") ammo_m456 = s.AmmoType;
                }

                foreach (ArmorCodexScriptable s in Resources.FindObjectsOfTypeAll(typeof(ArmorCodexScriptable)))
                {
                    if (s.ArmorType.Name == "composite skirt") armor_compositeskirt = s.ArmorType;
                    if (s.ArmorType.Name == "special armor") armor_cheeksnera = s.ArmorType;
                    if (s.ArmorType.Name == "special armor") armor_fronthullnera = s.ArmorType;
                    if (s.ArmorType.Name == "special armor") armor_mantletnera = s.ArmorType;
                    if (s.ArmorType.Name == "special armor") armor_turretsidesnera = s.ArmorType;
                    if (s.ArmorType.Name == "composite skirt") armor_turretroofarmor = s.ArmorType;
                    if (s.ArmorType.Name == "composite skirt") armor_upperglacisarmor = s.ArmorType;

                    //if (s.ArmorType.Name == "composite skirt")
                    //{
                    //    armor_hullsidearmor = s.ArmorType;
                    //}

                    //if (s.ArmorType.Name == "composite skirt")
                    //{
                    //    armor_hullfloorarmor = s.ArmorType;
                    //}

                    if (s.ArmorType.Name == "composite skirt") armor_commmandershatcharmor = s.ArmorType;
                    if (s.ArmorType.Name == "composite skirt") armor_loadershatcharmor = s.ArmorType;
                    if (s.ArmorType.Name == "composite skirt") armor_drivershatcharmor = s.ArmorType;
                    if (s.ArmorType.Name == "composite skirt") armor_turretringarmor = s.ArmorType;
                    if (s.ArmorType.Name == "composite skirt") armor_gunmantletfacearmor = s.ArmorType;
                }

                // m256
                gun_m256 = ScriptableObject.CreateInstance<WeaponSystemCodexScriptable>();
                gun_m256.name = "gun_m256";
                gun_m256.CaliberMm = 120;
                gun_m256.FriendlyName = "120mm Gun M256";
                gun_m256.Type = WeaponSystemCodexScriptable.WeaponType.LargeCannon;

                //Ammo stuff
                // m829 
                ammo_m829 = new AmmoType();
                Util.ShallowCopy(ammo_m829, ammo_m833);
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
                Util.ShallowCopy(ammo_m829a4, ammo_m833);
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

                // m830
                ammo_m830 = new AmmoType();
                Util.ShallowCopy(ammo_m830, ammo_m456);
                ammo_m830.Name = "M830 HEAT-MP-T";
                ammo_m830.Caliber = 120;
                ammo_m830.RhaPenetration = 600;
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
                Util.ShallowCopy(ammo_xm1147, ammo_m456);
                ammo_xm1147.Name = "XM1147 AMP-T";
                ammo_xm1147.Caliber = 120;
                ammo_xm1147.RhaPenetration = 480;
                ammo_xm1147.TntEquivalentKg = 3.324f;
                ammo_xm1147.MaxSpallRha = 180f;
                ammo_xm1147.MinSpallRha = 55f;
                ammo_xm1147.MuzzleVelocity = 1400f;
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

                //Armor stuff//
                armor_superCompositeskirt = new ArmorType();
                Util.ShallowCopy(armor_superCompositeskirt, armor_compositeskirt);
                armor_superCompositeskirt.RhaeMultiplierCe = 8.35f; //default 1.5
                armor_superCompositeskirt.RhaeMultiplierKe = 5.0f; //default 0.8
                armor_superCompositeskirt.Name = "Abrams super special composite skirt";

                armor_codex_superCompositeskirt = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_superCompositeskirt.name = "Abrams super special composite skirt";
                armor_codex_superCompositeskirt.ArmorType = armor_superCompositeskirt;

                armor_cheeksDUarmor = new ArmorType();
                Util.ShallowCopy(armor_cheeksDUarmor, armor_cheeksnera);
                armor_cheeksDUarmor.RhaeMultiplierCe = 2.2f; //default 1.3
                armor_cheeksDUarmor.RhaeMultiplierKe = 1.2f; //default 0.55
                armor_cheeksDUarmor.Name = "Abrams DU armor turret cheeks";

                armor_codex_cheeksDUarmor = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_cheeksDUarmor.name = "Abrams DU armor turret cheeks";
                armor_codex_cheeksDUarmor.ArmorType = armor_cheeksDUarmor;
                armor_cheeksDUarmor = new ArmorType();

                armor_fronthullDUarmor = new ArmorType();
                Util.ShallowCopy(armor_fronthullDUarmor, armor_fronthullnera);
                armor_fronthullDUarmor.RhaeMultiplierCe = 2.2f; //default 1.3
                armor_fronthullDUarmor.RhaeMultiplierKe = 1.4f; //default 0.45
                armor_fronthullDUarmor.Name = "Abrams DU armor hull front";

                armor_codex_fronthullDUarmor = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_fronthullDUarmor.name = "Abrams DU armor hull front";
                armor_codex_fronthullDUarmor.ArmorType = armor_fronthullDUarmor;
                armor_fronthullDUarmor = new ArmorType();

                armor_mantletDUarmor = new ArmorType();
                Util.ShallowCopy(armor_mantletDUarmor, armor_mantletnera);
                armor_mantletDUarmor.RhaeMultiplierCe = 2.15f; //default 1.3
                armor_mantletDUarmor.RhaeMultiplierKe = 1.5f; //default 1.4
                armor_mantletDUarmor.Name = "Abrams DU armor mantlet";

                armor_codex_mantletlDUarmor = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_mantletlDUarmor.name = "Abrams DU armor mantlet";
                armor_codex_mantletlDUarmor.ArmorType = armor_mantletDUarmor;
                armor_mantletDUarmor = new ArmorType();

                armor_turretsidesDUarmor = new ArmorType();
                Util.ShallowCopy(armor_turretsidesDUarmor, armor_turretsidesnera);
                armor_turretsidesDUarmor.RhaeMultiplierCe = 4.4f; //default 1.3
                armor_turretsidesDUarmor.RhaeMultiplierKe = 2.21f; //default 1.4
                armor_turretsidesDUarmor.Name = "Abrams DU armor turret sides";

                armor_codex_turretsidesDUarmor = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_turretsidesDUarmor.name = "Abrams DU armor turret sides";
                armor_codex_turretsidesDUarmor.ArmorType = armor_turretsidesDUarmor;
                armor_turretsidesDUarmor = new ArmorType();

                armor_turretroofCompositearmor = new ArmorType();
                Util.ShallowCopy(armor_turretroofCompositearmor, armor_turretroofarmor);
                armor_turretroofCompositearmor.RhaeMultiplierCe = 2.0f; //default composite skirt 1.5
                armor_turretroofCompositearmor.RhaeMultiplierKe = 2.3f; //default composite skirt 0.8
                armor_turretroofCompositearmor.Name = "Abrams roof special composite";

                armor_codex_turretroofCompositearmor = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_turretroofCompositearmor.name = "Abrams roof special composite";
                armor_codex_turretroofCompositearmor.ArmorType = armor_turretroofCompositearmor;
                armor_turretroofCompositearmor = new ArmorType();

                armor_upperglacisCompositearmor = new ArmorType();
                Util.ShallowCopy(armor_upperglacisCompositearmor, armor_upperglacisarmor);
                armor_upperglacisCompositearmor.RhaeMultiplierCe = 3.0f; //default composite skirt 1.5
                armor_upperglacisCompositearmor.RhaeMultiplierKe = 2.6f; //default composite skirt 0.8
                armor_upperglacisCompositearmor.Name = "Abrams upper glacis special composite";

                armor_codex_upperglacisCompositearmor = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_upperglacisCompositearmor.name = "Abrams upper glacis special composite";
                armor_codex_upperglacisCompositearmor.ArmorType = armor_upperglacisCompositearmor;
                armor_upperglacisCompositearmor = new ArmorType();

                //armor_hullsideCompositearmor = new ArmorType();
                //Util.ShallowCopy(armor_hullsideCompositearmor, armor_hullsidearmor);
                //armor_hullsideCompositearmor.RhaeMultiplierCe = 13.35f; //default composite skirt 1.5
                //armor_hullsideCompositearmor.RhaeMultiplierKe = 12.9f; //default composite skirt 0.8
                //armor_hullsideCompositearmor.Name = "Abrams hull side special composite";

                //armor_codex_hullsideCompositearmor = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                //armor_codex_hullsideCompositearmor.name = "Abrams hull side special composite";
                //armor_codex_hullsideCompositearmor.ArmorType = armor_hullsideCompositearmor;
                //armor_hullsideCompositearmor = new ArmorType();

                //armor_hullfloorCompositearmor = new ArmorType();
                //Util.ShallowCopy(armor_hullfloorCompositearmor, armor_hullfloorarmor);
                //armor_hullfloorCompositearmor.RhaeMultiplierCe = 13.35f; //default composite skirt 1.5
                //armor_hullfloorCompositearmor.RhaeMultiplierKe = 12.9f; //default composite skirt 0.8
                //armor_hullfloorCompositearmor.Name = "Abrams hull foor special composite";

                //armor_codex_hullfloorCompositearmor = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                //armor_codex_hullfloorCompositearmor.name = "Abrams hull floor special composite";
                //armor_codex_hullfloorCompositearmor.ArmorType = armor_hullfloorCompositearmor;
                //armor_hullfloorCompositearmor = new ArmorType();

                armor_commmandershatchCompositearmor = new ArmorType();
                Util.ShallowCopy(armor_commmandershatchCompositearmor, armor_commmandershatcharmor);
                armor_commmandershatchCompositearmor.RhaeMultiplierCe = 2.0f; //default composite skirt 1.5
                armor_commmandershatchCompositearmor.RhaeMultiplierKe = 2.3f; //default composite skirt 0.8
                armor_commmandershatchCompositearmor.Name = "Abrams commander's hatch special composite";

                armor_codex_commmandershatchCompositearmor = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_commmandershatchCompositearmor.name = "Abrams commander's hatch special composite";
                armor_codex_commmandershatchCompositearmor.ArmorType = armor_commmandershatchCompositearmor;
                armor_commmandershatchCompositearmor = new ArmorType();

                armor_loadershatchCompositearmor = new ArmorType();
                Util.ShallowCopy(armor_loadershatchCompositearmor, armor_loadershatcharmor);
                armor_loadershatchCompositearmor.RhaeMultiplierCe = 2.0f; //default composite skirt 1.5
                armor_loadershatchCompositearmor.RhaeMultiplierKe = 2.3f; //default composite skirt 0.8
                armor_loadershatchCompositearmor.Name = "Abrams loader's hatch special composite";

                armor_codex_loadershatchCompositearmor = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_loadershatchCompositearmor.name = "Abrams loader's hatch special composite";
                armor_codex_loadershatchCompositearmor.ArmorType = armor_loadershatchCompositearmor;
                armor_loadershatchCompositearmor = new ArmorType();

                armor_drivershatchCompositearmor = new ArmorType();
                Util.ShallowCopy(armor_loadershatchCompositearmor, armor_drivershatcharmor);
                armor_drivershatchCompositearmor.RhaeMultiplierCe = 2.0f; //default composite skirt 1.5
                armor_drivershatchCompositearmor.RhaeMultiplierKe = 2.3f; //default composite skirt 0.8
                armor_drivershatchCompositearmor.Name = "Abrams driver's hatch special composite";

                armor_codex_drivershatchCompositearmor = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_drivershatchCompositearmor.name = "Abrams driver's hatch special composite";
                armor_codex_drivershatchCompositearmor.ArmorType = armor_drivershatchCompositearmor;
                armor_drivershatchCompositearmor = new ArmorType();

                armor_turretringCompositearmor = new ArmorType();
                Util.ShallowCopy(armor_turretringCompositearmor, armor_turretringarmor);
                armor_turretringCompositearmor.RhaeMultiplierCe = 2.6f; //default composite skirt 1.5
                armor_turretringCompositearmor.RhaeMultiplierKe = 3.0f; //default composite skirt 0.8
                armor_turretringCompositearmor.Name = "Abrams turret ring special composite";

                armor_codex_turretringCompositearmor = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_turretringCompositearmor.name = "Abrams turret ring special composite";
                armor_codex_turretringCompositearmor.ArmorType = armor_turretringCompositearmor;
                armor_turretringCompositearmor = new ArmorType();

                armor_gunmantletfaceCompositearmor = new ArmorType();
                Util.ShallowCopy(armor_gunmantletfaceCompositearmor, armor_gunmantletfacearmor);
                armor_gunmantletfaceCompositearmor.RhaeMultiplierCe = 2.6f; //default composite skirt 1.5
                armor_gunmantletfaceCompositearmor.RhaeMultiplierKe = 3.0f; //default composite skirt 0.8
                armor_gunmantletfaceCompositearmor.Name = "Abrams gun mantlet face special composite";

                armor_codex_gunmantletfaceCompositearmor = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_gunmantletfaceCompositearmor.name = "Abrams gun mantlet face special composite";
                armor_codex_gunmantletfaceCompositearmor.ArmorType = armor_gunmantletfaceCompositearmor;
                armor_gunmantletfaceCompositearmor = new ArmorType();
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor compositeskirtPlate = armour.GetComponent<VariableArmor>();

                if (compositeskirtPlate == null) continue;
                if (compositeskirtPlate.Unit == null) continue;
                if (compositeskirtPlate.Unit.FriendlyName != "M1IP") continue;
                if (compositeskirtPlate.Name != "composite side skirt") continue;

                FieldInfo armorskirtPlate = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorskirtPlate.SetValue(compositeskirtPlate, armor_codex_superCompositeskirt);

                MelonLogger.Msg(compositeskirtPlate.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor cheeksDUarray = armour.GetComponent<VariableArmor>();
                if (cheeksDUarray == null) continue;
                if (cheeksDUarray.Unit == null) continue;
                if (cheeksDUarray.Unit.FriendlyName != "M1IP") continue;
                if (cheeksDUarray.Name != "turret cheek special armor array") continue;

                FieldInfo armorcheeksDU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorcheeksDU.SetValue(cheeksDUarray, armor_codex_cheeksDUarmor);

                MelonLogger.Msg(cheeksDUarray.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor hullDUarray = armour.GetComponent<VariableArmor>();
                if (hullDUarray == null) continue;
                if (hullDUarray.Unit == null) continue;
                if (hullDUarray.Unit.FriendlyName != "M1IP") continue;
                if (hullDUarray.Name != "hull front special armor array") continue;

                FieldInfo armorcheeksDU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorcheeksDU.SetValue(hullDUarray, armor_codex_fronthullDUarmor);

                MelonLogger.Msg(hullDUarray.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor mantletDUarray = armour.GetComponent<VariableArmor>();
                if (mantletDUarray == null) continue;
                if (mantletDUarray.Unit == null) continue;
                if (mantletDUarray.Unit.FriendlyName != "M1IP") continue;
                if (mantletDUarray.Name != "gun mantlet special armor array") continue;

                FieldInfo armorcheeksDU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorcheeksDU.SetValue(mantletDUarray, armor_codex_mantletlDUarmor);

                MelonLogger.Msg(mantletDUarray.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor turretsidesDUarray = armour.GetComponent<VariableArmor>();
                if (turretsidesDUarray == null) continue;
                if (turretsidesDUarray.Unit == null) continue;
                if (turretsidesDUarray.Unit.FriendlyName != "M1IP") continue;
                if (turretsidesDUarray.Name != "turret side special armor array") continue;

                FieldInfo armorcheeksDU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorcheeksDU.SetValue(turretsidesDUarray, armor_codex_turretsidesDUarmor);

                MelonLogger.Msg(turretsidesDUarray.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor turretroofCompositearray = armour.GetComponent<VariableArmor>();
                if (turretroofCompositearray == null) continue;
                if (turretroofCompositearray.Unit == null) continue;
                if (turretroofCompositearray.Unit.FriendlyName != "M1IP") continue;
                if (turretroofCompositearray.Name != "turret roof") continue;

                FieldInfo armorcheeksDU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorcheeksDU.SetValue(turretroofCompositearray, armor_codex_turretroofCompositearmor);

                MelonLogger.Msg(turretroofCompositearray.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor upperglacisCompositearray = armour.GetComponent<VariableArmor>();
                if (upperglacisCompositearray == null) continue;
                if (upperglacisCompositearray.Unit == null) continue;
                if (upperglacisCompositearray.Unit.FriendlyName != "M1IP") continue;
                if (upperglacisCompositearray.Name != "upper glacis") continue;

                FieldInfo armorcheeksDU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorcheeksDU.SetValue(upperglacisCompositearray, armor_codex_upperglacisCompositearmor);

                MelonLogger.Msg(upperglacisCompositearray.ArmorType);
            }

            //foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable")) //Maybe something to do with the fact that these uses UniformArmor instead?
            //{
            //    if (armour == null) continue;

            //    VariableArmor hullsideCompositearray = armour.GetComponent<VariableArmor>();
            //    if (hullsideCompositearray == null) continue;
            //    if (hullsideCompositearray.Unit == null) continue;
            //    if (hullsideCompositearray.Unit.FriendlyName != "M1IP") continue;
            //    if (hullsideCompositearray.Name != "hull side") continue;

            //    FieldInfo armorcheeksDU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
            //    armorcheeksDU.SetValue(hullsideCompositearray, armor_codex_hullsideCompositearmor);

            //    MelonLogger.Msg(hullsideCompositearray.ArmorType);
            //}

            //foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            //{
            //    if (armour == null) continue;

            //    VariableArmor hullfloorCompositearray = armour.GetComponent<VariableArmor>();
            //    if (hullfloorCompositearray == null) continue;
            //    if (hullfloorCompositearray.Unit == null) continue;
            //    if (hullfloorCompositearray.Unit.FriendlyName != "M1IP") continue;
            //    if (hullfloorCompositearray.Name != "hull floor") continue;

            //    FieldInfo armorcheeksDU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
            //    armorcheeksDU.SetValue(hullfloorCompositearray, armor_codex_hullfloorCompositearmor);

            //    MelonLogger.Msg(hullfloorCompositearray.ArmorType);
            //}

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor commandershatchCompositearray = armour.GetComponent<VariableArmor>();
                if (commandershatchCompositearray == null) continue;
                if (commandershatchCompositearray.Unit == null) continue;
                if (commandershatchCompositearray.Unit.FriendlyName != "M1IP") continue;
                if (commandershatchCompositearray.Name != "commander's hatch") continue;

                FieldInfo armorcheeksDU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorcheeksDU.SetValue(commandershatchCompositearray, armor_codex_commmandershatchCompositearmor);

                MelonLogger.Msg(commandershatchCompositearray.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor loadershatchCompositearray = armour.GetComponent<VariableArmor>();
                if (loadershatchCompositearray == null) continue;
                if (loadershatchCompositearray.Unit == null) continue;
                if (loadershatchCompositearray.Unit.FriendlyName != "M1IP") continue;
                if (loadershatchCompositearray.Name != "loader's hatch") continue;

                FieldInfo armorcheeksDU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorcheeksDU.SetValue(loadershatchCompositearray, armor_codex_loadershatchCompositearmor);

                MelonLogger.Msg(loadershatchCompositearray.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor drivershatchCompositearray = armour.GetComponent<VariableArmor>();
                if (drivershatchCompositearray == null) continue;
                if (drivershatchCompositearray.Unit == null) continue;
                if (drivershatchCompositearray.Unit.FriendlyName != "M1IP") continue;
                if (drivershatchCompositearray.Name != "driver's hatch") continue;

                FieldInfo armorcheeksDU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorcheeksDU.SetValue(drivershatchCompositearray, armor_codex_drivershatchCompositearmor);

                MelonLogger.Msg(drivershatchCompositearray.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor turretringCompositearray = armour.GetComponent<VariableArmor>();
                if (turretringCompositearray == null) continue;
                if (turretringCompositearray.Unit == null) continue;
                if (turretringCompositearray.Unit.FriendlyName != "M1IP") continue;
                if (turretringCompositearray.Name != "turret ring") continue;

                FieldInfo armorcheeksDU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorcheeksDU.SetValue(turretringCompositearray, armor_codex_turretringCompositearmor);

                MelonLogger.Msg(turretringCompositearray.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor gunmantletfaceCompositearray = armour.GetComponent<VariableArmor>();
                if (gunmantletfaceCompositearray == null) continue;
                if (gunmantletfaceCompositearray.Unit == null) continue;
                if (gunmantletfaceCompositearray.Unit.FriendlyName != "M1IP") continue;
                if (gunmantletfaceCompositearray.Name != "gun mantlet face") continue;

                FieldInfo armorcheeksDU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorcheeksDU.SetValue(gunmantletfaceCompositearray, armor_codex_gunmantletfaceCompositearmor);

                MelonLogger.Msg(gunmantletfaceCompositearray.ArmorType);
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
                        ammo_m829a4_vis.name = "M829A4 visual";
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
                        // rename to m1a1
                        string name = (vic.FriendlyName == "M1IP") ? "M1A1HU" : "M1E1";

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
                            UsableOptic optic = Util.GetDayOptic(mainGun.FCS);
                            optic.RotateAzimuth = true;
                            optic.slot.LinkedNightSight.PairedOptic.RotateAzimuth = true;
                        }

                        Transform muzzleFlashes = mainGun.MuzzleEffects[1].transform;
                        muzzleFlashes.GetChild(1).transform.localScale = new Vector3(2f, 2f, 2f);
                        muzzleFlashes.GetChild(2).transform.localScale = new Vector3(2f, 2f, 2f);
                        muzzleFlashes.GetChild(4).transform.localScale = new Vector3(2f, 2f, 2f);

                        mainGunInfo.Name = "120mm gun M256";
                        mainGun.Impulse = 68000;
                        FieldInfo codex = typeof(WeaponSystem).GetField("CodexEntry", BindingFlags.NonPublic | BindingFlags.Instance);
                        codex.SetValue(mainGun, gun_m256);

                        GameObject gunTube = vic_go.transform.Find("IPM1_rig/HULL/TURRET/GUN/gun_recoil").gameObject;
                        gunTube.transform.localScale = new Vector3(1.4f, 1.4f, 0.98f);

                        // convert ammo
                        LoadoutManager loadoutManager = vic.GetComponent<LoadoutManager>();

                        loadoutManager.TotalAmmoCounts = new int[] { m829Count.Value, m830Count.Value };

                        AmmoClipCodexScriptable sabotClipCodex = useSuperSabot.Value ? clip_codex_m829a4 : clip_codex_m829;
                        AmmoClipCodexScriptable heatClipCodex = useAMPShell.Value ? clip_codex_XM1147 : clip_codex_m830;

                        loadoutManager.LoadedAmmoTypes = new AmmoClipCodexScriptable[] { sabotClipCodex, heatClipCodex };

                        FieldInfo totalAmmoCount = typeof(LoadoutManager).GetField("_totalAmmoCount", BindingFlags.NonPublic | BindingFlags.Instance);
                        totalAmmoCount.SetValue(loadoutManager, 44);

                        for (int i = 0; i <= 2; i++)
                        {
                            GHPC.Weapons.AmmoRack rack = loadoutManager.RackLoadouts[i].Rack;
                            rack.ClipCapacity = i == 2 ? 4 : 18;
                            rack.ClipTypes = new AmmoType.AmmoClip[] { sabotClipCodex.ClipType, heatClipCodex.ClipType };
                            Util.EmptyRack(rack);
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
