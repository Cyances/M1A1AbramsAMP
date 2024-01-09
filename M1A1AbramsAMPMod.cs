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

namespace M1A1AMP
{
    public static class M1A1AbramsAMPMod
    {

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

        static WeaponSystemCodexScriptable gun_m256;

        //Ammo variables
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

        static AmmoClipCodexScriptable clip_codex_XM1147;
        static AmmoType.AmmoClip clip_XM1147;
        static AmmoCodexScriptable ammo_codex_XM1147;
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
        static GameObject ammo_xm1147_vis = null;
        static GameObject ammo_lahat_vis = null;

        static AmmoType ammo_m833;
        static AmmoType ammo_m456;
        static AmmoType ammo_bgm71;

        //Armor variables
        static ArmorType armor_compositeskirt_HU;
        static ArmorCodexScriptable armor_codex_superCompositeskirt_HU;
        static ArmorType armor_superCompositeskirt_HU;

        static ArmorType armor_cheeksnera_HU;
        static ArmorCodexScriptable armor_codex_cheeksDUarmor_HU;
        static ArmorType armor_cheeksDUarmor_HU;

        static ArmorType armor_fronthullnera_HU;
        static ArmorCodexScriptable armor_codex_fronthullDUarmor_HU;
        static ArmorType armor_fronthullDUarmor_HU;

        static ArmorType armor_mantletnera_HU;
        static ArmorCodexScriptable armor_codex_mantletDUarmor_HU;
        static ArmorType armor_mantletDUarmor_HU;

        static ArmorType armor_turretsidesnera_HU;
        static ArmorCodexScriptable armor_codex_turretsidesDUarmor_HU;
        static ArmorType armor_turretsidesDUarmor_HU;

        static ArmorType armor_turretroofarmor_HU;
        static ArmorCodexScriptable armor_codex_turretroofCompositearmor_HU;
        static ArmorType armor_turretroofCompositearmor_HU;

        static ArmorType armor_upperglacisarmor_HU;
        static ArmorCodexScriptable armor_codex_upperglacisCompositearmor_HU;
        static ArmorType armor_upperglacisCompositearmor_HU;

        static ArmorType armor_commmandershatcharmor_HU;
        static ArmorCodexScriptable armor_codex_commmandershatchCompositearmor_HU;
        static ArmorType armor_commmandershatchCompositearmor_HU;

        static ArmorType armor_loadershatcharmor_HU;
        static ArmorCodexScriptable armor_codex_loadershatchCompositearmor_HU;
        static ArmorType armor_loadershatchCompositearmor_HU;

        static ArmorType armor_drivershatcharmor_HU;
        static ArmorCodexScriptable armor_codex_drivershatchCompositearmor_HU;
        static ArmorType armor_drivershatchCompositearmor_HU;

        static ArmorType armor_turretringarmor_HU;
        static ArmorCodexScriptable armor_codex_turretringCompositearmor_HU;
        static ArmorType armor_turretringCompositearmor_HU;

        static ArmorType armor_gunmantletfacearmor_HU;
        static ArmorCodexScriptable armor_codex_gunmantletfaceCompositearmor_HU;
        static ArmorType armor_gunmantletfaceCompositearmor_HU;

        static ArmorType armor_trackarmor_HU;
        static ArmorCodexScriptable armor_codex_trackSpecialarmor_HU;
        static ArmorType armor_trackSpecialarmor_HU;

        static ArmorType armor_compositeskirt_HC;
        static ArmorCodexScriptable armor_codex_superCompositeskirt_HC;
        static ArmorType armor_superCompositeskirt_HC;

        static ArmorType armor_cheeksnera_HC;
        static ArmorCodexScriptable armor_codex_cheeksDUarmor_HC;
        static ArmorType armor_cheeksDUarmor_HC;

        static ArmorType armor_fronthullnera_HC;
        static ArmorCodexScriptable armor_codex_fronthullDUarmor_HC;
        static ArmorType armor_fronthullDUarmor_HC;

        static ArmorType armor_mantletnera_HC;
        static ArmorCodexScriptable armor_codex_mantletDUarmor_HC;
        static ArmorType armor_mantletDUarmor_HC;

        static ArmorType armor_turretsidesnera_HC;
        static ArmorCodexScriptable armor_codex_turretsidesDUarmor_HC;
        static ArmorType armor_turretsidesDUarmor_HC;

        static ArmorType armor_compositeskirt_HA;
        static ArmorCodexScriptable armor_codex_superCompositeskirt_HA;
        static ArmorType armor_superCompositeskirt_HA;

        static ArmorType armor_cheeksnera_HA;
        static ArmorCodexScriptable armor_codex_cheeksDUarmor_HA;
        static ArmorType armor_cheeksDUarmor_HA;

        static ArmorType armor_fronthullnera_HA;
        static ArmorCodexScriptable armor_codex_fronthullDUarmor_HA;
        static ArmorType armor_fronthullDUarmor_HA;

        static ArmorType armor_mantletnera_HA;
        static ArmorCodexScriptable armor_codex_mantletDUarmor_HA;
        static ArmorType armor_mantletDUarmor_HA;

        static ArmorType armor_turretsidesnera_HA;
        static ArmorCodexScriptable armor_codex_turretsidesDUarmor_HA;
        static ArmorType armor_turretsidesDUarmor_HA;

        static UniformArmor hullsideCompositearray;
        static UniformArmor hullrearCompositearray;
        static UniformArmor hullfloorCompositearray;
        static UniformArmor hullroofCompositearray;
        static UniformArmor firewallSpalllining;
        static UniformArmor ammorackdoorarray;
        static UniformArmor enginedeckCompositearray;
        static UniformArmor fenderCompositearray;
        static UniformArmor sideskirtCompositearray;
        static UniformArmor gunnersightCompositearray;
        static UniformArmor sprocketwheelImprovedarmor;
        static UniformArmor roadwheelIimprovedarmor;

        // gas
        static ReticleSO reticleSO_m829;
        static ReticleMesh.CachedReticle reticle_cached_m829;

        static ReticleSO reticleSO_m829a1;
        static ReticleMesh.CachedReticle reticle_cached_m829a1;

        static ReticleSO reticleSO_m829a2;
        static ReticleMesh.CachedReticle reticle_cached_m829a2;

        static ReticleSO reticleSO_m829a3;
        static ReticleMesh.CachedReticle reticle_cached_m829a3;

        static ReticleSO reticleSO_m829a4;
        static ReticleMesh.CachedReticle reticle_cached_m829a4;

        static ReticleSO reticleSO_m830;
        static ReticleMesh.CachedReticle reticle_cached_m830;

        static ReticleSO reticleSO_m830a1;
        static ReticleMesh.CachedReticle reticle_cached_m830a1;

        static ReticleSO reticleSO_m830a2;
        static ReticleMesh.CachedReticle reticle_cached_m830a2;

        static ReticleSO reticleSO_xm1147;
        static ReticleMesh.CachedReticle reticle_cached_xm1147;

        static ReticleSO reticleSO_lahat;
        static ReticleMesh.CachedReticle reticle_cached_lahat;


        public static void Config(MelonPreferences_Category cfg)
        {
            m1a1firstAmmo = cfg.CreateEntry<string>("M1A1 1st Round Type", "M829A4");
            m1a1firstAmmo.Description = "Round types carried by M1A1: 'M829', 'M829A1', 'M829A2', 'M829A3', 'M829A4', 'M830', 'M830A1', 'M830A2', 'XM1147', 'LAHAT' or 'XM1111'";
            m1a1secondAmmo = cfg.CreateEntry<string>("M1A1 2nd Round Type", "M830A2");
            m1a1thirdAmmo = cfg.CreateEntry<string>("M1A1 3rd Round Type", "XM1147");
            m1a1fourthAmmo = cfg.CreateEntry<string>("M1A1 4th Round Type", "LAHAT");

            m1a1firstammoCount = cfg.CreateEntry<int>("M1A1 1st Round Count", 20);
            m1a1firstammoCount.Description = "How many rounds per type each M1A1 should carry. Maximum of 50 rounds total. Bring in at least one primary round.";
            m1a1secondammoCount = cfg.CreateEntry<int>("M1A1 2nd Round Count", 12);
            m1a1thirdammoCount = cfg.CreateEntry<int>("M1A1 3rd Round Count", 12);
            m1a1fourthammoCount = cfg.CreateEntry<int>("M1A1 4th Round Count", 6);

            m1e1firstAmmo = cfg.CreateEntry<string>("M1E1 1st Round Type", "M829");
            m1e1firstAmmo.Description = "Round types carried by M1E1: 'M829', 'M829A1', 'M829A2', 'M829A3', 'M829A4', 'M830', 'M830A1', 'M830A2', 'XM1147', 'LAHAT' or 'XM1111'";
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
        }
        public static IEnumerator Convert(GameState _)
        {
            //Abrams armor list//
            var abrams_armorvariant_variable = new Dictionary<string, ArmorCodexScriptable>()
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
            var abrams_armorvariant_uniform = new Dictionary<string, UniformArmor>()
            {
                ["HU"] = hullsideCompositearray,
                ["HU"] = hullfloorCompositearray,
                ["HU"] = hullroofCompositearray,
                ["HU"] = firewallSpalllining,
                ["HU"] = ammorackdoorarray,
                ["HU"] = enginedeckCompositearray,
                ["HU"] = fenderCompositearray,
                ["HU"] = sideskirtCompositearray,
                ["HU"] = gunnersightCompositearray,
                ["HU"] = sprocketwheelImprovedarmor,
                ["HU"] = roadwheelIimprovedarmor,
            };

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

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor hullsideCompositearray = armour.GetComponent<UniformArmor>();
                if (hullsideCompositearray == null) continue;
                if (hullsideCompositearray.Unit == null) continue;
                if (hullsideCompositearray.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (hullsideCompositearray.Name == "hull side")
                {
                    hullsideCompositearray.PrimaryHeatRha = 210f;
                    hullsideCompositearray.PrimarySabotRha = 180f;
                }

                MelonLogger.Msg("Composite hull side armor: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor hullrearCompositearray = armour.GetComponent<UniformArmor>();
                if (hullrearCompositearray == null) continue;
                if (hullrearCompositearray.Unit == null) continue;
                if (hullrearCompositearray.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (hullrearCompositearray.Name == "hull rear")
                {
                    hullrearCompositearray.PrimaryHeatRha = 210f;
                    hullrearCompositearray.PrimarySabotRha = 180f;
                }

                MelonLogger.Msg("Composite hull rear armor: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor hullfloorCompositearray = armour.GetComponent<UniformArmor>();
                if (hullfloorCompositearray == null) continue;
                if (hullfloorCompositearray.Unit == null) continue;
                if (hullfloorCompositearray.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (hullfloorCompositearray.Name == "hull floor")
                {
                    hullfloorCompositearray.PrimaryHeatRha = 240f;
                    hullfloorCompositearray.PrimarySabotRha = 210f;
                }

                MelonLogger.Msg("Composite hull floor armor: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor hullroofCompositearray = armour.GetComponent<UniformArmor>();
                if (hullroofCompositearray == null) continue;
                if (hullroofCompositearray.Unit == null) continue;
                if (hullroofCompositearray.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (hullroofCompositearray.Name == "hull roof")
                {
                    hullroofCompositearray.PrimaryHeatRha = 240f;
                    hullroofCompositearray.PrimarySabotRha = 210f;
                }

                MelonLogger.Msg("Composite hull roof armor: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor firewallSpalllining = armour.GetComponent<UniformArmor>();
                if (firewallSpalllining == null) continue;
                if (firewallSpalllining.Unit == null) continue;
                if (firewallSpalllining.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (firewallSpalllining.Name == "firewall")
                {
                    firewallSpalllining.PrimaryHeatRha = 30f;
                    firewallSpalllining.PrimarySabotRha = 30f;
                }

                MelonLogger.Msg("Spall lining: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor ammorackdoorarray = armour.GetComponent<UniformArmor>();
                if (ammorackdoorarray == null) continue;
                if (ammorackdoorarray.Unit == null) continue;
                if (ammorackdoorarray.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (ammorackdoorarray.Name == "hull ammo rack door")
                {
                    ammorackdoorarray.PrimaryHeatRha = 45f;
                    ammorackdoorarray.PrimarySabotRha = 45f;
                }

                MelonLogger.Msg("Composite ammo rack door: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor enginedeckCompositearray = armour.GetComponent<UniformArmor>();
                if (enginedeckCompositearray == null) continue;
                if (enginedeckCompositearray.Unit == null) continue;
                if (enginedeckCompositearray.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (enginedeckCompositearray.Name == "engine deck")
                {
                    enginedeckCompositearray.PrimaryHeatRha = 300f;
                    enginedeckCompositearray.PrimarySabotRha = 300f;
                }

                MelonLogger.Msg("Composite engine deck armor: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor fenderCompositearray = armour.GetComponent<UniformArmor>();
                if (fenderCompositearray == null) continue;
                if (fenderCompositearray.Unit == null) continue;
                if (fenderCompositearray.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (fenderCompositearray.Name == "fender")
                {
                    fenderCompositearray.PrimaryHeatRha = 150f;
                    fenderCompositearray.PrimarySabotRha = 100f;
                }

                MelonLogger.Msg("Composite fender armor: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor sideskirtCompositearray = armour.GetComponent<UniformArmor>();
                if (sideskirtCompositearray == null) continue;
                if (sideskirtCompositearray.Unit == null) continue;
                if (sideskirtCompositearray.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (sideskirtCompositearray.Name == "side skirt")
                {
                    sideskirtCompositearray.PrimaryHeatRha = 550f;
                    sideskirtCompositearray.PrimarySabotRha = 320f;
                }

                MelonLogger.Msg("Composite side skirt: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor gunnersightCompositearray = armour.GetComponent<UniformArmor>();
                if (gunnersightCompositearray == null) continue;
                if (gunnersightCompositearray.Unit == null) continue;
                if (gunnersightCompositearray.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (gunnersightCompositearray.Name == "gunner's primary sight")
                {
                    gunnersightCompositearray.PrimaryHeatRha = 50f;
                    gunnersightCompositearray.PrimarySabotRha = 50f;
                }

                MelonLogger.Msg("Special gunner sight armor: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor sprocketwheelImprovedarmor = armour.GetComponent<UniformArmor>();
                if (sprocketwheelImprovedarmor == null) continue;
                if (sprocketwheelImprovedarmor.Unit == null) continue;
                if (sprocketwheelImprovedarmor.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (sprocketwheelImprovedarmor.Name == "sprocket wheel")
                {
                    sprocketwheelImprovedarmor.PrimaryHeatRha = 150f;
                    sprocketwheelImprovedarmor.PrimarySabotRha = 150f;
                }

                MelonLogger.Msg("Improved sprocket wheel armor: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor roadwheelImprovedarmor = armour.GetComponent<UniformArmor>();
                if (roadwheelImprovedarmor == null) continue;
                if (roadwheelImprovedarmor.Unit == null) continue;
                if (roadwheelImprovedarmor.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (roadwheelImprovedarmor.Name == "road wheel")
                {
                    roadwheelImprovedarmor.PrimaryHeatRha = 100f;
                    roadwheelImprovedarmor.PrimarySabotRha = 100f;
                }

                MelonLogger.Msg("Improved road wheel armor: Loaded");
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

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor hullsideCompositearray = armour.GetComponent<UniformArmor>();
                if (hullsideCompositearray == null) continue;
                if (hullsideCompositearray.Unit == null) continue;
                if (hullsideCompositearray.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;

                if (hullsideCompositearray.Name == "hull side")
                {
                    hullsideCompositearray.PrimaryHeatRha = 210f;
                    hullsideCompositearray.PrimarySabotRha = 180f;
                }

                MelonLogger.Msg("Composite hull side armor: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor hullrearCompositearray = armour.GetComponent<UniformArmor>();
                if (hullrearCompositearray == null) continue;
                if (hullrearCompositearray.Unit == null) continue;
                if (hullrearCompositearray.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (hullrearCompositearray.Name == "hull rear")
                {
                    hullrearCompositearray.PrimaryHeatRha = 210f;
                    hullrearCompositearray.PrimarySabotRha = 180f;
                }

                MelonLogger.Msg("Composite hull rear armor: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor hullfloorCompositearray = armour.GetComponent<UniformArmor>();
                if (hullfloorCompositearray == null) continue;
                if (hullfloorCompositearray.Unit == null) continue;
                if (hullfloorCompositearray.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (hullfloorCompositearray.Name == "hull floor")
                {
                    hullfloorCompositearray.PrimaryHeatRha = 240f;
                    hullfloorCompositearray.PrimarySabotRha = 210f;
                }

                MelonLogger.Msg("Composite hull floor armor: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor hullroofCompositearray = armour.GetComponent<UniformArmor>();
                if (hullroofCompositearray == null) continue;
                if (hullroofCompositearray.Unit == null) continue;
                if (hullroofCompositearray.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (hullroofCompositearray.Name == "hull roof")
                {
                    hullroofCompositearray.PrimaryHeatRha = 240f;
                    hullroofCompositearray.PrimarySabotRha = 210f;
                }

                MelonLogger.Msg("Composite hull roof armor: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor firewallSpalllining = armour.GetComponent<UniformArmor>();
                if (firewallSpalllining == null) continue;
                if (firewallSpalllining.Unit == null) continue;
                if (firewallSpalllining.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (firewallSpalllining.Name == "firewall")
                {
                    firewallSpalllining.PrimaryHeatRha = 30f;
                    firewallSpalllining.PrimarySabotRha = 30f;
                }

                MelonLogger.Msg("Spall lining: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor ammorackdoorarray = armour.GetComponent<UniformArmor>();
                if (ammorackdoorarray == null) continue;
                if (ammorackdoorarray.Unit == null) continue;
                if (ammorackdoorarray.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (ammorackdoorarray.Name == "hull ammo rack door")
                {
                    ammorackdoorarray.PrimaryHeatRha = 45f;
                    ammorackdoorarray.PrimarySabotRha = 45f;
                }

                MelonLogger.Msg("Composite ammo rack door: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor enginedeckCompositearray = armour.GetComponent<UniformArmor>();
                if (enginedeckCompositearray == null) continue;
                if (enginedeckCompositearray.Unit == null) continue;
                if (enginedeckCompositearray.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (enginedeckCompositearray.Name == "engine deck")
                {
                    enginedeckCompositearray.PrimaryHeatRha = 300f;
                    enginedeckCompositearray.PrimarySabotRha = 300f;
                }

                MelonLogger.Msg("Composite engine deck armor: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor fenderCompositearray = armour.GetComponent<UniformArmor>();
                if (fenderCompositearray == null) continue;
                if (fenderCompositearray.Unit == null) continue;
                if (fenderCompositearray.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (fenderCompositearray.Name == "engine deck")
                {
                    fenderCompositearray.PrimaryHeatRha = 150f;
                    fenderCompositearray.PrimarySabotRha = 100f;
                }

                MelonLogger.Msg("Composite fender armor: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor sideskirtCompositearray = armour.GetComponent<UniformArmor>();
                if (sideskirtCompositearray == null) continue;
                if (sideskirtCompositearray.Unit == null) continue;
                if (sideskirtCompositearray.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (sideskirtCompositearray.Name == "side skirt")
                {
                    sideskirtCompositearray.PrimaryHeatRha = 550f;
                    sideskirtCompositearray.PrimarySabotRha = 320f;
                }

                MelonLogger.Msg("Composite side skirt: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor gunnersightCompositearray = armour.GetComponent<UniformArmor>();
                if (gunnersightCompositearray == null) continue;
                if (gunnersightCompositearray.Unit == null) continue;
                if (gunnersightCompositearray.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (gunnersightCompositearray.Name == "gunner's primary sight")
                {
                    gunnersightCompositearray.PrimaryHeatRha = 50f;
                    gunnersightCompositearray.PrimarySabotRha = 50f;
                }

                MelonLogger.Msg("Special gunner sight armor: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor sprocketwheelImprovedarmor = armour.GetComponent<UniformArmor>();
                if (sprocketwheelImprovedarmor == null) continue;
                if (sprocketwheelImprovedarmor.Unit == null) continue;
                if (sprocketwheelImprovedarmor.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (sprocketwheelImprovedarmor.Name == "sprocket wheel")
                {
                    sprocketwheelImprovedarmor.PrimaryHeatRha = 150f;
                    sprocketwheelImprovedarmor.PrimarySabotRha = 150f;
                }

                MelonLogger.Msg("Improved sprocket wheel armor: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor roadwheelImprovedarmor = armour.GetComponent<UniformArmor>();
                if (roadwheelImprovedarmor == null) continue;
                if (roadwheelImprovedarmor.Unit == null) continue;
                if (roadwheelImprovedarmor.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (roadwheelImprovedarmor.Name == "road wheel")
                {
                    roadwheelImprovedarmor.PrimaryHeatRha = 100f;
                    roadwheelImprovedarmor.PrimarySabotRha = 100f;
                }

                MelonLogger.Msg("Improved road wheel armor: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor hullsideCompositearray = armour.GetComponent<UniformArmor>();
                if (hullsideCompositearray == null) continue;
                if (hullsideCompositearray.Unit == null) continue;
                if (hullsideCompositearray.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;

                if (hullsideCompositearray.Name == "hull side")
                {
                    hullsideCompositearray.PrimaryHeatRha = 210f;
                    hullsideCompositearray.PrimarySabotRha = 180f;
                }

                MelonLogger.Msg("Composite hull side armor: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor hullrearCompositearray = armour.GetComponent<UniformArmor>();
                if (hullrearCompositearray == null) continue;
                if (hullrearCompositearray.Unit == null) continue;
                if (hullrearCompositearray.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (hullrearCompositearray.Name == "hull rear")
                {
                    hullrearCompositearray.PrimaryHeatRha = 210f;
                    hullrearCompositearray.PrimarySabotRha = 180f;
                }

                MelonLogger.Msg("Composite hull rear armor: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor hullfloorCompositearray = armour.GetComponent<UniformArmor>();
                if (hullfloorCompositearray == null) continue;
                if (hullfloorCompositearray.Unit == null) continue;
                if (hullfloorCompositearray.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (hullfloorCompositearray.Name == "hull floor")
                {
                    hullfloorCompositearray.PrimaryHeatRha = 240f;
                    hullfloorCompositearray.PrimarySabotRha = 210f;
                }

                MelonLogger.Msg("Composite hull floor armor: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor hullroofCompositearray = armour.GetComponent<UniformArmor>();
                if (hullroofCompositearray == null) continue;
                if (hullroofCompositearray.Unit == null) continue;
                if (hullroofCompositearray.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (hullroofCompositearray.Name == "hull roof")
                {
                    hullroofCompositearray.PrimaryHeatRha = 240f;
                    hullroofCompositearray.PrimarySabotRha = 210f;
                }

                MelonLogger.Msg("Composite hull roof armor: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor firewallSpalllining = armour.GetComponent<UniformArmor>();
                if (firewallSpalllining == null) continue;
                if (firewallSpalllining.Unit == null) continue;
                if (firewallSpalllining.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (firewallSpalllining.Name == "firewall")
                {
                    firewallSpalllining.PrimaryHeatRha = 30f;
                    firewallSpalllining.PrimarySabotRha = 30f;
                }

                MelonLogger.Msg("Spall lining: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor ammorackdoorarray = armour.GetComponent<UniformArmor>();
                if (ammorackdoorarray == null) continue;
                if (ammorackdoorarray.Unit == null) continue;
                if (ammorackdoorarray.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (ammorackdoorarray.Name == "hull ammo rack door")
                {
                    ammorackdoorarray.PrimaryHeatRha = 45f;
                    ammorackdoorarray.PrimarySabotRha = 45f;
                }

                MelonLogger.Msg("Composite ammo rack door: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor enginedeckCompositearray = armour.GetComponent<UniformArmor>();
                if (enginedeckCompositearray == null) continue;
                if (enginedeckCompositearray.Unit == null) continue;
                if (enginedeckCompositearray.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (enginedeckCompositearray.Name == "engine deck")
                {
                    enginedeckCompositearray.PrimaryHeatRha = 300f;
                    enginedeckCompositearray.PrimarySabotRha = 300f;
                }

                MelonLogger.Msg("Composite engine deck armor: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor fenderCompositearray = armour.GetComponent<UniformArmor>();
                if (fenderCompositearray == null) continue;
                if (fenderCompositearray.Unit == null) continue;
                if (fenderCompositearray.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (fenderCompositearray.Name == "engine deck")
                {
                    fenderCompositearray.PrimaryHeatRha = 150f;
                    fenderCompositearray.PrimarySabotRha = 100f;
                }

                MelonLogger.Msg("Composite fender armor: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor sideskirtCompositearray = armour.GetComponent<UniformArmor>();
                if (sideskirtCompositearray == null) continue;
                if (sideskirtCompositearray.Unit == null) continue;
                if (sideskirtCompositearray.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (sideskirtCompositearray.Name == "side skirt")
                {
                    sideskirtCompositearray.PrimaryHeatRha = 550f;
                    sideskirtCompositearray.PrimarySabotRha = 320f;
                }

                MelonLogger.Msg("Composite side skirt: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor gunnersightCompositearray = armour.GetComponent<UniformArmor>();
                if (gunnersightCompositearray == null) continue;
                if (gunnersightCompositearray.Unit == null) continue;
                if (gunnersightCompositearray.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (gunnersightCompositearray.Name == "gunner's primary sight")
                {
                    gunnersightCompositearray.PrimaryHeatRha = 50f;
                    gunnersightCompositearray.PrimarySabotRha = 50f;
                }

                MelonLogger.Msg("Special gunner sight armor: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor sprocketwheelImprovedarmor = armour.GetComponent<UniformArmor>();
                if (sprocketwheelImprovedarmor == null) continue;
                if (sprocketwheelImprovedarmor.Unit == null) continue;
                if (sprocketwheelImprovedarmor.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (sprocketwheelImprovedarmor.Name == "sprocket wheel")
                {
                    sprocketwheelImprovedarmor.PrimaryHeatRha = 150f;
                    sprocketwheelImprovedarmor.PrimarySabotRha = 150f;
                }

                MelonLogger.Msg("Improved sprocket wheel armor: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor roadwheelImprovedarmor = armour.GetComponent<UniformArmor>();
                if (roadwheelImprovedarmor == null) continue;
                if (roadwheelImprovedarmor.Unit == null) continue;
                if (roadwheelImprovedarmor.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (roadwheelImprovedarmor.Name == "road wheel")
                {
                    roadwheelImprovedarmor.PrimaryHeatRha = 100f;
                    roadwheelImprovedarmor.PrimarySabotRha = 100f;
                }

                MelonLogger.Msg("Improved road wheel armor: Loaded");
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

            //Abrams round list
            var abrams_ammotype = new Dictionary<string, AmmoClipCodexScriptable>()
            {
                ["M829"] = clip_codex_m829,
                ["M829A1"] = clip_codex_m829a1,
                ["M829A2"] = clip_codex_m829a2,
                ["M829A3"] = clip_codex_m829a3,
                ["M829A4"] = clip_codex_m829a4,
                ["M830"] = clip_codex_m830,
                ["M830A1"] = clip_codex_m830a1,
                ["M830A2"] = clip_codex_m830a2,
                ["XM1147"] = clip_codex_XM1147,
                ["LAHAT"] = clip_codex_lahat,
            }; 
            
            foreach (GameObject vic_go in AbramsAMPMod.vic_gos)
            {
                Vehicle vic = vic_go.GetComponent<Vehicle>();

                if (vic == null) continue;

                if (vic.FriendlyName == "M1IP" || (m1e1Convert.Value && vic.FriendlyName == "M1"))
                {
                    int rand = (randomChance.Value) ? UnityEngine.Random.Range(1, 100) : 0;

                    if (rand <= randomChanceNum.Value)
                    {
                        //Rename Abrams////
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

                        ////GAS stuff////
                        if (reticleSO_m829 == null)
                        {
                            ////M829 GAS
                            reticleSO_m829 = ScriptableObject.Instantiate(ReticleMesh.cachedReticles["M1_105_GAS_APFSDS"].tree);
                            reticleSO_m829.name = "120mm_gas_ap";

                            Util.ShallowCopy(reticle_cached_m829, ReticleMesh.cachedReticles["M1_105_GAS_APFSDS"]);
                            reticle_cached_m829.tree = reticleSO_m829;

                            ReticleTree.VerticalBallistic reticle_range_m829 = (reticleSO_m829.planes[0]
                                as ReticleTree.FocalPlane).elements[1]
                                as ReticleTree.VerticalBallistic;
                            reticle_range_m829.projectile = ammo_codex_m829;
                            reticle_range_m829.UpdateBC();

                            ReticleTree.Text reticle_text_m829 = (((reticleSO_m829.planes[0]
                                as ReticleTree.FocalPlane).elements[0])
                                as ReticleTree.Angular).elements[0]
                                as ReticleTree.Text;
                            reticle_text_m829.text = "120-MM\nAPFSDS-T M829\nMETERS";

                            ////M829A1 GAS
                            reticleSO_m829a1 = ScriptableObject.Instantiate(ReticleMesh.cachedReticles["M1_105_GAS_APFSDS"].tree);
                            reticleSO_m829a1.name = "120mm_gas_ap";

                            Util.ShallowCopy(reticle_cached_m829a1, ReticleMesh.cachedReticles["M1_105_GAS_APFSDS"]);
                            reticle_cached_m829a1.tree = reticleSO_m829a1;

                            ReticleTree.VerticalBallistic reticle_range_m829a1 = (reticleSO_m829a1.planes[0]
                                as ReticleTree.FocalPlane).elements[1]
                                as ReticleTree.VerticalBallistic;
                            reticle_range_m829a1.projectile = ammo_codex_m829a1;
                            reticle_range_m829a1.UpdateBC();

                            ReticleTree.Text reticle_text_m829a1 = (((reticleSO_m829a1.planes[0]
                                as ReticleTree.FocalPlane).elements[0])
                                as ReticleTree.Angular).elements[0]
                                as ReticleTree.Text;
                            reticle_text_m829a1.text = "120-MM\nAPFSDS-T M829A1\nMETERS";

                            ////M829A2 GAS
                            reticleSO_m829a2 = ScriptableObject.Instantiate(ReticleMesh.cachedReticles["M1_105_GAS_APFSDS"].tree);
                            reticleSO_m829a2.name = "120mm_gas_ap";

                            Util.ShallowCopy(reticle_cached_m829a2, ReticleMesh.cachedReticles["M1_105_GAS_APFSDS"]);
                            reticle_cached_m829a2.tree = reticleSO_m829a2;

                            ReticleTree.VerticalBallistic reticle_range_m829a2 = (reticleSO_m829a2.planes[0]
                                as ReticleTree.FocalPlane).elements[1]
                                as ReticleTree.VerticalBallistic;
                            reticle_range_m829a2.projectile = ammo_codex_m829a2;
                            reticle_range_m829a2.UpdateBC();

                            ReticleTree.Text reticle_text_m829a2 = (((reticleSO_m829a2.planes[0]
                                as ReticleTree.FocalPlane).elements[0])
                                as ReticleTree.Angular).elements[0]
                                as ReticleTree.Text;
                            reticle_text_m829a2.text = "120-MM\nAPFSDS-T M829A2\nMETERS";

                            ////M829A3 GAS
                            reticleSO_m829a3 = ScriptableObject.Instantiate(ReticleMesh.cachedReticles["M1_105_GAS_APFSDS"].tree);
                            reticleSO_m829a3.name = "120mm_gas_ap";

                            Util.ShallowCopy(reticle_cached_m829a3, ReticleMesh.cachedReticles["M1_105_GAS_APFSDS"]);
                            reticle_cached_m829a3.tree = reticleSO_m829a3;

                            ReticleTree.VerticalBallistic reticle_range_m829a3 = (reticleSO_m829a3.planes[0]
                                as ReticleTree.FocalPlane).elements[1]
                                as ReticleTree.VerticalBallistic;
                            reticle_range_m829a3.projectile = ammo_codex_m829a3;
                            reticle_range_m829a3.UpdateBC();

                            ReticleTree.Text reticle_text_m829a3 = (((reticleSO_m829a3.planes[0]
                                as ReticleTree.FocalPlane).elements[0])
                                as ReticleTree.Angular).elements[0]
                                as ReticleTree.Text;
                            reticle_text_m829a3.text = "120-MM\nAPFSDS-T M829A3\nMETERS";

                            ////M829A4 GAS
                            reticleSO_m829a4 = ScriptableObject.Instantiate(ReticleMesh.cachedReticles["M1_105_GAS_APFSDS"].tree);
                            reticleSO_m829a4.name = "120mm_gas_ap";

                            Util.ShallowCopy(reticle_cached_m829a4, ReticleMesh.cachedReticles["M1_105_GAS_APFSDS"]);
                            reticle_cached_m829a4.tree = reticleSO_m829a4;

                            ReticleTree.VerticalBallistic reticle_range_m829a4 = (reticleSO_m829a4.planes[0]
                                as ReticleTree.FocalPlane).elements[1]
                                as ReticleTree.VerticalBallistic;
                            reticle_range_m829a4.projectile = ammo_codex_m829a4;
                            reticle_range_m829a4.UpdateBC();

                            ReticleTree.Text reticle_text_m829a4 = (((reticleSO_m829a4.planes[0]
                                as ReticleTree.FocalPlane).elements[0])
                                as ReticleTree.Angular).elements[0]
                                as ReticleTree.Text;
                            reticle_text_m829a4.text = "120-MM\nAPFSDS-T M829A4\nMETERS";

                            ////M830 GAS
                            reticleSO_m830 = ScriptableObject.Instantiate(ReticleMesh.cachedReticles["M1_105_GAS_HEAT"].tree);
                            reticleSO_m830.name = "120mm_gas_heat";

                            Util.ShallowCopy(reticle_cached_m830, ReticleMesh.cachedReticles["M1_105_GAS_HEAT"]);
                            reticle_cached_m830.tree = reticleSO_m830;

                            ReticleTree.VerticalBallistic reticle_range_m830 = (reticleSO_m830.planes[0]
                                as ReticleTree.FocalPlane).elements[1]
                                as ReticleTree.VerticalBallistic;
                            reticle_range_m830.projectile = ammo_codex_m830;
                            reticle_range_m830.UpdateBC();

                            ReticleTree.Text reticle_text_m830 = (((reticleSO_m830.planes[0]
                                as ReticleTree.FocalPlane).elements[0])
                                as ReticleTree.Angular).elements[0]
                                as ReticleTree.Text;

                            reticle_text_m830.text = "120-MM\nHEAT-FS-T M830\nMETERS";

                            ////M830A1 GAS
                            reticleSO_m830a1 = ScriptableObject.Instantiate(ReticleMesh.cachedReticles["M1_105_GAS_HEAT"].tree);
                            reticleSO_m830a1.name = "120mm_gas_heat";

                            Util.ShallowCopy(reticle_cached_m830a1, ReticleMesh.cachedReticles["M1_105_GAS_HEAT"]);
                            reticle_cached_m830a1.tree = reticleSO_m830a1;

                            ReticleTree.VerticalBallistic reticle_range_m830a1 = (reticleSO_m830a1.planes[0]
                                as ReticleTree.FocalPlane).elements[1]
                                as ReticleTree.VerticalBallistic;
                            reticle_range_m830a1.projectile = ammo_codex_m830a1;
                            reticle_range_m830a1.UpdateBC();

                            ReticleTree.Text reticle_text_m830a1 = (((reticleSO_m830a1.planes[0]
                                as ReticleTree.FocalPlane).elements[0])
                                as ReticleTree.Angular).elements[0]
                                as ReticleTree.Text;

                            reticle_text_m830a1.text = "120-MM\nHEAT-MP-T M830A1\nMETERS";

                            ////M830A2 GAS
                            reticleSO_m830a2 = ScriptableObject.Instantiate(ReticleMesh.cachedReticles["M1_105_GAS_HEAT"].tree);
                            reticleSO_m830a2.name = "120mm_gas_heat";

                            Util.ShallowCopy(reticle_cached_m830a2, ReticleMesh.cachedReticles["M1_105_GAS_HEAT"]);
                            reticle_cached_m830a2.tree = reticleSO_m830a2;

                            ReticleTree.VerticalBallistic reticle_range_m830a2 = (reticleSO_m830a2.planes[0]
                                as ReticleTree.FocalPlane).elements[1]
                                as ReticleTree.VerticalBallistic;
                            reticle_range_m830a2.projectile = ammo_codex_m830a2;
                            reticle_range_m830a2.UpdateBC();

                            ReticleTree.Text reticle_text_m830a2 = (((reticleSO_m830a2.planes[0]
                                as ReticleTree.FocalPlane).elements[0])
                                as ReticleTree.Angular).elements[0]
                                as ReticleTree.Text;

                            reticle_text_m830a2.text = "120-MM\nHEAT-FS-T M830A2\nMETERS";

                            ////XM1147 GAS
                            reticleSO_xm1147 = ScriptableObject.Instantiate(ReticleMesh.cachedReticles["M1_105_GAS_HEAT"].tree);
                            reticleSO_xm1147.name = "120mm_gas_heat";

                            Util.ShallowCopy(reticle_cached_xm1147, ReticleMesh.cachedReticles["M1_105_GAS_HEAT"]);
                            reticle_cached_xm1147.tree = reticleSO_xm1147;

                            ReticleTree.VerticalBallistic reticle_range_xm1147 = (reticleSO_xm1147.planes[0]
                                as ReticleTree.FocalPlane).elements[1]
                                as ReticleTree.VerticalBallistic;
                            reticle_range_xm1147.projectile = ammo_codex_XM1147;
                            reticle_range_xm1147.UpdateBC();

                            ReticleTree.Text reticle_text_xm1147 = (((reticleSO_xm1147.planes[0]
                                as ReticleTree.FocalPlane).elements[0])
                                as ReticleTree.Angular).elements[0]
                                as ReticleTree.Text;

                            reticle_text_xm1147.text = "120-MM\nAMP-T XM1147\nMETERS";

                            ////LAHAT GAS
                            reticleSO_lahat = ScriptableObject.Instantiate(ReticleMesh.cachedReticles["M1_105_GAS_HEAT"].tree);
                            reticleSO_lahat.name = "120mm_gas_heat";

                            Util.ShallowCopy(reticle_cached_lahat, ReticleMesh.cachedReticles["M1_105_GAS_HEAT"]);
                            reticle_cached_lahat.tree = reticleSO_lahat;

                            ReticleTree.VerticalBallistic reticle_range_lahat = (reticleSO_lahat.planes[0]
                                as ReticleTree.FocalPlane).elements[1]
                                as ReticleTree.VerticalBallistic;
                            reticle_range_lahat.projectile = ammo_codex_lahat;
                            reticle_range_lahat.UpdateBC();

                            ReticleTree.Text reticle_text_lahat = (((reticleSO_lahat.planes[0]
                                as ReticleTree.FocalPlane).elements[0])
                                as ReticleTree.Angular).elements[0]
                                as ReticleTree.Text;

                            reticle_text_lahat.text = "120-MM\nLAHAT\nMETERS";
                        }

                        ReticleMesh gas_m829 = vic.transform.Find("IPM1_rig/HULL/TURRET/GUN/Gun Scripts/Aux sight (GAS)/Reticle Mesh").gameObject.GetComponent<ReticleMesh>();
                        gas_m829.reticleSO = reticleSO_m829;
                        gas_m829.reticle = reticle_cached_m829;
                        gas_m829.SMR = null;
                        gas_m829.Load();

                        ReticleMesh gas_m829a1 = vic.transform.Find("IPM1_rig/HULL/TURRET/GUN/Gun Scripts/Aux sight (GAS)/Reticle Mesh").gameObject.GetComponent<ReticleMesh>();
                        gas_m829a1.reticleSO = reticleSO_m829a1;
                        gas_m829a1.reticle = reticle_cached_m829a1;
                        gas_m829a1.SMR = null;
                        gas_m829a1.Load();

                        ReticleMesh gas_m829a2 = vic.transform.Find("IPM1_rig/HULL/TURRET/GUN/Gun Scripts/Aux sight (GAS)/Reticle Mesh").gameObject.GetComponent<ReticleMesh>();
                        gas_m829a2.reticleSO = reticleSO_m829a2;
                        gas_m829a2.reticle = reticle_cached_m829a2;
                        gas_m829a2.SMR = null;
                        gas_m829a2.Load();

                        ReticleMesh gas_m829a3 = vic.transform.Find("IPM1_rig/HULL/TURRET/GUN/Gun Scripts/Aux sight (GAS)/Reticle Mesh").gameObject.GetComponent<ReticleMesh>();
                        gas_m829a3.reticleSO = reticleSO_m829a3;
                        gas_m829a3.reticle = reticle_cached_m829a3;
                        gas_m829a3.SMR = null;
                        gas_m829a3.Load();

                        ReticleMesh gas_m829a4 = vic.transform.Find("IPM1_rig/HULL/TURRET/GUN/Gun Scripts/Aux sight (GAS)/Reticle Mesh").gameObject.GetComponent<ReticleMesh>();
                        gas_m829a4.reticleSO = reticleSO_m829a4;
                        gas_m829a4.reticle = reticle_cached_m829a4;
                        gas_m829a4.SMR = null;
                        gas_m829a4.Load();

                        ReticleMesh gas_m830 = vic.transform.Find("IPM1_rig/HULL/TURRET/GUN/Gun Scripts/Aux sight (GAS)/Reticle Mesh HEAT").gameObject.GetComponent<ReticleMesh>();
                        gas_m830.reticleSO = reticleSO_m830;
                        gas_m830.reticle = reticle_cached_m830;
                        gas_m830.SMR = null;
                        gas_m830.Load();

                        ReticleMesh gas_m830a1 = vic.transform.Find("IPM1_rig/HULL/TURRET/GUN/Gun Scripts/Aux sight (GAS)/Reticle Mesh HEAT").gameObject.GetComponent<ReticleMesh>();
                        gas_m830a1.reticleSO = reticleSO_m830a1;
                        gas_m830a1.reticle = reticle_cached_m830a1;
                        gas_m830a1.SMR = null;
                        gas_m830a1.Load();

                        ReticleMesh gas_m830a2 = vic.transform.Find("IPM1_rig/HULL/TURRET/GUN/Gun Scripts/Aux sight (GAS)/Reticle Mesh HEAT").gameObject.GetComponent<ReticleMesh>();
                        gas_m830a2.reticleSO = reticleSO_m830a2;
                        gas_m830a2.reticle = reticle_cached_m830a2;
                        gas_m830a2.SMR = null;
                        gas_m830a2.Load();

                        ReticleMesh gas_xm1147 = vic.transform.Find("IPM1_rig/HULL/TURRET/GUN/Gun Scripts/Aux sight (GAS)/Reticle Mesh HEAT").gameObject.GetComponent<ReticleMesh>();
                        gas_xm1147.reticleSO = reticleSO_xm1147;
                        gas_xm1147.reticle = reticle_cached_xm1147;
                        gas_xm1147.SMR = null;
                        gas_xm1147.Load();

                        ReticleMesh gas_lahat = vic.transform.Find("IPM1_rig/HULL/TURRET/GUN/Gun Scripts/Aux sight (GAS)/Reticle Mesh HEAT").gameObject.GetComponent<ReticleMesh>();
                        gas_lahat.reticleSO = reticleSO_lahat;
                        gas_lahat.reticle = reticle_cached_lahat;
                        gas_lahat.SMR = null;
                        gas_lahat.Load();
                        ////End////

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

                        // Abrams loadout management
                        LoadoutManager loadoutManager = vic.GetComponent<LoadoutManager>();
                        AmmoType.AmmoClip[] ammo_clip_types = new AmmoType.AmmoClip[] { };

                        if (vic.FriendlyName == "M1A1" + m1a1Armor.Value || vic.FriendlyName == "M1E1" + m1e1Armor.Value)
                        {
                            AmmoClipCodexScriptable firstClipCodex = abrams_ammotype[vic.FriendlyName == "M1A1" + m1a1Armor.Value ? m1a1firstAmmo.Value : m1e1firstAmmo.Value];
                            AmmoClipCodexScriptable secondClipCodex = abrams_ammotype[vic.FriendlyName == "M1A1" + m1a1Armor.Value ? m1a1secondAmmo.Value : m1e1secondAmmo.Value];
                            AmmoClipCodexScriptable thirdClipCodex = abrams_ammotype[vic.FriendlyName == "M1A1" + m1a1Armor.Value ? m1a1thirdAmmo.Value : m1e1thirdAmmo.Value];
                            AmmoClipCodexScriptable fourthClipCodex = abrams_ammotype[vic.FriendlyName == "M1A1" + m1a1Armor.Value ? m1a1fourthAmmo.Value : m1e1fourthAmmo.Value];

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

                        //Guidance computer for LAHAT
                        GameObject guidance_computer_obj = new GameObject("Abrams Guidance Computer");
                        guidance_computer_obj.transform.parent = vic.transform;
                        guidance_computer_obj.AddComponent<MissileGuidanceUnit>();

                        guidance_computer_obj.AddComponent<Reparent>();
                        Reparent reparent = guidance_computer_obj.GetComponent<Reparent>();
                        reparent.NewParent = vic_go.transform.Find("IPM1_rig/HULL/TURRET/Turret Scripts/GPS/").gameObject.transform;
                        typeof(Reparent).GetMethod("Awake", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(reparent, new object[] { });

                        MissileGuidanceUnit computer = guidance_computer_obj.GetComponent<MissileGuidanceUnit>();
                        //computer.AimElement = mainGunInfo.FCS.AimTransform;
                        computer.AimElement = vic_go.transform.Find("IPM1_rig/HULL/TURRET/Turret Scripts/GPS/laser/").gameObject.transform;
                        mainGun.GuidanceUnit = computer;
                    }
                }
            }

            yield break;
        }

        public static void LateUpdate() {
            if (AbramsAMPMod.gameManager == null) return;

            CameraSlot cam = AbramsAMPMod.camManager._currentCamSlot;

            if (cam == null) return;
            if (cam.name != "Aux sight (GAS)") return;
            if (AbramsAMPMod.playerManager.CurrentPlayerWeapon.Name != "120mm gun M256") return;

            AmmoType currentAmmo = AbramsAMPMod.playerManager.CurrentPlayerWeapon.FCS.CurrentAmmoType;
            int reticleId = (currentAmmo.Name == "M829 APFSDS-T" || currentAmmo.Name == "M829A1 APFSDS-T") ? 0 : 2;

            GameObject reticle = cam.transform.GetChild(reticleId).gameObject;

            if (!reticle.activeSelf)
            {
                reticle.SetActive(true);
            }


            Vehicle vic = (Vehicle)AbramsAMPMod.playerManager.CurrentPlayerUnit;
            var gps = vic.transform.gameObject.transform.Find("IPM1_rig/HULL/TURRET/Turret Scripts/GPS").transform;
            if (gps == null || gps.gameObject.activeSelf == false) return;

            FireControlSystem FCS = AbramsAMPMod.playerManager.CurrentPlayerWeapon.FCS;
            ParticleSystem[] particleSystem = AbramsAMPMod.playerManager.CurrentPlayerWeapon.Weapon.MuzzleEffects;
            //US Vehicles/M1IP/IPM1_rig/HULL/TURRET/Turret Scripts/GPS

            if (FCS.CurrentAmmoType.Name == "LAHAT")
            {
                gps.GetChild(0).gameObject.SetActive(false);
                gps.GetChild(2).gameObject.SetActive(true);

                particleSystem[0].transform.GetChild(0).transform.gameObject.SetActive(false);
                particleSystem[0].transform.GetChild(1).transform.gameObject.SetActive(false);
                particleSystem[0].transform.GetChild(3).transform.gameObject.SetActive(false);
            }
            else
            {
                gps.GetChild(0).gameObject.SetActive(true);
                gps.GetChild(2).gameObject.SetActive(false);

                particleSystem[0].transform.GetChild(0).transform.gameObject.SetActive(true);
                particleSystem[0].transform.GetChild(1).transform.gameObject.SetActive(true);
                particleSystem[0].transform.GetChild(3).transform.gameObject.SetActive(true);
            }

        }

        public static void Init()
        {
            if (gun_m256 == null)
            {
                //borrow existing ammo and armor attributes
                foreach (AmmoCodexScriptable s in Resources.FindObjectsOfTypeAll(typeof(AmmoCodexScriptable)))
                {
                    if (s.AmmoType.Name == "M833 APFSDS-T") ammo_m833 = s.AmmoType;
                    if (s.AmmoType.Name == "M456 HEAT-FS-T") ammo_m456 = s.AmmoType;
                    if (s.AmmoType.Name == "BGM-71C I-TOW") ammo_bgm71 = s.AmmoType;
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
                    if (s.ArmorType.Name == "composite skirt") armor_commmandershatcharmor_HU = s.ArmorType;
                    if (s.ArmorType.Name == "composite skirt") armor_loadershatcharmor_HU = s.ArmorType;
                    if (s.ArmorType.Name == "composite skirt") armor_drivershatcharmor_HU = s.ArmorType;
                    if (s.ArmorType.Name == "composite skirt") armor_turretringarmor_HU = s.ArmorType;
                    if (s.ArmorType.Name == "composite skirt") armor_gunmantletfacearmor_HU = s.ArmorType;
                    if (s.ArmorType.Name == "tracks") armor_trackarmor_HU = s.ArmorType;

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
                ammo_m829a1.MuzzleVelocity = 1575f;
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
                ammo_m830.Name = "M830 HEAT-FS-T";
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

                // m830a1
                ammo_m830a1 = new AmmoType();
                Util.ShallowCopy(ammo_m830a1, ammo_m456);
                ammo_m830a1.Name = "M830A1 HEAT-MP-T";
                ammo_m830a1.Caliber = 120;
                ammo_m830a1.RhaPenetration = 480;
                ammo_m830a1.TntEquivalentKg = 2.721f;
                ammo_m830a1.MuzzleVelocity = 1400f;
                ammo_m830a1.Mass = 11.4f;
                ammo_m830a1.CertainRicochetAngle = 5.0f;
                ammo_m830a1.ShatterOnRicochet = false;
                ammo_m830a1.DetonateSpallCount = mpatFragments.Value; //Number of fragments generated when detonated (PD). Higher value means higher performance hit.
                ammo_m830a1.SpallMultiplier = 0.5f;
                ammo_m830a1.MaxSpallRha = 80f;
                ammo_m830a1.MinSpallRha = 1f;
                //ammo_m830a1.ImpactFuseTime = 0.000357143f; //0.5 meters after impact //delay removed since it negatively affects armor penetration

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
                ammo_m830a2.Name = "M830A2 IHEAT-FS-T";
                ammo_m830a2.Caliber = 120;
                ammo_m830a2.RhaPenetration = 1200;
                ammo_m830a2.TntEquivalentKg = 2.721f;
                ammo_m830a2.MuzzleVelocity = 1240f;
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
                clip_m830a2.Name = "M830A2 IHEAT-FS-T";
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
                ammo_xm1147.MaxSpallRha = 180f;
                ammo_xm1147.MinSpallRha = 55f;
                ammo_xm1147.MuzzleVelocity = 1410f;
                ammo_xm1147.Mass = 11.4f;
                ammo_xm1147.CertainRicochetAngle = 5.0f;
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

                // lahat
                ammo_lahat = new AmmoType();
                Util.ShallowCopy(ammo_lahat, ammo_bgm71);
                ammo_lahat.Name = "LAHAT";
                ammo_lahat.Guidance = AmmoType.GuidanceType.Laser;
                ammo_lahat.Caliber = 120;
                ammo_lahat.RhaPenetration = 800f;
                ammo_lahat.MuzzleVelocity = 300f;
                ammo_lahat.Mass = 13f;
                ammo_lahat.ArmingDistance = 50;
                ammo_lahat.TntEquivalentKg = 4.5f;
                ammo_lahat.TurnSpeed = 1.5f;
                ammo_lahat.MaxSpallRha = 30f;
                ammo_lahat.MinSpallRha = 5f;
                ammo_lahat.CertainRicochetAngle = 5.0f;
                ammo_lahat.ShotVisual = ammo_bgm71.ShotVisual;
                ammo_lahat.MaximumRange = 6000f;
                ammo_lahat.RangedFuseTime = 20f;
                ammo_lahat.UseTracer = true;
                ammo_lahat.Tandem = true;
                ammo_lahat.SpallMultiplier = 1.5f;

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

                //armor_hullsideCompositearmor_HU = new ArmorType();
                //Util.ShallowCopy(armor_hullsideCompositearmor_HU, armor_hullsidearmor_HU);
                //armor_hullsideCompositearmor_HU.RhaeMultiplierCe = 50.35f; //default composite skirt 1.5
                //armor_hullsideCompositearmor_HU.RhaeMultiplierKe = 50.9f; //default composite skirt 0.8
                //armor_hullsideCompositearmor_HU.Name = "Abrams hull side special composite";

                //armor_codex_hullsideCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                //armor_codex_hullsideCompositearmor_HU.name = "Abrams hull side special composite";
                //armor_codex_hullsideCompositearmor_HU.ArmorType = armor_hullsideCompositearmor_HU;
                //armor_hullsideCompositearmor_HU = new ArmorType();

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
                armor_trackSpecialarmor_HU.RhaeMultiplierCe = 15f; //default composite skirt 1.5
                armor_trackSpecialarmor_HU.RhaeMultiplierKe = 15f; //default composite skirt 0.8
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

                ////Visual models////
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

                ammo_m830a1_vis = GameObject.Instantiate(ammo_m456.VisualModel);
                ammo_m830a1_vis.name = "M830a1 visual";
                ammo_m830a1.VisualModel = ammo_m830a1_vis;
                ammo_m830a1.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_m830a1;
                ammo_m830a1.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_m830a1;

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
