﻿using System;
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
<<<<<<< Updated upstream:M1A1AbramsMod.cs
using M1A1Abrams;
=======
using M1A1AbramsAMP;
using GHPC.Equipment;
using GHPC;
using System.Xml.Linq;
>>>>>>> Stashed changes:M1A1AbramsAMPMod.cs

namespace M1A1AbramsAMP
{
    public class M1A1AbramsAMPMod : MelonMod
    {
        MelonPreferences_Category cfg;
        MelonPreferences_Entry<int> primaryammoCount;
        MelonPreferences_Entry<int> secondaryammoCount;
        MelonPreferences_Entry<int> tertiaryammoCount;
        MelonPreferences_Entry<bool> rotateAzimuth;
        MelonPreferences_Entry<bool> m1e1;
        MelonPreferences_Entry<int> randomChanceNum;
        MelonPreferences_Entry<bool> randomChance;
        MelonPreferences_Entry<bool> useSuperSabot;
        MelonPreferences_Entry<bool> useAMPShell;
        MelonPreferences_Entry<int> ampFragments;
<<<<<<< Updated upstream:M1A1AbramsMod.cs
=======
        MelonPreferences_Entry<string> m1a1Armor;
        MelonPreferences_Entry<string> m1e1Armor;
        MelonPreferences_Entry<string> m1primaryAmmo;
        MelonPreferences_Entry<string> m1secondaryAmmo;
        MelonPreferences_Entry<string> m1tertiaryAmmo;
>>>>>>> Stashed changes:M1A1AbramsAMPMod.cs

        GameObject[] vic_gos;
        GameObject gameManager;
        CameraManager cameraManager;
        PlayerInput playerManager;

        WeaponSystemCodexScriptable gun_m256;

        AmmoClipCodexScriptable clip_codex_m829;
        AmmoType.AmmoClip clip_m829;
        AmmoCodexScriptable ammo_codex_m829;
        AmmoType ammo_m829;

        AmmoClipCodexScriptable clip_codex_m829a1;
        AmmoType.AmmoClip clip_m829a1;
        AmmoCodexScriptable ammo_codex_m829a1;
        AmmoType ammo_m829a1;

        AmmoClipCodexScriptable clip_codex_m829a2;
        AmmoType.AmmoClip clip_m829a2;
        AmmoCodexScriptable ammo_codex_m829a2;
        AmmoType ammo_m829a2;

        AmmoClipCodexScriptable clip_codex_m829a3;
        AmmoType.AmmoClip clip_m829a3;
        AmmoCodexScriptable ammo_codex_m829a3;
        AmmoType ammo_m829a3;

        AmmoClipCodexScriptable clip_codex_m829a4;
        AmmoType.AmmoClip clip_m829a4;
        AmmoCodexScriptable ammo_codex_m829a4;
        AmmoType ammo_m829a4;

        AmmoClipCodexScriptable clip_codex_m830;
        AmmoType.AmmoClip clip_m830;
        AmmoCodexScriptable ammo_codex_m830;
        AmmoType ammo_m830;

        AmmoClipCodexScriptable clip_codex_m830a2;
        AmmoType.AmmoClip clip_m830a2;
        AmmoCodexScriptable ammo_codex_m830a2;
        AmmoType ammo_m830a2;

        AmmoClipCodexScriptable clip_codex_XM1147;
        AmmoType.AmmoClip clip_XM1147;
        AmmoCodexScriptable ammo_codex_XM1147;
        static AmmoType ammo_xm1147;

        AmmoType ammo_m833;
        AmmoType ammo_m456;

<<<<<<< Updated upstream:M1A1AbramsMod.cs
=======
        ArmorType armor_compositeskirt_HU;
        ArmorCodexScriptable armor_codex_superCompositeskirt_HU;
        ArmorType armor_superCompositeskirt_HU;

        ArmorType armor_cheeksnera_HU;
        ArmorCodexScriptable armor_codex_cheeksDUarmor_HU;
        ArmorType armor_cheeksDUarmor_HU;

        ArmorType armor_fronthullnera_HU;
        ArmorCodexScriptable armor_codex_fronthullDUarmor_HU;
        ArmorType armor_fronthullDUarmor_HU;

        ArmorType armor_mantletnera_HU;
        ArmorCodexScriptable armor_codex_mantletDUarmor_HU;
        ArmorType armor_mantletDUarmor_HU;

        ArmorType armor_turretsidesnera_HU;
        ArmorCodexScriptable armor_codex_turretsidesDUarmor_HU;
        ArmorType armor_turretsidesDUarmor_HU;

        ArmorType armor_turretroofarmor_HU;
        ArmorCodexScriptable armor_codex_turretroofCompositearmor_HU;
        ArmorType armor_turretroofCompositearmor_HU;

        ArmorType armor_upperglacisarmor_HU;
        ArmorCodexScriptable armor_codex_upperglacisCompositearmor_HU;
        ArmorType armor_upperglacisCompositearmor_HU;

        ArmorType armor_commmandershatcharmor_HU;
        ArmorCodexScriptable armor_codex_commmandershatchCompositearmor_HU;
        ArmorType armor_commmandershatchCompositearmor_HU;

        ArmorType armor_loadershatcharmor_HU;
        ArmorCodexScriptable armor_codex_loadershatchCompositearmor_HU;
        ArmorType armor_loadershatchCompositearmor_HU;

        ArmorType armor_drivershatcharmor_HU;
        ArmorCodexScriptable armor_codex_drivershatchCompositearmor_HU;
        ArmorType armor_drivershatchCompositearmor_HU;

        ArmorType armor_turretringarmor_HU;
        ArmorCodexScriptable armor_codex_turretringCompositearmor_HU;
        ArmorType armor_turretringCompositearmor_HU;

        ArmorType armor_gunmantletfacearmor_HU;
        ArmorCodexScriptable armor_codex_gunmantletfaceCompositearmor_HU;
        ArmorType armor_gunmantletfaceCompositearmor_HU;

        ArmorType armor_trackarmor_HU;
        ArmorCodexScriptable armor_codex_trackSpecialarmor_HU;
        ArmorType armor_trackSpecialarmor_HU;

        ArmorType armor_compositeskirt_HC;
        ArmorCodexScriptable armor_codex_superCompositeskirt_HC;
        ArmorType armor_superCompositeskirt_HC;

        ArmorType armor_cheeksnera_HC;
        ArmorCodexScriptable armor_codex_cheeksDUarmor_HC;
        ArmorType armor_cheeksDUarmor_HC;

        ArmorType armor_fronthullnera_HC;
        ArmorCodexScriptable armor_codex_fronthullDUarmor_HC;
        ArmorType armor_fronthullDUarmor_HC;

        ArmorType armor_mantletnera_HC;
        ArmorCodexScriptable armor_codex_mantletDUarmor_HC;
        ArmorType armor_mantletDUarmor_HC;

        ArmorType armor_turretsidesnera_HC;
        ArmorCodexScriptable armor_codex_turretsidesDUarmor_HC;
        ArmorType armor_turretsidesDUarmor_HC;

        ArmorType armor_compositeskirt_HA;
        ArmorCodexScriptable armor_codex_superCompositeskirt_HA;
        ArmorType armor_superCompositeskirt_HA;

        ArmorType armor_cheeksnera_HA;
        ArmorCodexScriptable armor_codex_cheeksDUarmor_HA;
        ArmorType armor_cheeksDUarmor_HA;

        ArmorType armor_fronthullnera_HA;
        ArmorCodexScriptable armor_codex_fronthullDUarmor_HA;
        ArmorType armor_fronthullDUarmor_HA;

        ArmorType armor_mantletnera_HA;
        ArmorCodexScriptable armor_codex_mantletDUarmor_HA;
        ArmorType armor_mantletDUarmor_HA;

        ArmorType armor_turretsidesnera_HA;
        ArmorCodexScriptable armor_codex_turretsidesDUarmor_HA;
        ArmorType armor_turretsidesDUarmor_HA;

>>>>>>> Stashed changes:M1A1AbramsAMPMod.cs
        public override void OnInitializeMelon()
        {
            cfg = MelonPreferences.CreateCategory("M1A1AMPConfig");
            primaryammoCount = cfg.CreateEntry<int>("M1A1/E1 Primary Round Count", 20);
            primaryammoCount.Description = "How many rounds per type each Abrams should carry. Maximum of 44 rounds total. Bring in at least one primary round.";
            secondaryammoCount = cfg.CreateEntry<int>("M1A1/E1 Secondary Round Count", 10);
            tertiaryammoCount = cfg.CreateEntry<int>("M1A1/E1 Tertiary Round Count", 14);

            m1primaryAmmo = cfg.CreateEntry<string>("M1A1/E1 Primary Round", "M829A4");
            m1primaryAmmo.Description = "Round types carried by M1A1 and M1E1: 'M829', 'M829A1', 'M829A2', 'M829A3', 'M829A4', 'M830', 'M830A2' or 'XM1147'";
            m1secondaryAmmo = cfg.CreateEntry<string>("M1A1/E1 Secondary Round", "M830A2");
            m1tertiaryAmmo = cfg.CreateEntry<string>("M1A1/E1 Tertiary Round", "XM1147");

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
            int reticleId = (currentAmmo.Name == "M829 APFSDS-T" || currentAmmo.Name == "M829A1 APFSDS-T") ? 0 : 2;

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
<<<<<<< Updated upstream:M1A1AbramsMod.cs
                    if (s.AmmoType.Name == "M833 APFSDS-T")
                    {
                        ammo_m833 = s.AmmoType;
                    }

                    if (s.AmmoType.Name == "M456 HEAT-FS-T")
                    {
                        ammo_m456 = s.AmmoType;
                    }
=======
                    if (s.AmmoType.Name == "M833 APFSDS-T") ammo_m833 = s.AmmoType;
                    if (s.AmmoType.Name == "M456 HEAT-FS-T") ammo_m456 = s.AmmoType;
                }

                foreach (ArmorCodexScriptable s in Resources.FindObjectsOfTypeAll(typeof(ArmorCodexScriptable)))
                {
                    if (s.ArmorType.Name == "composite skirt") armor_compositeskirt_HU = s.ArmorType;
                    if (s.ArmorType.Name == "special armor") armor_cheeksnera_HU = s.ArmorType;
                    if (s.ArmorType.Name == "special armor") armor_fronthullnera_HU = s.ArmorType;
                    if (s.ArmorType.Name == "special armor") armor_mantletnera_HU = s.ArmorType;
                    if (s.ArmorType.Name == "special armor") armor_turretsidesnera_HU = s.ArmorType;
                    if (s.ArmorType.Name == "composite skirt") armor_turretroofarmor_HU = s.ArmorType;
                    if (s.ArmorType.Name == "composite skirt") armor_upperglacisarmor_HU = s.ArmorType;
                    if (s.ArmorType.Name == "tracks") armor_trackarmor_HU = s.ArmorType;

                    if (s.ArmorType.Name == "composite skirt") armor_commmandershatcharmor_HU = s.ArmorType;
                    if (s.ArmorType.Name == "composite skirt") armor_loadershatcharmor_HU = s.ArmorType;
                    if (s.ArmorType.Name == "composite skirt") armor_drivershatcharmor_HU = s.ArmorType;
                    if (s.ArmorType.Name == "composite skirt") armor_turretringarmor_HU = s.ArmorType;
                    if (s.ArmorType.Name == "composite skirt") armor_gunmantletfacearmor_HU = s.ArmorType;

                    if (s.ArmorType.Name == "composite skirt") armor_compositeskirt_HC = s.ArmorType;
                    if (s.ArmorType.Name == "special armor") armor_cheeksnera_HC = s.ArmorType;
                    if (s.ArmorType.Name == "special armor") armor_fronthullnera_HC = s.ArmorType;
                    if (s.ArmorType.Name == "special armor") armor_mantletnera_HC = s.ArmorType;
                    if (s.ArmorType.Name == "special armor") armor_turretsidesnera_HC = s.ArmorType;

                    if (s.ArmorType.Name == "composite skirt") armor_compositeskirt_HA = s.ArmorType;
                    if (s.ArmorType.Name == "special armor") armor_cheeksnera_HA = s.ArmorType;
                    if (s.ArmorType.Name == "special armor") armor_fronthullnera_HA = s.ArmorType;
                    if (s.ArmorType.Name == "special armor") armor_mantletnera_HA = s.ArmorType;
                    if (s.ArmorType.Name == "special armor") armor_turretsidesnera_HA = s.ArmorType;
>>>>>>> Stashed changes:M1A1AbramsAMPMod.cs
                }

                // m256
                gun_m256 = ScriptableObject.CreateInstance<WeaponSystemCodexScriptable>();
                gun_m256.name = "gun_m256";
                gun_m256.CaliberMm = 120;
                gun_m256.FriendlyName = "120mm Gun M256";
                gun_m256.Type = WeaponSystemCodexScriptable.WeaponType.LargeCannon;

<<<<<<< Updated upstream:M1A1AbramsMod.cs
=======
                //Ammo stuff

>>>>>>> Stashed changes:M1A1AbramsAMPMod.cs
                // m829 
                ammo_m829 = new AmmoType();
                Util.ShallowCopy(ammo_m829, ammo_m833);
                ammo_m829.Name = "M829 APFSDS-T";
                ammo_m829.Caliber = 120;
                ammo_m829.RhaPenetration = 600;
                ammo_m829.MuzzleVelocity = 1670f;
                ammo_m829.Mass = 3.94f;

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

                // m829a1
                ammo_m829a1 = new AmmoType();
                Util.ShallowCopy(ammo_m829a1, ammo_m833);
                ammo_m829a1.Name = "M829A1 APFSDS-T";
                ammo_m829a1.Caliber = 120;
                ammo_m829a1.RhaPenetration = 700f;
                ammo_m829a1.MuzzleVelocity = 1670f;
                ammo_m829a1.Mass = 4.64f;

                ammo_codex_m829a1 = ScriptableObject.CreateInstance<AmmoCodexScriptable>();
                ammo_codex_m829a1.AmmoType = ammo_m829a1;
                ammo_codex_m829a1.name = "ammo_m829a1";

                clip_m829a1 = new AmmoType.AmmoClip();
                clip_m829a1.Capacity = 1;
                clip_m829a1.Name = "M829A1 APFSDS-T";
                clip_m829a1.MinimalPattern = new AmmoCodexScriptable[1];
                clip_m829a1.MinimalPattern[0] = ammo_codex_m829a1;

                clip_codex_m829a1 = ScriptableObject.CreateInstance<AmmoClipCodexScriptable>();
                clip_codex_m829a1.name = "clip_m829a1";
                clip_codex_m829a1.CompatibleWeaponSystems = new WeaponSystemCodexScriptable[1];
                clip_codex_m829a1.CompatibleWeaponSystems[0] = gun_m256;
                clip_codex_m829a1.ClipType = clip_m829a1;

                // m829a2
                ammo_m829a2 = new AmmoType();
                Util.ShallowCopy(ammo_m829a2, ammo_m833);
                ammo_m829a2.Name = "M829A2 APFSDS-T";
                ammo_m829a2.Caliber = 120;
                ammo_m829a2.RhaPenetration = 800f;
                ammo_m829a2.MuzzleVelocity = 1680f;
                ammo_m829a2.Mass = 4.74f;

                ammo_codex_m829a2 = ScriptableObject.CreateInstance<AmmoCodexScriptable>();
                ammo_codex_m829a2.AmmoType = ammo_m829a2;
                ammo_codex_m829a2.name = "ammo_m829a2";

                clip_m829a2 = new AmmoType.AmmoClip();
                clip_m829a2.Capacity = 1;
                clip_m829a2.Name = "M829A2 APFSDS-T";
                clip_m829a2.MinimalPattern = new AmmoCodexScriptable[1];
                clip_m829a2.MinimalPattern[0] = ammo_codex_m829a2;

                clip_codex_m829a2 = ScriptableObject.CreateInstance<AmmoClipCodexScriptable>();
                clip_codex_m829a2.name = "clip_m829a2";
                clip_codex_m829a2.CompatibleWeaponSystems = new WeaponSystemCodexScriptable[1];
                clip_codex_m829a2.CompatibleWeaponSystems[0] = gun_m256;
                clip_codex_m829a2.ClipType = clip_m829a2;

                // m829a3
                ammo_m829a3 = new AmmoType();
                Util.ShallowCopy(ammo_m829a3, ammo_m833);
                ammo_m829a3.Name = "M829A3 APFSDS-T";
                ammo_m829a3.Caliber = 120;
                ammo_m829a3.RhaPenetration = 900f;
                ammo_m829a3.MuzzleVelocity = 1555f;
                ammo_m829a3.Mass = 4.84f;

                ammo_codex_m829a3 = ScriptableObject.CreateInstance<AmmoCodexScriptable>();
                ammo_codex_m829a3.AmmoType = ammo_m829a3;
                ammo_codex_m829a3.name = "ammo_m829a3";

                clip_m829a3 = new AmmoType.AmmoClip();
                clip_m829a3.Capacity = 1;
                clip_m829a3.Name = "M829A3 APFSDS-T";
                clip_m829a3.MinimalPattern = new AmmoCodexScriptable[1];
                clip_m829a3.MinimalPattern[0] = ammo_codex_m829a3;

                clip_codex_m829a3 = ScriptableObject.CreateInstance<AmmoClipCodexScriptable>();
                clip_codex_m829a3.name = "clip_m829a3";
                clip_codex_m829a3.CompatibleWeaponSystems = new WeaponSystemCodexScriptable[1];
                clip_codex_m829a3.CompatibleWeaponSystems[0] = gun_m256;
                clip_codex_m829a3.ClipType = clip_m829a3;

                // m829a4
                ammo_m829a4 = new AmmoType();
                Util.ShallowCopy(ammo_m829a4, ammo_m833);
                ammo_m829a4.Name = "M829A4 APFSDS-T";
                ammo_m829a4.Caliber = 120;
                ammo_m829a4.RhaPenetration = 1000f;
                ammo_m829a4.MuzzleVelocity = 1700f;
                ammo_m829a4.Mass = 4.94f;
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

                // m830a2
                ammo_m830a2 = new AmmoType();
                Util.ShallowCopy(ammo_m830a2, ammo_m456);
                ammo_m830a2.Name = "M830A2 IHEAT-MP-T";
                ammo_m830a2.Caliber = 120;
                ammo_m830a2.RhaPenetration = 1200;
                ammo_m830a2.TntEquivalentKg = 2.721f;
                ammo_m830a2.MuzzleVelocity = 1410f;
                ammo_m830a2.Mass = 13.5f;
                ammo_m830a2.CertainRicochetAngle = 8.0f;
                ammo_m830a2.ShatterOnRicochet = false;
                ammo_m830a2.DetonateSpallCount = 150;
                ammo_m830a2.SpallMultiplier = 2f;
                ammo_m830a2.MaxSpallRha = 40f;
                ammo_m830a2.MinSpallRha = 5f;

                ammo_codex_m830a2 = ScriptableObject.CreateInstance<AmmoCodexScriptable>();
                ammo_codex_m830a2.AmmoType = ammo_m830a2;
                ammo_codex_m830a2.name = "ammo_m830a2";

                clip_m830a2 = new AmmoType.AmmoClip();
                clip_m830a2.Capacity = 1;
                clip_m830a2.Name = "M830A2 HEAT-FS-T";
                clip_m830a2.MinimalPattern = new AmmoCodexScriptable[1];
                clip_m830a2.MinimalPattern[0] = ammo_codex_m830a2;

                clip_codex_m830a2 = ScriptableObject.CreateInstance<AmmoClipCodexScriptable>();
                clip_codex_m830a2.name = "clip_m830a2";
                clip_codex_m830a2.CompatibleWeaponSystems = new WeaponSystemCodexScriptable[1];
                clip_codex_m830a2.CompatibleWeaponSystems[0] = gun_m256;
                clip_codex_m830a2.ClipType = clip_m830a2;

                // XM1147
                ammo_xm1147 = new AmmoType();
                Util.ShallowCopy(ammo_xm1147, ammo_m456);
                ammo_xm1147.Name = "XM1147 AMP-T";
                ammo_xm1147.Caliber = 120;
                ammo_xm1147.RhaPenetration = 480;
                ammo_xm1147.TntEquivalentKg = 3.324f;
<<<<<<< Updated upstream:M1A1AbramsMod.cs
                ammo_xm1147.MaxSpallRha = 160f;
                ammo_xm1147.MinSpallRha = 45f;
                ammo_xm1147.MuzzleVelocity = 1140f;
                ammo_xm1147.Mass = 13.5f;
=======
                ammo_xm1147.MaxSpallRha = 180f;
                ammo_xm1147.MinSpallRha = 55f;
                ammo_xm1147.MuzzleVelocity = 1410f;
                ammo_xm1147.Mass = 11.4f;
>>>>>>> Stashed changes:M1A1AbramsAMPMod.cs
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
<<<<<<< Updated upstream:M1A1AbramsMod.cs
            }

=======

                //Armor stuff//
                var abrams_armorvariant = new Dictionary<string, ArmorCodexScriptable>()
                {
                    ["HU"] = armor_codex_superCompositeskirt_HU,
                    ["HU"] = armor_codex_cheeksDUarmor_HU,
                    ["HU"] = armor_codex_fronthullDUarmor_HU,
                    ["HU"] = armor_codex_mantletDUarmor_HU,
                    ["HU"] = armor_codex_turretsidesDUarmor_HU,
                    ["HU"] = armor_codex_turretroofCompositearmor_HU,
                    ["HU"] = armor_codex_upperglacisCompositearmor_HU,
                    ["HU"] = armor_codex_commmandershatchCompositearmor_HU,
                    ["HU"] = armor_codex_loadershatchCompositearmor_HU,
                    ["HU"] = armor_codex_drivershatchCompositearmor_HU,
                    ["HU"] = armor_codex_turretringCompositearmor_HU,
                    ["HU"] = armor_codex_gunmantletfaceCompositearmor_HU,
                    ["HU"] = armor_codex_trackSpecialarmor_HU,
                    ["HC"] = armor_codex_superCompositeskirt_HC,
                    ["HC"] = armor_codex_cheeksDUarmor_HC,
                    ["HC"] = armor_codex_fronthullDUarmor_HC,
                    ["HC"] = armor_codex_mantletDUarmor_HC,
                    ["HC"] = armor_codex_turretsidesDUarmor_HC,
                    ["HA"] = armor_codex_superCompositeskirt_HA,
                    ["HA"] = armor_codex_cheeksDUarmor_HA,
                    ["HA"] = armor_codex_fronthullDUarmor_HA,
                    ["HA"] = armor_codex_mantletDUarmor_HA,
                    ["HA"] = armor_codex_turretsidesDUarmor_HA,
                };

                ////HU armor modifiers////
                armor_superCompositeskirt_HU = new ArmorType();
                Util.ShallowCopy(armor_superCompositeskirt_HU, armor_compositeskirt_HU);
                armor_superCompositeskirt_HU.RhaeMultiplierCe = 8.35f; //default 1.5
                armor_superCompositeskirt_HU.RhaeMultiplierKe = 5.0f; //default 0.8
                armor_superCompositeskirt_HU.Name = "Abrams HU super special composite skirt";

                armor_codex_superCompositeskirt_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_superCompositeskirt_HU.name = "Abrams HU super special composite skirt";
                armor_codex_superCompositeskirt_HU.ArmorType = armor_superCompositeskirt_HU;

                armor_cheeksDUarmor_HU = new ArmorType();
                Util.ShallowCopy(armor_cheeksDUarmor_HU, armor_cheeksnera_HU);
                armor_cheeksDUarmor_HU.RhaeMultiplierCe = 2.2f; //default 1.3
                armor_cheeksDUarmor_HU.RhaeMultiplierKe = 1.2f; //default 0.55
                armor_cheeksDUarmor_HU.Name = "Abrams HU DU armor turret cheeks";

                armor_codex_cheeksDUarmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_cheeksDUarmor_HU.name = "Abrams HU DU armor turret cheeks";
                armor_codex_cheeksDUarmor_HU.ArmorType = armor_cheeksDUarmor_HU;
                armor_cheeksDUarmor_HU = new ArmorType();

                armor_fronthullDUarmor_HU = new ArmorType();
                Util.ShallowCopy(armor_fronthullDUarmor_HU, armor_fronthullnera_HU);
                armor_fronthullDUarmor_HU.RhaeMultiplierCe = 2.2f; //default 1.3
                armor_fronthullDUarmor_HU.RhaeMultiplierKe = 1.4f; //default 0.45
                armor_fronthullDUarmor_HU.Name = "Abrams HU DU armor hull front";

                armor_codex_fronthullDUarmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_fronthullDUarmor_HU.name = "Abrams HU DU armor hull front";
                armor_codex_fronthullDUarmor_HU.ArmorType = armor_fronthullDUarmor_HU;
                armor_fronthullDUarmor_HU = new ArmorType();

                armor_mantletDUarmor_HU = new ArmorType();
                Util.ShallowCopy(armor_mantletDUarmor_HU, armor_mantletnera_HU);
                armor_mantletDUarmor_HU.RhaeMultiplierCe = 2.15f; //default 1.3
                armor_mantletDUarmor_HU.RhaeMultiplierKe = 1.5f; //default 1.4
                armor_mantletDUarmor_HU.Name = "Abrams HU DU armor mantlet";

                armor_codex_mantletDUarmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_mantletDUarmor_HU.name = "Abrams HU DU armor mantlet";
                armor_codex_mantletDUarmor_HU.ArmorType = armor_mantletDUarmor_HU;
                armor_mantletDUarmor_HU = new ArmorType();

                armor_turretsidesDUarmor_HU = new ArmorType();
                Util.ShallowCopy(armor_turretsidesDUarmor_HU, armor_turretsidesnera_HU);
                armor_turretsidesDUarmor_HU.RhaeMultiplierCe = 4.4f; //default 1.3
                armor_turretsidesDUarmor_HU.RhaeMultiplierKe = 2.21f; //default 1.4
                armor_turretsidesDUarmor_HU.Name = "Abrams HU DU armor turret sides";

                armor_codex_turretsidesDUarmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_turretsidesDUarmor_HU.name = "Abrams HU DU armor turret sides";
                armor_codex_turretsidesDUarmor_HU.ArmorType = armor_turretsidesDUarmor_HU;
                armor_turretsidesDUarmor_HU = new ArmorType();

                armor_turretroofCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_turretroofCompositearmor_HU, armor_turretroofarmor_HU);
                armor_turretroofCompositearmor_HU.RhaeMultiplierCe = 2.0f; //default composite skirt 1.5
                armor_turretroofCompositearmor_HU.RhaeMultiplierKe = 2.3f; //default composite skirt 0.8
                armor_turretroofCompositearmor_HU.Name = "Abrams HU roof special composite";

                armor_codex_turretroofCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_turretroofCompositearmor_HU.name = "Abrams HU roof special composite";
                armor_codex_turretroofCompositearmor_HU.ArmorType = armor_turretroofCompositearmor_HU;
                armor_turretroofCompositearmor_HU = new ArmorType();

                armor_upperglacisCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_upperglacisCompositearmor_HU, armor_upperglacisarmor_HU);
                armor_upperglacisCompositearmor_HU.RhaeMultiplierCe = 3.0f; //default composite skirt 1.5
                armor_upperglacisCompositearmor_HU.RhaeMultiplierKe = 2.6f; //default composite skirt 0.8
                armor_upperglacisCompositearmor_HU.Name = "Abrams HU upper glacis special composite";

                armor_codex_upperglacisCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_upperglacisCompositearmor_HU.name = "Abrams HU upper glacis special composite";
                armor_codex_upperglacisCompositearmor_HU.ArmorType = armor_upperglacisCompositearmor_HU;
                armor_upperglacisCompositearmor_HU = new ArmorType();

                armor_commmandershatchCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_commmandershatchCompositearmor_HU, armor_commmandershatcharmor_HU);
                armor_commmandershatchCompositearmor_HU.RhaeMultiplierCe = 2.0f; //default composite skirt 1.5
                armor_commmandershatchCompositearmor_HU.RhaeMultiplierKe = 2.3f; //default composite skirt 0.8
                armor_commmandershatchCompositearmor_HU.Name = "Abrams HU commander's hatch special composite";

                armor_codex_commmandershatchCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_commmandershatchCompositearmor_HU.name = "Abrams HU commander's hatch special composite";
                armor_codex_commmandershatchCompositearmor_HU.ArmorType = armor_commmandershatchCompositearmor_HU;
                armor_commmandershatchCompositearmor_HU = new ArmorType();

                armor_loadershatchCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_loadershatchCompositearmor_HU, armor_loadershatcharmor_HU);
                armor_loadershatchCompositearmor_HU.RhaeMultiplierCe = 2.0f; //default composite skirt 1.5
                armor_loadershatchCompositearmor_HU.RhaeMultiplierKe = 2.3f; //default composite skirt 0.8
                armor_loadershatchCompositearmor_HU.Name = "Abrams HU loader's hatch special composite";

                armor_codex_loadershatchCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_loadershatchCompositearmor_HU.name = "Abrams HU loader's hatch special composite";
                armor_codex_loadershatchCompositearmor_HU.ArmorType = armor_loadershatchCompositearmor_HU;
                armor_loadershatchCompositearmor_HU = new ArmorType();

                armor_drivershatchCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_loadershatchCompositearmor_HU, armor_drivershatcharmor_HU);
                armor_drivershatchCompositearmor_HU.RhaeMultiplierCe = 2.0f; //default composite skirt 1.5
                armor_drivershatchCompositearmor_HU.RhaeMultiplierKe = 2.3f; //default composite skirt 0.8
                armor_drivershatchCompositearmor_HU.Name = "Abrams HU driver's hatch special composite";

                armor_codex_drivershatchCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_drivershatchCompositearmor_HU.name = "Abrams HU driver's hatch special composite";
                armor_codex_drivershatchCompositearmor_HU.ArmorType = armor_drivershatchCompositearmor_HU;
                armor_drivershatchCompositearmor_HU = new ArmorType();

                armor_turretringCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_turretringCompositearmor_HU, armor_turretringarmor_HU);
                armor_turretringCompositearmor_HU.RhaeMultiplierCe = 2.6f; //default composite skirt 1.5
                armor_turretringCompositearmor_HU.RhaeMultiplierKe = 3.0f; //default composite skirt 0.8
                armor_turretringCompositearmor_HU.Name = "Abrams HU turret ring special composite";

                armor_codex_turretringCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_turretringCompositearmor_HU.name = "Abrams HU turret ring special composite";
                armor_codex_turretringCompositearmor_HU.ArmorType = armor_turretringCompositearmor_HU;
                armor_turretringCompositearmor_HU = new ArmorType();

                armor_gunmantletfaceCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_gunmantletfaceCompositearmor_HU, armor_gunmantletfacearmor_HU);
                armor_gunmantletfaceCompositearmor_HU.RhaeMultiplierCe = 2.6f; //default composite skirt 1.5
                armor_gunmantletfaceCompositearmor_HU.RhaeMultiplierKe = 3.0f; //default composite skirt 0.8
                armor_gunmantletfaceCompositearmor_HU.Name = "Abrams HU gun mantlet face special composite";

                armor_codex_gunmantletfaceCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_gunmantletfaceCompositearmor_HU.name = "Abrams HU gun mantlet face special composite";
                armor_codex_gunmantletfaceCompositearmor_HU.ArmorType = armor_gunmantletfaceCompositearmor_HU;
                armor_gunmantletfaceCompositearmor_HU = new ArmorType();

                armor_trackSpecialarmor_HU = new ArmorType();
                Util.ShallowCopy(armor_trackSpecialarmor_HU, armor_trackarmor_HU);
                armor_trackSpecialarmor_HU.RhaeMultiplierCe = 2.4f; //default composite skirt 1.5
                armor_trackSpecialarmor_HU.RhaeMultiplierKe = 2.2f; //default composite skirt 0.8
                armor_trackSpecialarmor_HU.Name = "Abrams HU special track armor";

                armor_codex_trackSpecialarmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_trackSpecialarmor_HU.name = "Abrams HU special track armor";
                armor_codex_trackSpecialarmor_HU.ArmorType = armor_trackSpecialarmor_HU;
                armor_trackSpecialarmor_HU = new ArmorType();
                ////End////

                ////HC armor modifiers (12.5% increase)////
                armor_superCompositeskirt_HC = new ArmorType();
                Util.ShallowCopy(armor_superCompositeskirt_HC, armor_compositeskirt_HC);
                armor_superCompositeskirt_HC.RhaeMultiplierCe = 1.875f; //default 1.5
                armor_superCompositeskirt_HC.RhaeMultiplierKe = 1.0f; //default 0.8
                armor_superCompositeskirt_HC.Name = "Abrams HC super special composite skirt";

                armor_codex_superCompositeskirt_HC = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_superCompositeskirt_HC.name = "Abrams HC super special composite skirt";
                armor_codex_superCompositeskirt_HC.ArmorType = armor_superCompositeskirt_HC;

                armor_cheeksDUarmor_HC = new ArmorType();
                Util.ShallowCopy(armor_cheeksDUarmor_HC, armor_cheeksnera_HC);
                armor_cheeksDUarmor_HC.RhaeMultiplierCe = 1.625f; //default 1.3
                armor_cheeksDUarmor_HC.RhaeMultiplierKe = 0.6875f; //default 0.55
                armor_cheeksDUarmor_HC.Name = "Abrams HC DU armor turret cheeks";

                armor_codex_cheeksDUarmor_HC = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_cheeksDUarmor_HC.name = "Abrams HC DU armor turret cheeks";
                armor_codex_cheeksDUarmor_HC.ArmorType = armor_cheeksDUarmor_HC;
                armor_cheeksDUarmor_HC = new ArmorType();

                armor_fronthullDUarmor_HC = new ArmorType();
                Util.ShallowCopy(armor_fronthullDUarmor_HC, armor_fronthullnera_HC);
                armor_fronthullDUarmor_HC.RhaeMultiplierCe = 1.625f; //default 1.3
                armor_fronthullDUarmor_HC.RhaeMultiplierKe = 0.625f; //default 0.45
                armor_fronthullDUarmor_HC.Name = "Abrams HC DU armor hull front";

                armor_codex_fronthullDUarmor_HC = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_fronthullDUarmor_HC.name = "Abrams HC DU armor hull front";
                armor_codex_fronthullDUarmor_HC.ArmorType = armor_fronthullDUarmor_HC;
                armor_fronthullDUarmor_HC = new ArmorType();

                armor_mantletDUarmor_HC = new ArmorType();
                Util.ShallowCopy(armor_mantletDUarmor_HC, armor_mantletnera_HC);
                armor_mantletDUarmor_HC.RhaeMultiplierCe = 1.625f; //default 1.3
                armor_mantletDUarmor_HC.RhaeMultiplierKe = 1.75f; //default 1.4
                armor_mantletDUarmor_HC.Name = "Abrams HC DU armor mantlet";

                armor_codex_mantletDUarmor_HC = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_mantletDUarmor_HC.name = "Abrams HC DU armor mantlet";
                armor_codex_mantletDUarmor_HC.ArmorType = armor_mantletDUarmor_HC;
                armor_mantletDUarmor_HC = new ArmorType();

                armor_turretsidesDUarmor_HC = new ArmorType();
                Util.ShallowCopy(armor_turretsidesDUarmor_HC, armor_turretsidesnera_HC);
                armor_turretsidesDUarmor_HC.RhaeMultiplierCe = 1.625f; //default 1.3
                armor_turretsidesDUarmor_HC.RhaeMultiplierKe = 1.75f; //default 1.4
                armor_turretsidesDUarmor_HC.Name = "Abrams HC DU armor turret sides";

                armor_codex_turretsidesDUarmor_HC = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_turretsidesDUarmor_HC.name = "Abrams HC DU armor turret sides";
                armor_codex_turretsidesDUarmor_HC.ArmorType = armor_turretsidesDUarmor_HC;
                armor_turretsidesDUarmor_HC = new ArmorType();
                ////End////

                ////HA armor modifiers (25% increase)////
                armor_superCompositeskirt_HA = new ArmorType();
                Util.ShallowCopy(armor_superCompositeskirt_HA, armor_compositeskirt_HA);
                armor_superCompositeskirt_HA.RhaeMultiplierCe = 1.6875f; //default 1.5
                armor_superCompositeskirt_HA.RhaeMultiplierKe = 0.9f; //default 0.8
                armor_superCompositeskirt_HA.Name = "Abrams HA super special composite skirt";

                armor_codex_superCompositeskirt_HA = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_superCompositeskirt_HA.name = "Abrams HA super special composite skirt";
                armor_codex_superCompositeskirt_HA.ArmorType = armor_superCompositeskirt_HA;

                armor_cheeksDUarmor_HA = new ArmorType();
                Util.ShallowCopy(armor_cheeksDUarmor_HA, armor_cheeksnera_HA);
                armor_cheeksDUarmor_HA.RhaeMultiplierCe = 1.4625f; //default 1.3
                armor_cheeksDUarmor_HA.RhaeMultiplierKe = 0.61875f; //default 0.55
                armor_cheeksDUarmor_HA.Name = "Abrams HA DU armor turret cheeks";

                armor_codex_cheeksDUarmor_HA = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_cheeksDUarmor_HA.name = "Abrams HA DU armor turret cheeks";
                armor_codex_cheeksDUarmor_HA.ArmorType = armor_cheeksDUarmor_HA;
                armor_cheeksDUarmor_HA = new ArmorType();

                armor_fronthullDUarmor_HA = new ArmorType();
                Util.ShallowCopy(armor_fronthullDUarmor_HA, armor_fronthullnera_HA);
                armor_fronthullDUarmor_HA.RhaeMultiplierCe = 1.4625f; //default 1.3
                armor_fronthullDUarmor_HA.RhaeMultiplierKe = 0.5625f; //default 0.45
                armor_fronthullDUarmor_HA.Name = "Abrams HA DU armor hull front";

                armor_codex_fronthullDUarmor_HA = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_fronthullDUarmor_HA.name = "Abrams HA DU armor hull front";
                armor_codex_fronthullDUarmor_HA.ArmorType = armor_fronthullDUarmor_HA;
                armor_fronthullDUarmor_HA = new ArmorType();

                armor_mantletDUarmor_HA = new ArmorType();
                Util.ShallowCopy(armor_mantletDUarmor_HA, armor_mantletnera_HA);
                armor_mantletDUarmor_HA.RhaeMultiplierCe = 1.4625f; //default 1.3
                armor_mantletDUarmor_HA.RhaeMultiplierKe = 1.575f; //default 1.4
                armor_mantletDUarmor_HA.Name = "Abrams HA DU armor mantlet";

                armor_codex_mantletDUarmor_HA = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_mantletDUarmor_HA.name = "Abrams HA DU armor mantlet";
                armor_codex_mantletDUarmor_HA.ArmorType = armor_mantletDUarmor_HA;
                armor_mantletDUarmor_HA = new ArmorType();

                armor_turretsidesDUarmor_HA = new ArmorType();
                Util.ShallowCopy(armor_turretsidesDUarmor_HA, armor_turretsidesnera_HA);
                armor_turretsidesDUarmor_HA.RhaeMultiplierCe = 1.4625f; //default 1.3
                armor_turretsidesDUarmor_HA.RhaeMultiplierKe = 1.575f; //default 1.4
                armor_turretsidesDUarmor_HA.Name = "Abrams HA DU armor turret sides";

                armor_codex_turretsidesDUarmor_HA = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_turretsidesDUarmor_HA.name = "Abrams HA DU armor turret sides";
                armor_codex_turretsidesDUarmor_HA.ArmorType = armor_turretsidesDUarmor_HA;
                armor_turretsidesDUarmor_HA = new ArmorType();
                ////End////
            }

            ////Assign modified armor to M1A1HU////
            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor compositeskirtPlate_HU = armour.GetComponent<VariableArmor>();

                if (compositeskirtPlate_HU == null) continue;
                if (compositeskirtPlate_HU.Unit == null) continue;
                if (compositeskirtPlate_HU.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (compositeskirtPlate_HU.Name != "composite side skirt") continue;

                FieldInfo armorskirtComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorskirtComposite_HU.SetValue(compositeskirtPlate_HU, armor_codex_superCompositeskirt_HU);

                MelonLogger.Msg(compositeskirtPlate_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor cheeksDUarray_HU = armour.GetComponent<VariableArmor>();
                if (cheeksDUarray_HU == null) continue;
                if (cheeksDUarray_HU.Unit == null) continue;
                if (cheeksDUarray_HU.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (cheeksDUarray_HU.Name != "turret cheek special armor array") continue;

                FieldInfo armorcheeksDU_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorcheeksDU_HU.SetValue(cheeksDUarray_HU, armor_codex_cheeksDUarmor_HU);

                MelonLogger.Msg(cheeksDUarray_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor hullfrontDUarray_HU = armour.GetComponent<VariableArmor>();
                if (hullfrontDUarray_HU == null) continue;
                if (hullfrontDUarray_HU.Unit == null) continue;
                if (hullfrontDUarray_HU.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (hullfrontDUarray_HU.Name != "hull front special armor array") continue;

                FieldInfo armorhullfrontDU_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorhullfrontDU_HU.SetValue(hullfrontDUarray_HU, armor_codex_fronthullDUarmor_HU);

                MelonLogger.Msg(hullfrontDUarray_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor mantletDUarray_HU = armour.GetComponent<VariableArmor>();
                if (mantletDUarray_HU == null) continue;
                if (mantletDUarray_HU.Unit == null) continue;
                if (mantletDUarray_HU.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (mantletDUarray_HU.Name != "gun mantlet special armor array") continue;

                FieldInfo armormantletDU_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armormantletDU_HU.SetValue(mantletDUarray_HU, armor_codex_mantletDUarmor_HU);

                MelonLogger.Msg(mantletDUarray_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor turretsidesDUarray_HU = armour.GetComponent<VariableArmor>();
                if (turretsidesDUarray_HU == null) continue;
                if (turretsidesDUarray_HU.Unit == null) continue;
                if (turretsidesDUarray_HU.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (turretsidesDUarray_HU.Name != "turret side special armor array") continue;

                FieldInfo armorturretsidesDU_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorturretsidesDU_HU.SetValue(turretsidesDUarray_HU, armor_codex_turretsidesDUarmor_HU);

                MelonLogger.Msg(turretsidesDUarray_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor turretroofCompositearray_HU = armour.GetComponent<VariableArmor>();
                if (turretroofCompositearray_HU == null) continue;
                if (turretroofCompositearray_HU.Unit == null) continue;
                if (turretroofCompositearray_HU.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (turretroofCompositearray_HU.Name != "turret roof") continue;

                FieldInfo armorturretroofComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorturretroofComposite_HU.SetValue(turretroofCompositearray_HU, armor_codex_turretroofCompositearmor_HU);

                MelonLogger.Msg(turretroofCompositearray_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor upperglacisCompositearray_HU = armour.GetComponent<VariableArmor>();
                if (upperglacisCompositearray_HU == null) continue;
                if (upperglacisCompositearray_HU.Unit == null) continue;
                if (upperglacisCompositearray_HU.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (upperglacisCompositearray_HU.Name != "upper glacis") continue;

                FieldInfo armorupperglacisComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorupperglacisComposite_HU.SetValue(upperglacisCompositearray_HU, armor_codex_upperglacisCompositearmor_HU);

                MelonLogger.Msg(upperglacisCompositearray_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor commandershatchCompositearray_HU = armour.GetComponent<VariableArmor>();
                if (commandershatchCompositearray_HU == null) continue;
                if (commandershatchCompositearray_HU.Unit == null) continue;
                if (commandershatchCompositearray_HU.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (commandershatchCompositearray_HU.Name != "commander's hatch") continue;

                FieldInfo armorcommandershatchComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorcommandershatchComposite_HU.SetValue(commandershatchCompositearray_HU, armor_codex_commmandershatchCompositearmor_HU);

                MelonLogger.Msg(commandershatchCompositearray_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor loadershatchCompositearray_HU = armour.GetComponent<VariableArmor>();
                if (loadershatchCompositearray_HU == null) continue;
                if (loadershatchCompositearray_HU.Unit == null) continue;
                if (loadershatchCompositearray_HU.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (loadershatchCompositearray_HU.Name != "loader's hatch") continue;

                FieldInfo armorloadershatchComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorloadershatchComposite_HU.SetValue(loadershatchCompositearray_HU, armor_codex_loadershatchCompositearmor_HU);

                MelonLogger.Msg(loadershatchCompositearray_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor drivershatchCompositearray_HU = armour.GetComponent<VariableArmor>();
                if (drivershatchCompositearray_HU == null) continue;
                if (drivershatchCompositearray_HU.Unit == null) continue;
                if (drivershatchCompositearray_HU.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (drivershatchCompositearray_HU.Name != "driver's hatch") continue;

                FieldInfo armordrivershatchDU_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armordrivershatchDU_HU.SetValue(drivershatchCompositearray_HU, armor_codex_drivershatchCompositearmor_HU);

                MelonLogger.Msg(drivershatchCompositearray_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor turretringCompositearray_HU = armour.GetComponent<VariableArmor>();
                if (turretringCompositearray_HU == null) continue;
                if (turretringCompositearray_HU.Unit == null) continue;
                if (turretringCompositearray_HU.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (turretringCompositearray_HU.Name != "turret ring") continue;

                FieldInfo armorturretringComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorturretringComposite_HU.SetValue(turretringCompositearray_HU, armor_codex_turretringCompositearmor_HU);

                MelonLogger.Msg(turretringCompositearray_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor gunmantletfaceCompositearray_HU = armour.GetComponent<VariableArmor>();
                if (gunmantletfaceCompositearray_HU == null) continue;
                if (gunmantletfaceCompositearray_HU.Unit == null) continue;
                if (gunmantletfaceCompositearray_HU.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (gunmantletfaceCompositearray_HU.Name != "gun mantlet face") continue;

                FieldInfo armorturretringComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorturretringComposite_HU.SetValue(gunmantletfaceCompositearray_HU, armor_codex_gunmantletfaceCompositearmor_HU);

                MelonLogger.Msg(gunmantletfaceCompositearray_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor trackSpecialarmor_HU = armour.GetComponent<VariableArmor>();
                if (trackSpecialarmor_HU == null) continue;
                if (trackSpecialarmor_HU.Unit == null) continue;
                if (trackSpecialarmor_HU.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (trackSpecialarmor_HU.Name != "left track") continue;

                FieldInfo armortrackSpecial_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armortrackSpecial_HU.SetValue(trackSpecialarmor_HU, armor_codex_trackSpecialarmor_HU);

                MelonLogger.Msg(trackSpecialarmor_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor trackSpecialarmor_HU = armour.GetComponent<VariableArmor>();
                if (trackSpecialarmor_HU == null) continue;
                if (trackSpecialarmor_HU.Unit == null) continue;
                if (trackSpecialarmor_HU.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (trackSpecialarmor_HU.Name != "right track") continue;

                FieldInfo armortrackSpecial_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armortrackSpecial_HU.SetValue(trackSpecialarmor_HU, armor_codex_trackSpecialarmor_HU);

                MelonLogger.Msg(trackSpecialarmor_HU.ArmorType);
            }
            ////End////

            ////Assign modified armor to M1E1HU////
            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor compositeskirtPlate_HU = armour.GetComponent<VariableArmor>();

                if (compositeskirtPlate_HU == null) continue;
                if (compositeskirtPlate_HU.Unit == null) continue;
                if (compositeskirtPlate_HU.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (compositeskirtPlate_HU.Name != "composite side skirt") continue;

                FieldInfo armorskirtComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorskirtComposite_HU.SetValue(compositeskirtPlate_HU, armor_codex_superCompositeskirt_HU);

                MelonLogger.Msg(compositeskirtPlate_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor cheeksDUarray_HU = armour.GetComponent<VariableArmor>();
                if (cheeksDUarray_HU == null) continue;
                if (cheeksDUarray_HU.Unit == null) continue;
                if (cheeksDUarray_HU.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (cheeksDUarray_HU.Name != "turret cheek special armor array") continue;

                FieldInfo armorcheeksDU_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorcheeksDU_HU.SetValue(cheeksDUarray_HU, armor_codex_cheeksDUarmor_HU);

                MelonLogger.Msg(cheeksDUarray_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor hullfrontDUarray_HU = armour.GetComponent<VariableArmor>();
                if (hullfrontDUarray_HU == null) continue;
                if (hullfrontDUarray_HU.Unit == null) continue;
                if (hullfrontDUarray_HU.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (hullfrontDUarray_HU.Name != "hull front special armor array") continue;

                FieldInfo armorhullfrontDU_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorhullfrontDU_HU.SetValue(hullfrontDUarray_HU, armor_codex_fronthullDUarmor_HU);

                MelonLogger.Msg(hullfrontDUarray_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor mantletDUarray_HU = armour.GetComponent<VariableArmor>();
                if (mantletDUarray_HU == null) continue;
                if (mantletDUarray_HU.Unit == null) continue;
                if (mantletDUarray_HU.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (mantletDUarray_HU.Name != "gun mantlet special armor array") continue;

                FieldInfo armormantletDU_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armormantletDU_HU.SetValue(mantletDUarray_HU, armor_codex_mantletDUarmor_HU);

                MelonLogger.Msg(mantletDUarray_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor turretsidesDUarray_HU = armour.GetComponent<VariableArmor>();
                if (turretsidesDUarray_HU == null) continue;
                if (turretsidesDUarray_HU.Unit == null) continue;
                if (turretsidesDUarray_HU.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (turretsidesDUarray_HU.Name != "turret side special armor array") continue;

                FieldInfo armorturretsidesDU_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorturretsidesDU_HU.SetValue(turretsidesDUarray_HU, armor_codex_turretsidesDUarmor_HU);

                MelonLogger.Msg(turretsidesDUarray_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor turretroofCompositearray_HU = armour.GetComponent<VariableArmor>();
                if (turretroofCompositearray_HU == null) continue;
                if (turretroofCompositearray_HU.Unit == null) continue;
                if (turretroofCompositearray_HU.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (turretroofCompositearray_HU.Name != "turret roof") continue;

                FieldInfo armorturretroofComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorturretroofComposite_HU.SetValue(turretroofCompositearray_HU, armor_codex_turretroofCompositearmor_HU);

                MelonLogger.Msg(turretroofCompositearray_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor upperglacisCompositearray_HU = armour.GetComponent<VariableArmor>();
                if (upperglacisCompositearray_HU == null) continue;
                if (upperglacisCompositearray_HU.Unit == null) continue;
                if (upperglacisCompositearray_HU.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (upperglacisCompositearray_HU.Name != "upper glacis") continue;

                FieldInfo armorupperglacisComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorupperglacisComposite_HU.SetValue(upperglacisCompositearray_HU, armor_codex_upperglacisCompositearmor_HU);

                MelonLogger.Msg(upperglacisCompositearray_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor commandershatchCompositearray_HU = armour.GetComponent<VariableArmor>();
                if (commandershatchCompositearray_HU == null) continue;
                if (commandershatchCompositearray_HU.Unit == null) continue;
                if (commandershatchCompositearray_HU.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (commandershatchCompositearray_HU.Name != "commander's hatch") continue;

                FieldInfo armorcommandershatchComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorcommandershatchComposite_HU.SetValue(commandershatchCompositearray_HU, armor_codex_commmandershatchCompositearmor_HU);

                MelonLogger.Msg(commandershatchCompositearray_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor loadershatchCompositearray_HU = armour.GetComponent<VariableArmor>();
                if (loadershatchCompositearray_HU == null) continue;
                if (loadershatchCompositearray_HU.Unit == null) continue;
                if (loadershatchCompositearray_HU.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (loadershatchCompositearray_HU.Name != "loader's hatch") continue;

                FieldInfo armorloadershatchComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorloadershatchComposite_HU.SetValue(loadershatchCompositearray_HU, armor_codex_loadershatchCompositearmor_HU);

                MelonLogger.Msg(loadershatchCompositearray_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor drivershatchCompositearray_HU = armour.GetComponent<VariableArmor>();
                if (drivershatchCompositearray_HU == null) continue;
                if (drivershatchCompositearray_HU.Unit == null) continue;
                if (drivershatchCompositearray_HU.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (drivershatchCompositearray_HU.Name != "driver's hatch") continue;

                FieldInfo armordrivershatchDU_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armordrivershatchDU_HU.SetValue(drivershatchCompositearray_HU, armor_codex_drivershatchCompositearmor_HU);

                MelonLogger.Msg(drivershatchCompositearray_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor turretringCompositearray_HU = armour.GetComponent<VariableArmor>();
                if (turretringCompositearray_HU == null) continue;
                if (turretringCompositearray_HU.Unit == null) continue;
                if (turretringCompositearray_HU.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (turretringCompositearray_HU.Name != "turret ring") continue;

                FieldInfo armorturretringComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorturretringComposite_HU.SetValue(turretringCompositearray_HU, armor_codex_turretringCompositearmor_HU);

                MelonLogger.Msg(turretringCompositearray_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor gunmantletfaceCompositearray_HU = armour.GetComponent<VariableArmor>();
                if (gunmantletfaceCompositearray_HU == null) continue;
                if (gunmantletfaceCompositearray_HU.Unit == null) continue;
                if (gunmantletfaceCompositearray_HU.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (gunmantletfaceCompositearray_HU.Name != "gun mantlet face") continue;

                FieldInfo armorturretringComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorturretringComposite_HU.SetValue(gunmantletfaceCompositearray_HU, armor_codex_gunmantletfaceCompositearmor_HU);

                MelonLogger.Msg(gunmantletfaceCompositearray_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor trackSpecialarmor_HU = armour.GetComponent<VariableArmor>();
                if (trackSpecialarmor_HU == null) continue;
                if (trackSpecialarmor_HU.Unit == null) continue;
                if (trackSpecialarmor_HU.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (trackSpecialarmor_HU.Name != "left track") continue;

                FieldInfo armortrackSpecial_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armortrackSpecial_HU.SetValue(trackSpecialarmor_HU, armor_codex_trackSpecialarmor_HU);

                MelonLogger.Msg(trackSpecialarmor_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor trackSpecialarmor_HU = armour.GetComponent<VariableArmor>();
                if (trackSpecialarmor_HU == null) continue;
                if (trackSpecialarmor_HU.Unit == null) continue;
                if (trackSpecialarmor_HU.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (trackSpecialarmor_HU.Name != "right track") continue;

                FieldInfo armortrackSpecial_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armortrackSpecial_HU.SetValue(trackSpecialarmor_HU, armor_codex_trackSpecialarmor_HU);

                MelonLogger.Msg(trackSpecialarmor_HU.ArmorType);
            }
            ////End////

            ////Assign modified armor to M1A1HC////
            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor compositeskirtPlate_HC = armour.GetComponent<VariableArmor>();

                if (compositeskirtPlate_HC == null) continue;
                if (compositeskirtPlate_HC.Unit == null) continue;
                if (compositeskirtPlate_HC.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HC") continue;
                if (compositeskirtPlate_HC.Name != "composite side skirt") continue;

                FieldInfo armorskirtComposite_HC = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorskirtComposite_HC.SetValue(compositeskirtPlate_HC, armor_codex_superCompositeskirt_HC);

                MelonLogger.Msg(compositeskirtPlate_HC.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor cheeksDUarray_HC = armour.GetComponent<VariableArmor>();
                if (cheeksDUarray_HC == null) continue;
                if (cheeksDUarray_HC.Unit == null) continue;
                if (cheeksDUarray_HC.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HC") continue;
                if (cheeksDUarray_HC.Name != "turret cheek special armor array") continue;

                FieldInfo armorcheeksDU_HC = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorcheeksDU_HC.SetValue(cheeksDUarray_HC, armor_codex_cheeksDUarmor_HC);

                MelonLogger.Msg(cheeksDUarray_HC.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor hullfrontDUarray_HC = armour.GetComponent<VariableArmor>();
                if (hullfrontDUarray_HC == null) continue;
                if (hullfrontDUarray_HC.Unit == null) continue;
                if (hullfrontDUarray_HC.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HC") continue;
                if (hullfrontDUarray_HC.Name != "hull front special armor array") continue;

                FieldInfo armorhullfrontDU_HC = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorhullfrontDU_HC.SetValue(hullfrontDUarray_HC, armor_codex_fronthullDUarmor_HC);

                MelonLogger.Msg(hullfrontDUarray_HC.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor mantletDUarray_HC = armour.GetComponent<VariableArmor>();
                if (mantletDUarray_HC == null) continue;
                if (mantletDUarray_HC.Unit == null) continue;
                if (mantletDUarray_HC.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HC") continue;
                if (mantletDUarray_HC.Name != "gun mantlet special armor array") continue;

                FieldInfo armormantletDU_HC = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armormantletDU_HC.SetValue(mantletDUarray_HC, armor_codex_mantletDUarmor_HC);

                MelonLogger.Msg(mantletDUarray_HC.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor turretsidesDUarray_HC = armour.GetComponent<VariableArmor>();
                if (turretsidesDUarray_HC == null) continue;
                if (turretsidesDUarray_HC.Unit == null) continue;
                if (turretsidesDUarray_HC.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HC") continue;
                if (turretsidesDUarray_HC.Name != "turret side special armor array") continue;

                FieldInfo armorturretsidesDU_HC = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorturretsidesDU_HC.SetValue(turretsidesDUarray_HC, armor_codex_turretsidesDUarmor_HC);

                MelonLogger.Msg(turretsidesDUarray_HC.ArmorType);
            }
            ////End////

            ////Assign modified armor to M1E1HC////
            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor compositeskirtPlate_HC = armour.GetComponent<VariableArmor>();

                if (compositeskirtPlate_HC == null) continue;
                if (compositeskirtPlate_HC.Unit == null) continue;
                if (compositeskirtPlate_HC.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HC")) continue;
                if (compositeskirtPlate_HC.Name != "composite side skirt") continue;

                FieldInfo armorskirtComposite_HC = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorskirtComposite_HC.SetValue(compositeskirtPlate_HC, armor_codex_superCompositeskirt_HC);

                MelonLogger.Msg(compositeskirtPlate_HC.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor cheeksDUarray_HC = armour.GetComponent<VariableArmor>();
                if (cheeksDUarray_HC == null) continue;
                if (cheeksDUarray_HC.Unit == null) continue;
                if (cheeksDUarray_HC.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HC")) continue;
                if (cheeksDUarray_HC.Name != "turret cheek special armor array") continue;

                FieldInfo armorcheeksDU_HC = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorcheeksDU_HC.SetValue(cheeksDUarray_HC, armor_codex_cheeksDUarmor_HC);

                MelonLogger.Msg(cheeksDUarray_HC.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor hullfrontDUarray_HC = armour.GetComponent<VariableArmor>();
                if (hullfrontDUarray_HC == null) continue;
                if (hullfrontDUarray_HC.Unit == null) continue;
                if (hullfrontDUarray_HC.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HC")) continue;
                if (hullfrontDUarray_HC.Name != "hull front special armor array") continue;

                FieldInfo armorhullfrontDU_HC = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorhullfrontDU_HC.SetValue(hullfrontDUarray_HC, armor_codex_fronthullDUarmor_HC);

                MelonLogger.Msg(hullfrontDUarray_HC.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor mantletDUarray_HC = armour.GetComponent<VariableArmor>();
                if (mantletDUarray_HC == null) continue;
                if (mantletDUarray_HC.Unit == null) continue;
                if (mantletDUarray_HC.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HC")) continue;
                if (mantletDUarray_HC.Name != "gun mantlet special armor array") continue;

                FieldInfo armormantletDU_HC = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armormantletDU_HC.SetValue(mantletDUarray_HC, armor_codex_mantletDUarmor_HC);

                MelonLogger.Msg(mantletDUarray_HC.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor turretsidesDUarray_HC = armour.GetComponent<VariableArmor>();
                if (turretsidesDUarray_HC == null) continue;
                if (turretsidesDUarray_HC.Unit == null) continue;
                if (turretsidesDUarray_HC.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HC")) continue;
                if (turretsidesDUarray_HC.Name != "turret side special armor array") continue;

                FieldInfo armorturretsidesDU_HC = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorturretsidesDU_HC.SetValue(turretsidesDUarray_HC, armor_codex_turretsidesDUarmor_HC);

                MelonLogger.Msg(turretsidesDUarray_HC.ArmorType);
            }
            ////End////

            ////Assign modified armor to M1A1HA////
            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor compositeskirtPlate_HA = armour.GetComponent<VariableArmor>();

                if (compositeskirtPlate_HA == null) continue;
                if (compositeskirtPlate_HA.Unit == null) continue;
                if (compositeskirtPlate_HA.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HA") continue;
                if (compositeskirtPlate_HA.Name != "composite side skirt") continue;

                FieldInfo armorskirtComposite_HA = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorskirtComposite_HA.SetValue(compositeskirtPlate_HA, armor_codex_superCompositeskirt_HA);

                MelonLogger.Msg(compositeskirtPlate_HA.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor cheeksDUarray_HA = armour.GetComponent<VariableArmor>();
                if (cheeksDUarray_HA == null) continue;
                if (cheeksDUarray_HA.Unit == null) continue;
                if (cheeksDUarray_HA.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HA") continue;
                if (cheeksDUarray_HA.Name != "turret cheek special armor array") continue;

                FieldInfo armorcheeksDU_HA = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorcheeksDU_HA.SetValue(cheeksDUarray_HA, armor_codex_cheeksDUarmor_HA);

                MelonLogger.Msg(cheeksDUarray_HA.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor hullfrontDUarray_HA = armour.GetComponent<VariableArmor>();
                if (hullfrontDUarray_HA == null) continue;
                if (hullfrontDUarray_HA.Unit == null) continue;
                if (hullfrontDUarray_HA.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HA") continue;
                if (hullfrontDUarray_HA.Name != "hull front special armor array") continue;

                FieldInfo armorhullfrontDU_HA = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorhullfrontDU_HA.SetValue(hullfrontDUarray_HA, armor_codex_fronthullDUarmor_HA);

                MelonLogger.Msg(hullfrontDUarray_HA.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor mantletDUarray_HA = armour.GetComponent<VariableArmor>();
                if (mantletDUarray_HA == null) continue;
                if (mantletDUarray_HA.Unit == null) continue;
                if (mantletDUarray_HA.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HA") continue;
                if (mantletDUarray_HA.Name != "gun mantlet special armor array") continue;

                FieldInfo armormantletDU_HA = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armormantletDU_HA.SetValue(mantletDUarray_HA, armor_codex_mantletDUarmor_HA);

                MelonLogger.Msg(mantletDUarray_HA.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor turretsidesDUarray_HA = armour.GetComponent<VariableArmor>();
                if (turretsidesDUarray_HA == null) continue;
                if (turretsidesDUarray_HA.Unit == null) continue;
                if (turretsidesDUarray_HA.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HA") continue;
                if (turretsidesDUarray_HA.Name != "turret side special armor array") continue;

                FieldInfo armorturretsidesDU_HA = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorturretsidesDU_HA.SetValue(turretsidesDUarray_HA, armor_codex_turretsidesDUarmor_HA);

                MelonLogger.Msg(turretsidesDUarray_HA.ArmorType);
            }
            ////End////

            ////Assign modified armor to M1E1HA////
            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor compositeskirtPlate_HA = armour.GetComponent<VariableArmor>();

                if (compositeskirtPlate_HA == null) continue;
                if (compositeskirtPlate_HA.Unit == null) continue;
                if (compositeskirtPlate_HA.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HA")) continue;
                if (compositeskirtPlate_HA.Name != "composite side skirt") continue;

                FieldInfo armorskirtComposite_HA = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorskirtComposite_HA.SetValue(compositeskirtPlate_HA, armor_codex_superCompositeskirt_HA);

                MelonLogger.Msg(compositeskirtPlate_HA.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor cheeksDUarray_HA = armour.GetComponent<VariableArmor>();
                if (cheeksDUarray_HA == null) continue;
                if (cheeksDUarray_HA.Unit == null) continue;
                if (cheeksDUarray_HA.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HA")) continue;
                if (cheeksDUarray_HA.Name != "turret cheek special armor array") continue;

                FieldInfo armorcheeksDU_HA = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorcheeksDU_HA.SetValue(cheeksDUarray_HA, armor_codex_cheeksDUarmor_HA);

                MelonLogger.Msg(cheeksDUarray_HA.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor hullfrontDUarray_HA = armour.GetComponent<VariableArmor>();
                if (hullfrontDUarray_HA == null) continue;
                if (hullfrontDUarray_HA.Unit == null) continue;
                if (hullfrontDUarray_HA.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HA")) continue;
                if (hullfrontDUarray_HA.Name != "hull front special armor array") continue;

                FieldInfo armorhullfrontDU_HA = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorhullfrontDU_HA.SetValue(hullfrontDUarray_HA, armor_codex_fronthullDUarmor_HA);

                MelonLogger.Msg(hullfrontDUarray_HA.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor mantletDUarray_HA = armour.GetComponent<VariableArmor>();
                if (mantletDUarray_HA == null) continue;
                if (mantletDUarray_HA.Unit == null) continue;
                if (mantletDUarray_HA.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HA")) continue;
                if (mantletDUarray_HA.Name != "gun mantlet special armor array") continue;

                FieldInfo armormantletDU_HA = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armormantletDU_HA.SetValue(mantletDUarray_HA, armor_codex_mantletDUarmor_HA);

                MelonLogger.Msg(mantletDUarray_HA.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor turretsidesDUarray_HA = armour.GetComponent<VariableArmor>();
                if (turretsidesDUarray_HA == null) continue;
                if (turretsidesDUarray_HA.Unit == null) continue;
                if (turretsidesDUarray_HA.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HA")) continue;
                if (turretsidesDUarray_HA.Name != "turret side special armor array") continue;

                FieldInfo armorturretsidesDU_HA = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                armorturretsidesDU_HA.SetValue(turretsidesDUarray_HA, armor_codex_turretsidesDUarmor_HA);

                MelonLogger.Msg(turretsidesDUarray_HA.ArmorType);
            }
            ////End////

            var abrams_ammotype = new Dictionary<string, AmmoClipCodexScriptable>()
            {
                ["M829"] = clip_codex_m829,
                ["M829A1"] = clip_codex_m829a1,
                ["M829A2"] = clip_codex_m829a2,
                ["M829A3"] = clip_codex_m829a3,
                ["M829A4"] = clip_codex_m829a4,
                ["M830"] = clip_codex_m830,
                ["M830A2"] = clip_codex_m830a2,
                ["XM1147"] = clip_codex_XM1147,
            };

>>>>>>> Stashed changes:M1A1AbramsAMPMod.cs
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
                    GameObject ammo_m829a1_vis = null;
                    GameObject ammo_m829a2_vis = null;
                    GameObject ammo_m829a3_vis = null;
                    GameObject ammo_m829a4_vis = null;
                    GameObject ammo_m830_vis = null;
                    GameObject ammo_m830a2_vis = null;
                    GameObject ammo_xm1147_vis = null;

                    // generate visual models 
                    if (ammo_m829_vis == null)
                    {
                        ammo_m829_vis = GameObject.Instantiate(ammo_m833.VisualModel);
                        ammo_m829_vis.name = "M829 visual";
                        ammo_m829.VisualModel = ammo_m829_vis;
                        ammo_m829.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_m829;
                        ammo_m829.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_m829;

                        ammo_m829a1_vis = GameObject.Instantiate(ammo_m833.VisualModel);
                        ammo_m829a1_vis.name = "M829A1 visual";
                        ammo_m829a1.VisualModel = ammo_m829a1_vis;
                        ammo_m829a1.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_m829a1;
                        ammo_m829a1.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_m829a1;

                        ammo_m829a2_vis = GameObject.Instantiate(ammo_m833.VisualModel);
                        ammo_m829a2_vis.name = "M829A2 visual";
                        ammo_m829a2.VisualModel = ammo_m829a2_vis;
                        ammo_m829a2.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_m829a2;
                        ammo_m829a2.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_m829a2;

                        ammo_m829a3_vis = GameObject.Instantiate(ammo_m833.VisualModel);
                        ammo_m829a3_vis.name = "M829A3 visual";
                        ammo_m829a3.VisualModel = ammo_m829a3_vis;
                        ammo_m829a3.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_m829a3;
                        ammo_m829a3.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_m829a3;

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

                        ammo_m830a2_vis = GameObject.Instantiate(ammo_m456.VisualModel);
                        ammo_m830a2_vis.name = "M830A2 visual";
                        ammo_m830a2.VisualModel = ammo_m830a2_vis;
                        ammo_m830a2.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_m830a2;
                        ammo_m830a2.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_m830a2;

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
                        AmmoType.AmmoClip[] ammo_clip_types = new AmmoType.AmmoClip[] { };

                        loadoutManager.TotalAmmoCounts = new int[] { primaryammoCount.Value, secondaryammoCount.Value, tertiaryammoCount.Value };

<<<<<<< Updated upstream:M1A1AbramsMod.cs
                        AmmoClipCodexScriptable sabotClipCodex = (useSuperSabot.Value) ? clip_codex_m829a4 : clip_codex_m829;
                        AmmoClipCodexScriptable heatClipCodex = (useAMPShell.Value) ? clip_codex_XM1147 : clip_codex_m830;
=======
                        
                        AmmoClipCodexScriptable primaryClipCodex = abrams_ammotype[m1primaryAmmo.Value];
                        AmmoClipCodexScriptable secondaryClipCodex = abrams_ammotype[m1secondaryAmmo.Value];
                        AmmoClipCodexScriptable TertiaryClipCodex = abrams_ammotype[m1tertiaryAmmo.Value];
>>>>>>> Stashed changes:M1A1AbramsAMPMod.cs

                        loadoutManager.LoadedAmmoTypes = new AmmoClipCodexScriptable[] { primaryClipCodex, secondaryClipCodex, TertiaryClipCodex };

                        FieldInfo totalAmmoTypes = typeof(LoadoutManager).GetField("_totalAmmoTypes", BindingFlags.NonPublic | BindingFlags.Instance);
                        totalAmmoTypes.SetValue(loadoutManager, 3);

                        FieldInfo totalAmmoCount = typeof(LoadoutManager).GetField("_totalAmmoCount", BindingFlags.NonPublic | BindingFlags.Instance);
                        totalAmmoCount.SetValue(loadoutManager, 44);

                        for (int i = 0; i <= 2; i++)
                        {
                            GHPC.Weapons.AmmoRack rack = loadoutManager.RackLoadouts[i].Rack;
                            rack.ClipCapacity = i == 2 ? 4 : 18;
                            rack.ClipTypes = ammo_clip_types;
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