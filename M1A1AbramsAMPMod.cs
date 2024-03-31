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
using NWH.VehiclePhysics;
using FMOD;
using MelonLoader.Utils;
using System.IO;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;
using GHPC.Weaponry;
using static GHPC.Equipment.VehicleSmokeManager;
using Thermals;
using GHPC.AI;
using TMPro;
using Rewired.Utils;
using GHPC.UI.Tips;
using UnityEngine.UI;
using System.Net;
using GHPC.Effects;

namespace M1A1AMP
{
    public static class M1A1AbramsAMPMod
    {
        ////MelonPreferences.cfg variables
        static MelonPreferences_Entry<int> m1a1firstammoCount, m1a1secondammoCount, m1a1thirdammoCount, m1a1fourthammoCount;
        static MelonPreferences_Entry<int> m1e1firstammoCount, m1e1secondammoCount, m1e1thirdammoCount, m1e1fourthammoCount;
        static MelonPreferences_Entry<string> m1a1firstAmmo, m1a1secondAmmo, m1a1thirdAmmo, m1a1fourthAmmo;
        static MelonPreferences_Entry<string> m1e1firstAmmo, m1e1secondAmmo, m1e1thirdAmmo, m1e1fourthAmmo;
        static MelonPreferences_Entry<bool> m2Coax, m2Slap;
        static MelonPreferences_Entry<bool> rotateAzimuth, betterDaysight, betterFlir, betterGas;
        static MelonPreferences_Entry<bool> m1e1Convert, randomChance;
        static MelonPreferences_Entry<int> randomChanceNum;
        static MelonPreferences_Entry<bool> m829spall, ampFuze;
        static MelonPreferences_Entry<string> m1a1Armor, m1e1Armor;
        static MelonPreferences_Entry<bool> demigodArmor, m1a1Smoke, m1e1Smoke, m1a1Rosy, m1e1Rosy, rosyPlus, rosyIR;
        static MelonPreferences_Entry<string> m1a1Agt, m1e1Agt;
        static MelonPreferences_Entry<bool> betterTransmission, governorDelete, uapWeight, m1a1Apu, m1e1Apu, noLuggage, betterSuspension, betterTracks, m1ipModel;
        static MelonPreferences_Entry<string> m1a1Loader, m1e1Loader, m1a1Commander, m1e1Commander, m1a1Gunner, m1e1Gunner;
        static MelonPreferences_Entry<bool> citv, alt_flir_colour;
        public static MelonPreferences_Entry<int> ampFragments, mpatFragments, heorFragments;
        public static MelonPreferences_Entry<bool> perfect_citv, citv_reticle, citv_smooth, perfect_override;
        public static MelonPreferences_Entry<float> proxyDistance;

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
        public static AmmoType.AmmoClip clip_m830a1;
        static AmmoCodexScriptable ammo_codex_m830a1;
        public static AmmoType ammo_m830a1;
        public static AmmoType m830a1_forward_frag = new AmmoType();

        static AmmoClipCodexScriptable clip_codex_m830a2;
        static AmmoType.AmmoClip clip_m830a2;
        static AmmoCodexScriptable ammo_codex_m830a2;
        static AmmoType ammo_m830a2;

        static AmmoClipCodexScriptable clip_codex_m830a3;
        static AmmoType.AmmoClip clip_m830a3;
        static AmmoCodexScriptable ammo_codex_m830a3;
        static AmmoType ammo_m830a3;

        static AmmoClipCodexScriptable clip_codex_xm1147;
        public static AmmoType.AmmoClip clip_xm1147;
        static AmmoCodexScriptable ammo_codex_xm1147;
        public static AmmoType ammo_xm1147;
        public static AmmoType xm1147_forward_frag = new AmmoType();

        static AmmoClipCodexScriptable clip_codex_lahat;
        static AmmoType.AmmoClip clip_lahat;
        static AmmoCodexScriptable ammo_codex_lahat;
        static AmmoType ammo_lahat;

        static AmmoClipCodexScriptable clip_codex_m908;
        static AmmoType.AmmoClip clip_m908;
        static AmmoCodexScriptable ammo_codex_m908;
        static AmmoType ammo_m908;

        static AmmoClipCodexScriptable clip_codex_m8api;
        static AmmoType.AmmoClip clip_m8api;
        static AmmoCodexScriptable ammo_codex_m8api;
        static AmmoType ammo_m8api;

        static AmmoClipCodexScriptable clip_codex_m2apt;
        static AmmoType.AmmoClip clip_m2apt;
        static AmmoCodexScriptable ammo_codex_m2apt;
        static AmmoType ammo_m2apt;

        static AmmoClipCodexScriptable clip_codex_m962slapt;
        static AmmoType.AmmoClip clip_m962slapt;
        static AmmoCodexScriptable ammo_codex_m962slapt;
        static AmmoType ammo_m962slapt;

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
        static GameObject ammo_m908_vis = null;

        static AmmoType ammo_m833, ammo_m456, ammo_3of26, ammo_bgm71, ammo_m8vnl;

        ////Armor variables
        ////Variables for copying existing ArmorType
        static ArmorType armor_compositeskirt_VNL, armor_specialarmor_VNL, armor_tracks_VNL, armor_gunsteel_VNL;

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

        ////SA Variant
        static ArmorCodexScriptable armor_codex_cheeksDUarmor_SA;
        static ArmorType armor_cheeksDUarmor_SA;

        static ArmorCodexScriptable armor_codex_fronthullDUarmor_SA;
        static ArmorType armor_fronthullDUarmor_SA;

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
        static ReticleSO reticleSO_m1a1firstRound, reticleSO_m1a1secondRound;
        static ReticleMesh.CachedReticle reticle_cached_m1a1firstRound, reticle_cached_m1a1secondRound;


        static ReticleSO reticleSO_m1e1firstRound, reticleSO_m1e1secondRound;
        static ReticleMesh.CachedReticle reticle_cached_m1e1firstRound, reticle_cached_m1e1secondRound;

        static GameObject citv_obj;

        static GameObject m82Object;
        static GameObject m82SmokeEffect;
        static GameObject RosySmokeEffect;

        static GameObject m1ip_cheeksface;
        static GameObject m1ip_cheeksnera;
        static GameObject m1ip_turretroof;

        public static void Config(MelonPreferences_Category cfg)
        {
            m1a1firstAmmo = cfg.CreateEntry<string>("M1A1 1st Round Type", "M829A4");
            m1a1firstAmmo.Description = "Round types carried by M1A1: 'M829', 'M829A1', 'M829A2', 'M829A3', 'M829A4', 'M830', 'M830A1', 'M830A2', 'M830A3', 'M908', 'XM1147' or 'LAHAT'";
            m1a1secondAmmo = cfg.CreateEntry<string>("M1A1 2nd Round Type", "M830A2");
            m1a1thirdAmmo = cfg.CreateEntry<string>("M1A1 3rd Round Type", "XM1147");
            m1a1fourthAmmo = cfg.CreateEntry<string>("M1A1 4th Round Type", "LAHAT");

            m1a1firstammoCount = cfg.CreateEntry<int>("M1A1 1st Round Count", 20);
            m1a1firstammoCount.Description = "How many rounds per type each M1A1 should carry. Maximum of 50 rounds total. Bring in at least one primary round.";
            m1a1secondammoCount = cfg.CreateEntry<int>("M1A1 2nd Round Count", 12);
            m1a1thirdammoCount = cfg.CreateEntry<int>("M1A1 3rd Round Count", 12);
            m1a1fourthammoCount = cfg.CreateEntry<int>("M1A1 4th Round Count", 6);

            m1e1firstAmmo = cfg.CreateEntry<string>("M1E1 1st Round Type", "M829");
            m1e1firstAmmo.Description = "Round types carried by M1E1: 'M829', 'M829A1', 'M829A2', 'M829A3', 'M829A4', 'M830', 'M830A1', 'M830A2', 'M830A3', 'M908', 'XM1147' or 'LAHAT'";
            m1e1secondAmmo = cfg.CreateEntry<string>("M1E1 2nd Round Type", "M830");
            m1e1thirdAmmo = cfg.CreateEntry<string>("M1E1 3rd Round Type", "M830A1");
            m1e1fourthAmmo = cfg.CreateEntry<string>("M1E1 4th Round Type", "M830A1");

            m1e1firstammoCount = cfg.CreateEntry<int>("M1E1 1st Round Count", 20);
            m1e1firstammoCount.Description = "How many rounds per type each M1E1 should carry. Maximum of 50 rounds total. Bring in at least one primary round.";
            m1e1secondammoCount = cfg.CreateEntry<int>("M1E1 2nd Round Count", 15);
            m1e1thirdammoCount = cfg.CreateEntry<int>("M1E1 3rd Round Count", 15);
            m1e1fourthammoCount = cfg.CreateEntry<int>("M1E1 4th Round Count", 0);

            m1a1Gunner = cfg.CreateEntry<string>("M1A1 Gunner", "Regular");
            m1a1Gunner.Description = "Crew proficiency: Cadet, Regular, Veteran or Ace";
            m1e1Gunner = cfg.CreateEntry<string>("M1E1 Gunner", "Regular");

            m1a1Loader = cfg.CreateEntry<string>("M1A1 Loader", "Regular");
            m1e1Loader = cfg.CreateEntry<string>("M1E1 Loader", "Regular");

            m1a1Commander = cfg.CreateEntry<string>("M1A1 Commander", "Regular");
            m1e1Commander = cfg.CreateEntry<string>("M1E1 Commander", "Regular");

            m2Coax = cfg.CreateEntry<bool>("M2 Coax", false);
            m2Coax.Description = "Replaces M240 coaxial gun with M2.";

            m2Slap = cfg.CreateEntry<bool>("M2 SLAP", false);
            m2Slap.Description = "Use M962 SLAP-T for M2 coax.";

            m829spall = cfg.CreateEntry<bool>("M829 Spall+", false);
            m829spall.Description = "Enhanced spalling for all M829s.";

            ampFragments = cfg.CreateEntry<int>("AMP Fragments", 600);
            ampFragments.Description = "How many fragments are generated when the below round explodes. NOTE: Higher number, means higher performance hit. Be careful in using higher number.";

            mpatFragments = cfg.CreateEntry<int>("MPAT Fragments", 600);

            heorFragments = cfg.CreateEntry<int>("HEOR Fragments", 300);

            ampFuze = cfg.CreateEntry<bool>("AMP Proxy Fuze", false);
            ampFuze.Description = "Switch AMP fuze to proximity instead of time-delay.";

            proxyDistance = cfg.CreateEntry<float>("ProxyDistance", 3);
            proxyDistance.Description = "Trigger distance of proximity fuze (in meters).";

            betterDaysight = cfg.CreateEntry<bool>("Daysight+", false);
            betterDaysight.Description = "More zoom levels/clearer image for gunner optics.";
            betterFlir = cfg.CreateEntry<bool>("FLIR+", false);
            betterGas = cfg.CreateEntry<bool>("GAS+", false);

            rotateAzimuth = cfg.CreateEntry<bool>("RotateAzimuth", false);
            rotateAzimuth.Description = "Horizontal stabilization of M1A1 sights when applying lead.";

            citv = cfg.CreateEntry<bool>("CITV", false);
            citv.Description = "Replaces commander's NVGs with variable-zoom thermals.";

            perfect_citv = cfg.CreateEntry<bool>("No Blur CITV", false);
            citv_reticle = cfg.CreateEntry<bool>("CITV Reticle", true);

            perfect_override = cfg.CreateEntry<bool>("Perfect CITV Override", false);
            perfect_override.Comment = "Basically lets you point-n-shoot with the CITV.";

            citv_smooth = cfg.CreateEntry<bool>("Smooth CITV Panning", true);
            citv_smooth.Comment = "Makes CITV feel more like a camera.";

            alt_flir_colour = cfg.CreateEntry<bool>("Alternate GPS FLIR Colour", false);
            alt_flir_colour.Description = "[Requires CITV to be enabled] Gives the gunner's sight FLIR the same colour palette as the CITV.";

            m1e1Convert = cfg.CreateEntry<bool>("M1E1", true);
            m1e1Convert.Description = "Convert M1s to M1E1s (i.e: they get the 120mm gun and enables armor upgrades).";

            randomChance = cfg.CreateEntry<bool>("Random", true);
            randomChance.Description = "M1IPs/M1s will have a random chance of being converted to M1A1s/M1E1s.";
            randomChanceNum = cfg.CreateEntry<int>("ConversionChance", 100);

            m1a1Armor = cfg.CreateEntry<string>("M1A1 Armor", "SA");
            m1a1Armor.Description = "Armor used by M1A1 and M1E1: 'HA', 'HC', 'SA', 'HU' or blank for base M1/IP armor";
            m1e1Armor = cfg.CreateEntry<string>("M1E1 Armor", "HC");

            uapWeight = cfg.CreateEntry<bool>("UAP", false);
            uapWeight.Description = "Unobtanium armor package for HU that gives it HA weight";

            demigodArmor = cfg.CreateEntry<bool>("Demigod Armor", false);
            demigodArmor.Description = "Almost deathproof Abrooms (HU variant only)";

            m1a1Smoke = cfg.CreateEntry<bool>("M1A1 Smoke+", false);
            m1a1Smoke.Description = "Twice the ammo and better throw distance.";
            m1e1Smoke = cfg.CreateEntry<bool>("M1E1 Smoke+", false);

            m1a1Rosy = cfg.CreateEntry<bool>("M1A1 ROSY", false);
            m1a1Rosy.Description = "Replaces M250 with 4 charges of \"Rapid Obscuring Sytem\" (Smoke+ required)";
            m1e1Rosy= cfg.CreateEntry<bool>("M1E1 ROSY", false);

            rosyPlus = cfg.CreateEntry<bool>("ROSY+", false);
            rosyPlus.Description = "Faster/larger smoke effect and if thermals are blocked for ROSY";

            rosyIR = cfg.CreateEntry<bool>("Multispectral", false);

            m1a1Agt = cfg.CreateEntry<string>("M1A1 Engine", "AGT1500");
            m1a1Agt.Description = "SPEEEED AND POWWAAAAH!";
            m1a1Agt.Comment = "AGT1500/AGT2000/AGT2500/AGT3000/T64";
            m1e1Agt = cfg.CreateEntry<string>("M1E1 Engine", "AGT1500");

            betterTransmission = cfg.CreateEntry<bool>("Transmission+", false);

            governorDelete = cfg.CreateEntry<bool>("GovernorDelete", false);

            betterSuspension = cfg.CreateEntry<bool>("Suspension+", false);

            betterTracks = cfg.CreateEntry<bool>("Tracks+", false);

            m1a1Apu = cfg.CreateEntry<bool>("M1A1 APU", false);
            m1e1Apu = cfg.CreateEntry<bool>("M1E1 APU", false);

            noLuggage = cfg.CreateEntry<bool>("Clean Turret", false);
            noLuggage.Description = "Remove items attached to turret like ALICE packs or MRE boxes";

            m1ipModel = cfg.CreateEntry<bool>("M1E1 IP Model", false);
            m1ipModel.Description = "Gives the M1IP model to base M1";
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
                ["M908"] = clip_codex_m908,
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
                ["M908"] = ammo_codex_m908,
            };


            GameObject m1ip_go = Resources.FindObjectsOfTypeAll(typeof(GameObject)).Where(o => o.name == "M1IP").FirstOrDefault() as GameObject;

            switch (m1a1Armor.Value)
            {
                ////Assign modified armor to M1A1HU
                case "HU":
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

                    ////M1A1HU DestructibleComponent pieces
                    /*foreach (GameObject dcomponent in GameObject.FindGameObjectsWithTag("Penetrable"))
                    {
                       if (dcomponent == null) continue;
                        GHPC.Equipment.DestructibleComponent m1a1DC_HU = dcomponent.GetComponent<GHPC.Equipment.DestructibleComponent>();
                        if (m1a1DC_HU == null)
                        //if (m1a1DC_HU.name == "main gun barrel")
                        //if (m1a1DC_HU.Unit == m1ip_go) continue;
                        if (m1a1DC_HU.Name == "main gun barrel")
                         {
                            m1a1DC_HU._fullHealth = -1;
                            m1a1DC_HU._health = -1;
                         }
                            //MelonLogger.Msg("M1A1HU UniformArmor: Modified");
                    }*/


                    ////M1A1HU UniformArmor pieces
                    foreach (GameObject Trarmour in GameObject.FindGameObjectsWithTag("Penetrable"))
                    {
                        if (Trarmour == null) continue;

                        Transform m1a1Tr_HU = Trarmour.GetComponent<Transform>();
                        if (m1a1Tr_HU == null) continue;
                        if (m1a1Tr_HU.name == "Fire wall.004")
                        {
                            m1a1Tr_HU.localPosition = new Vector3(0f, 1.0935f, 2.5294f);//y1.0935 z2.5294
                        }
                    }
                    break;

                ////Assign modified armor to M1A1SA
                case "SA":
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
                                armorcheeksDU_HC.SetValue(m1a1VA_HC, armor_codex_cheeksDUarmor_SA);

                                MelonLogger.Msg(m1a1VA_HC.ArmorType);
                            }


                            if (m1a1VA_HC.Name == "hull front special armor array")
                            {
                                FieldInfo armorhullfrontDU_HC = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                                armorhullfrontDU_HC.SetValue(m1a1VA_HC, armor_codex_fronthullDUarmor_SA);
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
                    break;

                ////Assign modified armor to M1A1HC
                case "HC":
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
                    break;

                ////Assign modified armor to M1A1HA
                case "HA":
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
                    break;
            }

            switch (m1e1Armor.Value)
            {
                ////Assign modified armor to M1E1HU
                case "HU":
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
                    break;

                ////Assign modified armor to M1E1SA
                case "SA":
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
                                armorcheeksDU_HC.SetValue(m1e1VA_HC, armor_codex_cheeksDUarmor_SA);
                                MelonLogger.Msg(m1e1VA_HC.ArmorType);
                            }

                            if (m1e1VA_HC.Name == "hull front special armor array")
                            {
                                FieldInfo armorhullfrontDU_HC = typeof(VariableArmor).GetField("_armorType", BindingFlags.NonPublic | BindingFlags.Instance);
                                armorhullfrontDU_HC.SetValue(m1e1VA_HC, armor_codex_fronthullDUarmor_SA);
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
                    break;

                ////Assign modified armor to M1E1HC
                case "HC":
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
                    break;

                ////Assign modified armor to M1E1HA
                case "HA":
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
                    break;
            }

            foreach (GameObject vic_go in AbramsAMPMod.vic_gos)
            {
                Vehicle vic = vic_go.GetComponent<Vehicle>();

                if (vic == null) continue;

                if (vic_go.GetComponent<Util.AlreadyConverted>() != null) continue;
                if (vic.FriendlyName == "M1IP" || (m1e1Convert.Value && vic.FriendlyName == "M1"))
                {
                    vic_go.AddComponent<Util.AlreadyConverted>();

                    int rand = (randomChance.Value) ? UnityEngine.Random.Range(1, 100) : 0;

                    if (rand <= randomChanceNum.Value)
                    {
                        vic_go.AddComponent<Util.AlreadyConverted>();
                        ////Rename Abrams
                        if (vic.FriendlyName == "M1IP")
                        {
                            vic._friendlyName = "M1A1" + m1a1Armor.Value;
                        }

                        if (vic.FriendlyName == "M1")
                        {
                            vic._friendlyName = "M1E1" + m1e1Armor.Value;
                        }

                        if (ampFuze.Value) vic_go.AddComponent<ProxySwitchAMP>();
                        vic_go.AddComponent<ProxySwitchMPAT>();

                        HeatSource m1ip_HeatSourceCopy = vic_go.GetComponent<HeatSource>();
                        

                        ////Weapons management
                        WeaponsManager weaponsManager = vic.GetComponent<WeaponsManager>();
                        WeaponSystemInfo mainGunInfo = weaponsManager.Weapons[0];
                        WeaponSystem mainGun = mainGunInfo.Weapon;

                        var gpsOptic = vic_go.transform.Find("IPM1_rig/HULL/TURRET/Turret Scripts/GPS/Optic/").gameObject.transform;
                        var flirOptic = vic_go.transform.Find("IPM1_rig/HULL/TURRET/Turret Scripts/GPS/FLIR/").gameObject.transform;
                        var gasOptic = vic_go.transform.Find("IPM1_rig/HULL/TURRET/GUN/Gun Scripts/Aux sight (GAS)/").gameObject.transform;
                        var TurretScripts = vic_go.transform.Find("IPM1_rig/HULL/TURRET/Turret Scripts/").gameObject.transform;
                        var m1ipLuggageScripts = vic_go.transform.Find("IPM1_rig/HULL/TURRET/Turret Scripts/").gameObject.transform;// /luggage/ for M1IP
                        var m1LuggageScripts = vic_go.transform.Find("IPM1_rig/HULL/TURRET/").gameObject.transform;// /turret decorations parent/ for M1

                        UsableOptic horizontalGps = gpsOptic.GetComponent<UsableOptic>();
                        UsableOptic horizontalFlir = flirOptic.GetComponent<UsableOptic>();

                        CameraSlot daysightPlus = gpsOptic.GetComponent<CameraSlot>();
                        CameraSlot flirPlus = flirOptic.GetComponent<CameraSlot>();
                        CameraSlot gasPlus = gasOptic.GetComponent<CameraSlot>();

                        AimablePlatform m1Turret = TurretScripts.GetComponent<AimablePlatform>();

                        ////Better optics stuff
                        UsableOptic optic = Util.GetDayOptic(mainGun.FCS);
                        if (rotateAzimuth.Value)
                        {
                            horizontalGps.RotateAzimuth = true;
                            horizontalFlir.RotateAzimuth = true;
                        }

                        List<float> gpsFovs = new List<float>();
                        gpsFovs.Add(6.5f);
                        gpsFovs.Add(3.472f);
                        gpsFovs.Add(1.204f);
                        gpsFovs.Add(0.488f);

                        if (betterDaysight.Value)
                        {
                            daysightPlus.DefaultFov = 12.5f;
                            daysightPlus.OtherFovs = gpsFovs.ToArray<float>();
                        }

                        if (betterFlir.Value)
                        {
                            //Scanline FOV change
                            GameObject.Destroy(flirOptic.transform.Find("Canvas Scanlines").gameObject);

                            flirPlus.DefaultFov = 12.5f;
                            flirPlus.OtherFovs = gpsFovs.ToArray<float>();
                            flirPlus.BaseBlur = 0;
                        }

                        if (betterGas.Value)
                        {
                            gasPlus.DefaultFov = 6.5f;//4.2f
                            gasPlus.OtherFovs = new float[] { 4.2f, 2.716f, 1.716f };
                            gasPlus.VibrationBlurScale = 0.1f;//0.2
                            gasPlus.VibrationShakeMultiplier = 0.2f;//0.5
                        }

                        if (citv.Value)
                        {
                            GameObject c = GameObject.Instantiate(citv_obj, vic.transform.Find("IPM1_rig/HULL/TURRET"));
                            c.transform.localPosition = new Vector3(-0.6794f, 0.9341f, 0.4348f);
                            c.transform.localEulerAngles = new Vector3(0f, 0f, 0f);

                            CITV citv_component = vic.DesignatedCameraSlots[0].LinkedNightSight.gameObject.AddComponent<CITV>();
                            citv_component.model = c;

                            c.transform.Find("assembly").GetComponent<VariableArmor>().Unit = vic;
                            c.transform.Find("glass").GetComponent<VariableArmor>().Unit = vic;

                            if (alt_flir_colour.Value)
                                optic.slot.LinkedNightSight.PairedOptic.post.profile.settings[2] = vic.DesignatedCameraSlots[0].LinkedNightSight.gameObject.
                                    GetComponent<SimpleNightVision>()._postVolume.profile.settings[1];
                            //ChromaticAberration s = optic.post.profile.AddSettings<ChromaticAberration>();
                            //s.active = true; 
                            //s.intensity.overrideState = true;
                            //s.intensity.value = 0.35f;

                            //vic._friendlyName += "+";
                        }

                        CameraSlot commanderzoom = vic.DesignatedCameraSlots[0].gameObject.GetComponent<CameraSlot>();
                        commanderzoom.AllowFreeZoom = true;
                        commanderzoom.DefaultFov = 60;//60
                        //commanderzoom.OtherFovs = new float[] {60f, 30f, 20f, 10f };//??? Unknown default*/

                        ////GAS stuff
                        if (vic.FriendlyName == "M1E1" + m1e1Armor.Value)
                        {
                            if (reticleSO_m1e1firstRound == null)
                            {
                                reticleSO_m1e1firstRound = ScriptableObject.Instantiate(ReticleMesh.cachedReticles["M1_105_GAS_APFSDS"].tree);
                                reticleSO_m1e1firstRound.name = "120mm_gas_m1e1firstRound";

                                Util.ShallowCopy(reticle_cached_m1e1firstRound, ReticleMesh.cachedReticles["M1_105_GAS_APFSDS"]);
                                reticle_cached_m1e1firstRound.tree = reticleSO_m1e1firstRound;

                                ReticleTree.Angular boresight_m1e1firstRound = ((reticleSO_m1e1firstRound.planes[0]
                                    as ReticleTree.FocalPlane).elements[0]
                                    as ReticleTree.Angular);

                                ReticleTree.VerticalBallistic reticle_range_m1e1firstRound = boresight_m1e1firstRound.elements[4] as ReticleTree.VerticalBallistic;
                                reticle_range_m1e1firstRound.projectile = abrams_ammocodex[m1e1firstAmmo.Value];
                                reticle_range_m1e1firstRound.UpdateBC();

                                ReticleTree.Text reticle_text_m1e1firstRound = boresight_m1e1firstRound.elements[0]
                                    as ReticleTree.Text;

                                string m1e1firstRound_name = abrams_ammocodex[m1e1firstAmmo.Value].AmmoType.Name;
                                reticle_text_m1e1firstRound.text = "120 MM\n " + m1e1firstRound_name + "\nMETERS";

                                reticleSO_m1e1secondRound = ScriptableObject.Instantiate(ReticleMesh.cachedReticles["M1_105_GAS_HEAT"].tree);
                                reticleSO_m1e1secondRound.name = "120mm_gas_m1e1secondRound";

                                Util.ShallowCopy(reticle_cached_m1e1secondRound, ReticleMesh.cachedReticles["M1_105_GAS_HEAT"]);
                                reticle_cached_m1e1secondRound.tree = reticleSO_m1e1secondRound;

                                ReticleTree.Angular boresight_m1e1secondRound = ((reticleSO_m1e1secondRound.planes[0]
                                    as ReticleTree.FocalPlane).elements[0]
                                    as ReticleTree.Angular);

                                ReticleTree.VerticalBallistic reticle_range_m1e1secondRound = boresight_m1e1secondRound.elements[4] as ReticleTree.VerticalBallistic;
                                reticle_range_m1e1secondRound.projectile = abrams_ammocodex[m1e1secondAmmo.Value];
                                reticle_range_m1e1secondRound.UpdateBC();

                                ReticleTree.Text reticle_text_m1e1secondRound = boresight_m1e1secondRound.elements[0]
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

                                ReticleTree.Angular boresight_m1a1firstRound = ((reticleSO_m1a1firstRound.planes[0]
                                    as ReticleTree.FocalPlane).elements[0]
                                    as ReticleTree.Angular);

                                ReticleTree.VerticalBallistic reticle_range_m1a1firstRound = boresight_m1a1firstRound.elements[4] as ReticleTree.VerticalBallistic;
                                reticle_range_m1a1firstRound.projectile = abrams_ammocodex[m1a1firstAmmo.Value];
                                reticle_range_m1a1firstRound.UpdateBC();

                                ReticleTree.Text reticle_text_m1a1firstRound = boresight_m1a1firstRound.elements[0]
                                    as ReticleTree.Text;

                                string m1a1firstRound_name = abrams_ammocodex[m1a1firstAmmo.Value].AmmoType.Name;
                                reticle_text_m1a1firstRound.text = "120 MM\n " + m1a1firstRound_name + "\nMETERS";

                                reticleSO_m1a1secondRound = ScriptableObject.Instantiate(ReticleMesh.cachedReticles["M1_105_GAS_HEAT"].tree);
                                reticleSO_m1a1secondRound.name = "120mm_gas_m1a1secondRound";

                                Util.ShallowCopy(reticle_cached_m1a1secondRound, ReticleMesh.cachedReticles["M1_105_GAS_HEAT"]);
                                reticle_cached_m1a1secondRound.tree = reticleSO_m1a1secondRound;

                                ReticleTree.Angular boresight_m1a1secondRound = ((reticleSO_m1a1secondRound.planes[0]
                                    as ReticleTree.FocalPlane).elements[0]
                                    as ReticleTree.Angular);

                                ReticleTree.VerticalBallistic reticle_range_m1a1secondRound = boresight_m1a1secondRound.elements[4] as ReticleTree.VerticalBallistic;
                                reticle_range_m1a1secondRound.projectile = abrams_ammocodex[m1a1secondAmmo.Value];
                                reticle_range_m1a1secondRound.UpdateBC();

                                ReticleTree.Text reticle_text_m1a1secondRound = boresight_m1a1secondRound.elements[0]
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

                        GameObject gunTube = vic_go.transform.Find("IPM1_rig/HULL/TURRET/GUN/gun_recoil").gameObject;
                        gunTube.transform.localScale = new Vector3(1.4f, 1.4f, 0.98f);

                        mainGunInfo.Name = "120mm gun M256";
                        mainGun.Impulse = 68000;
                        mainGun.CodexEntry = gun_m256;
                        mainGun.Feed.ReloadDuringMissileTracking = true;
                        mainGun.FireWhileGuidingMissile = true;

                        VehicleController m1VC = vic_go.GetComponent<VehicleController>();
                        NwhChassis m1Chassis = vic_go.GetComponent<NwhChassis>();
                        Rigidbody m1Rb = vic_go.GetComponent<Rigidbody>();
                        VehicleSmokeManager m1Smoke = vic_go.GetComponentInChildren<VehicleSmokeManager>();
                        LoadoutManager loadoutManager = vic.GetComponent<LoadoutManager>();
                        UnitAI m1Ai = vic.GetComponentInChildren<UnitAI>();
                        DriverAIController m1dAic = vic.GetComponent<DriverAIController>();
                        
                        m1dAic.maxSpeed = 32;//20

                        //Chonk quantifier
                        //Add weight instead of replace it
                        int mass_A1 = 3719;//59057;//55338 - Value for default M1
                        int mass_HA = 5261;//60599;
                        int mass_HC = 6078;//61416;
                        int mass_SA = 6894;//62232;
                        int mass_HU = uapWeight.Value ? 5261: 17327;//72665;//fully loaded SEPv3 as reference - was 68038

                        //kW Values
                        float engine_Agt1500 = 1132.38f;//1518.55f;
                        float engine_Agt2000 = 1494.75f;// 2004.49f;
                        float engine_Agt2500 = 1868.33f;//2505.61f;
                        float engine_Agt3000 = 2264.77f;// 3037.1f;
                        float engine_T64 = 3303.45f;// 4330f;

                        //HP Values
                        /*float engine_Agt1500 = 1518.55f;//1518.55f;
                        float engine_Agt2000 = 2004.49f;// 2004.49f;
                        float engine_Agt2500 = 2505.61f;//2505.61f;
                        float engine_Agt3000 = 3037.1f;// 3037.1f;
                        float engine_T64 = 4330f;// 4330f;*/
                        float agt2530_Maxrpm = 4000f;//3100f
                        float t64_Maxrpm = 4300f;//3100f
                        float engine_Minrpm = 600f;//600
                        float engine_Maxrpmchange = 4000f;


                        //10%
                        int brakes_Agt2000 = 76560;//69600 vanilla
                        int brakes_Agt2500 = 83520;
                        int brakes_Agt3000 = 90480;
                        int brakes_T64 = 97440;

                        //Suspension testing
                        for (int i = 0; i < 14; i++)
                        {
                            if (betterSuspension.Value)
                            {
                                m1VC.wheels[i].wheelController.damper.force = -3.2616f;//-3.2616
                                m1VC.wheels[i].wheelController.damper.maxForce = 39000;//19000
                                m1VC.wheels[i].wheelController.damper.unitBumpForce = 10000;//10000
                                m1VC.wheels[i].wheelController.damper.unitReboundForce = 39000;//19000

                                m1VC.wheels[i].wheelController.spring.bottomOutForce = -314031.9f;//-314031.9
                                //m1VC.wheels[i].wheelController.spring.compressionPercent = 0.2674f;//0.2674
                                m1VC.wheels[i].wheelController.spring.force = 45940.98f;//45940.98
                                m1VC.wheels[i].wheelController.spring.length = 0.3643f;//0.3443
                                m1VC.wheels[i].wheelController.spring.maxForce = 39000;//39000
                                m1VC.wheels[i].wheelController.spring.maxLength = 0.54f;//0.47
                                //m1VC.wheels[i].wheelController.spring.overExtended = false;//
                            }

                            if (betterTracks.Value)
                            {
                                m1VC.wheels[i].wheelController.fFriction.forceCoefficient = 1.25f;//1.2
                                m1VC.wheels[i].wheelController.fFriction.slipCoefficient = 1f;//1

                                m1VC.wheels[i].wheelController.sFriction.forceCoefficient = 0.85f;//0.8
                                m1VC.wheels[i].wheelController.sFriction.slipCoefficient = 1f;//1

                                m1VC.wheels[i].wheelController.TireWidth = 0.58f;//0.58
                            }
                        }

                        if (vic.FriendlyName == "M1A1" + m1a1Armor.Value)
                        {
                            MelonLogger.Msg("Base M1A1 Mass: " + m1Rb.mass);
                            switch (m1a1Commander.Value)
                            {
                                case "Cadet":
                                    m1Ai.SpotTimeMaxDistance = 2500;
                                    m1Ai.TargetSensor._spotTimeMax = 5;
                                    m1Ai.TargetSensor._spotTimeMaxDistance = 500;
                                    m1Ai.TargetSensor._spotTimeMaxVelocity = 2;
                                    m1Ai.TargetSensor._spotTimeMin = 1;
                                    m1Ai.TargetSensor._spotTimeMinDistance = 50;
                                    m1Ai.TargetSensor._targetCooldownTime = 3f;

                                    m1Ai.CommanderAI._identifyTargetDurationRange = new Vector2(3f, 4f);
                                    m1Ai.CommanderAI._sweepCommsCheckDuration = 5;
                                    break;
                                case "Veteran":
                                    m1Ai.SpotTimeMaxDistance = 3500;
                                    m1Ai.TargetSensor._spotTimeMax = 3;
                                    m1Ai.TargetSensor._spotTimeMaxDistance = 500;
                                    m1Ai.TargetSensor._spotTimeMaxVelocity = 7f;
                                    m1Ai.TargetSensor._spotTimeMin = 1;
                                    m1Ai.TargetSensor._spotTimeMinDistance = 50;
                                    m1Ai.TargetSensor._targetCooldownTime = 1.5f;

                                    m1Ai.CommanderAI._identifyTargetDurationRange = new Vector2(1.5f, 2.5f);
                                    m1Ai.CommanderAI._sweepCommsCheckDuration = 4;
                                    break;
                                case "Ace":
                                    m1Ai.SpotTimeMaxDistance = 4000;
                                    m1Ai.TargetSensor._spotTimeMax = 2;
                                    m1Ai.TargetSensor._spotTimeMaxDistance = 500;
                                    m1Ai.TargetSensor._spotTimeMaxVelocity = 10f;
                                    m1Ai.TargetSensor._spotTimeMin = 1;
                                    m1Ai.TargetSensor._spotTimeMinDistance = 50;
                                    m1Ai.TargetSensor._targetCooldownTime = 1f;

                                    m1Ai.CommanderAI._identifyTargetDurationRange = new Vector2(1f, 2f);
                                    m1Ai.CommanderAI._sweepCommsCheckDuration = 3;
                                    break;
                                default:
                                    m1Ai.SpotTimeMaxDistance = 3000;//3000
                                    m1Ai.TargetSensor._spotTimeMax = 4;//4
                                    m1Ai.TargetSensor._spotTimeMaxDistance = 500;//500
                                    m1Ai.TargetSensor._spotTimeMaxVelocity = 4;//4
                                    m1Ai.TargetSensor._spotTimeMin = 1;//1
                                    m1Ai.TargetSensor._spotTimeMinDistance = 50;//50
                                    m1Ai.TargetSensor._targetCooldownTime = 2f;//2

                                    m1Ai.CommanderAI._identifyTargetDurationRange = new Vector2(2f, 3f);//2,3
                                    m1Ai.CommanderAI._sweepCommsCheckDuration = 5;//5
                                    break;
                            }

                            switch (m1a1Gunner.Value)
                            {
                                case "Cadet":
                                    m1Ai.combatSpeedLimit = 10;
                                    m1Ai.firingSpeedLimit = 7;

                                    //m1Ai.AccuracyModifiers.Angle._radius = 3.9f;
                                    m1Ai.AccuracyModifiers.Angle.MaxDistance = 2000;
                                    m1Ai.AccuracyModifiers.Angle.MaxRadius = 4.5f;
                                    m1Ai.AccuracyModifiers.Angle.MinRadius = 2.5f;
                                    break;
                                case "Veteran":
                                    m1Ai.combatSpeedLimit = 20;
                                    m1Ai.firingSpeedLimit = 15;

                                    //m1Ai.AccuracyModifiers.Angle._radius = 2.9f;
                                    m1Ai.AccuracyModifiers.Angle.MaxDistance = 2500;
                                    m1Ai.AccuracyModifiers.Angle.MaxRadius = 2.5f;
                                    m1Ai.AccuracyModifiers.Angle.MinRadius = 1.5f;
                                    break;
                                case "Ace":
                                    m1Ai.combatSpeedLimit = 25;
                                    m1Ai.firingSpeedLimit = 20;

                                    //m1Ai.AccuracyModifiers.Angle._radius = 2.4f;
                                    m1Ai.AccuracyModifiers.Angle.MaxDistance = 3000;
                                    m1Ai.AccuracyModifiers.Angle.MaxRadius = 2f;
                                    m1Ai.AccuracyModifiers.Angle.MinRadius = 1f;
                                    m1Ai.AccuracyModifiers.Angle.IncreaseAccuracyPerShot = true;
                                    break;
                                default:
                                    //m1Ai.FireDelay = 1;//1.5229

                                    m1Ai.combatSpeedLimit = 15;//8.5
                                    m1Ai.firingSpeedLimit = 10;//5.5

                                    m1Ai.GunnerAI._delayFireTimer = 2.0325f;//2.0325
                                    m1Ai.GunnerAI._sweepAngle = 120;//120
                                    m1Ai.GunnerAI._sweepDirectionShiftSpeed = 0.25f;//.25
                                    m1Ai.GunnerAI._sweepSpeed = 20;//20
                                    m1Ai.GunnerAI._pauseLength = 1;//1
                                    m1Ai.GunnerAI._pauseTime = 2;//2

                                    //m1Ai.AccuracyModifiers.Angle._radius = 3.4f;//3.429
                                    m1Ai.AccuracyModifiers.Angle.MaxDistance = 2000;//2000
                                    m1Ai.AccuracyModifiers.Angle.MaxRadius = 4f;//4
                                    m1Ai.AccuracyModifiers.Angle.MinRadius = 2f;//2
                                    m1Ai.AccuracyModifiers.Angle.IncreaseAccuracyPerShot = false;//F

                                    m1Ai.AccuracyModifiers.Velocity.Max = 1.02f;//1.02
                                    m1Ai.AccuracyModifiers.Velocity.Min = 0.98f;//0.98
                                    m1Ai.AccuracyModifiers.Velocity.Target = 1;//1
                                    //m1Ai.AccuracyModifiers.Velocity.Value= 0.9998f;//0.9998
                                    m1Ai.AccuracyModifiers.Velocity.IncreaseAccuracyPerShot = true;//T
                                    break;
                            }

                            switch (m1a1Armor.Value)
                            {
                                case "HA":
                                    m1Rb.mass += mass_HA;
                                    break;
                                case "HC":
                                    m1Rb.mass += mass_HC;
                                    break;
                                case "SA":
                                    m1Rb.mass += mass_SA;
                                    break;
                                case "HU":
                                    m1Rb.mass += mass_HU;
                                    break;
                                default:
                                    m1Rb.mass += mass_A1;
                                    break;
                            }
                            MelonLogger.Msg("M1A1" + m1a1Armor.Value + " Mass: " + m1Rb.mass);

                            switch (m1a1Agt.Value)
                            {
                                case "AGT2000":
                                    m1VC.engine.maxPower = engine_Agt2000;
                                    m1Chassis._originalEnginePower = m1VC.engine.maxPower;

                                    m1VC.brakes.maxTorque = brakes_Agt2000;
                                    break;

                                case "AGT2500":
                                    m1VC.engine.maxPower = engine_Agt2500;
                                    m1VC.engine.maxRPM = agt2530_Maxrpm;
                                    m1VC.engine.maxRpmChange = engine_Maxrpmchange;
                                    m1VC.engine.minRPM = engine_Minrpm;

                                    m1Chassis._originalEnginePower = m1VC.engine.maxPower;

                                    m1VC.brakes.maxTorque = brakes_Agt2500;
                                    break;

                                case "AGT3000":
                                    m1VC.engine.maxPower = engine_Agt3000;
                                    m1VC.engine.maxRPM = agt2530_Maxrpm;
                                    m1VC.engine.maxRpmChange = engine_Maxrpmchange;
                                    m1VC.engine.minRPM = engine_Minrpm;

                                    m1VC.brakes.maxTorque = brakes_Agt3000;
                                    break;

                                case "T64":
                                    m1VC.engine.maxPower = engine_T64;
                                    m1VC.engine.maxRPM = t64_Maxrpm;
                                    m1VC.engine.maxRpmChange = engine_Maxrpmchange;
                                    m1VC.engine.minRPM = engine_Minrpm;

                                    m1Chassis._originalEnginePower = m1VC.engine.maxPower;

                                    m1VC.brakes.maxTorque = brakes_T64;
                                    break;

                                default:
                                    m1VC.engine.maxPower = engine_Agt1500;
                                    break;
                            }

                            switch (m1a1Loader.Value)
                            {
                                //Novice Cadet Regular Veteran Ace
                                case "Cadet":
                                    mainGun.Feed._totalReloadTime = 7;
                                    mainGun.Feed.SlowReloadMultiplier = 4.5f;
                                    loadoutManager.RackLoadouts[0].Rack._retrievalDelaySeconds = 5;
                                    loadoutManager.RackLoadouts[0].Rack._storageDelaySeconds = 5;
                                    break;
                                case "Regular":
                                    mainGun.Feed._totalReloadTime = 6;//6
                                    mainGun.Feed.SlowReloadMultiplier = 4.5f;//5
                                    loadoutManager.RackLoadouts[0].Rack._retrievalDelaySeconds = 4.5f;//5
                                    loadoutManager.RackLoadouts[0].Rack._storageDelaySeconds = 4.5f;//5
                                    break;
                                case "Veteran":
                                    mainGun.Feed._totalReloadTime = 5;
                                    mainGun.Feed.SlowReloadMultiplier = 4.5f;
                                    loadoutManager.RackLoadouts[0].Rack._retrievalDelaySeconds = 3.5f;
                                    loadoutManager.RackLoadouts[0].Rack._storageDelaySeconds = 3.5f;
                                    loadoutManager.RackLoadouts[2].Rack._retrievalDelaySeconds = 7f;//8
                                    loadoutManager.RackLoadouts[2].Rack._storageDelaySeconds = 7f;//8
                                    break;
                                case "Ace":
                                    mainGun.Feed._totalReloadTime = 4;
                                    mainGun.Feed.SlowReloadMultiplier = 4.5f;
                                    loadoutManager.RackLoadouts[0].Rack._retrievalDelaySeconds = 2.5f;
                                    loadoutManager.RackLoadouts[0].Rack._storageDelaySeconds = 2.5f;
                                    loadoutManager.RackLoadouts[2].Rack._retrievalDelaySeconds = 6f;//8
                                    loadoutManager.RackLoadouts[2].Rack._storageDelaySeconds = 6f;//8
                                    break;
                                default:
                                    mainGun.Feed._totalReloadTime = 6;//6
                                    mainGun.Feed.SlowReloadMultiplier = 4.5f;//5
                                    loadoutManager.RackLoadouts[0].Rack._retrievalDelaySeconds = 4.5f;//5
                                    loadoutManager.RackLoadouts[0].Rack._storageDelaySeconds = 4.5f;//5
                                    break;
                            }

                            if (m1a1Apu.Value)
                            {
                                mainGun.FCS.ComputerNeedsPower = false;
                                m1Turret.SpeedUnpowered = 40;//5;

                                if (m1VC.engine.maxPower > 3300f)
                                {
                                    m1Turret.SpeedPowered = 60;//40;
                                }
                            }

                            if (noLuggage.Value)
                            {
                                GameObject.Find("luggage").SetActive(false);
                            }

                            if (m1a1Smoke.Value)
                            {
                                m1Smoke._smokeGrenadeRequiredCrewPositions = CrewBrainFlag.None;
                                m1Smoke._smokeScreenRequiredCrewPositions = CrewBrainFlag.None;

                                m1Smoke._launchAngle = 20;//25
                                m1Smoke._distanceRange = new Vector2(40, 40);//25, 35
                                for (int i = 0; i < 12; i++)
                                {
                                    m1Smoke._smokeSlots[i].Rounds = 2;
                                }

                                if (m1a1Rosy.Value)
                                {

                                    m1Smoke._launchAngle = 6;//25
                                    m1Smoke._distanceRange = new Vector2(500, 500);//25, 35

                                    m1Smoke._smokePrefab = m82Object;

                                    for (int i = 0; i < 12; i++)
                                    {
                                        m1Smoke._smokeSlots[i].Rounds = 4;
                                    }
                                    /*//Left launchers
                                    m1Smoke._smokeSlots[2].Angle = -95;
                                    m1Smoke._smokeSlots[4].Angle = -77;
                                    m1Smoke._smokeSlots[5].Angle = -59;
                                    m1Smoke._smokeSlots[1].Angle = -41;
                                    m1Smoke._smokeSlots[3].Angle = -23;
                                    m1Smoke._smokeSlots[0].Angle = -5;

                                    //Right Launchers
                                    m1Smoke._smokeSlots[6].Angle = 5;
                                    m1Smoke._smokeSlots[9].Angle = 23;
                                    m1Smoke._smokeSlots[7].Angle = 41;
                                    m1Smoke._smokeSlots[11].Angle = 59;
                                    m1Smoke._smokeSlots[10].Angle = 77;
                                    m1Smoke._smokeSlots[8].Angle = 95;*/

                                    //Left launchers
                                    m1Smoke._smokeSlots[2].Angle = -82;
                                    m1Smoke._smokeSlots[4].Angle = -67;
                                    m1Smoke._smokeSlots[5].Angle = -52;
                                    m1Smoke._smokeSlots[1].Angle = -37;
                                    m1Smoke._smokeSlots[3].Angle = -22;
                                    m1Smoke._smokeSlots[0].Angle = -7;

                                    //Right Launchers
                                    m1Smoke._smokeSlots[6].Angle = 7;
                                    m1Smoke._smokeSlots[9].Angle = 22;
                                    m1Smoke._smokeSlots[7].Angle = 37;
                                    m1Smoke._smokeSlots[11].Angle = 52;
                                    m1Smoke._smokeSlots[10].Angle = 67;
                                    m1Smoke._smokeSlots[8].Angle = 82;

                                    //Salvo 1
                                    //S1 Left Pattern
                                    m1Smoke._smokeGroups[0].SmokePatternData[0].SmokeSlotIndex = 2;
                                    m1Smoke._smokeGroups[0].SmokePatternData[1].SmokeSlotIndex = 4;
                                    m1Smoke._smokeGroups[0].SmokePatternData[2].SmokeSlotIndex = 5;
                                    m1Smoke._smokeGroups[0].SmokePatternData[3].SmokeSlotIndex = 1;
                                    m1Smoke._smokeGroups[0].SmokePatternData[4].SmokeSlotIndex = 3;
                                    m1Smoke._smokeGroups[0].SmokePatternData[5].SmokeSlotIndex = 0;

                                    //S1 Right Pattern
                                    var sg1_smokePattern7 = m1Smoke._smokeGroups[0].SmokePatternData.ToList<SmokePatternData>();
                                    SmokePatternData smokePatternData7 = new SmokePatternData();
                                    smokePatternData7.SmokeSlotIndex = 6;
                                    sg1_smokePattern7.Add(smokePatternData7);

                                    m1Smoke._smokeGroups[0].SmokePatternData = sg1_smokePattern7.ToArray<SmokePatternData>();

                                    var sg1_smokePattern8 = m1Smoke._smokeGroups[0].SmokePatternData.ToList<SmokePatternData>();
                                    SmokePatternData smokePatternData8 = new SmokePatternData();
                                    smokePatternData8.SmokeSlotIndex = 9;
                                    sg1_smokePattern8.Add(smokePatternData8);

                                    m1Smoke._smokeGroups[0].SmokePatternData = sg1_smokePattern8.ToArray<SmokePatternData>();

                                    var sg1_smokePattern9 = m1Smoke._smokeGroups[0].SmokePatternData.ToList<SmokePatternData>();
                                    SmokePatternData smokePatternData9 = new SmokePatternData();
                                    smokePatternData9.SmokeSlotIndex = 7;
                                    sg1_smokePattern9.Add(smokePatternData9);

                                    m1Smoke._smokeGroups[0].SmokePatternData = sg1_smokePattern9.ToArray<SmokePatternData>();

                                    var sg1_smokePattern10 = m1Smoke._smokeGroups[0].SmokePatternData.ToList<SmokePatternData>();
                                    SmokePatternData smokePatternData10 = new SmokePatternData();
                                    smokePatternData10.SmokeSlotIndex = 11;
                                    sg1_smokePattern10.Add(smokePatternData10);

                                    m1Smoke._smokeGroups[0].SmokePatternData = sg1_smokePattern10.ToArray<SmokePatternData>();

                                    var sg1_smokePattern11 = m1Smoke._smokeGroups[0].SmokePatternData.ToList<SmokePatternData>();
                                    SmokePatternData smokePatternData11 = new SmokePatternData();
                                    smokePatternData11.SmokeSlotIndex = 10;
                                    sg1_smokePattern11.Add(smokePatternData11);

                                    m1Smoke._smokeGroups[0].SmokePatternData = sg1_smokePattern11.ToArray<SmokePatternData>();

                                    var sg1_smokePattern12 = m1Smoke._smokeGroups[0].SmokePatternData.ToList<SmokePatternData>();
                                    SmokePatternData smokePatternData12 = new SmokePatternData();
                                    smokePatternData12.SmokeSlotIndex = 8;
                                    sg1_smokePattern12.Add(smokePatternData12);

                                    m1Smoke._smokeGroups[0].SmokePatternData = sg1_smokePattern12.ToArray<SmokePatternData>();

                                    //Salvo 2
                                    //S2 Left Pattern
                                    m1Smoke._smokeGroups[1].SmokePatternData[0].SmokeSlotIndex = 2;
                                    m1Smoke._smokeGroups[1].SmokePatternData[1].SmokeSlotIndex = 4;
                                    m1Smoke._smokeGroups[1].SmokePatternData[2].SmokeSlotIndex = 5;
                                    m1Smoke._smokeGroups[1].SmokePatternData[3].SmokeSlotIndex = 1;
                                    m1Smoke._smokeGroups[1].SmokePatternData[4].SmokeSlotIndex = 3;
                                    m1Smoke._smokeGroups[1].SmokePatternData[5].SmokeSlotIndex = 0;

                                    //S2 Right Pattern
                                    var sg2_smokePattern7 = m1Smoke._smokeGroups[1].SmokePatternData.ToList<SmokePatternData>();
                                    SmokePatternData sg2smokePatternData7 = new SmokePatternData();
                                    sg2smokePatternData7.SmokeSlotIndex = 6;
                                    sg2_smokePattern7.Add(sg2smokePatternData7);

                                    m1Smoke._smokeGroups[1].SmokePatternData = sg2_smokePattern7.ToArray<SmokePatternData>();

                                    var sg2_smokePattern8 = m1Smoke._smokeGroups[1].SmokePatternData.ToList<SmokePatternData>();
                                    SmokePatternData sg2smokePatternData8 = new SmokePatternData();
                                    sg2smokePatternData8.SmokeSlotIndex = 9;
                                    sg2_smokePattern8.Add(sg2smokePatternData8);

                                    m1Smoke._smokeGroups[1].SmokePatternData = sg2_smokePattern8.ToArray<SmokePatternData>();

                                    var sg2_smokePattern9 = m1Smoke._smokeGroups[1].SmokePatternData.ToList<SmokePatternData>();
                                    SmokePatternData sg2smokePatternData9 = new SmokePatternData();
                                    sg2smokePatternData9.SmokeSlotIndex = 7;
                                    sg2_smokePattern9.Add(sg2smokePatternData9);

                                    m1Smoke._smokeGroups[1].SmokePatternData = sg2_smokePattern9.ToArray<SmokePatternData>();

                                    var sg2_smokePattern10 = m1Smoke._smokeGroups[1].SmokePatternData.ToList<SmokePatternData>();
                                    SmokePatternData sg2smokePatternData10 = new SmokePatternData();
                                    sg2smokePatternData10.SmokeSlotIndex = 11;
                                    sg2_smokePattern10.Add(sg2smokePatternData10);

                                    m1Smoke._smokeGroups[1].SmokePatternData = sg2_smokePattern10.ToArray<SmokePatternData>();

                                    var sg2_smokePattern11 = m1Smoke._smokeGroups[1].SmokePatternData.ToList<SmokePatternData>();
                                    SmokePatternData sg2smokePatternData11 = new SmokePatternData();
                                    sg2smokePatternData11.SmokeSlotIndex = 10;
                                    sg2_smokePattern11.Add(sg2smokePatternData11);

                                    m1Smoke._smokeGroups[1].SmokePatternData = sg2_smokePattern11.ToArray<SmokePatternData>();

                                    var sg2_smokePattern12 = m1Smoke._smokeGroups[1].SmokePatternData.ToList<SmokePatternData>();
                                    SmokePatternData sg2smokePatternData12 = new SmokePatternData();
                                    sg2smokePatternData12.SmokeSlotIndex = 8;
                                    sg2_smokePattern12.Add(sg2smokePatternData12);

                                    m1Smoke._smokeGroups[1].SmokePatternData = sg2_smokePattern12.ToArray<SmokePatternData>();

                                    //More smoke slots
                                    //GOATLAS
                                    /*var launcher12 = m1Smoke._smokeSlots.ToList<SmokeSlot>();
                                    SmokeSlot slot12 = new SmokeSlot();
                                    Util.ShallowCopy(slot12, m1Smoke._smokeSlots[2]);
                                    slot12.Rounds = 300;
                                    slot12.Angle = -120;
                                    launcher12.Add(slot12);

                                    m1Smoke._smokeSlots = launcher12.ToArray<SmokeSlot>();

                                    var launcher13 = m1Smoke._smokeSlots.ToList<SmokeSlot>();
                                    SmokeSlot slot13 = new SmokeSlot();
                                    Util.ShallowCopy(slot13, m1Smoke._smokeSlots[10]);
                                    slot13.Rounds = 300;
                                    slot13.Angle = 120;
                                    launcher13.Add(slot13);

                                    m1Smoke._smokeSlots = launcher13.ToArray<SmokeSlot>();/*

                                    //More smoke patterns
                                    /*var sg1_smokePattern7 = m1Smoke._smokeGroups[0].SmokePatternData.ToList<SmokePatternData>();
                                    SmokePatternData smokePatternData7 = new SmokePatternData();
                                    smokePatternData7.SmokeSlotIndex = 12;
                                    sg1_smokePattern7.Add(smokePatternData7);

                                    m1Smoke._smokeGroups[0].SmokePatternData = sg1_smokePattern7.ToArray<SmokePatternData>();

                                    var sg1_smokePattern8 = m1Smoke._smokeGroups[0].SmokePatternData.ToList<SmokePatternData>();
                                    SmokePatternData smokePatternData8 = new SmokePatternData();
                                    smokePatternData8.SmokeSlotIndex = 13;
                                    sg1_smokePattern8.Add(smokePatternData8);

                                    m1Smoke._smokeGroups[0].SmokePatternData = sg1_smokePattern8.ToArray<SmokePatternData>();


                                    //More Smoke Groups
                                    var smokeGroup3 = m1Smoke._smokeGroups.ToList<SmokePattern>();
                                    SmokePattern smokePattern3 = new SmokePattern();
                                    smokeGroup3.Add(smokePattern3);

                                    m1Smoke._smokeGroups = smokeGroup3.ToArray<SmokePattern>();

                                    m1Smoke._smokeGroups[2].SmokePatternData = sg1_smokePattern7.ToArray<SmokePatternData>();
                                    m1Smoke._smokeGroups[2].SmokePatternData = sg1_smokePattern8.ToArray<SmokePatternData>();*/
                                }
                            }
                        }

                        if (vic.FriendlyName == "M1E1" + m1e1Armor.Value)
                        {
                            switch (m1e1Commander.Value)
                            {
                                case "Cadet":
                                    m1Ai.SpotTimeMaxDistance = 2500;
                                    m1Ai.TargetSensor._spotTimeMax = 5;
                                    m1Ai.TargetSensor._spotTimeMaxDistance = 500;
                                    m1Ai.TargetSensor._spotTimeMaxVelocity = 2;
                                    m1Ai.TargetSensor._spotTimeMin = 1;
                                    m1Ai.TargetSensor._spotTimeMinDistance = 50;
                                    m1Ai.TargetSensor._targetCooldownTime = 3f;

                                    m1Ai.CommanderAI._identifyTargetDurationRange = new Vector2(3f, 4f);
                                    m1Ai.CommanderAI._sweepCommsCheckDuration = 5;
                                    break;
                                case "Veteran":
                                    m1Ai.SpotTimeMaxDistance = 3500;
                                    m1Ai.TargetSensor._spotTimeMax = 3;
                                    m1Ai.TargetSensor._spotTimeMaxDistance = 500;
                                    m1Ai.TargetSensor._spotTimeMaxVelocity = 7f;
                                    m1Ai.TargetSensor._spotTimeMin = 1;
                                    m1Ai.TargetSensor._spotTimeMinDistance = 50;
                                    m1Ai.TargetSensor._targetCooldownTime = 1.5f;

                                    m1Ai.CommanderAI._identifyTargetDurationRange = new Vector2(1.5f, 2.5f);
                                    m1Ai.CommanderAI._sweepCommsCheckDuration = 4;
                                    break;
                                case "Ace":
                                    m1Ai.SpotTimeMaxDistance = 4000;
                                    m1Ai.TargetSensor._spotTimeMax = 2;
                                    m1Ai.TargetSensor._spotTimeMaxDistance = 500;
                                    m1Ai.TargetSensor._spotTimeMaxVelocity = 10f;
                                    m1Ai.TargetSensor._spotTimeMin = 1;
                                    m1Ai.TargetSensor._spotTimeMinDistance = 50;
                                    m1Ai.TargetSensor._targetCooldownTime = 1f;

                                    m1Ai.CommanderAI._identifyTargetDurationRange = new Vector2(1f, 2f);
                                    m1Ai.CommanderAI._sweepCommsCheckDuration = 3;
                                    break;
                                default:
                                    m1Ai.SpotTimeMaxDistance = 3000;//3000
                                    m1Ai.TargetSensor._spotTimeMax = 4;//4
                                    m1Ai.TargetSensor._spotTimeMaxDistance = 500;//500
                                    m1Ai.TargetSensor._spotTimeMaxVelocity = 4;//4
                                    m1Ai.TargetSensor._spotTimeMin = 1;//1
                                    m1Ai.TargetSensor._spotTimeMinDistance = 50;//50
                                    m1Ai.TargetSensor._targetCooldownTime = 2f;//2

                                    m1Ai.CommanderAI._identifyTargetDurationRange = new Vector2(2f, 3f);//2,3
                                    m1Ai.CommanderAI._sweepCommsCheckDuration = 5;//5
                                    break;
                            }

                            switch (m1e1Gunner.Value)
                            {
                                case "Cadet":
                                    m1Ai.combatSpeedLimit = 10;
                                    m1Ai.firingSpeedLimit = 7;

                                    //m1Ai.AccuracyModifiers.Angle._radius = 3.9f;
                                    m1Ai.AccuracyModifiers.Angle.MaxDistance = 2000;
                                    m1Ai.AccuracyModifiers.Angle.MaxRadius = 4.5f;
                                    m1Ai.AccuracyModifiers.Angle.MinRadius = 2.5f;
                                    break;
                                case "Veteran":
                                    m1Ai.combatSpeedLimit = 20;
                                    m1Ai.firingSpeedLimit = 15;

                                    //m1Ai.AccuracyModifiers.Angle._radius = 2.9f;
                                    m1Ai.AccuracyModifiers.Angle.MaxDistance = 2500;
                                    m1Ai.AccuracyModifiers.Angle.MaxRadius = 2.5f;
                                    m1Ai.AccuracyModifiers.Angle.MinRadius = 1.5f;
                                    break;
                                case "Ace":
                                    m1Ai.combatSpeedLimit = 25;
                                    m1Ai.firingSpeedLimit = 20;

                                    //m1Ai.AccuracyModifiers.Angle._radius = 2.4f;
                                    m1Ai.AccuracyModifiers.Angle.MaxDistance = 3000;
                                    m1Ai.AccuracyModifiers.Angle.MaxRadius = 2f;
                                    m1Ai.AccuracyModifiers.Angle.MinRadius = 1f;
                                    m1Ai.AccuracyModifiers.Angle.IncreaseAccuracyPerShot = true;
                                    break;
                                default:
                                    //m1Ai.FireDelay = 1;//1.5229

                                    m1Ai.combatSpeedLimit = 15;//8.5
                                    m1Ai.firingSpeedLimit = 10;//5.5

                                    m1Ai.GunnerAI._delayFireTimer = 2.0325f;//2.0325
                                    m1Ai.GunnerAI._sweepAngle = 120;//120
                                    m1Ai.GunnerAI._sweepDirectionShiftSpeed = 0.25f;//.25
                                    m1Ai.GunnerAI._sweepSpeed = 20;//20
                                    m1Ai.GunnerAI._pauseLength = 1;//1
                                    m1Ai.GunnerAI._pauseTime = 2;//2

                                    //m1Ai.AccuracyModifiers.Angle._radius = 3.4f;//3.429
                                    m1Ai.AccuracyModifiers.Angle.MaxDistance = 2000;//2000
                                    m1Ai.AccuracyModifiers.Angle.MaxRadius = 4f;//4
                                    m1Ai.AccuracyModifiers.Angle.MinRadius = 2f;//2
                                    m1Ai.AccuracyModifiers.Angle.IncreaseAccuracyPerShot = false;//F

                                    m1Ai.AccuracyModifiers.Velocity.Max = 1.02f;//1.02
                                    m1Ai.AccuracyModifiers.Velocity.Min = 0.98f;//0.98
                                    m1Ai.AccuracyModifiers.Velocity.Target = 1;//1
                                    //m1Ai.AccuracyModifiers.Velocity.Value= 0.9998f;//0.9998
                                    m1Ai.AccuracyModifiers.Velocity.IncreaseAccuracyPerShot = true;//T
                                    break;
                            }

                            switch (m1e1Armor.Value)
                            {
                                case "HA":
                                    m1Rb.mass += mass_HA;
                                    break;
                                case "HC":
                                    m1Rb.mass += mass_HC;
                                    break;
                                case "SA":
                                    m1Rb.mass += mass_SA;
                                    break;
                                case "HU":
                                    m1Rb.mass += mass_HU;
                                    break;
                                default:
                                    m1Rb.mass += mass_A1;
                                    break;
                            }

                            switch (m1e1Agt.Value)
                            {
                                case "AGT2000":
                                    m1VC.engine.maxPower = engine_Agt2000;
                                    m1Chassis._originalEnginePower = m1VC.engine.maxPower;

                                    m1VC.brakes.maxTorque = brakes_Agt2000;
                                    break;

                                case "AGT2500":
                                    m1VC.engine.maxPower = engine_Agt2500;
                                    m1VC.engine.maxRPM = agt2530_Maxrpm;
                                    m1VC.engine.maxRpmChange = engine_Maxrpmchange;
                                    m1VC.engine.minRPM = engine_Minrpm;

                                    m1Chassis._originalEnginePower = m1VC.engine.maxPower;

                                    m1VC.brakes.maxTorque = brakes_Agt2500;
                                    break;

                                case "AGT3000":
                                    m1VC.engine.maxPower = engine_Agt3000;
                                    m1VC.engine.maxRPM = agt2530_Maxrpm;
                                    m1VC.engine.maxRpmChange = engine_Maxrpmchange;
                                    m1VC.engine.minRPM = engine_Minrpm;

                                    m1VC.brakes.maxTorque = brakes_Agt3000;
                                    break;

                                case "T64":
                                    m1VC.engine.maxPower = engine_T64;
                                    m1VC.engine.maxRPM = t64_Maxrpm;
                                    m1VC.engine.maxRpmChange = engine_Maxrpmchange;
                                    m1VC.engine.minRPM = engine_Minrpm;

                                    m1Chassis._originalEnginePower = m1VC.engine.maxPower;

                                    m1VC.brakes.maxTorque = brakes_T64;
                                    break;

                                default:
                                    m1VC.engine.maxPower = engine_Agt1500;
                                    break;
                            }

                            switch (m1e1Loader.Value)
                            {
                                case "Cadet":
                                    mainGun.Feed._totalReloadTime = 7;
                                    mainGun.Feed.SlowReloadMultiplier = 4.5f;
                                    loadoutManager.RackLoadouts[0].Rack._retrievalDelaySeconds = 5;
                                    loadoutManager.RackLoadouts[0].Rack._storageDelaySeconds = 5;
                                    break;
                                case "Regular":
                                    mainGun.Feed._totalReloadTime = 6;//6
                                    mainGun.Feed.SlowReloadMultiplier = 4.5f;//5
                                    loadoutManager.RackLoadouts[0].Rack._retrievalDelaySeconds = 4.5f;//5
                                    loadoutManager.RackLoadouts[0].Rack._storageDelaySeconds = 4.5f;//5
                                    break;
                                case "Veteran":
                                    mainGun.Feed._totalReloadTime = 5;
                                    mainGun.Feed.SlowReloadMultiplier = 4.5f;
                                    loadoutManager.RackLoadouts[0].Rack._retrievalDelaySeconds = 3.5f;
                                    loadoutManager.RackLoadouts[0].Rack._storageDelaySeconds = 3.5f;
                                    loadoutManager.RackLoadouts[2].Rack._retrievalDelaySeconds = 7f;//8
                                    loadoutManager.RackLoadouts[2].Rack._storageDelaySeconds = 7f;//8
                                    break;
                                case "Ace":
                                    mainGun.Feed._totalReloadTime = 4;
                                    mainGun.Feed.SlowReloadMultiplier = 4.5f;
                                    loadoutManager.RackLoadouts[0].Rack._retrievalDelaySeconds = 2.5f;
                                    loadoutManager.RackLoadouts[0].Rack._storageDelaySeconds = 2.5f;
                                    loadoutManager.RackLoadouts[2].Rack._retrievalDelaySeconds = 6f;
                                    loadoutManager.RackLoadouts[2].Rack._storageDelaySeconds = 6f;
                                    break;
                                default:
                                    mainGun.Feed._totalReloadTime = 6;//6
                                    mainGun.Feed.SlowReloadMultiplier = 4.5f;//5
                                    loadoutManager.RackLoadouts[0].Rack._retrievalDelaySeconds = 4.5f;//5
                                    loadoutManager.RackLoadouts[0].Rack._storageDelaySeconds = 4.5f;//5
                                    break;
                            }

                            if (m1e1Apu.Value)
                            {
                                mainGun.FCS.ComputerNeedsPower = false;
                                m1Turret.SpeedUnpowered = 40;//5;

                                if (m1VC.engine.maxPower > 3300f)
                                {
                                    m1Turret.SpeedPowered = 60;//40;
                                }
                            }

                            if (noLuggage.Value)
                            {
                                GameObject.Find("turret decorations parent").SetActive(false);
                            }

                            if (m1e1Smoke.Value)
                            {
                                m1Smoke._smokeGrenadeRequiredCrewPositions = CrewBrainFlag.None;
                                m1Smoke._smokeScreenRequiredCrewPositions = CrewBrainFlag.None;

                                m1Smoke._launchAngle = 20;//25
                                m1Smoke._distanceRange = new Vector2(40, 40);//25, 35
                                for (int i = 0; i < 12; i++)
                                {
                                    m1Smoke._smokeSlots[i].Rounds = 2;
                                }

                                if (m1e1Rosy.Value)
                                {

                                    m1Smoke._launchAngle = 6;//25
                                    m1Smoke._distanceRange = new Vector2(500, 500);//25, 35

                                    m1Smoke._smokePrefab = m82Object;
                                    for (int i = 0; i < 12; i++)
                                    {
                                        m1Smoke._smokeSlots[i].Rounds = 4;
                                    }

                                    //Left launchers
                                    m1Smoke._smokeSlots[2].Angle = -82;
                                    m1Smoke._smokeSlots[4].Angle = -67;
                                    m1Smoke._smokeSlots[5].Angle = -52;
                                    m1Smoke._smokeSlots[1].Angle = -37;
                                    m1Smoke._smokeSlots[3].Angle = -22;
                                    m1Smoke._smokeSlots[0].Angle = -7;

                                    //Right Launchers
                                    m1Smoke._smokeSlots[6].Angle = 7;
                                    m1Smoke._smokeSlots[9].Angle = 22;
                                    m1Smoke._smokeSlots[7].Angle = 37;
                                    m1Smoke._smokeSlots[11].Angle = 52;
                                    m1Smoke._smokeSlots[10].Angle = 67;
                                    m1Smoke._smokeSlots[8].Angle = 82;

                                    //Salvo 1
                                    //S1 Left Pattern
                                    m1Smoke._smokeGroups[0].SmokePatternData[0].SmokeSlotIndex = 2;
                                    m1Smoke._smokeGroups[0].SmokePatternData[1].SmokeSlotIndex = 4;
                                    m1Smoke._smokeGroups[0].SmokePatternData[2].SmokeSlotIndex = 5;
                                    m1Smoke._smokeGroups[0].SmokePatternData[3].SmokeSlotIndex = 1;
                                    m1Smoke._smokeGroups[0].SmokePatternData[4].SmokeSlotIndex = 3;
                                    m1Smoke._smokeGroups[0].SmokePatternData[5].SmokeSlotIndex = 0;

                                    //S1 Right Pattern
                                    var sg1_smokePattern7 = m1Smoke._smokeGroups[0].SmokePatternData.ToList<SmokePatternData>();
                                    SmokePatternData smokePatternData7 = new SmokePatternData();
                                    smokePatternData7.SmokeSlotIndex = 6;
                                    sg1_smokePattern7.Add(smokePatternData7);

                                    m1Smoke._smokeGroups[0].SmokePatternData = sg1_smokePattern7.ToArray<SmokePatternData>();

                                    var sg1_smokePattern8 = m1Smoke._smokeGroups[0].SmokePatternData.ToList<SmokePatternData>();
                                    SmokePatternData smokePatternData8 = new SmokePatternData();
                                    smokePatternData8.SmokeSlotIndex = 9;
                                    sg1_smokePattern8.Add(smokePatternData8);

                                    m1Smoke._smokeGroups[0].SmokePatternData = sg1_smokePattern8.ToArray<SmokePatternData>();

                                    var sg1_smokePattern9 = m1Smoke._smokeGroups[0].SmokePatternData.ToList<SmokePatternData>();
                                    SmokePatternData smokePatternData9 = new SmokePatternData();
                                    smokePatternData9.SmokeSlotIndex = 7;
                                    sg1_smokePattern9.Add(smokePatternData9);

                                    m1Smoke._smokeGroups[0].SmokePatternData = sg1_smokePattern9.ToArray<SmokePatternData>();

                                    var sg1_smokePattern10 = m1Smoke._smokeGroups[0].SmokePatternData.ToList<SmokePatternData>();
                                    SmokePatternData smokePatternData10 = new SmokePatternData();
                                    smokePatternData10.SmokeSlotIndex = 11;
                                    sg1_smokePattern10.Add(smokePatternData10);

                                    m1Smoke._smokeGroups[0].SmokePatternData = sg1_smokePattern10.ToArray<SmokePatternData>();

                                    var sg1_smokePattern11 = m1Smoke._smokeGroups[0].SmokePatternData.ToList<SmokePatternData>();
                                    SmokePatternData smokePatternData11 = new SmokePatternData();
                                    smokePatternData11.SmokeSlotIndex = 10;
                                    sg1_smokePattern11.Add(smokePatternData11);

                                    m1Smoke._smokeGroups[0].SmokePatternData = sg1_smokePattern11.ToArray<SmokePatternData>();

                                    var sg1_smokePattern12 = m1Smoke._smokeGroups[0].SmokePatternData.ToList<SmokePatternData>();
                                    SmokePatternData smokePatternData12 = new SmokePatternData();
                                    smokePatternData12.SmokeSlotIndex = 8;
                                    sg1_smokePattern12.Add(smokePatternData12);

                                    m1Smoke._smokeGroups[0].SmokePatternData = sg1_smokePattern12.ToArray<SmokePatternData>();

                                    //Salvo 2
                                    //S2 Left Pattern
                                    m1Smoke._smokeGroups[1].SmokePatternData[0].SmokeSlotIndex = 2;
                                    m1Smoke._smokeGroups[1].SmokePatternData[1].SmokeSlotIndex = 4;
                                    m1Smoke._smokeGroups[1].SmokePatternData[2].SmokeSlotIndex = 5;
                                    m1Smoke._smokeGroups[1].SmokePatternData[3].SmokeSlotIndex = 1;
                                    m1Smoke._smokeGroups[1].SmokePatternData[4].SmokeSlotIndex = 3;
                                    m1Smoke._smokeGroups[1].SmokePatternData[5].SmokeSlotIndex = 0;

                                    //S2 Right Pattern
                                    var sg2_smokePattern7 = m1Smoke._smokeGroups[1].SmokePatternData.ToList<SmokePatternData>();
                                    SmokePatternData sg2smokePatternData7 = new SmokePatternData();
                                    sg2smokePatternData7.SmokeSlotIndex = 6;
                                    sg2_smokePattern7.Add(sg2smokePatternData7);

                                    m1Smoke._smokeGroups[1].SmokePatternData = sg2_smokePattern7.ToArray<SmokePatternData>();

                                    var sg2_smokePattern8 = m1Smoke._smokeGroups[1].SmokePatternData.ToList<SmokePatternData>();
                                    SmokePatternData sg2smokePatternData8 = new SmokePatternData();
                                    sg2smokePatternData8.SmokeSlotIndex = 9;
                                    sg2_smokePattern8.Add(sg2smokePatternData8);

                                    m1Smoke._smokeGroups[1].SmokePatternData = sg2_smokePattern8.ToArray<SmokePatternData>();

                                    var sg2_smokePattern9 = m1Smoke._smokeGroups[1].SmokePatternData.ToList<SmokePatternData>();
                                    SmokePatternData sg2smokePatternData9 = new SmokePatternData();
                                    sg2smokePatternData9.SmokeSlotIndex = 7;
                                    sg2_smokePattern9.Add(sg2smokePatternData9);

                                    m1Smoke._smokeGroups[1].SmokePatternData = sg2_smokePattern9.ToArray<SmokePatternData>();

                                    var sg2_smokePattern10 = m1Smoke._smokeGroups[1].SmokePatternData.ToList<SmokePatternData>();
                                    SmokePatternData sg2smokePatternData10 = new SmokePatternData();
                                    sg2smokePatternData10.SmokeSlotIndex = 11;
                                    sg2_smokePattern10.Add(sg2smokePatternData10);

                                    m1Smoke._smokeGroups[1].SmokePatternData = sg2_smokePattern10.ToArray<SmokePatternData>();

                                    var sg2_smokePattern11 = m1Smoke._smokeGroups[1].SmokePatternData.ToList<SmokePatternData>();
                                    SmokePatternData sg2smokePatternData11 = new SmokePatternData();
                                    sg2smokePatternData11.SmokeSlotIndex = 10;
                                    sg2_smokePattern11.Add(sg2smokePatternData11);

                                    m1Smoke._smokeGroups[1].SmokePatternData = sg2_smokePattern11.ToArray<SmokePatternData>();

                                    var sg2_smokePattern12 = m1Smoke._smokeGroups[1].SmokePatternData.ToList<SmokePatternData>();
                                    SmokePatternData sg2smokePatternData12 = new SmokePatternData();
                                    sg2smokePatternData12.SmokeSlotIndex = 8;
                                    sg2_smokePattern12.Add(sg2smokePatternData12);

                                    m1Smoke._smokeGroups[1].SmokePatternData = sg2_smokePattern12.ToArray<SmokePatternData>();
                                }
                            }

                            if (m1ipModel.Value)
                            {
                                ////IP model to base M1
                                GameObject m1_hull = vic_go.transform.Find("M1_rig/M1_hull/").gameObject;
                                GameObject m1_skinned = vic_go.transform.Find("M1_rig/M1_skinned/").gameObject;
                                m1_hull.SetActive(false);
                                m1_skinned.SetActive(false);

                                GameObject m1ip_hull = vic_go.transform.Find("IPM1_rig/M1IP_hull/").gameObject;
                                GameObject m1ip_skinned = vic_go.transform.Find("IPM1_rig/M1IP_skinned/").gameObject;
                                m1ip_hull.SetActive(true);
                                m1ip_skinned.SetActive(true);


                                //M1 TURRET FOLLOW/M1A0_turret_armour
                                GameObject m1_turretcheeks = vic.transform.Find("IPM1_rig/HULL/TURRET").GetComponent<LateFollowTarget>()
                                    ._lateFollowers[0].transform.Find("M1A0_turret_armour/CHEEKS NERA").gameObject;
                                m1_turretcheeks.SetActive(false);

                                GameObject m1_turretcheeksface = vic.transform.Find("IPM1_rig/HULL/TURRET").GetComponent<LateFollowTarget>()
                                    ._lateFollowers[0].transform.Find("M1A0_turret_armour/CHEEKS OUTTER").gameObject;
                                m1_turretcheeksface.SetActive(false);

                                GameObject m1_turretroof = vic.transform.Find("IPM1_rig/HULL/TURRET").GetComponent<LateFollowTarget>()
                                    ._lateFollowers[0].transform.Find("M1A0_turret_armour/ROOF").gameObject;
                                m1_turretroof.SetActive(false);



                                Transform turret = vic.transform.Find("IPM1_rig/HULL/TURRET");
                                GameObject.Instantiate(m1ip_cheeksnera, turret.GetComponent<LateFollowTarget>()._lateFollowers[0].transform.Find("M1A0_turret_armour"));
                                GameObject.Instantiate(m1ip_cheeksface, turret.GetComponent<LateFollowTarget>()._lateFollowers[0].transform.Find("M1A0_turret_armour"));
                                GameObject.Instantiate(m1ip_turretroof, turret.GetComponent<LateFollowTarget>()._lateFollowers[0].transform.Find("M1A0_turret_armour"));
                            }
                        }

                        if (betterTransmission.Value)
                        {
                            List<float> fwGears = new List<float>();
                            fwGears.Add(8.28f);
                            fwGears.Add(5.81f);
                            fwGears.Add(2.98f);
                            fwGears.Add(1.76f);
                            fwGears.Add(1.36f);
                            fwGears.Add(1.16f);

                            List<float> rvGears = new List<float>();
                            rvGears.Add(-1.76f);
                            rvGears.Add(-2.98f);
                            rvGears.Add(-8.28f);

                            List<float> Gears = new List<float>();
                            Gears.Add(-1.76f);
                            Gears.Add(-2.98f);
                            Gears.Add(-8.28f);
                            Gears.Add(0f);
                            Gears.Add(8.28f);
                            Gears.Add(5.81f);
                            Gears.Add(2.98f);
                            Gears.Add(1.76f);
                            Gears.Add(1.36f);
                            Gears.Add(1.16f);

                            //m1VC.transmission.adjustedShiftDownRpm = 720f;// 720f;
                            //m1VC.transmission.adjustedShiftUpRpm = 3500f;//2900f;
                            m1VC.transmission.forwardGears = fwGears;//5.81 2.98 1.86 1.26
                            m1VC.transmission.gearMultiplier = 9.28f;//9.28f
                            m1VC.transmission.gears = Gears;//-2.32 -8.19 0 5.81 2.98 1.86 1.26
                            m1VC.transmission.reverseGears = rvGears;//-2.32 -8.19
                            //m1VC.transmission.targetClutchRPM = 2400f;//2300f;
                            //m1VC.transmission.targetShiftDownRPM = 750f;//750;
                            //m1VC.transmission.targetShiftUpRPM = 3000f;//2900;
                            m1VC.transmission.shiftDuration = 0.1f;//.309
                            m1VC.transmission.shiftDurationRandomness = 0.1f;//.2
                            m1VC.transmission.shiftPointRandomness = 0.05f;//.05
                            //m1VC.transmission.differentialType = Transmission.DifferentialType.LimitedSlip;
                        }

                        if (governorDelete.Value)
                        {
                            m1Chassis._maxForwardSpeed = 32f;//20
                            m1Chassis._maxReverseSpeed = 16f;//11.176
                        }

                        //// Abrams loadout management
                        AmmoType.AmmoClip[] m256_ammo_clip_types = new AmmoType.AmmoClip[] { };

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
                            GHPC.Weapons.AmmoRack m256rack = loadoutManager.RackLoadouts[i].Rack;
                            m256rack.ClipCapacity = i == 2 ? 4 : 21;
                            m256rack.ClipTypes = m256_ammo_clip_types;
                            Util.EmptyRack(m256rack);
                        }

                        WeaponSystemInfo coaxGunInfo = weaponsManager.Weapons[1];
                        WeaponSystem coaxGun = coaxGunInfo.Weapon;

                        if (m2Coax.Value)
                        {
                            coaxGunInfo.Name = "M2HB Coaxial Gun";
                            //coaxGun.WeaponSound.LoopEventPath = null;
                            coaxGun.WeaponSound.LoopEventPath = "event:/Weapons/MG_m85_400rmp";
                            //coaxGun.WeaponSound.LoopEvent.eventBuffer

                            //coaxGun.WeaponSound.SingleShotByDefault = true;
                            //coaxGun.WeaponSound.SingleShotEventPaths[0] = "event:/Weapons/MG_m85_400rmp";
                            coaxGun.SetCycleTime(0.133f);
                            coaxGun.BaseDeviationAngle = 0.025f;// 0.05

                            coaxGun.Feed.AmmoTypeInBreech = null;
                            coaxGun.Feed.ReadyRack.ClipTypes[0] = m2Slap.Value ? clip_m962slapt : clip_m8api;
                            coaxGun.Feed.ReadyRack.Awake();
                            coaxGun.Feed.Start();
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

                        ////ERA detection for TUSK designation
                        foreach (GameObject armor_go in GameObject.FindGameObjectsWithTag("Penetrable"))
                        {
                            if (armor_go.name != "HULLARMOR") continue;
                            if (!armor_go.transform.parent.GetComponent<LateFollow>()) continue;

                            string name = armor_go.transform.parent.GetComponent<LateFollow>().ParentUnit.FriendlyName;
                            //string name = armor_go.transform.parent.GetComponent<LateFollow>().ParentUnit.UniqueName;

                            if (name == "M1A1" + m1a1Armor.Value || name == "M1E1" + m1e1Armor.Value)
                            //if (name == "M1IP" || name == "M1")
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

            if (citv_obj == null)
            {
                var bundle = AssetBundle.LoadFromFile(Path.Combine(MelonEnvironment.ModsDirectory + "/m1a1CITV/", "citv"));
                citv_obj = bundle.LoadAsset<GameObject>("citv.prefab");
                citv_obj.hideFlags = HideFlags.DontUnloadUnusedAsset;
                citv_obj.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                GameObject assem = citv_obj.transform.Find("assembly").gameObject;
                GameObject glass = citv_obj.transform.Find("glass").gameObject;

                assem.tag = "Penetrable";
                glass.tag = "Penetrable";

                VariableArmor assem_armour = assem.AddComponent<VariableArmor>();
                VariableArmor glass_armour = glass.AddComponent<VariableArmor>();
                //HeatSource assem_armour_Ts = assem.AddComponent<HeatSource>();
                //HeatSource glass_armour_Ts = glass.AddComponent<HeatSource>();
                assem_armour.AverageRha = 40f;
                assem_armour._name = "CITV";
                glass_armour._name = "CITV glass";
            }

            if (gun_m256 == null)
            {

                ////Borrow existing ammo and armor attributes
                foreach (AmmoCodexScriptable s in Resources.FindObjectsOfTypeAll(typeof(AmmoCodexScriptable)))
                {
                    if (s.AmmoType.Name == "M833 APFSDS-T") ammo_m833 = s.AmmoType;
                    if (s.AmmoType.Name == "M456 HEAT-FS-T") ammo_m456 = s.AmmoType;
                    if (s.AmmoType.Name == "3OF26 HEF-FS-T") ammo_3of26 = s.AmmoType;
                    if (s.AmmoType.Name == "BGM-71C I-TOW") ammo_bgm71 = s.AmmoType;
                    if (s.AmmoType.Name == "M8 API") ammo_m8vnl = s.AmmoType;
                }

                foreach (ArmorCodexScriptable s in Resources.FindObjectsOfTypeAll(typeof(ArmorCodexScriptable)))
                {
                    if (s.ArmorType.Name == "composite skirt") armor_compositeskirt_VNL = s.ArmorType;
                    if (s.ArmorType.Name == "special armor") armor_specialarmor_VNL = s.ArmorType;
                    if (s.ArmorType.Name == "tracks") armor_tracks_VNL = s.ArmorType;
                    if (s.ArmorType.Name == "gun steel") armor_gunsteel_VNL = s.ArmorType;
                }

                foreach (AmmoClipCodexScriptable s in Resources.FindObjectsOfTypeAll(typeof(AmmoClipCodexScriptable)))
                {
                    if (clip_codex_m2apt != null) break;
                }

                var era_optimizations_m829a3 = new List<AmmoType.ArmorOptimization>() { };
                var era_optimizations_m829a4 = new List<AmmoType.ArmorOptimization>() { };
                var era_optimizations_m830a2 = new List<AmmoType.ArmorOptimization>() { };
                var era_optimizations_lahat = new List<AmmoType.ArmorOptimization>() { };

                string[] era_names = new string[] {
                    "kontakt-1 armour",
                    "kontakt-5 armour",
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

                        AmmoType.ArmorOptimization optimization_m830a23 = new AmmoType.ArmorOptimization();
                        optimization_m830a23.Armor = s;
                        optimization_m830a23.RhaRatio = 0.15f;
                        era_optimizations_m830a2.Add(optimization_m830a23);

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
                //m829 
                ammo_m829 = new AmmoType();
                Util.ShallowCopy(ammo_m829, ammo_m833);
                ammo_m829.Caliber = 120;
                ammo_m829.CertainRicochetAngle = 9f;//5f;
                ammo_m829.Mass = 3.94f;
                ammo_m829.MaxNutationPenalty = 0f;
                //ammo_m829.MaxSpallRha = 16f;
                ammo_m829.MuzzleVelocity = 1670f;
                ammo_m829.Name = "M829 APFSDS-T";
                ammo_m829.RhaPenetration = 600;
                if (m829spall.Value) ammo_m829.SpallMultiplier = 1.25f;

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

                //m829a1
                ammo_m829a1 = new AmmoType();
                Util.ShallowCopy(ammo_m829a1, ammo_m833);
                ammo_m829a1.Caliber = 120;
                ammo_m829a1.CertainRicochetAngle = 9f;// 5f;
                ammo_m829a1.Mass = 4.64f;
                ammo_m829a1.MuzzleVelocity = 1575f;
                ammo_m829a1.Name = "M829A1 APFSDS-T";
                ammo_m829a1.MaxNutationPenalty = 0f;
                //ammo_m829a1.MaxSpallRha = 20f;
                ammo_m829a1.RhaPenetration = 700f;
                if (m829spall.Value) ammo_m829a1.SpallMultiplier = 1.25f;

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

                //m829a2
                ammo_m829a2 = new AmmoType();
                Util.ShallowCopy(ammo_m829a2, ammo_m833);
                ammo_m829a2.Caliber = 120;
                ammo_m829a2.CertainRicochetAngle = 9f;// 4f;
                ammo_m829a2.Mass = 4.74f;
                ammo_m829a2.MaxNutationPenalty = 0f;
                //ammo_m829a2.MaxSpallRha = 24f;
                ammo_m829a2.MuzzleVelocity = 1680f;
                ammo_m829a2.Name = "M829A2 APFSDS-T";
                ammo_m829a2.RhaPenetration = 750f;
                if (m829spall.Value) ammo_m829a2.SpallMultiplier = 1.5f;

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

                //m829a3
                ammo_m829a3 = new AmmoType();
                Util.ShallowCopy(ammo_m829a3, ammo_m833);
                ammo_m829a3.ArmorOptimizations = era_optimizations_m829a3.ToArray<AmmoType.ArmorOptimization>();
                ammo_m829a3.Caliber = 120;
                ammo_m829a3.CertainRicochetAngle = 8f;//3f;
                ammo_m829a3.Mass = 4.84f;
                ammo_m829a3.MaxNutationPenalty = 0f;
                //ammo_m829a3.MaxSpallRha = 28f;
                ammo_m829a3.MuzzleVelocity = 1555f;
                ammo_m829a3.Name = "M829A3 APFSDS-T";
                ammo_m829a3.RhaPenetration = 840f;
                if (m829spall.Value) ammo_m829a3.SpallMultiplier = 1.75f;

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

                //m829a4
                ammo_m829a4 = new AmmoType();
                Util.ShallowCopy(ammo_m829a4, ammo_m833);
                ammo_m829a4.ArmorOptimizations = era_optimizations_m829a4.ToArray<AmmoType.ArmorOptimization>();
                ammo_m829a4.Caliber = 120;
                ammo_m829a4.CertainRicochetAngle = 6f;//2f;
                ammo_m829a4.Mass = 4.94f;
                ammo_m829a4.MaxNutationPenalty = 0f;
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

                //m830
                ammo_m830 = new AmmoType();
                Util.ShallowCopy(ammo_m830, ammo_m456);
                ammo_m830.Caliber = 120;
                ammo_m830.CertainRicochetAngle = 5f;//4.0f;
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

                //m830a1
                ammo_m830a1 = new AmmoType();
                Util.ShallowCopy(ammo_m830a1, ammo_m456);
                ammo_m830a1.Caliber = 120;
                ammo_m830a1.CertainRicochetAngle = 5f;//0.0f;
                ammo_m830a1.Coeff = 0.16f;
                ammo_m830a1.DetonateSpallCount = mpatFragments.Value; //Number of fragments generated when detonated (PD). Higher value means higher performance hit.
                //ammo_m830a1.ImpactFuseTime = 0.000357143f; //0.5 meters after impact //delay removed since it negatively affects armor penetration
                ammo_m830a1.Mass = 11.4f;
                ammo_m830a1.MaxSpallRha = 50f;
                ammo_m830a1.MinSpallRha = 15f;
                ammo_m830a1.MuzzleVelocity = 1410f;
                ammo_m830a1.Name = "M830A1 HEAT-MP-T";
                ammo_m830a1.RhaPenetration = 480;
                ammo_m830a1.ShatterOnRicochet = false;
                ammo_m830a1.SpallMultiplier = 0.5f;
                ammo_m830a1.ShotVisual = ammo_3of26.ShotVisual;
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

                m830a1_forward_frag.Name = "MPAT forward frag";
                m830a1_forward_frag.RhaPenetration = 120f;
                m830a1_forward_frag.MuzzleVelocity = 600f;
                m830a1_forward_frag.Category = AmmoType.AmmoCategory.Penetrator;
                m830a1_forward_frag.Mass = 0.005f;
                m830a1_forward_frag.SectionalArea = 0.03f;
                m830a1_forward_frag.Coeff = 1f;
                m830a1_forward_frag.UseTracer = false;
                m830a1_forward_frag.CertainRicochetAngle = 10f;
                m830a1_forward_frag.SpallMultiplier = 0.2f;
                m830a1_forward_frag.Caliber = 3f;
                m830a1_forward_frag.ImpactTypeUnfuzed = GHPC.Effects.ParticleEffectsManager.EffectVisualType.BulletImpact;
                m830a1_forward_frag.ImpactTypeUnfuzedTerrain = GHPC.Effects.ParticleEffectsManager.EffectVisualType.BulletImpactTerrain;

                ProxyFuzeMPAT.AddFuzeMPAT(ammo_m830a1);

                //m830a2
                ammo_m830a2 = new AmmoType();
                Util.ShallowCopy(ammo_m830a2, ammo_m456);
                ammo_m830a2.ArmorOptimizations = era_optimizations_m830a2.ToArray<AmmoType.ArmorOptimization>();
                ammo_m830a2.Caliber = 120;
                ammo_m830a2.CertainRicochetAngle = 0.0f;
                //ammo_m830a2.Coeff = 0.16f;
                ammo_m830a2.DetonateSpallCount = 200;
                ammo_m830a2.Mass = 13.5f;
                ammo_m830a2.MaxSpallRha = 35f;
                ammo_m830a2.MinSpallRha = 5f;
                ammo_m830a2.MuzzleVelocity = 1410f;
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

                //m830a3
                ammo_m830a3 = new AmmoType();
                Util.ShallowCopy(ammo_m830a3, ammo_m456);
                ammo_m830a3.ArmorOptimizations = era_optimizations_m830a2.ToArray<AmmoType.ArmorOptimization>();
                ammo_m830a3.Caliber = 120;
                ammo_m830a3.CertainRicochetAngle = 0.0f;
                //ammo_m830a3.Coeff = 0.16f;
                ammo_m830a3.DetonateSpallCount = 100;
                ammo_m830a3.Mass = 13.5f;
                ammo_m830a3.MaxSpallRha = 25f;
                ammo_m830a3.MinSpallRha = 5f;
                ammo_m830a3.MuzzleVelocity = 1310f;
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

                //xm1147
                ammo_xm1147 = new AmmoType();
                Util.ShallowCopy(ammo_xm1147, ammo_m456);
                ammo_xm1147.Caliber = 120;
                ammo_xm1147.Category = AmmoType.AmmoCategory.Explosive;
                ammo_xm1147.CertainRicochetAngle = 0.0f;
                ammo_xm1147.Coeff = 0.16f;
                ammo_xm1147.DetonateSpallCount = ampFragments.Value; //Number of fragments generated when detonated (PD/AB). Higher value means higher performance hit.
                ammo_xm1147.Mass = 11.4f;
                ammo_xm1147.MaxSpallRha = 120f;
                ammo_xm1147.MinSpallRha = 50f;
                ammo_xm1147.MuzzleVelocity = 1410f;
                ammo_xm1147.Name = "XM1147 AMP-T";
                ammo_xm1147.RhaPenetration = 250;
                ammo_xm1147.ShatterOnRicochet = false;
                ammo_xm1147.ShotVisual = ammo_3of26.ShotVisual;
                ammo_xm1147.SpallMultiplier = 2f;
                ammo_xm1147.TntEquivalentKg = 4.14f; //2.3Kg PAX-3, but treated 80% more power than equivalent TNT load

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

                xm1147_forward_frag.Name = "AMP forward frag";
                xm1147_forward_frag.RhaPenetration = 100f;
                xm1147_forward_frag.MuzzleVelocity = 700f;
                xm1147_forward_frag.Category = AmmoType.AmmoCategory.Penetrator;
                xm1147_forward_frag.Mass = 0.005f;
                xm1147_forward_frag.SectionalArea = 0.03f ;
                xm1147_forward_frag.Coeff = 1f;
                xm1147_forward_frag.UseTracer = false;
                xm1147_forward_frag.CertainRicochetAngle = 10f;
                xm1147_forward_frag.SpallMultiplier = 0.2f;
                xm1147_forward_frag.Caliber = 3f;
                xm1147_forward_frag.ImpactTypeUnfuzed = GHPC.Effects.ParticleEffectsManager.EffectVisualType.BulletImpact;
                xm1147_forward_frag.ImpactTypeUnfuzedTerrain = GHPC.Effects.ParticleEffectsManager.EffectVisualType.BulletImpactTerrain;

                if (ampFuze.Value) ProxyFuzeAMP.AddFuzeAMP(ammo_xm1147);

                //lahat
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
                ammo_lahat.UseErrorCorrection = false;
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

                //m908
                ammo_m908 = new AmmoType();
                Util.ShallowCopy(ammo_m908, ammo_3of26);
                ammo_m908.Caliber = 120;
                ammo_m908.CertainRicochetAngle = 13f;//0.0f;
                ammo_m908.Coeff = 0.16f;
                ammo_m908.DetonateSpallCount = heorFragments.Value; //Number of fragments generated when detonated (PD). Higher value means higher performance hit.
                ammo_m908.ImpactFuseTime = 0.000357143f; //0.5 meters after impact
                ammo_m908.Mass = 11.4f;
                ammo_m908.MaxSpallRha = 75f;
                ammo_m908.MinSpallRha = 25f;
                ammo_m908.MuzzleVelocity = 1410f;
                ammo_m908.Name = "M908 HE-OR-T";
                ammo_m908.RhaPenetration = 250;
                ammo_m908.ShatterOnRicochet = false;
                ammo_m908.ShotVisual = ammo_3of26.ShotVisual;
                ammo_m908.TntEquivalentKg = 4.8f;//3.2Kg Comp A3 IRL but apparently RDX is 50% stronger than TNT so 4.8

                ammo_codex_m908 = ScriptableObject.CreateInstance<AmmoCodexScriptable>();
                ammo_codex_m908.AmmoType = ammo_m908;
                ammo_codex_m908.name = "ammo_m908";

                clip_m908 = new AmmoType.AmmoClip();
                clip_m908.Capacity = 1;
                clip_m908.Name = "M908 HE-OR-T";
                clip_m908.MinimalPattern = new AmmoCodexScriptable[1];
                clip_m908.MinimalPattern[0] = ammo_codex_m908;

                clip_codex_m908 = ScriptableObject.CreateInstance<AmmoClipCodexScriptable>();
                clip_codex_m908.name = "clip_m908";
                clip_codex_m908.CompatibleWeaponSystems = new WeaponSystemCodexScriptable[1];
                clip_codex_m908.CompatibleWeaponSystems[0] = gun_m256;
                clip_codex_m908.ClipType = clip_m908;

                //m2
                ammo_m2apt = new AmmoType();
                Util.ShallowCopy(ammo_m2apt, ammo_m8vnl);
                ammo_m2apt.CertainRicochetAngle = 15f;//5f;
                ammo_m2apt.MaxSpallRha = 8f;
                ammo_m2apt.MinSpallRha = 2f;
                ammo_m2apt.MuzzleVelocity = 887;
                ammo_m2apt.Name = "12.7x99mm M2 AP-T";
                ammo_m2apt.NutationPenaltyDistance = 0f;
                ammo_m2apt.MaxNutationPenalty = 0f;
                ammo_m2apt.RhaPenetration = 29f;
                ammo_m2apt.SpallMultiplier = 10f;
                ammo_m2apt.UseTracer = true;

                ammo_codex_m2apt = ScriptableObject.CreateInstance<AmmoCodexScriptable>();
                ammo_codex_m2apt.AmmoType = ammo_m2apt;
                ammo_codex_m2apt.name = "ammo_m2apt";

                clip_m2apt = new AmmoType.AmmoClip();
                clip_m2apt.Capacity = 3000;
                clip_m2apt.Name = "M2 AP-T";
                clip_m2apt.MinimalPattern = new AmmoCodexScriptable[1];
                clip_m2apt.MinimalPattern[0] = ammo_codex_m2apt;

                clip_codex_m2apt = ScriptableObject.CreateInstance<AmmoClipCodexScriptable>();
                clip_codex_m2apt.name = "clip_m2apt";
                clip_codex_m2apt.ClipType = clip_m2apt;

                //m8
                ammo_m8api = new AmmoType();
                Util.ShallowCopy(ammo_m8api, ammo_m8vnl);
                ammo_m8api.CertainRicochetAngle = 15f;//5f;
                ammo_m8api.MaxSpallRha = 8f;
                ammo_m8api.MinSpallRha = 2f;
                ammo_m8api.MuzzleVelocity = 887;
                ammo_m8api.Name = "12.7x99mm M8 AP-I";
                ammo_m8api.NutationPenaltyDistance = 0f;
                ammo_m8api.MaxNutationPenalty = 0f;
                ammo_m8api.RhaPenetration = 29f;
                ammo_m8api.SpallMultiplier = 20f;

                ammo_codex_m8api = ScriptableObject.CreateInstance<AmmoCodexScriptable>();
                ammo_codex_m8api.AmmoType = ammo_m8api;
                ammo_codex_m8api.name = "ammo_m8api";

                clip_m8api = new AmmoType.AmmoClip();
                clip_m8api.Capacity = 3000;
                clip_m8api.Name = "M8 AP-I/T Mix";
                clip_m8api.MinimalPattern = new AmmoCodexScriptable[]
                    {
                        ammo_codex_m2apt,
                        ammo_codex_m8api,
                        ammo_codex_m8api,
                    };
                clip_m8api.MinimalPattern[0] = ammo_codex_m8api;

                clip_codex_m8api = ScriptableObject.CreateInstance<AmmoClipCodexScriptable>();
                clip_codex_m8api.name = "clip_m8api";
                clip_codex_m8api.ClipType = clip_m8api;

                //m962
                ammo_m962slapt = new AmmoType();
                Util.ShallowCopy(ammo_m962slapt, ammo_m8vnl);
                ammo_m962slapt.CertainRicochetAngle = 15f;//5f;
                ammo_m962slapt.Coeff = 1.615f;//1.9f
                ammo_m962slapt.MaxSpallRha = 12f;
                ammo_m962slapt.MinSpallRha = 4f;
                ammo_m962slapt.MuzzleVelocity = 1200f;
                ammo_m962slapt.Name = "12.7x99mm M962 SLAP-T";
                ammo_m962slapt.NutationPenaltyDistance = 0f;
                ammo_m962slapt.MaxNutationPenalty = 0f;
                ammo_m962slapt.RhaPenetration = 36f;
                ammo_m962slapt.SpallMultiplier = 15f;
                ammo_m962slapt.UseTracer = true;

                ammo_codex_m962slapt = ScriptableObject.CreateInstance<AmmoCodexScriptable>();
                ammo_codex_m962slapt.AmmoType = ammo_m962slapt;
                ammo_codex_m962slapt.name = "ammo_m962slapt";

                clip_m962slapt = new AmmoType.AmmoClip();
                clip_m962slapt.Capacity = 3000;
                clip_m962slapt.Name = "12.7x99mm M962 SLAP-T";
                clip_m962slapt.MinimalPattern = new AmmoCodexScriptable[1];
                clip_m962slapt.MinimalPattern[0] = ammo_codex_m962slapt;

                clip_codex_m962slapt = ScriptableObject.CreateInstance<AmmoClipCodexScriptable>();
                clip_codex_m962slapt.name = "clip_m962slapt";
                clip_codex_m962slapt.ClipType = clip_m962slapt;

                //Armor stuff

                ////HU armor modifiers
                armor_superCompositeskirt_HU = new ArmorType();
                Util.ShallowCopy(armor_superCompositeskirt_HU, armor_compositeskirt_VNL);
                armor_superCompositeskirt_HU.RhaeMultiplierCe = demigodArmor.Value ? 100f : 11f; //default 1.5
                armor_superCompositeskirt_HU.RhaeMultiplierKe = demigodArmor.Value ? 100f : 6f; //default 0.8
                //armor_superCompositeskirt_HU.SpallPowerMultiplier = 10f; //default 0.8
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
                
                ////SA armor modifiers (85% increase)
                armor_cheeksDUarmor_SA = new ArmorType();
                Util.ShallowCopy(armor_cheeksDUarmor_SA, armor_specialarmor_VNL);
                armor_cheeksDUarmor_SA.RhaeMultiplierCe = 1.885f; //default 1.3
                armor_cheeksDUarmor_SA.RhaeMultiplierKe = 1.045f; //default 0.55
                armor_cheeksDUarmor_SA.Name = "Abrams SA DU armor turret cheeks";

                armor_codex_cheeksDUarmor_SA = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_cheeksDUarmor_SA.name = "Abrams SA DU armor turret cheeks";
                armor_codex_cheeksDUarmor_SA.ArmorType = armor_cheeksDUarmor_SA;
                armor_cheeksDUarmor_SA = new ArmorType();

                armor_fronthullDUarmor_SA = new ArmorType();
                Util.ShallowCopy(armor_fronthullDUarmor_SA, armor_specialarmor_VNL);
                armor_fronthullDUarmor_SA.RhaeMultiplierCe = 1.885f; //default 1.3
                armor_fronthullDUarmor_SA.RhaeMultiplierKe = 0.925f; //default 0.45
                armor_fronthullDUarmor_SA.Name = "Abrams SA DU armor hull front";

                armor_codex_fronthullDUarmor_SA = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
                armor_codex_fronthullDUarmor_SA.name = "Abrams SA DU armor hull front";
                armor_codex_fronthullDUarmor_SA.ArmorType = armor_fronthullDUarmor_SA;
                armor_fronthullDUarmor_SA = new ArmorType();

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

                ammo_m908_vis = GameObject.Instantiate(ammo_m456.VisualModel);
                ammo_m908_vis.name = "M908 visual";
                ammo_m908.VisualModel = ammo_m908_vis;
                ammo_m908.VisualModel.GetComponent<AmmoStoredVisual>().AmmoType = ammo_m908;
                ammo_m908.VisualModel.GetComponent<AmmoStoredVisual>().AmmoScriptable = ammo_codex_m908;

                //Attempt to copy vanilla smoke grenades to actually make ROSY be like ROSY
                if (m82Object == null)
                {
                    foreach (GameObject m82Smoke in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
                    {//Smoke - 3D6 81mm Smoke - M82 66mm
                        if (m82Smoke.name == "Smoke - M82 66mm") m82Object = m82Smoke;
                        if (m82Smoke.name == "Smoke White Single Normal") m82SmokeEffect = m82Smoke;

                        /*if (smokestuff.name == "Smoke White Single Normal")
                        {
                            m82SmokeEffect = smokestuff;
                        }*/
                    }
                    //Smoke White Single Normal/Smoke Discharger White Single Normal/Smoke Ground Tracer 1/Smoke Ground Cloud 1

                    RosySmokeEffect = GameObject.Instantiate(m82SmokeEffect);
                    RosySmokeEffect.name = "Rosy Multispectral Single Normal";

                    LightBandExclusiveItem RosyLB = RosySmokeEffect.GetComponent<LightBandExclusiveItem>();

                    RosyLB.ShowInThermal = rosyIR.Value;

                    if (rosyPlus.Value)
                    {
                        var RosyEffect = RosySmokeEffect.transform.Find("Smoke Discharger White Single Normal/Smoke Ground Tracer 1/Smoke Ground Cloud 1").gameObject.transform;

                        ParticleSystem RosyCloud = RosyEffect.GetComponent<ParticleSystem>();

                        RosyCloud.maxParticles = 12000;
                        RosyCloud.startSize = 30;

                        SmokeRound m82Plus = m82Object.GetComponent<SmokeRound>();
                        m82Plus._fuseTimeRange = new Vector2(0.325f, 0.375f);//1.3 1.7
                        m82Plus._effectPrefab = RosySmokeEffect;
                    }


                    //MelonLogger.Msg("M82 Object: " + m82Object.name);
                    //MelonLogger.Msg("ROSY Smoke Effect: " + RosySmokeEffect.name);
                }


                if (m1ip_cheeksnera == null)
                {
                    foreach (Vehicle obj in Resources.FindObjectsOfTypeAll(typeof(Vehicle)))
                    {
                        if (obj.gameObject.name == "M1IP")
                        {
                            m1ip_cheeksnera = obj.transform.Find("M1IP TURRET FOLLOW/Turret_Armor/cheeks composite arrays").gameObject;
                            m1ip_cheeksface = obj.transform.Find("M1IP TURRET FOLLOW/Turret_Armor/CHEEKS OUTTER").gameObject;
                            m1ip_turretroof = obj.transform.Find("M1IP TURRET FOLLOW/Turret_Armor/ROOF.001").gameObject;
                        }
                    }
                }
            }

            StateController.RunOrDefer(GameState.GameReady, new GameStateEventHandler(Convert), GameStatePriority.Lowest);
        }

        [HarmonyPatch(typeof(GHPC.Weapons.LiveRound), "Start")]
        public static class Airburst
        {
            private static void Postfix(GHPC.Weapons.LiveRound __instance)
            {
                if (!ampFuze.Value)
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
}
