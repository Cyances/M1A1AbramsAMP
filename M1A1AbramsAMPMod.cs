using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GHPC.Camera;
using GHPC.Player;
using MelonLoader;
using UnityEngine;
using GHPC.State;
using System.Collections;
using GHPC.Weapons;
using GHPC.Equipment.Optics;
using GHPC.Vehicle;
using System.Reflection;
using Reticle;
using GHPC.Equipment;
using GHPC.Utility;
using GHPC;
using HarmonyLib;
using static NWH.WheelController3D.WheelController;

namespace M1A1AMP
{
    public static class M1A1AbramsAMPMod
    {
        ////MelonPreferences.cfg variables
        static MelonPreferences_Entry<int> m1a1firstammoCount;
        static MelonPreferences_Entry<int> m1a1secondammoCount;
        static MelonPreferences_Entry<int> m1a1thirdammoCount;
        static MelonPreferences_Entry<int> m1a1fourthammoCount;
        static MelonPreferences_Entry<int> m1e1firstammoCount;
        static MelonPreferences_Entry<int> m1e1secondammoCount;
        static MelonPreferences_Entry<int> m1e1thirdammoCount;
        static MelonPreferences_Entry<int> m1e1fourthammoCount;
        static MelonPreferences_Entry<string> m1a1firstAmmo;
        static MelonPreferences_Entry<string> m1a1secondAmmo;
        static MelonPreferences_Entry<string> m1a1thirdAmmo;
        static MelonPreferences_Entry<string> m1a1fourthAmmo;
        static MelonPreferences_Entry<string> m1e1firstAmmo;
        static MelonPreferences_Entry<string> m1e1secondAmmo;
        static MelonPreferences_Entry<string> m1e1thirdAmmo;
        static MelonPreferences_Entry<string> m1e1fourthAmmo;
        static MelonPreferences_Entry<bool> rotateAzimuth;
        static MelonPreferences_Entry<bool> m1e1Convert;
        static MelonPreferences_Entry<int> randomChanceNum;
        static MelonPreferences_Entry<bool> randomChance;
        static MelonPreferences_Entry<int> ampFragments;
        static MelonPreferences_Entry<int> mpatFragments;
        static MelonPreferences_Entry<string> m1a1Armor;
        static MelonPreferences_Entry<string> m1e1Armor;
        static MelonPreferences_Entry<bool> demigodArmor;

        static WeaponSystemCodexScriptable gun_m256;

        ////Ammo variables
        static AmmoClipCodexScriptable clip_codex_m829;
        static AmmoType.AmmoClip clip_m829;
        static AmmoCodexScriptable ammo_codex_m829;
        static AmmoType ammo_m829;

        static AmmoClipCodexScriptable clip_codex_m829a1;
        static AmmoType.AmmoClip clip_m829a1;
        static AmmoCodexScriptable ammo_codex_m829a1;
        static AmmoType ammo_m829a1;

        static AmmoClipCodexScriptable clip_codex_m829a2;
        static AmmoType.AmmoClip clip_m829a2;
        static AmmoCodexScriptable ammo_codex_m829a2;
        static AmmoType ammo_m829a2;

        static AmmoClipCodexScriptable clip_codex_m829a3;
        static AmmoType.AmmoClip clip_m829a3;
        static AmmoCodexScriptable ammo_codex_m829a3;
        static AmmoType ammo_m829a3;

        static AmmoClipCodexScriptable clip_codex_m829a4;
        static AmmoType.AmmoClip clip_m829a4;
        static AmmoCodexScriptable ammo_codex_m829a4;
        static AmmoType ammo_m829a4;

        static AmmoClipCodexScriptable clip_codex_m830;
        static AmmoType.AmmoClip clip_m830;
        static AmmoCodexScriptable ammo_codex_m830;
        static AmmoType ammo_m830;

        static AmmoClipCodexScriptable clip_codex_m830a1;
        static AmmoType.AmmoClip clip_m830a1;
        static AmmoCodexScriptable ammo_codex_m830a1;
        static AmmoType ammo_m830a1;

        static AmmoClipCodexScriptable clip_codex_m830a2;
        static AmmoType.AmmoClip clip_m830a2;
        static AmmoCodexScriptable ammo_codex_m830a2;
        static AmmoType ammo_m830a2;

        static AmmoClipCodexScriptable clip_codex_m830a3;
        static AmmoType.AmmoClip clip_m830a3;
        static AmmoCodexScriptable ammo_codex_m830a3;
        static AmmoType ammo_m830a3;

        static AmmoClipCodexScriptable clip_codex_xm1147;
        static AmmoType.AmmoClip clip_xm1147;
        static AmmoCodexScriptable ammo_codex_xm1147;
        static AmmoType ammo_xm1147;

        static AmmoClipCodexScriptable clip_codex_lahat;
        static AmmoType.AmmoClip clip_lahat;
        static AmmoCodexScriptable ammo_codex_lahat;
        static AmmoType ammo_lahat;

        static GameObject ammo_m829_vis = null;
        static GameObject ammo_m829a1_vis = null;
        static GameObject ammo_m829a2_vis = null;
        static GameObject ammo_m829a3_vis = null;
        static GameObject ammo_m829a4_vis = null;
        static GameObject ammo_m830_vis = null;
        static GameObject ammo_m830a1_vis = null;
        static GameObject ammo_m830a2_vis = null;
        static GameObject ammo_m830a3_vis = null;
        static GameObject ammo_xm1147_vis = null;
        static GameObject ammo_lahat_vis = null;

        static AmmoType ammo_m833;
        static AmmoType ammo_m456;
        static AmmoType ammo_bgm71;

        ////Armor variables
        ////Variables for copying existing ArmorType
        static ArmorType armor_compositeskirt_VNL;
        static ArmorType armor_specialarmor_VNL;
        static ArmorType armor_tracks_VNL;
        static ArmorType armor_gunsteel_VNL;

        ////HU Variant
        static ArmorCodexScriptable armor_codex_superCompositeskirt_HU;
        static ArmorType armor_superCompositeskirt_HU;

        static ArmorCodexScriptable armor_codex_cheeksDUarmor_HU;
        static ArmorType armor_cheeksDUarmor_HU;

        static ArmorCodexScriptable armor_codex_fronthullDUarmor_HU;
        static ArmorType armor_fronthullDUarmor_HU;

        static ArmorCodexScriptable armor_codex_mantletDUarmor_HU;
        static ArmorType armor_mantletDUarmor_HU;

        static ArmorCodexScriptable armor_codex_turretsidesDUarmor_HU;
        static ArmorType armor_turretsidesDUarmor_HU;

        static ArmorCodexScriptable armor_codex_turretroofCompositearmor_HU;
        static ArmorType armor_turretroofCompositearmor_HU;

        static ArmorCodexScriptable armor_codex_upperglacisCompositearmor_HU;
        static ArmorType armor_upperglacisCompositearmor_HU;

        static ArmorCodexScriptable armor_codex_commmandershatchCompositearmor_HU;
        static ArmorType armor_commmandershatchCompositearmor_HU;

        static ArmorCodexScriptable armor_codex_loadershatchCompositearmor_HU;
        static ArmorType armor_loadershatchCompositearmor_HU;

        static ArmorCodexScriptable armor_codex_drivershatchCompositearmor_HU;
        static ArmorType armor_drivershatchCompositearmor_HU;

        static ArmorCodexScriptable armor_codex_turretringCompositearmor_HU;
        static ArmorType armor_turretringCompositearmor_HU;

        static ArmorCodexScriptable armor_codex_gunmantletfaceCompositearmor_HU;
        static ArmorType armor_gunmantletfaceCompositearmor_HU;

        static ArmorCodexScriptable armor_codex_trackSpecialarmor_HU;
        static ArmorType armor_trackSpecialarmor_HU;

        static ArmorCodexScriptable armor_codex_gunbarrelImprovedarmor_HU;
        static ArmorType armor_gunbarrelImprovedarmor_HU;

        static ArmorCodexScriptable armor_codex_blowoutpanelCompositearmor_HU;
        static ArmorType armor_blowoutpanelCompositearmor_HU;

        static ArmorCodexScriptable armor_codex_bustleImprovedfirewall_HU;
        static ArmorType armor_bustleImprovedfirewall_HU;

        static ArmorCodexScriptable armor_codex_turretrearSpecialarray_HU;
        static ArmorType armor_turretrearSpecialarray_HU;

        static ArmorCodexScriptable armor_codex_GPSImprovedhousing_HU;
        static ArmorType armor_GPSImprovedhousing_HU;

        static ArmorCodexScriptable armor_codex_GPSImproveddoor_HU;
        static ArmorType armor_GPSImproveddoor_HU;

        static ArmorCodexScriptable armor_codex_turretbottomCompositearmor_HU;
        static ArmorType armor_turretbottomCompositearmor_HU;

        static ArmorCodexScriptable armor_codex_semireadyrackdoorCompositearmor_HU;
        static ArmorType armor_semireadyrackdoorCompositearmor_HU;

        static ArmorCodexScriptable armor_codex_trunnionCompositearmor_HU;
        static ArmorType armor_trunnionCompositearmor_HU;

        static ArmorCodexScriptable armor_codex_readyrackdoorCompositearmor_HU;
        static ArmorType armor_readyrackdoorCompositearmor_HU;

        static ArmorCodexScriptable armor_codex_lowerfrontplateCompositearmor_HU;
        static ArmorType armor_lowerflontplateCompositearmor_HU;

        static ArmorCodexScriptable armor_codex_hullfrontbackingplateCompositearmor_HU;
        static ArmorType armor_hullfrontbackingplateCompositearmor_HU;

        static ArmorCodexScriptable armor_codex_turretcheekfaceCompositearmor_HU;
        static ArmorType armor_turretcheekfaceCompositearmor_HU;

        static ArmorCodexScriptable armor_codex_turretcheekbackingplateCompositearmor_HU;
        static ArmorType armor_turretcheekbackingplateCompositearmor_HU;

        static ArmorCodexScriptable armor_codex_turretsidebackingplateCompositearmor_HU;
        static ArmorType armor_turretsidebackingplateCompositearmor_HU;

        static ArmorCodexScriptable armor_codex_turretsidefaceCompositearmor_HU;
        static ArmorType armor_turretsidefaceCompositearmor_HU;

        ////HC Variant
        static ArmorCodexScriptable armor_codex_superCompositeskirt_HC;
        static ArmorType armor_superCompositeskirt_HC;

        static ArmorCodexScriptable armor_codex_cheeksDUarmor_HC;
        static ArmorType armor_cheeksDUarmor_HC;

        static ArmorCodexScriptable armor_codex_fronthullDUarmor_HC;
        static ArmorType armor_fronthullDUarmor_HC;

        static ArmorCodexScriptable armor_codex_mantletDUarmor_HC;
        static ArmorType armor_mantletDUarmor_HC;

        static ArmorCodexScriptable armor_codex_turretsidesDUarmor_HC;
        static ArmorType armor_turretsidesDUarmor_HC;

        static ArmorCodexScriptable armor_codex_superCompositeskirt_HA;
        static ArmorType armor_superCompositeskirt_HA;

        ////HA Variant
        static ArmorCodexScriptable armor_codex_cheeksDUarmor_HA;
        static ArmorType armor_cheeksDUarmor_HA;

        static ArmorCodexScriptable armor_codex_fronthullDUarmor_HA;
        static ArmorType armor_fronthullDUarmor_HA;

        static ArmorCodexScriptable armor_codex_mantletDUarmor_HA;
        static ArmorType armor_mantletDUarmor_HA;

        static ArmorCodexScriptable armor_codex_turretsidesDUarmor_HA;
        static ArmorType armor_turretsidesDUarmor_HA;

        ////GAS variables
        static ReticleSO reticleSO_m1a1firstRound;
        static ReticleMesh.CachedReticle reticle_cached_m1a1firstRound;

        static ReticleSO reticleSO_m1a1secondRound;
        static ReticleMesh.CachedReticle reticle_cached_m1a1secondRound;

        static ReticleSO reticleSO_m1e1firstRound;
        static ReticleMesh.CachedReticle reticle_cached_m1e1firstRound;

        static ReticleSO reticleSO_m1e1secondRound;
        static ReticleMesh.CachedReticle reticle_cached_m1e1secondRound;

        public static void Config(MelonPreferences_Category cfg)
        {
            m1a1firstAmmo = cfg.CreateEntry<string>("M1A1 1st Round Type", "M829A4");
            m1a1firstAmmo.Description = "Round types carried by M1A1: 'M829', 'M829A1', 'M829A2', 'M829A3', 'M829A4', 'M830', 'M830A1', 'M830A2', 'M830A3', 'XM1147', 'LAHAT' or 'XM1111'";
            m1a1secondAmmo = cfg.CreateEntry<string>("M1A1 2nd Round Type", "M830A2");
            m1a1thirdAmmo = cfg.CreateEntry<string>("M1A1 3rd Round Type", "XM1147");
            m1a1fourthAmmo = cfg.CreateEntry<string>("M1A1 4th Round Type", "LAHAT");

            m1a1firstammoCount = cfg.CreateEntry<int>("M1A1 1st Round Count", 20);
            m1a1firstammoCount.Description = "How many rounds per type each M1A1 should carry. Maximum of 50 rounds total. Bring in at least one primary round.";
            m1a1secondammoCount = cfg.CreateEntry<int>("M1A1 2nd Round Count", 12);
            m1a1thirdammoCount = cfg.CreateEntry<int>("M1A1 3rd Round Count", 12);
            m1a1fourthammoCount = cfg.CreateEntry<int>("M1A1 4th Round Count", 6);

            m1e1firstAmmo = cfg.CreateEntry<string>("M1E1 1st Round Type", "M829");
            m1e1firstAmmo.Description = "Round types carried by M1E1: 'M829', 'M829A1', 'M829A2', 'M829A3', 'M829A4', 'M830', 'M830A1', 'M830A2', 'M830A3', 'XM1147', 'LAHAT' or 'XM1111'";
            m1e1secondAmmo = cfg.CreateEntry<string>("M1E1 2nd Round Type", "M829");
            m1e1thirdAmmo = cfg.CreateEntry<string>("M1E1 3rd Round Type", "M830");
            m1e1fourthAmmo = cfg.CreateEntry<string>("M1E1 4th Round Type", "M830A1");

            m1e1firstammoCount = cfg.CreateEntry<int>("M1E1 1st Round Count", 10);
            m1e1firstammoCount.Description = "How many rounds per type each M1E1 should carry. Maximum of 50 rounds total. Bring in at least one primary round.";
            m1e1secondammoCount = cfg.CreateEntry<int>("M1E1 2nd Round Count", 10);
            m1e1thirdammoCount = cfg.CreateEntry<int>("M1E1 3rd Round Count", 15);
            m1e1fourthammoCount = cfg.CreateEntry<int>("M1E1 4th Round Count", 15);

            ampFragments = cfg.CreateEntry<int>("AMP Fragments", 600);
            ampFragments.Description = "How many fragments are generated when the AMP round explodes (in point-detonate/airburst mode). NOTE: Higher number, means higher performance hit. Be careful in using higher number.";

            mpatFragments = cfg.CreateEntry<int>("MPAT Fragments", 600);
            mpatFragments.Description = "How many fragments are generated when the MPAT round explodes (in point-detonate mode). NOTE: Higher number, means higher performance hit. Be careful in using higher number.";

            rotateAzimuth = cfg.CreateEntry<bool>("RotateAzimuth", false);
            rotateAzimuth.Description = "Horizontal stabilization of M1A1 sights when applying lead.";

            m1e1Convert = cfg.CreateEntry<bool>("M1E1", true);
            m1e1Convert.Description = "Convert M1s to M1E1s (i.e: they get the 120mm gun and enables armor upgrades).";

            randomChance = cfg.CreateEntry<bool>("Random", true);
            randomChance.Description = "M1IPs/M1s will have a random chance of being converted to M1A1s/M1E1s.";
            randomChanceNum = cfg.CreateEntry<int>("ConversionChance", 100);

            m1a1Armor = cfg.CreateEntry<string>("M1A1 Armor", "HU");
            m1a1Armor.Description = "Armor used by M1A1: 'HA', 'HC', 'HU' or blank for base M1IP armor";

            m1e1Armor = cfg.CreateEntry<string>("M1E1 Armor", "HU");
            m1e1Armor.Description = "Armor used by M1E1: 'HA', 'HC', 'HU' or blank for base M1 armor";

            demigodArmor = cfg.CreateEntry<bool>("Demigod Armor", false);
            demigodArmor.Description = "Almost deathproof Abrooms (HU variant only)";
        }
        public static IEnumerator Convert(GameState _)
        {
            ////Abrams round list
            var abrams_clipcodex = new Dictionary<string, AmmoClipCodexScriptable>()
            {
                ["M829"] = clip_codex_m829,
                ["M829A1"] = clip_codex_m829a1,
                ["M829A2"] = clip_codex_m829a2,
                ["M829A3"] = clip_codex_m829a3,
                ["M829A4"] = clip_codex_m829a4,
                ["M830"] = clip_codex_m830,
                ["M830A1"] = clip_codex_m830a1,
                ["M830A2"] = clip_codex_m830a2,
                ["M830A3"] = clip_codex_m830a3,
                ["XM1147"] = clip_codex_xm1147,
                ["LAHAT"] = clip_codex_lahat,
            };

            var abrams_ammocodex = new Dictionary<string, AmmoCodexScriptable>()
            {
                ["M829"] = ammo_codex_m829,
                ["M829A1"] = ammo_codex_m829a1,
                ["M829A2"] = ammo_codex_m829a2,
                ["M829A3"] = ammo_codex_m829a3,
                ["M829A4"] = ammo_codex_m829a4,
                ["M830"] = ammo_codex_m830,
                ["M830A1"] = ammo_codex_m830a1,
                ["M830A2"] = ammo_codex_m830a2,
                ["M830A3"] = ammo_codex_m830a3,
                ["XM1147"] = ammo_codex_xm1147,
                ["LAHAT"] = ammo_codex_lahat,
            };

            ////Assign modified armor to M1A1HU
            if (m1a1Armor.Value == "HU")
            {
                foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
                {
                    if (armour == null) continue;

                    VariableArmor m1a1VA_HU = armour.GetComponent<VariableArmor>();
                    if (m1a1VA_HU == null) continue;
                    if (m1a1VA_HU.Unit == null) continue;
                    if (m1a1VA_HU.Unit.FriendlyName == "M1IP")
                    {
                        if (m1a1VA_HU.Name == "composite side skirt")
                        {
                            FieldInfo armorskirtComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorskirtComposite_HU.SetValue(m1a1VA_HU, armor_codex_superCompositeskirt_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "turret cheek special armor array")
                        {
                            FieldInfo armorcheeksDU_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorcheeksDU_HU.SetValue(m1a1VA_HU, armor_codex_cheeksDUarmor_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "hull front special armor array")
                        {
                            FieldInfo armorhullfrontDU_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorhullfrontDU_HU.SetValue(m1a1VA_HU, armor_codex_fronthullDUarmor_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "gun mantlet special armor array")
                        {
                            FieldInfo armormantletDU_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armormantletDU_HU.SetValue(m1a1VA_HU, armor_codex_mantletDUarmor_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "turret side special armor array")
                        {
                            FieldInfo armorturretsidesDU_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorturretsidesDU_HU.SetValue(m1a1VA_HU, armor_codex_turretsidesDUarmor_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "turret roof")
                        {
                            FieldInfo armorturretroofComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorturretroofComposite_HU.SetValue(m1a1VA_HU, armor_codex_turretroofCompositearmor_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "upper glacis")
                        {
                            FieldInfo armorupperglacisComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorupperglacisComposite_HU.SetValue(m1a1VA_HU, armor_codex_upperglacisCompositearmor_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "commander's hatch")
                        {
                            FieldInfo armorcommandershatchComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorcommandershatchComposite_HU.SetValue(m1a1VA_HU, armor_codex_commmandershatchCompositearmor_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "loader's hatch")
                        {
                            FieldInfo armorloadershatchComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorloadershatchComposite_HU.SetValue(m1a1VA_HU, armor_codex_loadershatchCompositearmor_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "driver's hatch")
                        {
                            FieldInfo armordrivershatchDU_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armordrivershatchDU_HU.SetValue(m1a1VA_HU, armor_codex_drivershatchCompositearmor_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "turret ring")
                        {
                            FieldInfo armorturretringComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorturretringComposite_HU.SetValue(m1a1VA_HU, armor_codex_turretringCompositearmor_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "gun mantlet face")
                        {
                            FieldInfo gunmantletfaceDU_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            gunmantletfaceDU_HU.SetValue(m1a1VA_HU, armor_codex_gunmantletfaceCompositearmor_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "left track")
                        {
                            FieldInfo armortrackSpecialL_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armortrackSpecialL_HU.SetValue(m1a1VA_HU, armor_codex_trackSpecialarmor_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "right track")
                        {
                            FieldInfo armortrackSpecialR_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armortrackSpecialR_HU.SetValue(m1a1VA_HU, armor_codex_trackSpecialarmor_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "main gun barrel")
                        {
                            FieldInfo gunbarrelImproved_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            gunbarrelImproved_HU.SetValue(m1a1VA_HU, armor_codex_gunbarrelImprovedarmor_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "bustle racks firewall")
                        {
                            FieldInfo bustlefirewallImproved_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            bustlefirewallImproved_HU.SetValue(m1a1VA_HU, armor_codex_bustleImprovedfirewall_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "center blowout panel")
                        {
                            FieldInfo blowoutpanelCompositeC_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            blowoutpanelCompositeC_HU.SetValue(m1a1VA_HU, armor_codex_blowoutpanelCompositearmor_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "left blowout panel")
                        {
                            FieldInfo blowoutpanelCompositeL_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            blowoutpanelCompositeL_HU.SetValue(m1a1VA_HU, armor_codex_blowoutpanelCompositearmor_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }


                        if (m1a1VA_HU.Name == "right blowout panel")
                        {
                            FieldInfo blowoutpanelCompositeR_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            blowoutpanelCompositeR_HU.SetValue(m1a1VA_HU, armor_codex_blowoutpanelCompositearmor_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "turret rear face")
                        {
                            FieldInfo turretrearSpecial_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            turretrearSpecial_HU.SetValue(m1a1VA_HU, armor_codex_turretrearSpecialarray_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "GPS doghouse")
                        {
                            FieldInfo GPShousingImproved_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            GPShousingImproved_HU.SetValue(m1a1VA_HU, armor_codex_GPSImprovedhousing_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "GPS doghouse door")
                        {
                            FieldInfo GPShousingdoorImproved_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            GPShousingdoorImproved_HU.SetValue(m1a1VA_HU, armor_codex_GPSImproveddoor_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "turret bottom")
                        {
                            FieldInfo turretbottomComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            turretbottomComposite_HU.SetValue(m1a1VA_HU, armor_codex_turretbottomCompositearmor_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "trunnion")
                        {
                            FieldInfo trunnionComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            trunnionComposite_HU.SetValue(m1a1VA_HU, armor_codex_trunnionCompositearmor_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "semi-ready rack door")
                        {
                            FieldInfo semireadyComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            semireadyComposite_HU.SetValue(m1a1VA_HU, armor_codex_semireadyrackdoorCompositearmor_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "ready rack door")
                        {
                            FieldInfo readyComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            readyComposite_HU.SetValue(m1a1VA_HU, armor_codex_readyrackdoorCompositearmor_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "lower front plate")
                        {
                            FieldInfo lfpComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            lfpComposite_HU.SetValue(m1a1VA_HU, armor_codex_lowerfrontplateCompositearmor_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "hull front backing plate")
                        {
                            FieldInfo hullfrontbackingComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            hullfrontbackingComposite_HU.SetValue(m1a1VA_HU, armor_codex_hullfrontbackingplateCompositearmor_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "turret cheek face")
                        {
                            FieldInfo turretcheekfaceComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            turretcheekfaceComposite_HU.SetValue(m1a1VA_HU, armor_codex_turretcheekfaceCompositearmor_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "turret cheek backing plate")
                        {
                            FieldInfo turretcheekbackingComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            turretcheekbackingComposite_HU.SetValue(m1a1VA_HU, armor_codex_turretcheekbackingplateCompositearmor_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "turret side backing plate")
                        {
                            FieldInfo turretsidebackingComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            turretsidebackingComposite_HU.SetValue(m1a1VA_HU, armor_codex_turretsidebackingplateCompositearmor_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }

                        if (m1a1VA_HU.Name == "turret side face")
                        {
                            FieldInfo turretsidefaceComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            turretsidefaceComposite_HU.SetValue(m1a1VA_HU, armor_codex_turretsidefaceCompositearmor_HU);
                            MelonLogger.Msg("M1A1HU: " + m1a1VA_HU.ArmorType);
                        }
                    }
                }

                ////M1A1HU UniformArmor pieces
                foreach (GameObject uarmour in GameObject.FindGameObjectsWithTag("Penetrable"))
                {
                    if (uarmour == null) continue;

                    UniformArmor m1a1UA_HU = uarmour.GetComponent<UniformArmor>();
                    if (m1a1UA_HU == null) continue;
                    if (m1a1UA_HU.Unit == null) continue;
                    if (m1a1UA_HU.Unit.FriendlyName == "M1IP")
                    {
                        if (m1a1UA_HU.Name == "hull side")
                        {
                            m1a1UA_HU.PrimaryHeatRha = demigodArmor.Value ? 10000f : 300f;
                            m1a1UA_HU.PrimarySabotRha = demigodArmor.Value ? 10000f : 200f;
                        }

                        if (m1a1UA_HU.Name == "hull rear")
                        {
                            m1a1UA_HU.PrimaryHeatRha = demigodArmor.Value ? 10000f : 300f;
                            m1a1UA_HU.PrimarySabotRha = demigodArmor.Value ? 10000f : 200f;
                        }

                        if (m1a1UA_HU.Name == "hull floor")
                        {
                            m1a1UA_HU.PrimaryHeatRha = demigodArmor.Value ? 10000f : 300f;
                            m1a1UA_HU.PrimarySabotRha = demigodArmor.Value ? 10000f : 200f;
                        }

                        if (m1a1UA_HU.Name == "hull floor rear")
                        {
                            m1a1UA_HU.PrimaryHeatRha = demigodArmor.Value ? 10000f : 300f;
                            m1a1UA_HU.PrimarySabotRha = demigodArmor.Value ? 10000f : 200f;
                        }

                        if (m1a1UA_HU.Name == "hull roof")
                        {
                            m1a1UA_HU.PrimaryHeatRha = demigodArmor.Value ? 10000f : 300f;
                            m1a1UA_HU.PrimarySabotRha = demigodArmor.Value ? 10000f : 200f;
                        }

                        if (m1a1UA_HU.Name == "firewall")
                        {
                            m1a1UA_HU.PrimaryHeatRha = demigodArmor.Value ? 10000f : 80f;
                            m1a1UA_HU.PrimarySabotRha = demigodArmor.Value ? 10000f : 80f;
                        }

                        if (m1a1UA_HU.Name == "hull ammo rack door")
                        {
                            m1a1UA_HU.PrimaryHeatRha = demigodArmor.Value ? 10000f : 100f;
                            m1a1UA_HU.PrimarySabotRha = demigodArmor.Value ? 10000f : 100f;
                        }

                        if (m1a1UA_HU.Name == "engine deck")
                        {
                            m1a1UA_HU.PrimaryHeatRha = demigodArmor.Value ? 10000f : 350f;
                            m1a1UA_HU.PrimarySabotRha = demigodArmor.Value ? 10000f : 250f;
                        }

                        if (m1a1UA_HU.Name == "fender")
                        {
                            m1a1UA_HU.PrimaryHeatRha = demigodArmor.Value ? 10000f : 100f;
                            m1a1UA_HU.PrimarySabotRha = demigodArmor.Value ? 10000f : 50f;
                        }

                        if (m1a1UA_HU.Name == "side skirt")
                        {
                            m1a1UA_HU.PrimaryHeatRha = demigodArmor.Value ? 10000f : 550f;
                            m1a1UA_HU.PrimarySabotRha = demigodArmor.Value ? 10000f : 300f;
                        }

                        if (m1a1UA_HU.Name == "gunner's primary sight")
                        {
                            m1a1UA_HU.PrimaryHeatRha = demigodArmor.Value ? 10000f : 50f;
                            m1a1UA_HU.PrimarySabotRha = demigodArmor.Value ? 10000f : 50f;
                        }

                        if (m1a1UA_HU.Name == "sprocket wheel")
                        {
                            m1a1UA_HU.PrimaryHeatRha = demigodArmor.Value ? 10000f : 50f;
                            m1a1UA_HU.PrimarySabotRha = demigodArmor.Value ? 10000f : 50f;
                        }

                        if (m1a1UA_HU.Name == "road wheel")
                        {
                            m1a1UA_HU.PrimaryHeatRha = demigodArmor.Value ? 10000f : 50f;
                            m1a1UA_HU.PrimarySabotRha = demigodArmor.Value ? 10000f : 50f;
                        }

                        if (m1a1UA_HU.Name == "engine")
                        {
                            m1a1UA_HU.PrimaryHeatRha = demigodArmor.Value ? 10000f : 150f;
                            m1a1UA_HU.PrimarySabotRha = demigodArmor.Value ? 10000f : 150f;
                        }
                        //MelonLogger.Msg("M1A1HU UniformArmor: Modified");
                    }
                }
            }

            ////Assign modified armor to M1E1HU
            if (m1e1Armor.Value == "HU")
            {
                foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
                {
                    if (armour == null) continue;

                    VariableArmor m1e1VA_HU = armour.GetComponent<VariableArmor>();
                    if (m1e1VA_HU == null) continue;
                    if (m1e1VA_HU.Unit == null) continue;
                    if (m1e1VA_HU.Unit.FriendlyName == "M1" && m1e1Convert.Value == true)
                    {
                        if (m1e1VA_HU.Name == "composite side skirt")
                        {
                            FieldInfo armorskirtComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorskirtComposite_HU.SetValue(m1e1VA_HU, armor_codex_superCompositeskirt_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "turret cheek special armor array")
                        {
                            FieldInfo armorcheeksDU_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorcheeksDU_HU.SetValue(m1e1VA_HU, armor_codex_cheeksDUarmor_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "hull front special armor array")
                        {
                            FieldInfo armorhullfrontDU_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorhullfrontDU_HU.SetValue(m1e1VA_HU, armor_codex_fronthullDUarmor_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "gun mantlet special armor array")
                        {
                            FieldInfo armormantletDU_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armormantletDU_HU.SetValue(m1e1VA_HU, armor_codex_mantletDUarmor_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "turret side special armor array")
                        {
                            FieldInfo armorturretsidesDU_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorturretsidesDU_HU.SetValue(m1e1VA_HU, armor_codex_turretsidesDUarmor_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "turret roof")
                        {
                            FieldInfo armorturretroofComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorturretroofComposite_HU.SetValue(m1e1VA_HU, armor_codex_turretroofCompositearmor_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "upper glacis")
                        {
                            FieldInfo armorupperglacisComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorupperglacisComposite_HU.SetValue(m1e1VA_HU, armor_codex_upperglacisCompositearmor_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "commander's hatch")
                        {
                            FieldInfo armorcommandershatchComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorcommandershatchComposite_HU.SetValue(m1e1VA_HU, armor_codex_commmandershatchCompositearmor_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "loader's hatch")
                        {
                            FieldInfo armorloadershatchComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorloadershatchComposite_HU.SetValue(m1e1VA_HU, armor_codex_loadershatchCompositearmor_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "driver's hatch")
                        {
                            FieldInfo armordrivershatchDU_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armordrivershatchDU_HU.SetValue(m1e1VA_HU, armor_codex_drivershatchCompositearmor_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "turret ring")
                        {
                            FieldInfo armorturretringComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorturretringComposite_HU.SetValue(m1e1VA_HU, armor_codex_turretringCompositearmor_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "gun mantlet face")
                        {
                            FieldInfo gunmantletfaceDU_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            gunmantletfaceDU_HU.SetValue(m1e1VA_HU, armor_codex_gunmantletfaceCompositearmor_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "left track")
                        {
                            FieldInfo armortrackSpecialL_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armortrackSpecialL_HU.SetValue(m1e1VA_HU, armor_codex_trackSpecialarmor_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "right track")
                        {
                            FieldInfo armortrackSpecialR_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armortrackSpecialR_HU.SetValue(m1e1VA_HU, armor_codex_trackSpecialarmor_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "main gun barrel")
                        {
                            FieldInfo gunbarrelImproved_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            gunbarrelImproved_HU.SetValue(m1e1VA_HU, armor_codex_gunbarrelImprovedarmor_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "bustle racks firewall")
                        {
                            FieldInfo bustlefirewallImproved_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            bustlefirewallImproved_HU.SetValue(m1e1VA_HU, armor_codex_bustleImprovedfirewall_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "center blowout panel")
                        {
                            FieldInfo blowoutpanelCompositeC_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            blowoutpanelCompositeC_HU.SetValue(m1e1VA_HU, armor_codex_blowoutpanelCompositearmor_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "left blowout panel")
                        {
                            FieldInfo blowoutpanelCompositeL_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            blowoutpanelCompositeL_HU.SetValue(m1e1VA_HU, armor_codex_blowoutpanelCompositearmor_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }


                        if (m1e1VA_HU.Name == "right blowout panel")
                        {
                            FieldInfo blowoutpanelCompositeR_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            blowoutpanelCompositeR_HU.SetValue(m1e1VA_HU, armor_codex_blowoutpanelCompositearmor_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "turret rear face")
                        {
                            FieldInfo turretrearSpecial_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            turretrearSpecial_HU.SetValue(m1e1VA_HU, armor_codex_turretrearSpecialarray_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "GPS doghouse")
                        {
                            FieldInfo GPShousingImproved_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            GPShousingImproved_HU.SetValue(m1e1VA_HU, armor_codex_GPSImprovedhousing_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "GPS doghouse door")
                        {
                            FieldInfo GPShousingdoorImproved_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            GPShousingdoorImproved_HU.SetValue(m1e1VA_HU, armor_codex_GPSImproveddoor_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "turret bottom")
                        {
                            FieldInfo turretbottomComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            turretbottomComposite_HU.SetValue(m1e1VA_HU, armor_codex_turretbottomCompositearmor_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "trunnion")
                        {
                            FieldInfo trunnionComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            trunnionComposite_HU.SetValue(m1e1VA_HU, armor_codex_trunnionCompositearmor_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "semi-ready rack door")
                        {
                            FieldInfo semireadyComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            semireadyComposite_HU.SetValue(m1e1VA_HU, armor_codex_semireadyrackdoorCompositearmor_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "ready rack door")
                        {
                            FieldInfo readyComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            readyComposite_HU.SetValue(m1e1VA_HU, armor_codex_readyrackdoorCompositearmor_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "lower front plate")
                        {
                            FieldInfo lfpComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            lfpComposite_HU.SetValue(m1e1VA_HU, armor_codex_lowerfrontplateCompositearmor_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "hull front backing plate")
                        {
                            FieldInfo hullfrontbackingComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            hullfrontbackingComposite_HU.SetValue(m1e1VA_HU, armor_codex_hullfrontbackingplateCompositearmor_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "turret cheek face")
                        {
                            FieldInfo turretcheekfaceComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            turretcheekfaceComposite_HU.SetValue(m1e1VA_HU, armor_codex_turretcheekfaceCompositearmor_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "turret cheek backing plate")
                        {
                            FieldInfo turretcheekbackingComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            turretcheekbackingComposite_HU.SetValue(m1e1VA_HU, armor_codex_turretcheekbackingplateCompositearmor_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "turret side backing plate")
                        {
                            FieldInfo turretsidebackingComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            turretsidebackingComposite_HU.SetValue(m1e1VA_HU, armor_codex_turretsidebackingplateCompositearmor_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }

                        if (m1e1VA_HU.Name == "turret side face")
                        {
                            FieldInfo turretsidefaceComposite_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            turretsidefaceComposite_HU.SetValue(m1e1VA_HU, armor_codex_turretsidefaceCompositearmor_HU);
                            MelonLogger.Msg("M1E1HU: " + m1e1VA_HU.ArmorType);
                        }
                    }
                }

                ////M1E1HU UniformArmor pieces
                foreach (GameObject uarmour in GameObject.FindGameObjectsWithTag("Penetrable"))
                {
                    if (uarmour == null) continue;

                    UniformArmor m1e1UA_HU = uarmour.GetComponent<UniformArmor>();
                    if (m1e1UA_HU == null) continue;
                    if (m1e1UA_HU.Unit == null) continue;
                    if (m1e1UA_HU.Unit.FriendlyName == "M1" && m1e1Convert.Value == true)
                    {
                        if (m1e1UA_HU.Name == "hull side")
                        {
                            m1e1UA_HU.PrimaryHeatRha = demigodArmor.Value ? 10000f : 300f;
                            m1e1UA_HU.PrimarySabotRha = demigodArmor.Value ? 10000f : 200f;
                        }

                        if (m1e1UA_HU.Name == "hull rear")
                        {
                            m1e1UA_HU.PrimaryHeatRha = demigodArmor.Value ? 10000f : 300f;
                            m1e1UA_HU.PrimarySabotRha = demigodArmor.Value ? 10000f : 200f;
                        }

                        if (m1e1UA_HU.Name == "hull floor")
                        {
                            m1e1UA_HU.PrimaryHeatRha = demigodArmor.Value ? 10000f : 300f;
                            m1e1UA_HU.PrimarySabotRha = demigodArmor.Value ? 10000f : 200f;
                        }

                        if (m1e1UA_HU.Name == "hull floor rear")
                        {
                            m1e1UA_HU.PrimaryHeatRha = demigodArmor.Value ? 10000f : 300f;
                            m1e1UA_HU.PrimarySabotRha = demigodArmor.Value ? 10000f : 200f;
                        }

                        if (m1e1UA_HU.Name == "hull roof")
                        {
                            m1e1UA_HU.PrimaryHeatRha = demigodArmor.Value ? 10000f : 300f;
                            m1e1UA_HU.PrimarySabotRha = demigodArmor.Value ? 10000f : 200f;
                        }


                        if (m1e1UA_HU.Name == "firewall")
                        {
                            m1e1UA_HU.PrimaryHeatRha = demigodArmor.Value ? 10000f : 80f;
                            m1e1UA_HU.PrimarySabotRha = demigodArmor.Value ? 10000f : 80f;
                        }

                        if (m1e1UA_HU.Name == "hull ammo rack door")
                        {
                            m1e1UA_HU.PrimaryHeatRha = demigodArmor.Value ? 10000f : 100f;
                            m1e1UA_HU.PrimarySabotRha = demigodArmor.Value ? 10000f : 100f;
                        }

                        if (m1e1UA_HU.Name == "engine deck")
                        {
                            m1e1UA_HU.PrimaryHeatRha = demigodArmor.Value ? 10000f : 350f;
                            m1e1UA_HU.PrimarySabotRha = demigodArmor.Value ? 10000f : 250f;
                        }

                        if (m1e1UA_HU.Name == "fender")
                        {
                            m1e1UA_HU.PrimaryHeatRha = demigodArmor.Value ? 10000f : 100f;
                            m1e1UA_HU.PrimarySabotRha = demigodArmor.Value ? 10000f : 50f;
                        }

                        if (m1e1UA_HU.Name == "side skirt")
                        {
                            m1e1UA_HU.PrimaryHeatRha = demigodArmor.Value ? 10000f : 550f;
                            m1e1UA_HU.PrimarySabotRha = demigodArmor.Value ? 10000f : 300f;
                        }

                        if (m1e1UA_HU.Name == "gunner's primary sight")
                        {
                            m1e1UA_HU.PrimaryHeatRha = demigodArmor.Value ? 10000f : 50f;
                            m1e1UA_HU.PrimarySabotRha = demigodArmor.Value ? 10000f : 50f;
                        }

                        if (m1e1UA_HU.Name == "sprocket wheel")
                        {
                            m1e1UA_HU.PrimaryHeatRha = demigodArmor.Value ? 10000f : 50f;
                            m1e1UA_HU.PrimarySabotRha = demigodArmor.Value ? 10000f : 50f;
                        }

                        if (m1e1UA_HU.Name == "road wheel")
                        {
                            m1e1UA_HU.PrimaryHeatRha = demigodArmor.Value ? 10000f : 50f;
                            m1e1UA_HU.PrimarySabotRha = demigodArmor.Value ? 10000f : 50f;
                        }

                        if (m1e1UA_HU.Name == "engine")
                        {
                            m1e1UA_HU.PrimaryHeatRha = demigodArmor.Value ? 10000f : 150f;
                            m1e1UA_HU.PrimarySabotRha = demigodArmor.Value ? 10000f : 150f;
                        }
                        //MelonLogger.Msg("M1E1HU UniformArmor: Modified");
                    }
                }
            }

            ////Assign modified armor to M1A1HC
            if (m1a1Armor.Value == "HC")
            {
                foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
                {
                    if (armour == null) continue;

                    VariableArmor m1a1VA_HC = armour.GetComponent<VariableArmor>();
                    if (m1a1VA_HC == null) continue;
                    if (m1a1VA_HC.Unit == null) continue;
                    if (m1a1VA_HC.Unit.FriendlyName == "M1IP")
                    {
                        if (m1a1VA_HC.Name == "composite side skirt")
                        {
                            FieldInfo armorskirtComposite_HC = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorskirtComposite_HC.SetValue(m1a1VA_HC, armor_codex_superCompositeskirt_HC);
                            MelonLogger.Msg(m1a1VA_HC.ArmorType);
                        }

                        if (m1a1VA_HC.Name == "turret cheek special armor array")
                        {
                            FieldInfo armorcheeksDU_HC = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorcheeksDU_HC.SetValue(m1a1VA_HC, armor_codex_cheeksDUarmor_HC);

                            MelonLogger.Msg(m1a1VA_HC.ArmorType);
                        }


                        if (m1a1VA_HC.Name == "hull front special armor array")
                        {
                            FieldInfo armorhullfrontDU_HC = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorhullfrontDU_HC.SetValue(m1a1VA_HC, armor_codex_fronthullDUarmor_HC);
                            MelonLogger.Msg(m1a1VA_HC.ArmorType);
                        }

                        if (m1a1VA_HC.Name == "gun mantlet special armor array")
                        {
                            FieldInfo armormantletDU_HC = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armormantletDU_HC.SetValue(m1a1VA_HC, armor_codex_mantletDUarmor_HC);
                            MelonLogger.Msg(m1a1VA_HC.ArmorType);
                        }

                        if (m1a1VA_HC.Name == "turret side special armor array")
                        {
                            FieldInfo armorturretsidesDU_HC = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorturretsidesDU_HC.SetValue(m1a1VA_HC, armor_codex_turretsidesDUarmor_HC);
                            MelonLogger.Msg(m1a1VA_HC.ArmorType);
                        }
                    }
                }
            }

            ////Assign modified armor to M1E1HC
            if (m1e1Armor.Value == "HC")
            {
                foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
                {
                    if (armour == null) continue;

                    VariableArmor m1e1VA_HC = armour.GetComponent<VariableArmor>();
                    if (m1e1VA_HC == null) continue;
                    if (m1e1VA_HC.Unit == null) continue;
                    if (m1e1VA_HC.Unit.FriendlyName == "M1" && m1e1Convert.Value == true)
                    {
                        if (m1e1VA_HC.Name == "composite side skirt")
                        {
                            FieldInfo armorskirtComposite_HC = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorskirtComposite_HC.SetValue(m1e1VA_HC, armor_codex_superCompositeskirt_HC);
                            MelonLogger.Msg(m1e1VA_HC.ArmorType);
                        }

                        if (m1e1VA_HC.Name == "turret cheek special armor array")
                        {
                            FieldInfo armorcheeksDU_HC = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorcheeksDU_HC.SetValue(m1e1VA_HC, armor_codex_cheeksDUarmor_HC);
                            MelonLogger.Msg(m1e1VA_HC.ArmorType);
                        }

                        if (m1e1VA_HC.Name == "hull front special armor array")
                        {
                            FieldInfo armorhullfrontDU_HC = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorhullfrontDU_HC.SetValue(m1e1VA_HC, armor_codex_fronthullDUarmor_HC);
                            MelonLogger.Msg(m1e1VA_HC.ArmorType);
                        }

                        if (m1e1VA_HC.Name == "gun mantlet special armor array")
                        {
                            FieldInfo armormantletDU_HC = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armormantletDU_HC.SetValue(m1e1VA_HC, armor_codex_mantletDUarmor_HC);
                            MelonLogger.Msg(m1e1VA_HC.ArmorType);
                        }


                        if (m1e1VA_HC.Name == "turret side special armor array")
                        {
                            FieldInfo armorturretsidesDU_HC = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorturretsidesDU_HC.SetValue(m1e1VA_HC, armor_codex_turretsidesDUarmor_HC);
                            MelonLogger.Msg(m1e1VA_HC.ArmorType);
                        }
                    }
                }
            }

            ////Assign modified armor to M1A1HA
            if (m1a1Armor.Value == "HA")
            {
                foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
                {
                    if (armour == null) continue;

                    VariableArmor m1a1VA_HA = armour.GetComponent<VariableArmor>();
                    if (m1a1VA_HA == null) continue;
                    if (m1a1VA_HA.Unit == null) continue;
                    if (m1a1VA_HA.Unit.FriendlyName == "M1IP")
                    {
                        if (m1a1VA_HA.Name == "composite side skirt")
                        {
                            FieldInfo armorskirtComposite_HA = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorskirtComposite_HA.SetValue(m1a1VA_HA, armor_codex_superCompositeskirt_HA);
                            MelonLogger.Msg(m1a1VA_HA.ArmorType);
                        }

                        if (m1a1VA_HA.Name == "turret cheek special armor array")
                        {
                            FieldInfo armorcheeksDU_HA = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorcheeksDU_HA.SetValue(m1a1VA_HA, armor_codex_cheeksDUarmor_HA);
                            MelonLogger.Msg(m1a1VA_HA.ArmorType);
                        }

                        if (m1a1VA_HA.Name == "hull front special armor array")
                        {
                            FieldInfo armorhullfrontDU_HA = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorhullfrontDU_HA.SetValue(m1a1VA_HA, armor_codex_fronthullDUarmor_HA);
                            MelonLogger.Msg(m1a1VA_HA.ArmorType);
                        }

                        if (m1a1VA_HA.Name == "gun mantlet special armor array")
                        {
                            FieldInfo armormantletDU_HA = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armormantletDU_HA.SetValue(m1a1VA_HA, armor_codex_mantletDUarmor_HA);
                            MelonLogger.Msg(m1a1VA_HA.ArmorType);
                        }


                        if (m1a1VA_HA.Name == "turret side special armor array")
                        {
                            FieldInfo armorturretsidesDU_HA = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorturretsidesDU_HA.SetValue(m1a1VA_HA, armor_codex_turretsidesDUarmor_HA);
                            MelonLogger.Msg(m1a1VA_HA.ArmorType);
                        }
                    }
                }
            }

            ////Assign modified armor to M1E1HA
            if (m1e1Armor.Value == "HA")
            {
                foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
                {
                    if (armour == null) continue;

                    VariableArmor m1e1VA_HA = armour.GetComponent<VariableArmor>();
                    if (m1e1VA_HA == null) continue;
                    if (m1e1VA_HA.Unit == null) continue;
                    if (m1e1VA_HA.Unit.FriendlyName == "M1" && m1e1Convert.Value == true)
                    {
                        if (m1e1VA_HA.Name == "composite side skirt")
                        {
                            FieldInfo armorskirtComposite_HA = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorskirtComposite_HA.SetValue(m1e1VA_HA, armor_codex_superCompositeskirt_HA);
                            MelonLogger.Msg(m1e1VA_HA.ArmorType);
                        }

                        if (m1e1VA_HA.Name == "turret cheek special armor array")
                        {
                            FieldInfo armorcheeksDU_HA = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorcheeksDU_HA.SetValue(m1e1VA_HA, armor_codex_cheeksDUarmor_HA);
                            MelonLogger.Msg(m1e1VA_HA.ArmorType);
                        }

                        if (m1e1VA_HA.Name == "hull front special armor array")
                        {
                            FieldInfo armorhullfrontDU_HA = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorhullfrontDU_HA.SetValue(m1e1VA_HA, armor_codex_fronthullDUarmor_HA);
                            MelonLogger.Msg(m1e1VA_HA.ArmorType);
                        }

                        if (m1e1VA_HA.Name == "gun mantlet special armor array")
                        {
                            FieldInfo armormantletDU_HA = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armormantletDU_HA.SetValue(m1e1VA_HA, armor_codex_mantletDUarmor_HA);
                            MelonLogger.Msg(m1e1VA_HA.ArmorType);
                        }


                        if (m1e1VA_HA.Name == "turret side special armor array")
                        {
                            FieldInfo armorturretsidesDU_HA = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                            armorturretsidesDU_HA.SetValue(m1e1VA_HA, armor_codex_turretsidesDUarmor_HA);
                            MelonLogger.Msg(m1e1VA_HA.ArmorType);
                        }
                    }
                }
            }

            foreach (GameObject vic_go in AbramsAMPMod.vic_gos)
            {
                Vehicle vic = vic_go.GetComponent<Vehicle>();

                if (vic == null) continue;

                if (vic.FriendlyName == "M1IP" || (m1e1Convert.Value && vic.FriendlyName == "M1"))
                {
                    int rand = (randomChance.Value) ? UnityEngine.Random.Range(1, 100) : 0;

                    if (rand <= randomChanceNum.Value)
                    {
                        ////Rename Abrams
                        if (vic.FriendlyName == "M1IP")
                        {
                            vic._friendlyName = "M1A1" + m1a1Armor.Value;
                        }

                        if (vic.FriendlyName == "M1")
                        {
                            vic._friendlyName = "M1E1" + m1e1Armor.Value;
                        }

                        WeaponsManager weaponsManager = vic.GetComponent<WeaponsManager>();
                        WeaponSystemInfo mainGunInfo = weaponsManager.Weapons[0];
                        WeaponSystem mainGun = mainGunInfo.Weapon;

                        if (rotateAzimuth.Value)
                        {
                            UsableOptic optic = Util.GetDayOptic(mainGun.FCS);
                            optic.RotateAzimuth = true;
                            optic.slot.LinkedNightSight.PairedOptic.RotateAzimuth = true;
                        }

                        ////GAS stuff
                        if (vic.FriendlyName == "M1E1" + m1e1Armor.Value)
                        {
                            if (reticleSO_m1e1firstRound == null)
                            {
                                reticleSO_m1e1firstRound = ScriptableObject.Instantiate(ReticleMesh.cachedReticles["M1_105_GAS_APFSDS"].tree);
                                reticleSO_m1e1firstRound.name = "120mm_gas_m1e1firstRound";

                                Util.ShallowCopy(reticle_cached_m1e1firstRound, ReticleMesh.cachedReticles["M1_105_GAS_APFSDS"]);
                                reticle_cached_m1e1firstRound.tree = reticleSO_m1e1firstRound;

                                ReticleTree.VerticalBallistic reticle_range_m1e1firstRound = (reticleSO_m1e1firstRound.planes[0]
                                    as ReticleTree.FocalPlane).elements[1]
                                    as ReticleTree.VerticalBallistic;
                                reticle_range_m1e1firstRound.projectile = abrams_ammocodex[m1e1firstAmmo.Value];
                                reticle_range_m1e1firstRound.UpdateBC();

                                ReticleTree.Text reticle_text_m1e1firstRound = (((reticleSO_m1e1firstRound.planes[0]
                                    as ReticleTree.FocalPlane).elements[0])
                                    as ReticleTree.Angular).elements[0]
                                    as ReticleTree.Text;

                                string m1e1firstRound_name = abrams_ammocodex[m1e1firstAmmo.Value].AmmoType.Name;
                                reticle_text_m1e1firstRound.text = "120 MM\n " + m1e1firstRound_name + "\nMETERS";

                                reticleSO_m1e1secondRound = ScriptableObject.Instantiate(ReticleMesh.cachedReticles["M1_105_GAS_HEAT"].tree);
                                reticleSO_m1e1secondRound.name = "120mm_gas_m1e1secondRound";

                                Util.ShallowCopy(reticle_cached_m1e1secondRound, ReticleMesh.cachedReticles["M1_105_GAS_HEAT"]);
                                reticle_cached_m1e1secondRound.tree = reticleSO_m1e1secondRound;

                                ReticleTree.VerticalBallistic reticle_range_m1e1secondRound = (reticleSO_m1e1secondRound.planes[0]
                                    as ReticleTree.FocalPlane).elements[1]
                                    as ReticleTree.VerticalBallistic;
                                reticle_range_m1e1secondRound.projectile = abrams_ammocodex[m1e1secondAmmo.Value];
                                reticle_range_m1e1secondRound.UpdateBC();

                                ReticleTree.Text reticle_text_m1e1secondRound = (((reticleSO_m1e1secondRound.planes[0]
                                    as ReticleTree.FocalPlane).elements[0])
                                    as ReticleTree.Angular).elements[0]
                                    as ReticleTree.Text;

                                string m1e1secondRound_name = abrams_ammocodex[m1e1secondAmmo.Value].AmmoType.Name;
                                reticle_text_m1e1secondRound.text = "120 MM\n " + m1e1secondRound_name + "\nMETERS";
                            }

                            ////Setting the reticles
                            ReticleMesh gas_m1e1firstRound = vic.transform.Find("IPM1_rig/HULL/TURRET/GUN/Gun Scripts/Aux sight (GAS)/Reticle Mesh").gameObject.GetComponent<ReticleMesh>();
                            gas_m1e1firstRound.reticleSO = reticleSO_m1e1firstRound;
                            gas_m1e1firstRound.reticle = reticle_cached_m1e1firstRound;
                            gas_m1e1firstRound.SMR = null;
                            gas_m1e1firstRound.Load();

                            ReticleMesh gas_m1e1secondRound = vic.transform.Find("IPM1_rig/HULL/TURRET/GUN/Gun Scripts/Aux sight (GAS)/Reticle Mesh HEAT").gameObject.GetComponent<ReticleMesh>();
                            gas_m1e1secondRound.reticleSO = reticleSO_m1e1secondRound;
                            gas_m1e1secondRound.reticle = reticle_cached_m1e1secondRound;
                            gas_m1e1secondRound.SMR = null;
                            gas_m1e1secondRound.Load();
                        }

                        if (vic.FriendlyName == "M1A1" + m1a1Armor.Value)
                        {
                            if (reticleSO_m1a1firstRound == null)
                            {
                                reticleSO_m1a1firstRound = ScriptableObject.Instantiate(ReticleMesh.cachedReticles["M1_105_GAS_APFSDS"].tree);
                                reticleSO_m1a1firstRound.name = "120mm_gas_m1a1firstRound";

                                Util.ShallowCopy(reticle_cached_m1a1firstRound, ReticleMesh.cachedReticles["M1_105_GAS_APFSDS"]);
                                reticle_cached_m1a1firstRound.tree = reticleSO_m1a1firstRound;

                                ReticleTree.VerticalBallistic reticle_range_m1a1firstRound = (reticleSO_m1a1firstRound.planes[0]
                                    as ReticleTree.FocalPlane).elements[1]
                                    as ReticleTree.VerticalBallistic;
                                reticle_range_m1a1firstRound.projectile = abrams_ammocodex[m1a1firstAmmo.Value];
                                reticle_range_m1a1firstRound.UpdateBC();

                                ReticleTree.Text reticle_text_m1a1firstRound = (((reticleSO_m1a1firstRound.planes[0]
                                    as ReticleTree.FocalPlane).elements[0])
                                    as ReticleTree.Angular).elements[0]
                                    as ReticleTree.Text;

                                string m1a1firstRound_name = abrams_ammocodex[m1a1firstAmmo.Value].AmmoType.Name;
                                reticle_text_m1a1firstRound.text = "120 MM\n " + m1a1firstRound_name + "\nMETERS";

                                reticleSO_m1a1secondRound = ScriptableObject.Instantiate(ReticleMesh.cachedReticles["M1_105_GAS_HEAT"].tree);
                                reticleSO_m1a1secondRound.name = "120mm_gas_m1a1secondRound";

                                Util.ShallowCopy(reticle_cached_m1a1secondRound, ReticleMesh.cachedReticles["M1_105_GAS_HEAT"]);
                                reticle_cached_m1a1secondRound.tree = reticleSO_m1a1secondRound;

                                ReticleTree.VerticalBallistic reticle_range_m1a1secondRound = (reticleSO_m1a1secondRound.planes[0]
                                    as ReticleTree.FocalPlane).elements[1]
                                    as ReticleTree.VerticalBallistic;
                                reticle_range_m1a1secondRound.projectile = abrams_ammocodex[m1a1secondAmmo.Value];
                                reticle_range_m1a1secondRound.UpdateBC();

                                ReticleTree.Text reticle_text_m1a1secondRound = (((reticleSO_m1a1secondRound.planes[0]
                                    as ReticleTree.FocalPlane).elements[0])
                                    as ReticleTree.Angular).elements[0]
                                    as ReticleTree.Text;

                                string m1a1secondRound_name = abrams_ammocodex[m1a1secondAmmo.Value].AmmoType.Name;
                                reticle_text_m1a1secondRound.text = "120 MM\n " + m1a1secondRound_name + "\nMETERS";
                            }

                            ////Setting the reticles
                            ReticleMesh gas_m1a1firstRound = vic.transform.Find("IPM1_rig/HULL/TURRET/GUN/Gun Scripts/Aux sight (GAS)/Reticle Mesh").gameObject.GetComponent<ReticleMesh>();
                            gas_m1a1firstRound.reticleSO = reticleSO_m1a1firstRound;
                            gas_m1a1firstRound.reticle = reticle_cached_m1a1firstRound;
                            gas_m1a1firstRound.SMR = null;
                            gas_m1a1firstRound.Load();

                            ReticleMesh gas_m1a1secondRound = vic.transform.Find("IPM1_rig/HULL/TURRET/GUN/Gun Scripts/Aux sight (GAS)/Reticle Mesh HEAT").gameObject.GetComponent<ReticleMesh>();
                            gas_m1a1secondRound.reticleSO = reticleSO_m1a1secondRound;
                            gas_m1a1secondRound.reticle = reticle_cached_m1a1secondRound;
                            gas_m1a1secondRound.SMR = null;
                            gas_m1a1secondRound.Load();
                        }

                        Transform muzzleFlashes = mainGun.MuzzleEffects[1].transform;
                        muzzleFlashes.GetChild(1).transform.localScale = new Vector3(2f, 2f, 2f);
                        muzzleFlashes.GetChild(2).transform.localScale = new Vector3(2f, 2f, 2f);
                        muzzleFlashes.GetChild(4).transform.localScale = new Vector3(2f, 2f, 2f);

                        mainGunInfo.Name = "120mm gun M256";
                        mainGun.Impulse = 68000;
                        mainGun.CodexEntry = gun_m256;
                        mainGun.Feed.ReloadDuringMissileTracking = true;
                        mainGun.FireWhileGuidingMissile = true;

                        GameObject gunTube = vic_go.transform.Find("IPM1_rig/HULL/TURRET/GUN/gun_recoil").gameObject;
                        gunTube.transform.localScale = new Vector3(1.4f, 1.4f, 0.98f);

                        //// Abrams loadout management
                        LoadoutManager loadoutManager = vic.GetComponent<LoadoutManager>();
                        AmmoType.AmmoClip[] ammo_clip_types = new AmmoType.AmmoClip[] { };

                        if (vic.FriendlyName == "M1A1" + m1a1Armor.Value || vic.FriendlyName == "M1E1" + m1e1Armor.Value)
                        {
                            AmmoClipCodexScriptable firstClipCodex = abrams_clipcodex[vic.FriendlyName == "M1A1" + m1a1Armor.Value ? m1a1firstAmmo.Value : m1e1firstAmmo.Value];
                            AmmoClipCodexScriptable secondClipCodex = abrams_clipcodex[vic.FriendlyName == "M1A1" + m1a1Armor.Value ? m1a1secondAmmo.Value : m1e1secondAmmo.Value];
                            AmmoClipCodexScriptable thirdClipCodex = abrams_clipcodex[vic.FriendlyName == "M1A1" + m1a1Armor.Value ? m1a1thirdAmmo.Value : m1e1thirdAmmo.Value];
                            AmmoClipCodexScriptable fourthClipCodex = abrams_clipcodex[vic.FriendlyName == "M1A1" + m1a1Armor.Value ? m1a1fourthAmmo.Value : m1e1fourthAmmo.Value];

                            loadoutManager.LoadedAmmoTypes = new AmmoClipCodexScriptable[] { firstClipCodex, secondClipCodex, thirdClipCodex, fourthClipCodex };

                            FieldInfo totalAmmoTypes = typeof(LoadoutManager).GetField("_totalAmmoTypes", BindingFlags.NonPublic | BindingFlags.Instance);
                            totalAmmoTypes.SetValue(loadoutManager, 4);
                        }

                        if (vic.FriendlyName == "M1A1" + m1a1Armor.Value)
                        {
                            loadoutManager.TotalAmmoCounts = new int[] { m1a1firstammoCount.Value, m1a1secondammoCount.Value, m1a1thirdammoCount.Value, m1a1fourthammoCount.Value };
                            FieldInfo totalAmmoCount = typeof(LoadoutManager).GetField("_totalAmmoCount", BindingFlags.NonPublic | BindingFlags.Instance);
                            totalAmmoCount.SetValue(loadoutManager, 50);
                        }

                        if (vic.FriendlyName == "M1E1" + m1e1Armor.Value)
                        {
                            loadoutManager.TotalAmmoCounts = new int[] { m1e1firstammoCount.Value, m1e1secondammoCount.Value, m1e1thirdammoCount.Value, m1e1fourthammoCount.Value };
                            FieldInfo totalAmmoCount = typeof(LoadoutManager).GetField("_totalAmmoCount", BindingFlags.NonPublic | BindingFlags.Instance);
                            totalAmmoCount.SetValue(loadoutManager, 50);
                        }

                        for (int i = 0; i <= 2; i++)
                        {
                            GHPC.Weapons.AmmoRack rack = loadoutManager.RackLoadouts[i].Rack;
                            rack.ClipCapacity = i == 2 ? 4 : 21;
                            rack.ClipTypes = ammo_clip_types;
                            Util.EmptyRack(rack);
                        }

                        loadoutManager.SpawnCurrentLoadout();
                        mainGun.Feed.AmmoTypeInBreech = null;
                        mainGun.Feed.Start();
                        loadoutManager.RegisterAllBallistics();

                        ////Guidance computer for LAHAT
                        GameObject guidance_computer_obj = new GameObject("Abrams Guidance Computer");
                        guidance_computer_obj.transform.parent = vic.transform;
                        guidance_computer_obj.AddComponent<MissileGuidanceUnit>();

                        guidance_computer_obj.AddComponent<Reparent>();
                        Reparent reparent = guidance_computer_obj.GetComponent<Reparent>();
                        reparent.NewParent = vic_go.transform.Find("IPM1_rig/HULL/TURRET/Turret Scripts/GPS/").gameObject.transform;
                        typeof(Reparent).GetMethod("Awake", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(reparent, new object[] { });

                        MissileGuidanceUnit computer = guidance_computer_obj.GetComponent<MissileGuidanceUnit>();
                        computer.AimElement = vic_go.transform.Find("IPM1_rig/HULL/TURRET/Turret Scripts/GPS/laser/").gameObject.transform;
                        mainGun.GuidanceUnit = computer;

                        ////ERA detection for designation amendment
                        foreach (GameObject armor_go in GameObject.FindGameObjectsWithTag("Penetrable"))
                        {
                            if (armor_go.name != "HULLARMOR") continue;
                            if (!armor_go.transform.parent.GetComponent<LateFollow>()) continue;

                            string name = armor_go.transform.parent.GetComponent<LateFollow>().ParentUnit.FriendlyName;

                            if (name == "M1A1" + m1a1Armor.Value || name == "M1E1" + m1e1Armor.Value)
                            {
                                if (armor_go.transform.Find("Hull ERA Array(Clone)"))
                                {
                                    vic._friendlyName += " TUSK";
                                }
                            }
                        }
                    }
                }
            }
            yield break;
        }

        public static void LateUpdate()
        {
            if (AbramsAMPMod.gameManager == null) return;

            CameraSlot cam = AbramsAMPMod.camManager._currentCamSlot;

            if (cam == null) return;
            if (cam.name != "Aux sight (GAS)") return;
            if (AbramsAMPMod.playerManager.CurrentPlayerWeapon.Name != "120mm gun M256") return;

            AmmoType currentAmmo = AbramsAMPMod.playerManager.CurrentPlayerWeapon.FCS.CurrentAmmoType;
            int reticleId = (currentAmmo.Name == "M829 APFSDS-T" || currentAmmo.Name == "M829A1 APFSDS-T" || currentAmmo.Name == "M829A2 APFSDS-T" || currentAmmo.Name == "M829A3 APFSDS-T" || currentAmmo.Name == "M829A4 APFSDS-T") ? 0 : 2;

            GameObject reticle = cam.transform.GetChild(reticleId).gameObject;

            if (!reticle.activeSelf)
            {
                reticle.SetActive(true);
            }

        }
        public static void Init()
        {
            if (gun_m256 == null)
            {
                ////Borrow existing ammo and armor attributes
                foreach (AmmoCodexScriptable s in Resources.FindObjectsOfTypeAll(typeof(AmmoCodexScriptable)))
                {
                    if (s.AmmoType.Name == "M833 APFSDS-T") ammo_m833 = s.AmmoType;
                    if (s.AmmoType.Name == "M456 HEAT-FS-T") ammo_m456 = s.AmmoType;
                    if (s.AmmoType.Name == "BGM-71C I-TOW") ammo_bgm71 = s.AmmoType;
                }

                foreach (ArmorCodexScriptable s in Resources.FindObjectsOfTypeAll(typeof(ArmorCodexScriptable)))
                {
                    if (s.ArmorType.Name == "composite skirt") armor_compositeskirt_VNL = s.ArmorType;
                    if (s.ArmorType.Name == "special armor") armor_specialarmor_VNL = s.ArmorType;
                    if (s.ArmorType.Name == "tracks") armor_tracks_VNL = s.ArmorType;
                    if (s.ArmorType.Name == "gun steel") armor_gunsteel_VNL = s.ArmorType;
                }

                var era_optimizations_m829a3 = new List<AmmoType.ArmorOptimization>() { };
                var era_optimizations_m829a4 = new List<AmmoType.ArmorOptimization>() { };
                var era_optimizations_m830a2 = new List<AmmoType.ArmorOptimization>() { };
                var era_optimizations_lahat = new List<AmmoType.ArmorOptimization>() { };

                string[] era_names = new string[] {
                    "kontakt-1 armour",
                    "ARAT-1 Armor Codex",
                    "BRAT-M3 Armor Codex",
                    "BRAT-M5 Armor Codex",
                };

                foreach (ArmorCodexScriptable s in Resources.FindObjectsOfTypeAll<ArmorCodexScriptable>())
                {
                    if (era_names.Contains(s.name))
                    {
                        AmmoType.ArmorOptimization optimization_m829a3 = new AmmoType.ArmorOptimization();
                        optimization_m829a3.Armor = s;
                        optimization_m829a3.RhaRatio = 0.2f;
                        era_optimizations_m829a3.Add(optimization_m829a3);

                        AmmoType.ArmorOptimization optimization_m829a4 = new AmmoType.ArmorOptimization();
                        optimization_m829a4.Armor = s;
                        optimization_m829a4.RhaRatio = 0.15f;
                        era_optimizations_m829a4.Add(optimization_m829a4);

                        AmmoType.ArmorOptimization optimization_m830a2 = new AmmoType.ArmorOptimization();
                        optimization_m830a2.Armor = s;
                        optimization_m830a2.RhaRatio = 0.15f;
                        era_optimizations_m830a2.Add(optimization_m830a2);

                        AmmoType.ArmorOptimization optimization_lahat = new AmmoType.ArmorOptimization();
                        optimization_lahat.Armor = s;
                        optimization_lahat.RhaRatio = 0.2f;
                        era_optimizations_lahat.Add(optimization_lahat);
                    }

                    if (era_optimizations_m829a3.Count == era_names.Length) break;
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
                ammo_m829.Caliber = 120;
                ammo_m829.CertainRicochetAngle = 5f;
                ammo_m829.Mass = 3.94f;
                //ammo_m829.MaxSpallRha = 16f;
                ammo_m829.MuzzleVelocity = 1670f;
                ammo_m829.Name = "M829 APFSDS-T";
                ammo_m829.RhaPenetration = 600;
                //ammo_m829.SpallMultiplier = 1.5f;

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
                ammo_m829a1.Caliber = 120;
                ammo_m829a1.CertainRicochetAngle = 5f;
                ammo_m829a1.Mass = 4.64f;
                ammo_m829a1.MuzzleVelocity = 1575f;
                ammo_m829a1.Name = "M829A1 APFSDS-T";
                //ammo_m829a1.MaxSpallRha = 20f;
                ammo_m829a1.RhaPenetration = 700f;
                //ammo_m829a1.SpallMultiplier = 1.75f;

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
                ammo_m829a2.Caliber = 120;
                ammo_m829a2.CertainRicochetAngle = 4f;
                ammo_m829a2.Mass = 4.74f;
                //ammo_m829a2.MaxSpallRha = 24f;
                ammo_m829a2.MuzzleVelocity = 1680f;
                ammo_m829a2.Name = "M829A2 APFSDS-T";
                ammo_m829a2.RhaPenetration = 750f;
                //ammo_m829a2.SpallMultiplier = 2.0f;

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
                ammo_m829a3.ArmorOptimizations = era_optimizations_m829a3.ToArray<AmmoType.ArmorOptimization>();
                ammo_m829a3.Caliber = 120;
                ammo_m829a3.CertainRicochetAngle = 3f;
                ammo_m829a3.Mass = 4.84f;
                //ammo_m829a3.MaxSpallRha = 28f;
                ammo_m829a3.MuzzleVelocity = 1555f;
                ammo_m829a3.Name = "M829A3 APFSDS-T";
                ammo_m829a3.RhaPenetration = 840f;
                //ammo_m829a3.SpallMultiplier = 2.5f;

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
                ammo_m829a4.ArmorOptimizations = era_optimizations_m829a4.ToArray<AmmoType.ArmorOptimization>();
                ammo_m829a4.Caliber = 120;
                ammo_m829a4.CertainRicochetAngle = 2f;
                ammo_m829a4.Mass = 4.94f;
                ammo_m829a4.MaxSpallRha = 25f;
                ammo_m829a4.Name = "M829A4 APFSDS-T";
                ammo_m829a4.MuzzleVelocity = 1700f;
                ammo_m829a4.RhaPenetration = 1000f;
                ammo_m829a4.SpallMultiplier = 2f;

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
                ammo_m830.Caliber = 120;
                ammo_m830.CertainRicochetAngle = 4.0f;
                ammo_m830.DetonateSpallCount = 50;
                ammo_m830.Mass = 13.5f;
                ammo_m830.MuzzleVelocity = 1140f;
                ammo_m830.Name = "M830 HEAT-FS-T";
                ammo_m830.RhaPenetration = 600;
                ammo_m830.ShatterOnRicochet = false;
                ammo_m830.SpallMultiplier = 1.5f;
                ammo_m830.TntEquivalentKg = 1.814f;

                ammo_codex_m830 = ScriptableObject.CreateInstance<AmmoCodexScriptable>();
                ammo_codex_m830.AmmoType = ammo_m830;
                ammo_codex_m830.name = "ammo_m830";

                clip_m830 = new AmmoType.AmmoClip();
                clip_m830.Capacity = 1;
                clip_m830.Name = "M830 HEAT-FS-T";
                clip_m830.MinimalPattern = new AmmoCodexScriptable[1];
                clip_m830.MinimalPattern[0] = ammo_codex_m830;

                clip_codex_m830 = ScriptableObject.CreateInstance<AmmoClipCodexScriptable>();
                clip_codex_m830.name = "clip_m830";
                clip_codex_m830.CompatibleWeaponSystems = new WeaponSystemCodexScriptable[1];
                clip_codex_m830.CompatibleWeaponSystems[0] = gun_m256;
                clip_codex_m830.ClipType = clip_m830;

                // m830a1
                ammo_m830a1 = new AmmoType();
                Util.ShallowCopy(ammo_m830a1, ammo_m456);
                ammo_m830a1.Caliber = 120;
                ammo_m830a1.CertainRicochetAngle = 0.0f;
                ammo_m830a1.DetonateSpallCount = mpatFragments.Value; //Number of fragments generated when detonated (PD). Higher value means higher performance hit.
                //ammo_m830a1.ImpactFuseTime = 0.000357143f; //0.5 meters after impact //delay removed since it negatively affects armor penetration
                ammo_m830a1.Mass = 11.4f;
                ammo_m830a1.MaxSpallRha = 50f;
                ammo_m830a1.MinSpallRha = 1f;
                ammo_m830a1.MuzzleVelocity = 1400f;
                ammo_m830a1.Name = "M830A1 HEAT-MP-T";
                ammo_m830a1.RhaPenetration = 480;
                ammo_m830a1.ShatterOnRicochet = false;
                ammo_m830a1.SpallMultiplier = 0.5f;
                ammo_m830a1.TntEquivalentKg = 2.721f;

                ammo_codex_m830a1 = ScriptableObject.CreateInstance<AmmoCodexScriptable>();
                ammo_codex_m830a1.AmmoType = ammo_m830a1;
                ammo_codex_m830a1.name = "ammo_m830a1";

                clip_m830a1 = new AmmoType.AmmoClip();
                clip_m830a1.Capacity = 1;
                clip_m830a1.Name = "M830A1 HEAT-MP-T";
                clip_m830a1.MinimalPattern = new AmmoCodexScriptable[1];
                clip_m830a1.MinimalPattern[0] = ammo_codex_m830a1;

                clip_codex_m830a1 = ScriptableObject.CreateInstance<AmmoClipCodexScriptable>();
                clip_codex_m830a1.name = "clip_m830a1";
                clip_codex_m830a1.CompatibleWeaponSystems = new WeaponSystemCodexScriptable[1];
                clip_codex_m830a1.CompatibleWeaponSystems[0] = gun_m256;
                clip_codex_m830a1.ClipType = clip_m830a1;

                // m830a2
                ammo_m830a2 = new AmmoType();
                Util.ShallowCopy(ammo_m830a2, ammo_m456);
                ammo_m830a2.ArmorOptimizations = era_optimizations_m830a2.ToArray<AmmoType.ArmorOptimization>();
                ammo_m830a2.Caliber = 120;
                ammo_m830a2.CertainRicochetAngle = 0.0f;
                ammo_m830a2.DetonateSpallCount = 200;
                ammo_m830a2.Mass = 13.5f;
                ammo_m830a2.MaxSpallRha = 35f;
                ammo_m830a2.MinSpallRha = 5f;
                ammo_m830a2.MuzzleVelocity = 1400f;
                ammo_m830a2.Name = "M830A2 IHEAT-FS-T";
                ammo_m830a2.RhaPenetration = 700;
                ammo_m830a2.ShatterOnRicochet = false;
                ammo_m830a2.SpallMultiplier = 2f;
                ammo_m830a2.TntEquivalentKg = 2.721f;

                ammo_codex_m830a2 = ScriptableObject.CreateInstance<AmmoCodexScriptable>();
                ammo_codex_m830a2.AmmoType = ammo_m830a2;
                ammo_codex_m830a2.name = "ammo_m830a2";

                clip_m830a2 = new AmmoType.AmmoClip();
                clip_m830a2.Capacity = 1;
                clip_m830a2.Name = "M830A2 IHEAT-FS-T";
                clip_m830a2.MinimalPattern = new AmmoCodexScriptable[1];
                clip_m830a2.MinimalPattern[0] = ammo_codex_m830a2;

                clip_codex_m830a2 = ScriptableObject.CreateInstance<AmmoClipCodexScriptable>();
                clip_codex_m830a2.name = "clip_m830a2";
                clip_codex_m830a2.CompatibleWeaponSystems = new WeaponSystemCodexScriptable[1];
                clip_codex_m830a2.CompatibleWeaponSystems[0] = gun_m256;
                clip_codex_m830a2.ClipType = clip_m830a2;

                // m830a3
                ammo_m830a3 = new AmmoType();
                Util.ShallowCopy(ammo_m830a3, ammo_m456);
                ammo_m830a3.ArmorOptimizations = era_optimizations_m830a2.ToArray<AmmoType.ArmorOptimization>();
                ammo_m830a3.Caliber = 120;
                ammo_m830a3.CertainRicochetAngle = 0.0f;
                ammo_m830a3.DetonateSpallCount = 100;
                ammo_m830a3.Mass = 13.5f;
                ammo_m830a3.MaxSpallRha = 25f;
                ammo_m830a3.MinSpallRha = 5f;
                ammo_m830a3.MuzzleVelocity = 1300f;
                ammo_m830a3.Name = "M830A3 IHEAT-FS-T";
                ammo_m830a3.RhaPenetration = 1000;
                ammo_m830a3.ShatterOnRicochet = false;
                ammo_m830a3.SpallMultiplier = 2f;
                ammo_m830a3.TntEquivalentKg = 2.721f;

                ammo_codex_m830a3 = ScriptableObject.CreateInstance<AmmoCodexScriptable>();
                ammo_codex_m830a3.AmmoType = ammo_m830a3;
                ammo_codex_m830a3.name = "ammo_m830a3";

                clip_m830a3 = new AmmoType.AmmoClip();
                clip_m830a3.Capacity = 1;
                clip_m830a3.Name = "M830A3 IHEAT-FS-T";
                clip_m830a3.MinimalPattern = new AmmoCodexScriptable[1];
                clip_m830a3.MinimalPattern[0] = ammo_codex_m830a3;

                clip_codex_m830a3 = ScriptableObject.CreateInstance<AmmoClipCodexScriptable>();
                clip_codex_m830a3.name = "clip_m830a3";
                clip_codex_m830a3.CompatibleWeaponSystems = new WeaponSystemCodexScriptable[1];
                clip_codex_m830a3.CompatibleWeaponSystems[0] = gun_m256;
                clip_codex_m830a3.ClipType = clip_m830a3;

                // xm1147
                ammo_xm1147 = new AmmoType();
                Util.ShallowCopy(ammo_xm1147, ammo_m456);
                ammo_xm1147.Caliber = 120;
                ammo_xm1147.CertainRicochetAngle = 0.0f;
                ammo_xm1147.DetonateSpallCount = ampFragments.Value; //Number of fragments generated when detonated (PD/AB). Higher value means higher performance hit.
                ammo_xm1147.Mass = 11.4f;
                ammo_xm1147.MaxSpallRha = 180f;
                ammo_xm1147.MinSpallRha = 55f;
                ammo_xm1147.MuzzleVelocity = 1410f;
                ammo_xm1147.Name = "XM1147 AMP-T";
                ammo_xm1147.RhaPenetration = 480;
                ammo_xm1147.ShatterOnRicochet = false;
                ammo_xm1147.SpallMultiplier = 2f;
                ammo_xm1147.TntEquivalentKg = 3.45f; //50% more power than equivalent load

                ammo_codex_xm1147 = ScriptableObject.CreateInstance<AmmoCodexScriptable>();
                ammo_codex_xm1147.AmmoType = ammo_xm1147;
                ammo_codex_xm1147.name = "ammo_xm1147";

                clip_xm1147 = new AmmoType.AmmoClip();
                clip_xm1147.Capacity = 1;
                clip_xm1147.Name = "XM1147 AMP-T";
                clip_xm1147.MinimalPattern = new AmmoCodexScriptable[1];
                clip_xm1147.MinimalPattern[0] = ammo_codex_xm1147;

                clip_codex_xm1147 = ScriptableObject.CreateInstance<AmmoClipCodexScriptable>();
                clip_codex_xm1147.name = "clip_xm1147";
                clip_codex_xm1147.CompatibleWeaponSystems = new WeaponSystemCodexScriptable[1];
                clip_codex_xm1147.CompatibleWeaponSystems[0] = gun_m256;
                clip_codex_xm1147.ClipType = clip_xm1147;

                // lahat
                ammo_lahat = new AmmoType();
                Util.ShallowCopy(ammo_lahat, ammo_bgm71);
                ammo_lahat.ArmingDistance = 50;
                ammo_lahat.ArmorOptimizations = era_optimizations_lahat.ToArray<AmmoType.ArmorOptimization>();
                ammo_lahat.Caliber = 120;
                ammo_lahat.CertainRicochetAngle = 3.0f;
                ammo_lahat.Guidance = AmmoType.GuidanceType.Laser;
                ammo_lahat.MaximumRange = 6000f;
                ammo_lahat.MaxSpallRha = 15f;
                ammo_lahat.MinSpallRha = 5f;
                ammo_lahat.MuzzleVelocity = 300f;
                ammo_lahat.Mass = 13f;
                ammo_lahat.Name = "LAHAT";
                ammo_lahat.RhaPenetration = 800f;
                ammo_lahat.ShotVisual = ammo_bgm71.ShotVisual;
                ammo_lahat.SpallMultiplier = 1.5f;
                ammo_lahat.TurnSpeed = 1.5f;
                ammo_lahat.RangedFuseTime = 20f;
                ammo_lahat.Tandem = true;
                ammo_lahat.TntEquivalentKg = 4.5f;
                ammo_lahat.UseTracer = true;

                ammo_codex_lahat = ScriptableObject.CreateInstance<AmmoCodexScriptable>();
                ammo_codex_lahat.AmmoType = ammo_lahat;
                ammo_codex_lahat.name = "ammo_lahat";

                clip_lahat = new AmmoType.AmmoClip();
                clip_lahat.Capacity = 1;
                clip_lahat.Name = "LAHAT";
                clip_lahat.MinimalPattern = new AmmoCodexScriptable[1];
                clip_lahat.MinimalPattern[0] = ammo_codex_lahat;

                clip_codex_lahat = ScriptableObject.CreateInstance<AmmoClipCodexScriptable>();
                clip_codex_lahat.name = "clip_lahat";
                clip_codex_lahat.ClipType = clip_lahat;

                //Armor stuff

                ////HU armor modifiers
                armor_superCompositeskirt_HU = new ArmorType();
                Util.ShallowCopy(armor_superCompositeskirt_HU, armor_compositeskirt_VNL);
                armor_superCompositeskirt_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 11f; //default 1.5
                armor_superCompositeskirt_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 6f; //default 0.8
                armor_superCompositeskirt_HU.Name = "Abrams HU super special composite skirt";

                armor_codex_superCompositeskirt_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_superCompositeskirt_HU.name = "Abrams HU super special composite skirt";
                armor_codex_superCompositeskirt_HU.ArmorType = armor_superCompositeskirt_HU;

                armor_cheeksDUarmor_HU = new ArmorType();
                Util.ShallowCopy(armor_cheeksDUarmor_HU, armor_specialarmor_VNL);
                armor_cheeksDUarmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 2.2f; //default 1.3
                armor_cheeksDUarmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 1.25f; //default 0.55
                armor_cheeksDUarmor_HU.Name = "Abrams HU DU armor turret cheeks";

                armor_codex_cheeksDUarmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_cheeksDUarmor_HU.name = "Abrams HU DU armor turret cheeks";
                armor_codex_cheeksDUarmor_HU.ArmorType = armor_cheeksDUarmor_HU;
                armor_cheeksDUarmor_HU = new ArmorType();

                armor_fronthullDUarmor_HU = new ArmorType();
                Util.ShallowCopy(armor_fronthullDUarmor_HU, armor_specialarmor_VNL);
                armor_fronthullDUarmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 2.2f; //default 1.3
                armor_fronthullDUarmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 1.2f; //default 0.45
                armor_fronthullDUarmor_HU.Name = "Abrams HU DU armor hull front";

                armor_codex_fronthullDUarmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_fronthullDUarmor_HU.name = "Abrams HU DU armor hull front";
                armor_codex_fronthullDUarmor_HU.ArmorType = armor_fronthullDUarmor_HU;
                armor_fronthullDUarmor_HU = new ArmorType();

                armor_mantletDUarmor_HU = new ArmorType();
                Util.ShallowCopy(armor_mantletDUarmor_HU, armor_specialarmor_VNL);
                armor_mantletDUarmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 2.15f; //default 1.3
                armor_mantletDUarmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 1.65f; //default 1.4
                armor_mantletDUarmor_HU.Name = "Abrams HU DU armor mantlet";

                armor_codex_mantletDUarmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_mantletDUarmor_HU.name = "Abrams HU DU armor mantlet";
                armor_codex_mantletDUarmor_HU.ArmorType = armor_mantletDUarmor_HU;
                armor_mantletDUarmor_HU = new ArmorType();

                armor_turretsidesDUarmor_HU = new ArmorType();
                Util.ShallowCopy(armor_turretsidesDUarmor_HU, armor_specialarmor_VNL);
                armor_turretsidesDUarmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 4.4f; //default 1.3
                armor_turretsidesDUarmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 2.21f; //default 1.4
                armor_turretsidesDUarmor_HU.Name = "Abrams HU DU armor turret sides";

                armor_codex_turretsidesDUarmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_turretsidesDUarmor_HU.name = "Abrams HU DU armor turret sides";
                armor_codex_turretsidesDUarmor_HU.ArmorType = armor_turretsidesDUarmor_HU;
                armor_turretsidesDUarmor_HU = new ArmorType();

                armor_turretroofCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_turretroofCompositearmor_HU, armor_compositeskirt_VNL);
                armor_turretroofCompositearmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 7f; //default composite skirt 1.5
                armor_turretroofCompositearmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 5.9f; //default composite skirt 0.8
                armor_turretroofCompositearmor_HU.Name = "Abrams HU roof special composite";

                armor_codex_turretroofCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_turretroofCompositearmor_HU.name = "Abrams HU roof special composite";
                armor_codex_turretroofCompositearmor_HU.ArmorType = armor_turretroofCompositearmor_HU;
                armor_turretroofCompositearmor_HU = new ArmorType();

                armor_upperglacisCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_upperglacisCompositearmor_HU, armor_compositeskirt_VNL);
                armor_upperglacisCompositearmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 5.5f; //default composite skirt 1.5
                armor_upperglacisCompositearmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 4.7f; //default composite skirt 0.8
                armor_upperglacisCompositearmor_HU.Name = "Abrams HU upper glacis special composite";

                armor_codex_upperglacisCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_upperglacisCompositearmor_HU.name = "Abrams HU upper glacis special composite";
                armor_codex_upperglacisCompositearmor_HU.ArmorType = armor_upperglacisCompositearmor_HU;
                armor_upperglacisCompositearmor_HU = new ArmorType();

                armor_commmandershatchCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_commmandershatchCompositearmor_HU, armor_compositeskirt_VNL);
                armor_commmandershatchCompositearmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 3.6f; //default composite skirt 1.5
                armor_commmandershatchCompositearmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 3f; //default composite skirt 0.8
                armor_commmandershatchCompositearmor_HU.Name = "Abrams HU commander's hatch special composite";

                armor_codex_commmandershatchCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_commmandershatchCompositearmor_HU.name = "Abrams HU commander's hatch special composite";
                armor_codex_commmandershatchCompositearmor_HU.ArmorType = armor_commmandershatchCompositearmor_HU;
                armor_commmandershatchCompositearmor_HU = new ArmorType();

                armor_loadershatchCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_loadershatchCompositearmor_HU, armor_compositeskirt_VNL);
                armor_loadershatchCompositearmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 3.6f; //default composite skirt 1.5
                armor_loadershatchCompositearmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 3f; //default composite skirt 0.8
                armor_loadershatchCompositearmor_HU.Name = "Abrams HU loader's hatch special composite";

                armor_codex_loadershatchCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_loadershatchCompositearmor_HU.name = "Abrams HU loader's hatch special composite";
                armor_codex_loadershatchCompositearmor_HU.ArmorType = armor_loadershatchCompositearmor_HU;
                armor_loadershatchCompositearmor_HU = new ArmorType();

                armor_drivershatchCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_loadershatchCompositearmor_HU, armor_compositeskirt_VNL);
                armor_drivershatchCompositearmor_HU.RhaeMultiplierCe = 3.6f; //default composite skirt 1.5
                armor_drivershatchCompositearmor_HU.RhaeMultiplierKe = 3f; //default composite skirt 0.8
                armor_drivershatchCompositearmor_HU.Name = "Abrams HU driver's hatch special composite";

                armor_codex_drivershatchCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_drivershatchCompositearmor_HU.name = "Abrams HU driver's hatch special composite";
                armor_codex_drivershatchCompositearmor_HU.ArmorType = armor_drivershatchCompositearmor_HU;
                armor_drivershatchCompositearmor_HU = new ArmorType();

                armor_turretringCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_turretringCompositearmor_HU, armor_compositeskirt_VNL);
                armor_turretringCompositearmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 5f; //default composite skirt 1.5
                armor_turretringCompositearmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 5f; //default composite skirt 0.8
                armor_turretringCompositearmor_HU.Name = "Abrams HU turret ring special composite";

                armor_codex_turretringCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_turretringCompositearmor_HU.name = "Abrams HU turret ring special composite";
                armor_codex_turretringCompositearmor_HU.ArmorType = armor_turretringCompositearmor_HU;
                armor_turretringCompositearmor_HU = new ArmorType();

                armor_gunmantletfaceCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_gunmantletfaceCompositearmor_HU, armor_compositeskirt_VNL);
                armor_gunmantletfaceCompositearmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 23f; //default composite skirt 1.5
                armor_gunmantletfaceCompositearmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 18f; //default composite skirt 0.8
                armor_gunmantletfaceCompositearmor_HU.Name = "Abrams HU gun mantlet face special composite";

                armor_codex_gunmantletfaceCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_gunmantletfaceCompositearmor_HU.name = "Abrams HU gun mantlet face special composite";
                armor_codex_gunmantletfaceCompositearmor_HU.ArmorType = armor_gunmantletfaceCompositearmor_HU;
                armor_gunmantletfaceCompositearmor_HU = new ArmorType();

                armor_trackSpecialarmor_HU = new ArmorType();
                Util.ShallowCopy(armor_trackSpecialarmor_HU, armor_tracks_VNL);
                armor_trackSpecialarmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 10f; //default composite skirt 1.5
                armor_trackSpecialarmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 10f; //default composite skirt 0.8
                armor_trackSpecialarmor_HU.Name = "Abrams HU special track armor";

                armor_codex_trackSpecialarmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_trackSpecialarmor_HU.name = "Abrams HU special track armor";
                armor_codex_trackSpecialarmor_HU.ArmorType = armor_trackSpecialarmor_HU;
                armor_trackSpecialarmor_HU = new ArmorType();

                armor_gunbarrelImprovedarmor_HU = new ArmorType();
                Util.ShallowCopy(armor_gunbarrelImprovedarmor_HU, armor_gunsteel_VNL);
                armor_gunbarrelImprovedarmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 7f; //default composite skirt 1.5
                armor_gunbarrelImprovedarmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 7f; //default composite skirt 0.8
                armor_gunbarrelImprovedarmor_HU.Name = "Abrams HU Improved barrel armor";

                armor_codex_gunbarrelImprovedarmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_gunbarrelImprovedarmor_HU.name = "Abrams HU Improved barrel armor";
                armor_codex_gunbarrelImprovedarmor_HU.ArmorType = armor_gunbarrelImprovedarmor_HU;
                armor_gunbarrelImprovedarmor_HU = new ArmorType();

                armor_bustleImprovedfirewall_HU = new ArmorType();
                Util.ShallowCopy(armor_bustleImprovedfirewall_HU, armor_compositeskirt_VNL);
                armor_bustleImprovedfirewall_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 2.667f; //default composite skirt 1.5
                armor_bustleImprovedfirewall_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 2.667f; //default composite skirt 0.8
                armor_bustleImprovedfirewall_HU.Name = "Abrams HU bustle spall lining";

                armor_codex_bustleImprovedfirewall_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_bustleImprovedfirewall_HU.name = "Abrams HU bustle spall lining";
                armor_codex_bustleImprovedfirewall_HU.ArmorType = armor_bustleImprovedfirewall_HU;
                armor_bustleImprovedfirewall_HU = new ArmorType();

                armor_blowoutpanelCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_blowoutpanelCompositearmor_HU, armor_compositeskirt_VNL);
                armor_blowoutpanelCompositearmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 18f; //default composite skirt 1.5
                armor_blowoutpanelCompositearmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 15f; //default composite skirt 0.8
                armor_blowoutpanelCompositearmor_HU.Name = "Abrams HU Composite blowout panel";

                armor_codex_blowoutpanelCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_blowoutpanelCompositearmor_HU.name = "Abrams HU Composite blowout panel";
                armor_codex_blowoutpanelCompositearmor_HU.ArmorType = armor_blowoutpanelCompositearmor_HU;
                armor_blowoutpanelCompositearmor_HU = new ArmorType();

                armor_turretrearSpecialarray_HU = new ArmorType();
                Util.ShallowCopy(armor_turretrearSpecialarray_HU, armor_specialarmor_VNL);
                armor_turretrearSpecialarray_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 40f; //default special armor 1
                armor_turretrearSpecialarray_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 20f; //default special armor 1
                armor_turretrearSpecialarray_HU.Name = "Abrams HU Special armor turret rear";

                armor_codex_turretrearSpecialarray_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_turretrearSpecialarray_HU.name = "Abrams HU Special armor turret rear";
                armor_codex_turretrearSpecialarray_HU.ArmorType = armor_turretrearSpecialarray_HU;
                armor_turretrearSpecialarray_HU = new ArmorType();

                armor_GPSImprovedhousing_HU = new ArmorType();
                Util.ShallowCopy(armor_GPSImprovedhousing_HU, armor_compositeskirt_VNL);
                armor_GPSImprovedhousing_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 5f; //default composite skirt 1.5
                armor_GPSImprovedhousing_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 5f; //default composite skirt 0.8
                armor_GPSImprovedhousing_HU.Name = "Abrams HU GPS housing composite";

                armor_codex_GPSImprovedhousing_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_GPSImprovedhousing_HU.name = "Abrams HU GPS housing composite";
                armor_codex_GPSImprovedhousing_HU.ArmorType = armor_GPSImprovedhousing_HU;
                armor_GPSImprovedhousing_HU = new ArmorType();

                armor_GPSImproveddoor_HU = new ArmorType();
                Util.ShallowCopy(armor_GPSImproveddoor_HU, armor_compositeskirt_VNL);
                armor_GPSImproveddoor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 5f; //default composite skirt 1.5
                armor_GPSImproveddoor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 5f; //default composite skirt 0.8
                armor_GPSImproveddoor_HU.Name = "Abrams HU GPS door composite";

                armor_codex_GPSImproveddoor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_GPSImproveddoor_HU.name = "Abrams HU GPS door composite";
                armor_codex_GPSImproveddoor_HU.ArmorType = armor_GPSImproveddoor_HU;
                armor_GPSImproveddoor_HU = new ArmorType();

                armor_turretbottomCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_turretbottomCompositearmor_HU, armor_compositeskirt_VNL);
                armor_turretbottomCompositearmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 14f; //default composite skirt 1.5
                armor_turretbottomCompositearmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 12f; //default composite skirt 0.8
                armor_turretbottomCompositearmor_HU.Name = "Abrams HU turret bottom composite";

                armor_codex_turretbottomCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_turretbottomCompositearmor_HU.name = "Abrams HU turret bottom composite";
                armor_codex_turretbottomCompositearmor_HU.ArmorType = armor_turretbottomCompositearmor_HU;
                armor_turretbottomCompositearmor_HU = new ArmorType();

                armor_semireadyrackdoorCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_semireadyrackdoorCompositearmor_HU, armor_compositeskirt_VNL);
                armor_semireadyrackdoorCompositearmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 5f; //default composite skirt 1.5
                armor_semireadyrackdoorCompositearmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 5f; //default composite skirt 0.8
                armor_semireadyrackdoorCompositearmor_HU.Name = "Abrams HU semiready rack composite";

                armor_codex_semireadyrackdoorCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_semireadyrackdoorCompositearmor_HU.name = "Abrams HU semiready rack composite";
                armor_codex_semireadyrackdoorCompositearmor_HU.ArmorType = armor_semireadyrackdoorCompositearmor_HU;
                armor_semireadyrackdoorCompositearmor_HU = new ArmorType();

                armor_readyrackdoorCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_readyrackdoorCompositearmor_HU, armor_compositeskirt_VNL);
                armor_readyrackdoorCompositearmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 5f; //default composite skirt 1.5
                armor_readyrackdoorCompositearmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 5f; //default composite skirt 0.8
                armor_readyrackdoorCompositearmor_HU.Name = "Abrams HU ready rack composite";

                armor_codex_readyrackdoorCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_readyrackdoorCompositearmor_HU.name = "Abrams HU ready rack composite";
                armor_codex_readyrackdoorCompositearmor_HU.ArmorType = armor_readyrackdoorCompositearmor_HU;
                armor_readyrackdoorCompositearmor_HU = new ArmorType();

                armor_trunnionCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_trunnionCompositearmor_HU, armor_compositeskirt_VNL);
                armor_trunnionCompositearmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 1.5f; //default composite skirt 1.5
                armor_trunnionCompositearmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 1.5f; //default composite skirt 0.8
                armor_trunnionCompositearmor_HU.Name = "Abrams HU trunnion composite";

                armor_codex_trunnionCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_trunnionCompositearmor_HU.name = "Abrams HU trunnion composite";
                armor_codex_trunnionCompositearmor_HU.ArmorType = armor_trunnionCompositearmor_HU;
                armor_trunnionCompositearmor_HU = new ArmorType();

                armor_lowerflontplateCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_lowerflontplateCompositearmor_HU, armor_compositeskirt_VNL);
                armor_lowerflontplateCompositearmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 3.333f; //default composite skirt 1.5
                armor_lowerflontplateCompositearmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 3.333f; //default composite skirt 0.8
                armor_lowerflontplateCompositearmor_HU.Name = "Abrams HU lower front composite";

                armor_codex_lowerfrontplateCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_lowerfrontplateCompositearmor_HU.name = "Abrams HU lower front composite";
                armor_codex_lowerfrontplateCompositearmor_HU.ArmorType = armor_lowerflontplateCompositearmor_HU;
                armor_lowerflontplateCompositearmor_HU = new ArmorType();

                armor_hullfrontbackingplateCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_hullfrontbackingplateCompositearmor_HU, armor_compositeskirt_VNL);
                armor_hullfrontbackingplateCompositearmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 2.5f; //default composite skirt 1.5
                armor_hullfrontbackingplateCompositearmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 2.5f; //default composite skirt 0.8
                armor_hullfrontbackingplateCompositearmor_HU.Name = "Abrams HU hull front backing composite";

                armor_codex_hullfrontbackingplateCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_hullfrontbackingplateCompositearmor_HU.name = "Abrams HU hull front backing composite";
                armor_codex_hullfrontbackingplateCompositearmor_HU.ArmorType = armor_hullfrontbackingplateCompositearmor_HU;
                armor_hullfrontbackingplateCompositearmor_HU = new ArmorType();

                armor_turretcheekfaceCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_turretcheekfaceCompositearmor_HU, armor_compositeskirt_VNL);
                armor_turretcheekfaceCompositearmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 1.6f; //default composite skirt 1.5
                armor_turretcheekfaceCompositearmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 1.6f; //default composite skirt 0.8
                armor_turretcheekfaceCompositearmor_HU.Name = "Abrams HU cheek face composite";

                armor_codex_turretcheekfaceCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_turretcheekfaceCompositearmor_HU.name = "Abrams HU cheek face composite";
                armor_codex_turretcheekfaceCompositearmor_HU.ArmorType = armor_turretcheekfaceCompositearmor_HU;
                armor_turretcheekfaceCompositearmor_HU = new ArmorType();

                armor_turretcheekbackingplateCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_turretcheekbackingplateCompositearmor_HU, armor_compositeskirt_VNL);
                armor_turretcheekbackingplateCompositearmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 3f; //default composite skirt 1.5
                armor_turretcheekbackingplateCompositearmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 3f; //default composite skirt 0.8
                armor_turretcheekbackingplateCompositearmor_HU.Name = "Abrams HU cheek backing composite";

                armor_codex_turretcheekbackingplateCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_turretcheekbackingplateCompositearmor_HU.name = "Abrams HU cheek backing composite";
                armor_codex_turretcheekbackingplateCompositearmor_HU.ArmorType = armor_turretcheekbackingplateCompositearmor_HU;
                armor_turretcheekbackingplateCompositearmor_HU = new ArmorType();

                armor_turretsidebackingplateCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_turretsidebackingplateCompositearmor_HU, armor_compositeskirt_VNL);
                armor_turretsidebackingplateCompositearmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 3f; //default composite skirt 1.5
                armor_turretsidebackingplateCompositearmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 3f; //default composite skirt 0.8
                armor_turretsidebackingplateCompositearmor_HU.Name = "Abrams HU side backing composite";

                armor_codex_turretsidebackingplateCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_turretsidebackingplateCompositearmor_HU.name = "Abrams HU side backing composite";
                armor_codex_turretsidebackingplateCompositearmor_HU.ArmorType = armor_turretsidebackingplateCompositearmor_HU;
                armor_turretsidebackingplateCompositearmor_HU = new ArmorType();

                armor_turretsidefaceCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_turretsidefaceCompositearmor_HU, armor_compositeskirt_VNL);
                armor_turretsidefaceCompositearmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 2.667f; //default composite skirt 1.5
                armor_turretsidefaceCompositearmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 2.667f; //default composite skirt 0.8
                armor_turretsidefaceCompositearmor_HU.Name = "Abrams HU side face composite";

                armor_codex_turretsidefaceCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_turretsidefaceCompositearmor_HU.name = "Abrams HU side face composite";
                armor_codex_turretsidefaceCompositearmor_HU.ArmorType = armor_turretsidefaceCompositearmor_HU;
                armor_turretsidefaceCompositearmor_HU = new ArmorType();
                ////End

                ////HC armor modifiers (45% increase)
                armor_superCompositeskirt_HC = new ArmorType();
                Util.ShallowCopy(armor_superCompositeskirt_HC, armor_compositeskirt_VNL);
                armor_superCompositeskirt_HC.RhaeMultiplierCe = 2.175f; //default 1.5
                armor_superCompositeskirt_HC.RhaeMultiplierKe = 1.16f; //default 0.8
                armor_superCompositeskirt_HC.Name = "Abrams HC super special composite skirt";

                armor_codex_superCompositeskirt_HC = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_superCompositeskirt_HC.name = "Abrams HC super special composite skirt";
                armor_codex_superCompositeskirt_HC.ArmorType = armor_superCompositeskirt_HC;

                armor_cheeksDUarmor_HC = new ArmorType();
                Util.ShallowCopy(armor_cheeksDUarmor_HC, armor_specialarmor_VNL);
                armor_cheeksDUarmor_HC.RhaeMultiplierCe = 1.885f; //default 1.3
                armor_cheeksDUarmor_HC.RhaeMultiplierKe = 0.7975f; //default 0.55
                armor_cheeksDUarmor_HC.Name = "Abrams HC DU armor turret cheeks";

                armor_codex_cheeksDUarmor_HC = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_cheeksDUarmor_HC.name = "Abrams HC DU armor turret cheeks";
                armor_codex_cheeksDUarmor_HC.ArmorType = armor_cheeksDUarmor_HC;
                armor_cheeksDUarmor_HC = new ArmorType();

                armor_fronthullDUarmor_HC = new ArmorType();
                Util.ShallowCopy(armor_fronthullDUarmor_HC, armor_specialarmor_VNL);
                armor_fronthullDUarmor_HC.RhaeMultiplierCe = 1.885f; //default 1.3
                armor_fronthullDUarmor_HC.RhaeMultiplierKe = 0.87f; //default 0.45
                armor_fronthullDUarmor_HC.Name = "Abrams HC DU armor hull front";

                armor_codex_fronthullDUarmor_HC = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_fronthullDUarmor_HC.name = "Abrams HC DU armor hull front";
                armor_codex_fronthullDUarmor_HC.ArmorType = armor_fronthullDUarmor_HC;
                armor_fronthullDUarmor_HC = new ArmorType();

                armor_mantletDUarmor_HC = new ArmorType();
                Util.ShallowCopy(armor_mantletDUarmor_HC, armor_specialarmor_VNL);
                armor_mantletDUarmor_HC.RhaeMultiplierCe = 1.495f; //default 1.3
                armor_mantletDUarmor_HC.RhaeMultiplierKe = 1.61f; //default 1.4
                armor_mantletDUarmor_HC.Name = "Abrams HC DU armor mantlet";

                armor_codex_mantletDUarmor_HC = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_mantletDUarmor_HC.name = "Abrams HC DU armor mantlet";
                armor_codex_mantletDUarmor_HC.ArmorType = armor_mantletDUarmor_HC;
                armor_mantletDUarmor_HC = new ArmorType();

                armor_turretsidesDUarmor_HC = new ArmorType();
                Util.ShallowCopy(armor_turretsidesDUarmor_HC, armor_specialarmor_VNL);
                armor_turretsidesDUarmor_HC.RhaeMultiplierCe = 1.885f; //default 1.3
                armor_turretsidesDUarmor_HC.RhaeMultiplierKe = 2.03f; //default 1.4
                armor_turretsidesDUarmor_HC.Name = "Abrams HC DU armor turret sides";

                armor_codex_turretsidesDUarmor_HC = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_turretsidesDUarmor_HC.name = "Abrams HC DU armor turret sides";
                armor_codex_turretsidesDUarmor_HC.ArmorType = armor_turretsidesDUarmor_HC;
                armor_turretsidesDUarmor_HC = new ArmorType();
                ////End

                ////HA armor modifiers (30% increase)
                armor_superCompositeskirt_HA = new ArmorType();
                Util.ShallowCopy(armor_superCompositeskirt_HA, armor_compositeskirt_VNL);
                armor_superCompositeskirt_HA.RhaeMultiplierCe = 1.95f; //default 1.5
                armor_superCompositeskirt_HA.RhaeMultiplierKe = 1.04f; //default 0.8
                armor_superCompositeskirt_HA.Name = "Abrams HA super special composite skirt";

                armor_codex_superCompositeskirt_HA = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_superCompositeskirt_HA.name = "Abrams HA super special composite skirt";
                armor_codex_superCompositeskirt_HA.ArmorType = armor_superCompositeskirt_HA;

                armor_cheeksDUarmor_HA = new ArmorType();
                Util.ShallowCopy(armor_cheeksDUarmor_HA, armor_specialarmor_VNL);
                armor_cheeksDUarmor_HA.RhaeMultiplierCe = 1.69f; //default 1.3
                armor_cheeksDUarmor_HA.RhaeMultiplierKe = 0.715f; //default 0.55
                armor_cheeksDUarmor_HA.Name = "Abrams HA DU armor turret cheeks";

                armor_codex_cheeksDUarmor_HA = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_cheeksDUarmor_HA.name = "Abrams HA DU armor turret cheeks";
                armor_codex_cheeksDUarmor_HA.ArmorType = armor_cheeksDUarmor_HA;
                armor_cheeksDUarmor_HA = new ArmorType();

                armor_fronthullDUarmor_HA = new ArmorType();
                Util.ShallowCopy(armor_fronthullDUarmor_HA, armor_specialarmor_VNL);
                armor_fronthullDUarmor_HA.RhaeMultiplierCe = 1.69f; //default 1.3
                armor_fronthullDUarmor_HA.RhaeMultiplierKe = 0.65f; //default 0.45
                armor_fronthullDUarmor_HA.Name = "Abrams HA DU armor hull front";

                armor_codex_fronthullDUarmor_HA = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_fronthullDUarmor_HA.name = "Abrams HA DU armor hull front";
                armor_codex_fronthullDUarmor_HA.ArmorType = armor_fronthullDUarmor_HA;
                armor_fronthullDUarmor_HA = new ArmorType();

                armor_mantletDUarmor_HA = new ArmorType();
                Util.ShallowCopy(armor_mantletDUarmor_HA, armor_specialarmor_VNL);
                armor_mantletDUarmor_HA.RhaeMultiplierCe = 1.43f; //default 1.3
                armor_mantletDUarmor_HA.RhaeMultiplierKe = 1.54f; //default 1.4
                armor_mantletDUarmor_HA.Name = "Abrams HA DU armor mantlet";

                armor_codex_mantletDUarmor_HA = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_mantletDUarmor_HA.name = "Abrams HA DU armor mantlet";
                armor_codex_mantletDUarmor_HA.ArmorType = armor_mantletDUarmor_HA;
                armor_mantletDUarmor_HA = new ArmorType();

                armor_turretsidesDUarmor_HA = new ArmorType();
                Util.ShallowCopy(armor_turretsidesDUarmor_HA, armor_specialarmor_VNL);
                armor_turretsidesDUarmor_HA.RhaeMultiplierCe = 1.69f; //default 1.3
                armor_turretsidesDUarmor_HA.RhaeMultiplierKe = 1.82f; //default 1.4
                armor_turretsidesDUarmor_HA.Name = "Abrams HA DU armor turret sides";

                armor_codex_turretsidesDUarmor_HA = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_turretsidesDUarmor_HA.name = "Abrams HA DU armor turret sides";
                armor_codex_turretsidesDUarmor_HA.ArmorType = armor_turretsidesDUarmor_HA;
                armor_turretsidesDUarmor_HA = new ArmorType();
                ////End

                ////Visual models
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
                ammo_m829a4_vis.name = "M829A4 visual";
                ammo_m829a4.VisualModel = ammo_m829a4_vis;
                ammo_m829a4.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_m829a4;
                ammo_m829a4.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_m829a4;

                ammo_m830_vis = GameObject.Instantiate(ammo_m456.VisualModel);
                ammo_m830_vis.name = "M830 visual";
                ammo_m830.VisualModel = ammo_m830_vis;
                ammo_m830.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_m830;
                ammo_m830.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_m830;

                ammo_m830a1_vis = GameObject.Instantiate(ammo_m456.VisualModel);
                ammo_m830a1_vis.name = "M830A1 visual";
                ammo_m830a1.VisualModel = ammo_m830a1_vis;
                ammo_m830a1.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_m830a1;
                ammo_m830a1.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_m830a1;

                ammo_m830a2_vis = GameObject.Instantiate(ammo_m456.VisualModel);
                ammo_m830a2_vis.name = "M830A2 visual";
                ammo_m830a2.VisualModel = ammo_m830a2_vis;
                ammo_m830a2.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_m830a2;
                ammo_m830a2.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_m830a2;

                ammo_m830a3_vis = GameObject.Instantiate(ammo_m456.VisualModel);
                ammo_m830a3_vis.name = "M830A3 visual";
                ammo_m830a3.VisualModel = ammo_m830a3_vis;
                ammo_m830a3.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_m830a3;
                ammo_m830a3.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_m830a3;

                ammo_xm1147_vis = GameObject.Instantiate(ammo_m456.VisualModel);
                ammo_xm1147_vis.name = "XM1147 visual";
                ammo_xm1147.VisualModel = ammo_xm1147_vis;
                ammo_xm1147.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_xm1147;
                ammo_xm1147.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_xm1147;

                ammo_lahat_vis = GameObject.Instantiate(ammo_m456.VisualModel);
                ammo_lahat_vis.name = "LAHAT visual";
                ammo_lahat.VisualModel = ammo_lahat_vis;
                ammo_lahat.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_lahat;
                ammo_lahat.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_lahat;
            }

            StateController.RunOrDefer(GameState.GameReady, new GameStateEventHandler(Convert), GameStatePriority.Lowest);
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
