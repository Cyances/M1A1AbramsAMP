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
        static MelonPreferences_Entry<bool> demigodArmor;

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
        //HU Variant
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

        static ArmorType armor_gunbarrel_HU;
        static ArmorCodexScriptable armor_codex_gunbarrelImprovedarmor_HU;
        static ArmorType armor_gunbarrelImprovedarmor_HU;

        static ArmorType armor_blowoutpanel_HU;
        static ArmorCodexScriptable armor_codex_blowoutpanelCompositearmorC_HU;
        static ArmorType armor_blowoutpanelCompositearmorC_HU;

        static ArmorCodexScriptable armor_codex_blowoutpanelCompositearmorL_HU;
        static ArmorType armor_blowoutpanelCompositearmorL_HU;

        static ArmorCodexScriptable armor_codex_blowoutpanelCompositearmorR_HU;
        static ArmorType armor_blowoutpanelCompositearmorR_HU;

        static ArmorType armor_bustlefirewall_HU;
        static ArmorCodexScriptable armor_codex_bustleImprovedfirewall_HU;
        static ArmorType armor_bustleImprovedfirewall_HU;

        static ArmorType armor_turretrearnera_HU;
        static ArmorCodexScriptable armor_codex_turretrearSpecialarray_HU;
        static ArmorType armor_turretrearSpecialarray_HU;

        static ArmorType armor_GPShousing_HU;
        static ArmorCodexScriptable armor_codex_GPSImprovedhousing_HU;
        static ArmorType armor_GPSImprovedhousing_HU;

        static ArmorType armor_GPSdoor_HU;
        static ArmorCodexScriptable armor_codex_GPSImproveddoor_HU;
        static ArmorType armor_GPSImproveddoor_HU;

        //HC Variant
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

        //HA Variant
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
                ["XM1147"] = clip_codex_XM1147,
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
                ["XM1147"] = ammo_codex_XM1147,
                ["LAHAT"] = ammo_codex_lahat,
            };

            ////Abrams armor list
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
                ["HU"] = armor_codex_gunbarrelImprovedarmor_HU,
                ["HU"] = armor_codex_blowoutpanelCompositearmorC_HU,
                ["HU"] = armor_codex_blowoutpanelCompositearmorL_HU,
                ["HU"] = armor_codex_blowoutpanelCompositearmorR_HU,
                ["HU"] = armor_codex_bustleImprovedfirewall_HU,
                ["HU"] = armor_codex_turretrearSpecialarray_HU,
                ["HU"] = armor_codex_GPSImprovedhousing_HU,
                ["HU"] = armor_codex_GPSImproveddoor_HU,

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
                ["HU"] = hullrearCompositearray,
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

            ////Assign modified armor to M1A1HU
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

                VariableArmor gunbarrelImprovedarmor_DU = armour.GetComponent<VariableArmor>();
                if (gunbarrelImprovedarmor_DU == null) continue;
                if (gunbarrelImprovedarmor_DU.Unit == null) continue;
                if (gunbarrelImprovedarmor_DU.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (gunbarrelImprovedarmor_DU.Name != "main gun barrel") continue;

                FieldInfo gunbarrelImproved_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                gunbarrelImproved_HU.SetValue(gunbarrelImprovedarmor_DU, armor_codex_gunbarrelImprovedarmor_HU);

                MelonLogger.Msg(gunbarrelImprovedarmor_DU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor bustlefirewallImprovedarmor_DU = armour.GetComponent<VariableArmor>();
                if (bustlefirewallImprovedarmor_DU == null) continue;
                if (bustlefirewallImprovedarmor_DU.Unit == null) continue;
                if (bustlefirewallImprovedarmor_DU.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (bustlefirewallImprovedarmor_DU.Name != "bustle racks firewall") continue;

                FieldInfo bustlefirewallImproved_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                bustlefirewallImproved_HU.SetValue(bustlefirewallImprovedarmor_DU, armor_codex_bustleImprovedfirewall_HU);

                MelonLogger.Msg(bustlefirewallImprovedarmor_DU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor blowoutpanelCompositearmorC = armour.GetComponent<VariableArmor>();
                if (blowoutpanelCompositearmorC == null) continue;
                if (blowoutpanelCompositearmorC.Unit == null) continue;
                if (blowoutpanelCompositearmorC.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (blowoutpanelCompositearmorC.Name != "center blowout panel") continue;

                FieldInfo blowoutpanelCompositeC_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                blowoutpanelCompositeC_HU.SetValue(blowoutpanelCompositearmorC, armor_codex_blowoutpanelCompositearmorC_HU);

                MelonLogger.Msg(blowoutpanelCompositearmorC.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor blowoutpanelCompositearmorL = armour.GetComponent<VariableArmor>();
                if (blowoutpanelCompositearmorL == null) continue;
                if (blowoutpanelCompositearmorL.Unit == null) continue;
                if (blowoutpanelCompositearmorL.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (blowoutpanelCompositearmorL.Name != "left blowout panel") continue;

                FieldInfo blowoutpanelCompositeL_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                blowoutpanelCompositeL_HU.SetValue(blowoutpanelCompositearmorL, armor_codex_blowoutpanelCompositearmorL_HU);

                MelonLogger.Msg(blowoutpanelCompositearmorL.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor blowoutpanelCompositearmorR = armour.GetComponent<VariableArmor>();
                if (blowoutpanelCompositearmorR == null) continue;
                if (blowoutpanelCompositearmorR.Unit == null) continue;
                if (blowoutpanelCompositearmorR.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (blowoutpanelCompositearmorR.Name != "right blowout panel") continue;

                FieldInfo blowoutpanelCompositeR_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                blowoutpanelCompositeR_HU.SetValue(blowoutpanelCompositearmorR, armor_codex_blowoutpanelCompositearmorR_HU);

                MelonLogger.Msg(blowoutpanelCompositearmorR.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor turretrearSpecialarmor_HU = armour.GetComponent<VariableArmor>();
                if (turretrearSpecialarmor_HU == null) continue;
                if (turretrearSpecialarmor_HU.Unit == null) continue;
                if (turretrearSpecialarmor_HU.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (turretrearSpecialarmor_HU.Name != "turret rear face") continue;

                FieldInfo turretrearSpecial_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                turretrearSpecial_HU.SetValue(turretrearSpecialarmor_HU, armor_codex_turretrearSpecialarray_HU);

                MelonLogger.Msg(turretrearSpecialarmor_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor GPShousingImpvrovedarmor_HU = armour.GetComponent<VariableArmor>();
                if (GPShousingImpvrovedarmor_HU == null) continue;
                if (GPShousingImpvrovedarmor_HU.Unit == null) continue;
                if (GPShousingImpvrovedarmor_HU.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (GPShousingImpvrovedarmor_HU.Name != "GPS doghouse") continue;

                FieldInfo GPShousingImproved_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                GPShousingImproved_HU.SetValue(GPShousingImpvrovedarmor_HU, armor_codex_GPSImprovedhousing_HU);

                MelonLogger.Msg(GPShousingImpvrovedarmor_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor GPShousingImpvrovedarmor_HU = armour.GetComponent<VariableArmor>();
                if (GPShousingImpvrovedarmor_HU == null) continue;
                if (GPShousingImpvrovedarmor_HU.Unit == null) continue;
                if (GPShousingImpvrovedarmor_HU.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (GPShousingImpvrovedarmor_HU.Name != "GPS doghouse door") continue;

                FieldInfo GPShousingImproved_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                GPShousingImproved_HU.SetValue(GPShousingImpvrovedarmor_HU, armor_codex_GPSImproveddoor_HU);

                MelonLogger.Msg(GPShousingImpvrovedarmor_HU.ArmorType);
            }

            ////M1A1HU UniformArmor pieces
            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor hullsideCompositearray = armour.GetComponent<UniformArmor>();
                if (hullsideCompositearray == null) continue;
                if (hullsideCompositearray.Unit == null) continue;
                if (hullsideCompositearray.Unit.FriendlyName != "M1IP" || m1a1Armor.Value != "HU") continue;
                if (hullsideCompositearray.Name == "hull side")
                {
                    hullsideCompositearray.PrimaryHeatRha = demigodArmor.Value ? 10000f : 300f;
                    hullsideCompositearray.PrimarySabotRha = demigodArmor.Value ? 10000f : 200f;
                }

                //MelonLogger.Msg("Composite hull side armor: Loaded");
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
                    hullrearCompositearray.PrimaryHeatRha = demigodArmor.Value ? 10000f : 300f;
                    hullrearCompositearray.PrimarySabotRha = demigodArmor.Value ? 10000f : 200f;
                }

                //MelonLogger.Msg("Composite hull rear armor: Loaded");
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
                    hullfloorCompositearray.PrimaryHeatRha = demigodArmor.Value ? 10000f : 300f;
                    hullfloorCompositearray.PrimarySabotRha = demigodArmor.Value ? 10000f : 200f;
                }

                //MelonLogger.Msg("Composite hull floor armor: Loaded");
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
                    hullroofCompositearray.PrimaryHeatRha = demigodArmor.Value ? 10000f : 300f;
                    hullroofCompositearray.PrimarySabotRha = demigodArmor.Value ? 10000f : 200f;
                }

                //MelonLogger.Msg("Composite hull roof armor: Loaded");
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
                    firewallSpalllining.PrimaryHeatRha = demigodArmor.Value ? 10000f : 30f;
                    firewallSpalllining.PrimarySabotRha = demigodArmor.Value ? 10000f : 30f;
                }

                //MelonLogger.Msg("Spall lining: Loaded");
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
                    ammorackdoorarray.PrimaryHeatRha = demigodArmor.Value ? 10000f : 45f;
                    ammorackdoorarray.PrimarySabotRha = demigodArmor.Value ? 10000f : 45f;
                }

                //MelonLogger.Msg("Composite ammo rack door: Loaded");
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
                    enginedeckCompositearray.PrimaryHeatRha = demigodArmor.Value ? 10000f : 350f;
                    enginedeckCompositearray.PrimarySabotRha = demigodArmor.Value ? 10000f : 250f;
                }

                //MelonLogger.Msg("Composite engine deck armor: Loaded");
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
                    fenderCompositearray.PrimaryHeatRha = demigodArmor.Value ? 10000f : 100f;
                    fenderCompositearray.PrimarySabotRha = demigodArmor.Value ? 10000f : 50f;
                }

                //MelonLogger.Msg("Composite fender armor: Loaded");
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
                    sideskirtCompositearray.PrimaryHeatRha = demigodArmor.Value ? 10000f : 550f;
                    sideskirtCompositearray.PrimarySabotRha = demigodArmor.Value ? 10000f : 300f;
                }

                //MelonLogger.Msg("Composite side skirt: Loaded");
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
                    gunnersightCompositearray.PrimaryHeatRha = demigodArmor.Value ? 10000f : 50f;
                    gunnersightCompositearray.PrimarySabotRha = demigodArmor.Value ? 10000f : 50f;
                }

                //MelonLogger.Msg("Special gunner sight armor: Loaded");
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
                    sprocketwheelImprovedarmor.PrimaryHeatRha = demigodArmor.Value ? 10000f : 50f;
                    sprocketwheelImprovedarmor.PrimarySabotRha = demigodArmor.Value ? 10000f : 50f;
                }

                //MelonLogger.Msg("Improved sprocket wheel armor: Loaded");
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
                    roadwheelImprovedarmor.PrimaryHeatRha = demigodArmor.Value ? 10000f : 50f;
                    roadwheelImprovedarmor.PrimarySabotRha = demigodArmor.Value ? 10000f : 50f;
                }

                //MelonLogger.Msg("Improved road wheel armor: Loaded");
                MelonLogger.Msg("M1A1HU UniformArmor: Modified");
            }
            ////End

            ////Assign modified armor to M1E1HU
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

                VariableArmor gunbarrelImprovedarmor_DU = armour.GetComponent<VariableArmor>();
                if (gunbarrelImprovedarmor_DU == null) continue;
                if (gunbarrelImprovedarmor_DU.Unit == null) continue;
                if (gunbarrelImprovedarmor_DU.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (gunbarrelImprovedarmor_DU.Name != "main gun barrel") continue;

                FieldInfo gunbarrelImproved_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                gunbarrelImproved_HU.SetValue(gunbarrelImprovedarmor_DU, armor_codex_gunbarrelImprovedarmor_HU);

                MelonLogger.Msg(gunbarrelImprovedarmor_DU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor bustlefirewallImprovedarmor_DU = armour.GetComponent<VariableArmor>();
                if (bustlefirewallImprovedarmor_DU == null) continue;
                if (bustlefirewallImprovedarmor_DU.Unit == null) continue;
                if (bustlefirewallImprovedarmor_DU.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (bustlefirewallImprovedarmor_DU.Name != "bustle racks firewall") continue;

                FieldInfo bustlefirewallImproved_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                bustlefirewallImproved_HU.SetValue(bustlefirewallImprovedarmor_DU, armor_codex_bustleImprovedfirewall_HU);

                MelonLogger.Msg(bustlefirewallImprovedarmor_DU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor blowoutpanelCompositearmorC = armour.GetComponent<VariableArmor>();
                if (blowoutpanelCompositearmorC == null) continue;
                if (blowoutpanelCompositearmorC.Unit == null) continue;
                if (blowoutpanelCompositearmorC.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (blowoutpanelCompositearmorC.Name != "center blowout panel") continue;

                FieldInfo blowoutpanelCompositeC_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                blowoutpanelCompositeC_HU.SetValue(blowoutpanelCompositearmorC, armor_codex_blowoutpanelCompositearmorC_HU);

                MelonLogger.Msg(blowoutpanelCompositearmorC.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor blowoutpanelCompositearmorL = armour.GetComponent<VariableArmor>();
                if (blowoutpanelCompositearmorL == null) continue;
                if (blowoutpanelCompositearmorL.Unit == null) continue;
                if (blowoutpanelCompositearmorL.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (blowoutpanelCompositearmorL.Name != "left blowout panel") continue;

                FieldInfo blowoutpanelCompositeL_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                blowoutpanelCompositeL_HU.SetValue(blowoutpanelCompositearmorL, armor_codex_blowoutpanelCompositearmorL_HU);

                MelonLogger.Msg(blowoutpanelCompositearmorL.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor blowoutpanelCompositearmorR = armour.GetComponent<VariableArmor>();
                if (blowoutpanelCompositearmorR == null) continue;
                if (blowoutpanelCompositearmorR.Unit == null) continue;
                if (blowoutpanelCompositearmorR.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (blowoutpanelCompositearmorR.Name != "right blowout panel") continue;

                FieldInfo blowoutpanelCompositeR_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                blowoutpanelCompositeR_HU.SetValue(blowoutpanelCompositearmorR, armor_codex_blowoutpanelCompositearmorR_HU);

                MelonLogger.Msg(blowoutpanelCompositearmorR.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor turretrearSpecialarmor_HU = armour.GetComponent<VariableArmor>();
                if (turretrearSpecialarmor_HU == null) continue;
                if (turretrearSpecialarmor_HU.Unit == null) continue;
                if (turretrearSpecialarmor_HU.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (turretrearSpecialarmor_HU.Name != "turret rear face") continue;

                FieldInfo turretrearSpecial_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                turretrearSpecial_HU.SetValue(turretrearSpecialarmor_HU, armor_codex_turretrearSpecialarray_HU);

                MelonLogger.Msg(turretrearSpecialarmor_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor GPShousingImpvrovedarmor_HU = armour.GetComponent<VariableArmor>();
                if (GPShousingImpvrovedarmor_HU == null) continue;
                if (GPShousingImpvrovedarmor_HU.Unit == null) continue;
                if (GPShousingImpvrovedarmor_HU.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (GPShousingImpvrovedarmor_HU.Name != "GPS doghouse") continue;

                FieldInfo GPShousingImproved_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                GPShousingImproved_HU.SetValue(GPShousingImpvrovedarmor_HU, armor_codex_GPSImprovedhousing_HU);

                MelonLogger.Msg(GPShousingImpvrovedarmor_HU.ArmorType);
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                VariableArmor GPShousingImpvrovedarmor_HU = armour.GetComponent<VariableArmor>();
                if (GPShousingImpvrovedarmor_HU == null) continue;
                if (GPShousingImpvrovedarmor_HU.Unit == null) continue;
                if (GPShousingImpvrovedarmor_HU.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (GPShousingImpvrovedarmor_HU.Name != "GPS doghouse door") continue;

                FieldInfo GPShousingImproved_HU = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                GPShousingImproved_HU.SetValue(GPShousingImpvrovedarmor_HU, armor_codex_GPSImproveddoor_HU);

                MelonLogger.Msg(GPShousingImpvrovedarmor_HU.ArmorType);
            }

            ////M1E1HU UniformArmor pieces
            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor hullsideCompositearray = armour.GetComponent<UniformArmor>();
                if (hullsideCompositearray == null) continue;
                if (hullsideCompositearray.Unit == null) continue;
                if (hullsideCompositearray.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;

                if (hullsideCompositearray.Name == "hull side")
                {
                    hullsideCompositearray.PrimaryHeatRha = demigodArmor.Value ? 10000f : 300f;
                    hullsideCompositearray.PrimarySabotRha = demigodArmor.Value ? 10000f : 200f;
                }

                //MelonLogger.Msg("Composite hull side armor: Loaded");
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
                    hullrearCompositearray.PrimaryHeatRha = demigodArmor.Value ? 10000f : 300f;
                    hullrearCompositearray.PrimarySabotRha = demigodArmor.Value ? 10000f : 200f;
                }

                //MelonLogger.Msg("Composite hull rear armor: Loaded");
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
                    hullfloorCompositearray.PrimaryHeatRha = demigodArmor.Value ? 10000f : 300f;
                    hullfloorCompositearray.PrimarySabotRha = demigodArmor.Value ? 10000f : 200f;
                }

                //MelonLogger.Msg("Composite hull floor armor: Loaded");
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
                    hullroofCompositearray.PrimaryHeatRha = demigodArmor.Value ? 10000f : 300f;
                    hullroofCompositearray.PrimarySabotRha = demigodArmor.Value ? 10000f : 200f;
                }

                //MelonLogger.Msg("Composite hull roof armor: Loaded");
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
                    firewallSpalllining.PrimaryHeatRha = demigodArmor.Value ? 10000f : 30f;
                    firewallSpalllining.PrimarySabotRha = demigodArmor.Value ? 10000f : 30f;
                }

                //MelonLogger.Msg("Spall lining: Loaded");
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
                    ammorackdoorarray.PrimaryHeatRha = demigodArmor.Value ? 10000f : 45f;
                    ammorackdoorarray.PrimarySabotRha = demigodArmor.Value ? 10000f : 45f;
                }

                //MelonLogger.Msg("Composite ammo rack door: Loaded");
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
                    enginedeckCompositearray.PrimaryHeatRha = demigodArmor.Value ? 10000f : 350f;
                    enginedeckCompositearray.PrimarySabotRha = demigodArmor.Value ? 10000f : 250f;
                }

                //MelonLogger.Msg("Composite engine deck armor: Loaded");
            }

            foreach (GameObject armour in GameObject.FindGameObjectsWithTag("Penetrable"))
            {
                if (armour == null) continue;

                UniformArmor fenderCompositearray = armour.GetComponent<UniformArmor>();
                if (fenderCompositearray == null) continue;
                if (fenderCompositearray.Unit == null) continue;
                if (fenderCompositearray.Unit.FriendlyName != "M1" || (m1e1Convert.Value == true && m1e1Armor.Value != "HU")) continue;
                if (fenderCompositearray.Name == "fender")
                {
                    fenderCompositearray.PrimaryHeatRha = demigodArmor.Value ? 10000f : 100f;
                    fenderCompositearray.PrimarySabotRha = demigodArmor.Value ? 10000f : 50f;
                }

                //MelonLogger.Msg("Composite fender armor: Loaded");
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
                    sideskirtCompositearray.PrimaryHeatRha = demigodArmor.Value ? 10000f : 550f;
                    sideskirtCompositearray.PrimarySabotRha = demigodArmor.Value ? 10000f : 300f;
                }

                //MelonLogger.Msg("Composite side skirt: Loaded");
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
                    gunnersightCompositearray.PrimaryHeatRha = demigodArmor.Value ? 10000f : 50f;
                    gunnersightCompositearray.PrimarySabotRha = demigodArmor.Value ? 10000f : 50f;
                }

                //MelonLogger.Msg("Special gunner sight armor: Loaded");
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
                    sprocketwheelImprovedarmor.PrimaryHeatRha = demigodArmor.Value ? 10000f : 50f;
                    sprocketwheelImprovedarmor.PrimarySabotRha = demigodArmor.Value ? 10000f : 50f;
                }

                //MelonLogger.Msg("Improved sprocket wheel armor: Loaded");
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
                    roadwheelImprovedarmor.PrimaryHeatRha = demigodArmor.Value ? 10000f : 50f;
                    roadwheelImprovedarmor.PrimarySabotRha = demigodArmor.Value ? 10000f : 50f;
                }

                //MelonLogger.Msg("Improved road wheel armor: Loaded");
                MelonLogger.Msg("M1E1HU UniformArmor: Modified");
            }
            ////End

            ////Assign modified armor to M1A1HC
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
            ////End

            ////Assign modified armor to M1E1HC
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
            ////End

            ////Assign modified armor to M1A1HA
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
            ////End

            ////Assign modified armor to M1E1HA
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
            ////End
            
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
                    if (s.ArmorType.Name == "gun steel") armor_gunbarrel_HU = s.ArmorType;
                    if (s.ArmorType.Name == "composite skirt") armor_bustlefirewall_HU = s.ArmorType;
                    if (s.ArmorType.Name == "composite skirt") armor_blowoutpanel_HU = s.ArmorType;
                    if (s.ArmorType.Name == "special armor") armor_turretrearnera_HU = s.ArmorType;
                    if (s.ArmorType.Name == "composite skirt") armor_GPShousing_HU = s.ArmorType;
                    if (s.ArmorType.Name == "composite skirt") armor_GPSdoor_HU = s.ArmorType;

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
                ammo_m830.Name = "M830 HEAT-FS-T";
                ammo_m830.Caliber = 120;
                ammo_m830.RhaPenetration = 600;
                ammo_m830.TntEquivalentKg = 1.814f;
                ammo_m830.MuzzleVelocity = 1140f;
                ammo_m830.Mass = 13.5f;
                ammo_m830.CertainRicochetAngle = 8.0f;
                ammo_m830.ShatterOnRicochet = false;
                ammo_m830.SpallMultiplier = 1.5f;

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
                ammo_m830a1.MaxSpallRha = 60f;
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
                ammo_m830a2.CertainRicochetAngle = 5.0f;
                ammo_m830a2.ShatterOnRicochet = false;
                ammo_m830a2.DetonateSpallCount = 150;
                ammo_m830a2.SpallMultiplier = 2f;
                ammo_m830a2.MaxSpallRha = 50f;
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
                ammo_xm1147.TntEquivalentKg = 3.45f; //50% more power than equivalent load
                ammo_xm1147.MaxSpallRha = 180f;
                ammo_xm1147.MinSpallRha = 55f;
                ammo_xm1147.MuzzleVelocity = 1410f;
                ammo_xm1147.Mass = 11.4f;
                ammo_xm1147.CertainRicochetAngle = 1.0f;
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

                ////HU armor modifiers
                armor_superCompositeskirt_HU = new ArmorType();
                Util.ShallowCopy(armor_superCompositeskirt_HU, armor_compositeskirt_HU);
                armor_superCompositeskirt_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 11f; //default 1.5
                armor_superCompositeskirt_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 6f; //default 0.8
                armor_superCompositeskirt_HU.Name = "Abrams HU super special composite skirt";

                armor_codex_superCompositeskirt_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_superCompositeskirt_HU.name = "Abrams HU super special composite skirt";
                armor_codex_superCompositeskirt_HU.ArmorType = armor_superCompositeskirt_HU;

                armor_cheeksDUarmor_HU = new ArmorType();
                Util.ShallowCopy(armor_cheeksDUarmor_HU, armor_cheeksnera_HU);
                armor_cheeksDUarmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 2.2f; //default 1.3
                armor_cheeksDUarmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 1.2f; //default 0.55
                armor_cheeksDUarmor_HU.Name = "Abrams HU DU armor turret cheeks";

                armor_codex_cheeksDUarmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_cheeksDUarmor_HU.name = "Abrams HU DU armor turret cheeks";
                armor_codex_cheeksDUarmor_HU.ArmorType = armor_cheeksDUarmor_HU;
                armor_cheeksDUarmor_HU = new ArmorType();

                armor_fronthullDUarmor_HU = new ArmorType();
                Util.ShallowCopy(armor_fronthullDUarmor_HU, armor_fronthullnera_HU);
                armor_fronthullDUarmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 2.2f; //default 1.3
                armor_fronthullDUarmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 1.4f; //default 0.45
                armor_fronthullDUarmor_HU.Name = "Abrams HU DU armor hull front";

                armor_codex_fronthullDUarmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_fronthullDUarmor_HU.name = "Abrams HU DU armor hull front";
                armor_codex_fronthullDUarmor_HU.ArmorType = armor_fronthullDUarmor_HU;
                armor_fronthullDUarmor_HU = new ArmorType();

                armor_mantletDUarmor_HU = new ArmorType();
                Util.ShallowCopy(armor_mantletDUarmor_HU, armor_mantletnera_HU);
                armor_mantletDUarmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 2.15f; //default 1.3
                armor_mantletDUarmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 1.5f; //default 1.4
                armor_mantletDUarmor_HU.Name = "Abrams HU DU armor mantlet";

                armor_codex_mantletDUarmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_mantletDUarmor_HU.name = "Abrams HU DU armor mantlet";
                armor_codex_mantletDUarmor_HU.ArmorType = armor_mantletDUarmor_HU;
                armor_mantletDUarmor_HU = new ArmorType();

                armor_turretsidesDUarmor_HU = new ArmorType();
                Util.ShallowCopy(armor_turretsidesDUarmor_HU, armor_turretsidesnera_HU);
                armor_turretsidesDUarmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 4.4f; //default 1.3
                armor_turretsidesDUarmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 2.21f; //default 1.4
                armor_turretsidesDUarmor_HU.Name = "Abrams HU DU armor turret sides";

                armor_codex_turretsidesDUarmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_turretsidesDUarmor_HU.name = "Abrams HU DU armor turret sides";
                armor_codex_turretsidesDUarmor_HU.ArmorType = armor_turretsidesDUarmor_HU;
                armor_turretsidesDUarmor_HU = new ArmorType();

                armor_turretroofCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_turretroofCompositearmor_HU, armor_turretroofarmor_HU);
                armor_turretroofCompositearmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 7f; //default composite skirt 1.5
                armor_turretroofCompositearmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 5.9f; //default composite skirt 0.8
                armor_turretroofCompositearmor_HU.Name = "Abrams HU roof special composite";

                armor_codex_turretroofCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_turretroofCompositearmor_HU.name = "Abrams HU roof special composite";
                armor_codex_turretroofCompositearmor_HU.ArmorType = armor_turretroofCompositearmor_HU;
                armor_turretroofCompositearmor_HU = new ArmorType();

                armor_upperglacisCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_upperglacisCompositearmor_HU, armor_upperglacisarmor_HU);
                armor_upperglacisCompositearmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 5.5f; //default composite skirt 1.5
                armor_upperglacisCompositearmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 4.7f; //default composite skirt 0.8
                armor_upperglacisCompositearmor_HU.Name = "Abrams HU upper glacis special composite";

                armor_codex_upperglacisCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_upperglacisCompositearmor_HU.name = "Abrams HU upper glacis special composite";
                armor_codex_upperglacisCompositearmor_HU.ArmorType = armor_upperglacisCompositearmor_HU;
                armor_upperglacisCompositearmor_HU = new ArmorType();

                armor_commmandershatchCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_commmandershatchCompositearmor_HU, armor_commmandershatcharmor_HU);
                armor_commmandershatchCompositearmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 3.6f; //default composite skirt 1.5
                armor_commmandershatchCompositearmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 3f; //default composite skirt 0.8
                armor_commmandershatchCompositearmor_HU.Name = "Abrams HU commander's hatch special composite";

                armor_codex_commmandershatchCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_commmandershatchCompositearmor_HU.name = "Abrams HU commander's hatch special composite";
                armor_codex_commmandershatchCompositearmor_HU.ArmorType = armor_commmandershatchCompositearmor_HU;
                armor_commmandershatchCompositearmor_HU = new ArmorType();

                armor_loadershatchCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_loadershatchCompositearmor_HU, armor_loadershatcharmor_HU);
                armor_loadershatchCompositearmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 3.6f; //default composite skirt 1.5
                armor_loadershatchCompositearmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 3f; //default composite skirt 0.8
                armor_loadershatchCompositearmor_HU.Name = "Abrams HU loader's hatch special composite";

                armor_codex_loadershatchCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_loadershatchCompositearmor_HU.name = "Abrams HU loader's hatch special composite";
                armor_codex_loadershatchCompositearmor_HU.ArmorType = armor_loadershatchCompositearmor_HU;
                armor_loadershatchCompositearmor_HU = new ArmorType();

                armor_drivershatchCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_loadershatchCompositearmor_HU, armor_drivershatcharmor_HU);
                armor_drivershatchCompositearmor_HU.RhaeMultiplierCe = 3.6f; //default composite skirt 1.5
                armor_drivershatchCompositearmor_HU.RhaeMultiplierKe = 3f; //default composite skirt 0.8
                armor_drivershatchCompositearmor_HU.Name = "Abrams HU driver's hatch special composite";

                armor_codex_drivershatchCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_drivershatchCompositearmor_HU.name = "Abrams HU driver's hatch special composite";
                armor_codex_drivershatchCompositearmor_HU.ArmorType = armor_drivershatchCompositearmor_HU;
                armor_drivershatchCompositearmor_HU = new ArmorType();

                armor_turretringCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_turretringCompositearmor_HU, armor_turretringarmor_HU);
                armor_turretringCompositearmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 5f; //default composite skirt 1.5
                armor_turretringCompositearmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 5f; //default composite skirt 0.8
                armor_turretringCompositearmor_HU.Name = "Abrams HU turret ring special composite";

                armor_codex_turretringCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_turretringCompositearmor_HU.name = "Abrams HU turret ring special composite";
                armor_codex_turretringCompositearmor_HU.ArmorType = armor_turretringCompositearmor_HU;
                armor_turretringCompositearmor_HU = new ArmorType();

                armor_gunmantletfaceCompositearmor_HU = new ArmorType();
                Util.ShallowCopy(armor_gunmantletfaceCompositearmor_HU, armor_gunmantletfacearmor_HU);
                armor_gunmantletfaceCompositearmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 23f; //default composite skirt 1.5
                armor_gunmantletfaceCompositearmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 18f; //default composite skirt 0.8
                armor_gunmantletfaceCompositearmor_HU.Name = "Abrams HU gun mantlet face special composite";

                armor_codex_gunmantletfaceCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_gunmantletfaceCompositearmor_HU.name = "Abrams HU gun mantlet face special composite";
                armor_codex_gunmantletfaceCompositearmor_HU.ArmorType = armor_gunmantletfaceCompositearmor_HU;
                armor_gunmantletfaceCompositearmor_HU = new ArmorType();

                armor_trackSpecialarmor_HU = new ArmorType();
                Util.ShallowCopy(armor_trackSpecialarmor_HU, armor_trackarmor_HU);
                armor_trackSpecialarmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 10f; //default composite skirt 1.5
                armor_trackSpecialarmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 10f; //default composite skirt 0.8
                armor_trackSpecialarmor_HU.Name = "Abrams HU special track armor";

                armor_codex_trackSpecialarmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_trackSpecialarmor_HU.name = "Abrams HU special track armor";
                armor_codex_trackSpecialarmor_HU.ArmorType = armor_trackSpecialarmor_HU;
                armor_trackSpecialarmor_HU = new ArmorType();

                armor_gunbarrelImprovedarmor_HU = new ArmorType();
                Util.ShallowCopy(armor_gunbarrelImprovedarmor_HU, armor_gunbarrel_HU);
                armor_gunbarrelImprovedarmor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 7f; //default composite skirt 1.5
                armor_gunbarrelImprovedarmor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 7f; //default composite skirt 0.8
                armor_gunbarrelImprovedarmor_HU.Name = "Abrams HU Improved barrel armor";

                armor_codex_gunbarrelImprovedarmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_gunbarrelImprovedarmor_HU.name = "Abrams HU Improved barrel armor";
                armor_codex_gunbarrelImprovedarmor_HU.ArmorType = armor_gunbarrelImprovedarmor_HU;
                armor_gunbarrelImprovedarmor_HU = new ArmorType();

                armor_bustleImprovedfirewall_HU = new ArmorType();
                Util.ShallowCopy(armor_bustleImprovedfirewall_HU, armor_bustlefirewall_HU);
                armor_bustleImprovedfirewall_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 2f; //default composite skirt 1.5
                armor_bustleImprovedfirewall_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 2f; //default composite skirt 0.8
                armor_bustleImprovedfirewall_HU.Name = "Abrams HU bustle spall lining";

                armor_codex_bustleImprovedfirewall_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_bustleImprovedfirewall_HU.name = "Abrams HU bustle spall lining";
                armor_codex_bustleImprovedfirewall_HU.ArmorType = armor_bustleImprovedfirewall_HU;
                armor_bustleImprovedfirewall_HU = new ArmorType();

                armor_blowoutpanelCompositearmorC_HU = new ArmorType();
                Util.ShallowCopy(armor_blowoutpanelCompositearmorC_HU, armor_blowoutpanel_HU);
                armor_blowoutpanelCompositearmorC_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 10f; //default composite skirt 1.5
                armor_blowoutpanelCompositearmorC_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 10f; //default composite skirt 0.8
                armor_blowoutpanelCompositearmorC_HU.Name = "Abrams HU Composite blowout panel center";

                armor_codex_blowoutpanelCompositearmorC_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_blowoutpanelCompositearmorC_HU.name = "Abrams HU Composite blowout panel center";
                armor_codex_blowoutpanelCompositearmorC_HU.ArmorType = armor_blowoutpanelCompositearmorC_HU;
                armor_blowoutpanelCompositearmorC_HU = new ArmorType();

                armor_blowoutpanelCompositearmorL_HU = new ArmorType();
                Util.ShallowCopy(armor_blowoutpanelCompositearmorL_HU, armor_blowoutpanel_HU);
                armor_blowoutpanelCompositearmorL_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 10f; //default composite skirt 1.5
                armor_blowoutpanelCompositearmorL_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 10f; //default composite skirt 0.8
                armor_blowoutpanelCompositearmorL_HU.Name = "Abrams HU Composite blowout panel left";

                armor_codex_blowoutpanelCompositearmorL_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_blowoutpanelCompositearmorL_HU.name = "Abrams HU Composite blowout panel left";
                armor_codex_blowoutpanelCompositearmorL_HU.ArmorType = armor_blowoutpanelCompositearmorL_HU;
                armor_blowoutpanelCompositearmorL_HU = new ArmorType();

                armor_blowoutpanelCompositearmorR_HU = new ArmorType();
                Util.ShallowCopy(armor_blowoutpanelCompositearmorR_HU, armor_blowoutpanel_HU);
                armor_blowoutpanelCompositearmorR_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 10f; //default composite skirt 1.5
                armor_blowoutpanelCompositearmorR_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 10f; //default composite skirt 0.8
                armor_blowoutpanelCompositearmorR_HU.Name = "Abrams HU Composite blowout panel right";

                armor_codex_blowoutpanelCompositearmorR_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_blowoutpanelCompositearmorR_HU.name = "Abrams HU Composite blowout panel right";
                armor_codex_blowoutpanelCompositearmorR_HU.ArmorType = armor_blowoutpanelCompositearmorR_HU;
                armor_blowoutpanelCompositearmorR_HU = new ArmorType();

                armor_turretrearSpecialarray_HU = new ArmorType();
                Util.ShallowCopy(armor_turretrearSpecialarray_HU, armor_turretrearnera_HU);
                armor_turretrearSpecialarray_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 40f; //default special armor 1
                armor_turretrearSpecialarray_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 20f; //default special armor 1
                armor_turretrearSpecialarray_HU.Name = "Abrams HU Special armor turret rear";

                armor_codex_turretrearSpecialarray_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_turretrearSpecialarray_HU.name = "Abrams HU Special armor turret rear";
                armor_codex_turretrearSpecialarray_HU.ArmorType = armor_turretrearSpecialarray_HU;
                armor_turretrearSpecialarray_HU = new ArmorType();

                armor_GPSImprovedhousing_HU = new ArmorType();
                Util.ShallowCopy(armor_GPSImprovedhousing_HU, armor_GPShousing_HU);
                armor_GPSImprovedhousing_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 5f; //default composite skirt 1.5
                armor_GPSImprovedhousing_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 5f; //default composite skirt 0.8
                armor_GPSImprovedhousing_HU.Name = "Abrams HU GPS housing composite";

                armor_codex_GPSImprovedhousing_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_GPSImprovedhousing_HU.name = "Abrams HU GPS housing composite";
                armor_codex_GPSImprovedhousing_HU.ArmorType = armor_GPSImprovedhousing_HU;
                armor_GPSImprovedhousing_HU = new ArmorType();

                armor_GPSImproveddoor_HU = new ArmorType();
                Util.ShallowCopy(armor_GPSImproveddoor_HU, armor_GPSdoor_HU);
                armor_GPSImproveddoor_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 5f; //default composite skirt 1.5
                armor_GPSImproveddoor_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 5f; //default composite skirt 0.8
                armor_GPSImproveddoor_HU.Name = "Abrams HU GPS door composite";

                armor_codex_GPSImproveddoor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_GPSImproveddoor_HU.name = "Abrams HU GPS door composite";
                armor_codex_GPSImproveddoor_HU.ArmorType = armor_GPSImproveddoor_HU;
                armor_GPSImproveddoor_HU = new ArmorType();
                ////End

                ////HC armor modifiers (12.5% increase
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
                ////End

                ////HA armor modifiers (25% increase
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
