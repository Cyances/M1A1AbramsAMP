using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GHPC;
using GHPC.Equipment;
using GHPC.Weapons;
using M1A1AMP;
using UnityEngine;

namespace M1A1AbramsAMP
{
    public class AmmoArmor
    {
        ////Ammo variables
        public static AmmoClipCodexScriptable clip_codex_m829;
        public static AmmoType.AmmoClip clip_m829;
        public static AmmoCodexScriptable ammo_codex_m829;
        public static AmmoType ammo_m829;

        public static AmmoClipCodexScriptable clip_codex_m829a1;
        public static AmmoType.AmmoClip clip_m829a1;
        public static AmmoCodexScriptable ammo_codex_m829a1;
        public static AmmoType ammo_m829a1;

        public static AmmoClipCodexScriptable clip_codex_m829a2;
        public static AmmoType.AmmoClip clip_m829a2;
        public static AmmoCodexScriptable ammo_codex_m829a2;
        public static AmmoType ammo_m829a2;

        public static AmmoClipCodexScriptable clip_codex_m829a3;
        public static AmmoType.AmmoClip clip_m829a3;
        public static AmmoCodexScriptable ammo_codex_m829a3;
        public static AmmoType ammo_m829a3;

        public static AmmoClipCodexScriptable clip_codex_m829a4;
        public static AmmoType.AmmoClip clip_m829a4;
        public static AmmoCodexScriptable ammo_codex_m829a4;
        public static AmmoType ammo_m829a4;

        public static AmmoClipCodexScriptable clip_codex_m830;
        public static AmmoType.AmmoClip clip_m830;
        public static AmmoCodexScriptable ammo_codex_m830;
        public static AmmoType ammo_m830;

        public static AmmoClipCodexScriptable clip_codex_m830a1;
        public static AmmoType.AmmoClip clip_m830a1;
        public static AmmoCodexScriptable ammo_codex_m830a1;
        public static AmmoType ammo_m830a1;
        public static AmmoType m830a1_forward_frag = new AmmoType();

        public static AmmoClipCodexScriptable clip_codex_m830a2;
        public static AmmoType.AmmoClip clip_m830a2;
        public static AmmoCodexScriptable ammo_codex_m830a2;
        public static AmmoType ammo_m830a2;

        public static AmmoClipCodexScriptable clip_codex_m830a3;
        public static AmmoType.AmmoClip clip_m830a3;
        public static AmmoCodexScriptable ammo_codex_m830a3;
        public static AmmoType ammo_m830a3;

        public static AmmoClipCodexScriptable clip_codex_xm1147;
        public static AmmoType.AmmoClip clip_xm1147;
        public static AmmoCodexScriptable ammo_codex_xm1147;
        public static AmmoType ammo_xm1147;
        public static AmmoType xm1147_forward_frag = new AmmoType();

        public static AmmoClipCodexScriptable clip_codex_lahat;
        public static AmmoType.AmmoClip clip_lahat;
        public static AmmoCodexScriptable ammo_codex_lahat;
        public static AmmoType ammo_lahat;

        public static AmmoClipCodexScriptable clip_codex_m908;
        public static AmmoType.AmmoClip clip_m908;
        public static AmmoCodexScriptable ammo_codex_m908;
        public static AmmoType ammo_m908;

        public static AmmoClipCodexScriptable clip_codex_m8api;
        public static AmmoType.AmmoClip clip_m8api;
        public static AmmoCodexScriptable ammo_codex_m8api;
        public static AmmoType ammo_m8api;

        public static AmmoClipCodexScriptable clip_codex_m2apt;
        public static AmmoType.AmmoClip clip_m2apt;
        public static AmmoCodexScriptable ammo_codex_m2apt;
        public static AmmoType ammo_m2apt;

        public static AmmoClipCodexScriptable clip_codex_m962slapt;
        public static AmmoType.AmmoClip clip_m962slapt;
        public static AmmoCodexScriptable ammo_codex_m962slapt;
        public static AmmoType ammo_m962slapt;

        public static GameObject ammo_m829_vis = null;
        public static GameObject ammo_m829a1_vis = null;
        public static GameObject ammo_m829a2_vis = null;
        public static GameObject ammo_m829a3_vis = null;
        public static GameObject ammo_m829a4_vis = null;
        public static GameObject ammo_m830_vis = null;
        public static GameObject ammo_m830a1_vis = null;
        public static GameObject ammo_m830a2_vis = null;
        public static GameObject ammo_m830a3_vis = null;
        public static GameObject ammo_xm1147_vis = null;
        public static GameObject ammo_lahat_vis = null;
        public static GameObject ammo_m908_vis = null;

        public static AmmoType ammo_m833, ammo_m456, ammo_3of26, ammo_bgm71, ammo_m8vnl;

        ////Armor variables
        ////Variables for copying existing ArmorType
        public static ArmorType armor_compositeskirt_VNL, armor_specialarmor_VNL, armor_tracks_VNL, armor_gunsteel_VNL;

        ////HU Variant
        public static ArmorCodexScriptable armor_codex_superCompositeskirt_HU;
        public static ArmorType armor_superCompositeskirt_HU;

        public static ArmorCodexScriptable armor_codex_cheeksDUarmor_HU;
        public static ArmorType armor_cheeksDUarmor_HU;

        public static ArmorCodexScriptable armor_codex_fronthullDUarmor_HU;
        public static ArmorType armor_fronthullDUarmor_HU;

        public static ArmorCodexScriptable armor_codex_mantletDUarmor_HU;
        public static ArmorType armor_mantletDUarmor_HU;

        public static ArmorCodexScriptable armor_codex_turretsidesDUarmor_HU;
        public static ArmorType armor_turretsidesDUarmor_HU;

        public static ArmorCodexScriptable armor_codex_turretroofCompositearmor_HU;
        public static ArmorType armor_turretroofCompositearmor_HU;

        public static ArmorCodexScriptable armor_codex_upperglacisCompositearmor_HU;
        public static ArmorType armor_upperglacisCompositearmor_HU;

        public static ArmorCodexScriptable armor_codex_commmandershatchCompositearmor_HU;
        public static ArmorType armor_commmandershatchCompositearmor_HU;

        public static ArmorCodexScriptable armor_codex_loadershatchCompositearmor_HU;
        public static ArmorType armor_loadershatchCompositearmor_HU;

        public static ArmorCodexScriptable armor_codex_drivershatchCompositearmor_HU;
        public static ArmorType armor_drivershatchCompositearmor_HU;

        public static ArmorCodexScriptable armor_codex_turretringCompositearmor_HU;
        public static ArmorType armor_turretringCompositearmor_HU;

        public static ArmorCodexScriptable armor_codex_gunmantletfaceCompositearmor_HU;
        public static ArmorType armor_gunmantletfaceCompositearmor_HU;

        public static ArmorCodexScriptable armor_codex_trackSpecialarmor_HU;
        public static ArmorType armor_trackSpecialarmor_HU;

        public static ArmorCodexScriptable armor_codex_gunbarrelImprovedarmor_HU;
        public static ArmorType armor_gunbarrelImprovedarmor_HU;

        public static ArmorCodexScriptable armor_codex_blowoutpanelCompositearmor_HU;
        public static ArmorType armor_blowoutpanelCompositearmor_HU;

        public static ArmorCodexScriptable armor_codex_bustleImprovedfirewall_HU;
        public static ArmorType armor_bustleImprovedfirewall_HU;

        public static ArmorCodexScriptable armor_codex_turretrearSpecialarray_HU;
        public static ArmorType armor_turretrearSpecialarray_HU;

        public static ArmorCodexScriptable armor_codex_GPSImprovedhousing_HU;
        public static ArmorType armor_GPSImprovedhousing_HU;

        public static ArmorCodexScriptable armor_codex_GPSImproveddoor_HU;
        public static ArmorType armor_GPSImproveddoor_HU;

        public static ArmorCodexScriptable armor_codex_turretbottomCompositearmor_HU;
        public static ArmorType armor_turretbottomCompositearmor_HU;

        public static ArmorCodexScriptable armor_codex_semireadyrackdoorCompositearmor_HU;
        public static ArmorType armor_semireadyrackdoorCompositearmor_HU;

        public static ArmorCodexScriptable armor_codex_trunnionCompositearmor_HU;
        public static ArmorType armor_trunnionCompositearmor_HU;

        public static ArmorCodexScriptable armor_codex_readyrackdoorCompositearmor_HU;
        public static ArmorType armor_readyrackdoorCompositearmor_HU;

        public static ArmorCodexScriptable armor_codex_lowerfrontplateCompositearmor_HU;
        public static ArmorType armor_lowerflontplateCompositearmor_HU;

        public static ArmorCodexScriptable armor_codex_hullfrontbackingplateCompositearmor_HU;
        public static ArmorType armor_hullfrontbackingplateCompositearmor_HU;

        public static ArmorCodexScriptable armor_codex_turretcheekfaceCompositearmor_HU;
        public static ArmorType armor_turretcheekfaceCompositearmor_HU;

        public static ArmorCodexScriptable armor_codex_turretcheekbackingplateCompositearmor_HU;
        public static ArmorType armor_turretcheekbackingplateCompositearmor_HU;

        public static ArmorCodexScriptable armor_codex_turretsidebackingplateCompositearmor_HU;
        public static ArmorType armor_turretsidebackingplateCompositearmor_HU;

        public static ArmorCodexScriptable armor_codex_turretsidefaceCompositearmor_HU;
        public static ArmorType armor_turretsidefaceCompositearmor_HU;

        ////SA Variant
        public static ArmorCodexScriptable armor_codex_cheeksDUarmor_SA;
        public static ArmorType armor_cheeksDUarmor_SA;

        public static ArmorCodexScriptable armor_codex_fronthullDUarmor_SA;
        public static ArmorType armor_fronthullDUarmor_SA;

        ////HC Variant
        public static ArmorCodexScriptable armor_codex_superCompositeskirt_HC;
        public static ArmorType armor_superCompositeskirt_HC;

        public static ArmorCodexScriptable armor_codex_cheeksDUarmor_HC;
        public static ArmorType armor_cheeksDUarmor_HC;

        public static ArmorCodexScriptable armor_codex_fronthullDUarmor_HC;
        public static ArmorType armor_fronthullDUarmor_HC;

        public static ArmorCodexScriptable armor_codex_mantletDUarmor_HC;
        public static ArmorType armor_mantletDUarmor_HC;

        public static ArmorCodexScriptable armor_codex_turretsidesDUarmor_HC;
        public static ArmorType armor_turretsidesDUarmor_HC;

        public static ArmorCodexScriptable armor_codex_superCompositeskirt_HA;
        public static ArmorType armor_superCompositeskirt_HA;

        ////HA Variant
        public static ArmorCodexScriptable armor_codex_cheeksDUarmor_HA;
        public static ArmorType armor_cheeksDUarmor_HA;

        public static ArmorCodexScriptable armor_codex_fronthullDUarmor_HA;
        public static ArmorType armor_fronthullDUarmor_HA;

        public static ArmorCodexScriptable armor_codex_mantletDUarmor_HA;
        public static ArmorType armor_mantletDUarmor_HA;

        public static ArmorCodexScriptable armor_codex_turretsidesDUarmor_HA;
        public static ArmorType armor_turretsidesDUarmor_HA;
        public static void Init ()            
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
            M1A1AbramsAMPMod.gun_m256 = ScriptableObject.CreateInstance<WeaponSystemCodexScriptable>();
            M1A1AbramsAMPMod.gun_m256.name = "M1A1AbramsAMPMod.gun_m256";
            M1A1AbramsAMPMod.gun_m256.CaliberMm = 120;
            M1A1AbramsAMPMod.gun_m256.FriendlyName = "120mm Gun M256";
            M1A1AbramsAMPMod.gun_m256.Type = WeaponSystemCodexScriptable.WeaponType.LargeCannon;

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
            if (M1A1AbramsAMPMod.m829spall.Value) ammo_m829.SpallMultiplier = 1.25f;

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
            clip_codex_m829.CompatibleWeaponSystems[0] = M1A1AbramsAMPMod.gun_m256;
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
            if (M1A1AbramsAMPMod.m829spall.Value) ammo_m829a1.SpallMultiplier = 1.25f;

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
            clip_codex_m829a1.CompatibleWeaponSystems[0] = M1A1AbramsAMPMod.gun_m256;
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
            if (M1A1AbramsAMPMod.m829spall.Value) ammo_m829a2.SpallMultiplier = 1.5f;

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
            clip_codex_m829a2.CompatibleWeaponSystems[0] = M1A1AbramsAMPMod.gun_m256;
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
            if (M1A1AbramsAMPMod.m829spall.Value) ammo_m829a3.SpallMultiplier = 1.75f;

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
            clip_codex_m829a3.CompatibleWeaponSystems[0] = M1A1AbramsAMPMod.gun_m256;
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
            clip_codex_m829a4.CompatibleWeaponSystems[0] = M1A1AbramsAMPMod.gun_m256;
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
            clip_codex_m830.CompatibleWeaponSystems[0] = M1A1AbramsAMPMod.gun_m256;
            clip_codex_m830.ClipType = clip_m830;

            //m830a1
            ammo_m830a1 = new AmmoType();
            Util.ShallowCopy(ammo_m830a1, ammo_m456);
            ammo_m830a1.Caliber = 120;
            ammo_m830a1.CertainRicochetAngle = 5f;//0.0f;
            ammo_m830a1.Coeff = 0.16f;
            ammo_m830a1.DetonateSpallCount = M1A1AbramsAMPMod.mpatFragments.Value; //Number of fragments generated when detonated (PD). Higher value means higher performance hit.
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
            clip_codex_m830a1.CompatibleWeaponSystems[0] = M1A1AbramsAMPMod.gun_m256;
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
            clip_codex_m830a2.CompatibleWeaponSystems[0] = M1A1AbramsAMPMod.gun_m256;
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
            clip_codex_m830a3.CompatibleWeaponSystems[0] = M1A1AbramsAMPMod.gun_m256;
            clip_codex_m830a3.ClipType = clip_m830a3;

            //xm1147
            ammo_xm1147 = new AmmoType();
            Util.ShallowCopy(ammo_xm1147, ammo_m456);
            ammo_xm1147.Caliber = 120;
            ammo_xm1147.Category = AmmoType.AmmoCategory.Explosive;
            ammo_xm1147.CertainRicochetAngle = 0.0f;
            ammo_xm1147.Coeff = 0.16f;
            ammo_xm1147.DetonateSpallCount = M1A1AbramsAMPMod.ampFragments.Value; //Number of fragments generated when detonated (PD/AB). Higher value means higher performance hit.
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
            clip_codex_xm1147.CompatibleWeaponSystems[0] = M1A1AbramsAMPMod.gun_m256;
            clip_codex_xm1147.ClipType = clip_xm1147;

            xm1147_forward_frag.Name = "AMP forward frag";
            xm1147_forward_frag.RhaPenetration = 100f;
            xm1147_forward_frag.MuzzleVelocity = 700f;
            xm1147_forward_frag.Category = AmmoType.AmmoCategory.Penetrator;
            xm1147_forward_frag.Mass = 0.005f;
            xm1147_forward_frag.SectionalArea = 0.03f;
            xm1147_forward_frag.Coeff = 1f;
            xm1147_forward_frag.UseTracer = false;
            xm1147_forward_frag.CertainRicochetAngle = 10f;
            xm1147_forward_frag.SpallMultiplier = 0.2f;
            xm1147_forward_frag.Caliber = 3f;
            xm1147_forward_frag.ImpactTypeUnfuzed = GHPC.Effects.ParticleEffectsManager.EffectVisualType.BulletImpact;
            xm1147_forward_frag.ImpactTypeUnfuzedTerrain = GHPC.Effects.ParticleEffectsManager.EffectVisualType.BulletImpactTerrain;

            if (M1A1AbramsAMPMod.ampFuze.Value) ProxyFuzeAMP.AddFuzeAMP(ammo_xm1147);

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
            ammo_m908.DetonateSpallCount = M1A1AbramsAMPMod.heorFragments.Value; //Number of fragments generated when detonated (PD). Higher value means higher performance hit.
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
            clip_codex_m908.CompatibleWeaponSystems[0] = M1A1AbramsAMPMod.gun_m256;
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
            armor_superCompositeskirt_HU.RhaeMultiplierCe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 11f; //default 1.5
            armor_superCompositeskirt_HU.RhaeMultiplierKe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 6f; //default 0.8
                                                                                            //armor_superCompositeskirt_HU.SpallPowerMultiplier = 10f; //default 0.8
            armor_superCompositeskirt_HU.Name = "Abrams HU super special composite skirt";

            armor_codex_superCompositeskirt_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
            armor_codex_superCompositeskirt_HU.name = "Abrams HU super special composite skirt";
            armor_codex_superCompositeskirt_HU.ArmorType = armor_superCompositeskirt_HU;

            armor_cheeksDUarmor_HU = new ArmorType();
            Util.ShallowCopy(armor_cheeksDUarmor_HU, armor_specialarmor_VNL);
            armor_cheeksDUarmor_HU.RhaeMultiplierCe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 2.2f; //default 1.3
            armor_cheeksDUarmor_HU.RhaeMultiplierKe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 1.25f; //default 0.55
            armor_cheeksDUarmor_HU.Name = "Abrams HU DU armor turret cheeks";

            armor_codex_cheeksDUarmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
            armor_codex_cheeksDUarmor_HU.name = "Abrams HU DU armor turret cheeks";
            armor_codex_cheeksDUarmor_HU.ArmorType = armor_cheeksDUarmor_HU;
            armor_cheeksDUarmor_HU = new ArmorType();

            armor_fronthullDUarmor_HU = new ArmorType();
            Util.ShallowCopy(armor_fronthullDUarmor_HU, armor_specialarmor_VNL);
            armor_fronthullDUarmor_HU.RhaeMultiplierCe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 2.2f; //default 1.3
            armor_fronthullDUarmor_HU.RhaeMultiplierKe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 1.2f; //default 0.45
            armor_fronthullDUarmor_HU.Name = "Abrams HU DU armor hull front";

            armor_codex_fronthullDUarmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
            armor_codex_fronthullDUarmor_HU.name = "Abrams HU DU armor hull front";
            armor_codex_fronthullDUarmor_HU.ArmorType = armor_fronthullDUarmor_HU;
            armor_fronthullDUarmor_HU = new ArmorType();

            armor_mantletDUarmor_HU = new ArmorType();
            Util.ShallowCopy(armor_mantletDUarmor_HU, armor_specialarmor_VNL);
            armor_mantletDUarmor_HU.RhaeMultiplierCe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 2.15f; //default 1.3
            armor_mantletDUarmor_HU.RhaeMultiplierKe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 1.65f; //default 1.4
            armor_mantletDUarmor_HU.Name = "Abrams HU DU armor mantlet";

            armor_codex_mantletDUarmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
            armor_codex_mantletDUarmor_HU.name = "Abrams HU DU armor mantlet";
            armor_codex_mantletDUarmor_HU.ArmorType = armor_mantletDUarmor_HU;
            armor_mantletDUarmor_HU = new ArmorType();

            armor_turretsidesDUarmor_HU = new ArmorType();
            Util.ShallowCopy(armor_turretsidesDUarmor_HU, armor_specialarmor_VNL);
            armor_turretsidesDUarmor_HU.RhaeMultiplierCe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 4.4f; //default 1.3
            armor_turretsidesDUarmor_HU.RhaeMultiplierKe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 2.21f; //default 1.4
            armor_turretsidesDUarmor_HU.Name = "Abrams HU DU armor turret sides";

            armor_codex_turretsidesDUarmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
            armor_codex_turretsidesDUarmor_HU.name = "Abrams HU DU armor turret sides";
            armor_codex_turretsidesDUarmor_HU.ArmorType = armor_turretsidesDUarmor_HU;
            armor_turretsidesDUarmor_HU = new ArmorType();

            armor_turretroofCompositearmor_HU = new ArmorType();
            Util.ShallowCopy(armor_turretroofCompositearmor_HU, armor_compositeskirt_VNL);
            armor_turretroofCompositearmor_HU.RhaeMultiplierCe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 7f; //default composite skirt 1.5
            armor_turretroofCompositearmor_HU.RhaeMultiplierKe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 5.9f; //default composite skirt 0.8
            armor_turretroofCompositearmor_HU.Name = "Abrams HU roof special composite";

            armor_codex_turretroofCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
            armor_codex_turretroofCompositearmor_HU.name = "Abrams HU roof special composite";
            armor_codex_turretroofCompositearmor_HU.ArmorType = armor_turretroofCompositearmor_HU;
            armor_turretroofCompositearmor_HU = new ArmorType();

            armor_upperglacisCompositearmor_HU = new ArmorType();
            Util.ShallowCopy(armor_upperglacisCompositearmor_HU, armor_compositeskirt_VNL);
            armor_upperglacisCompositearmor_HU.RhaeMultiplierCe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 5.5f; //default composite skirt 1.5
            armor_upperglacisCompositearmor_HU.RhaeMultiplierKe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 4.7f; //default composite skirt 0.8
            armor_upperglacisCompositearmor_HU.Name = "Abrams HU upper glacis special composite";

            armor_codex_upperglacisCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
            armor_codex_upperglacisCompositearmor_HU.name = "Abrams HU upper glacis special composite";
            armor_codex_upperglacisCompositearmor_HU.ArmorType = armor_upperglacisCompositearmor_HU;
            armor_upperglacisCompositearmor_HU = new ArmorType();

            armor_commmandershatchCompositearmor_HU = new ArmorType();
            Util.ShallowCopy(armor_commmandershatchCompositearmor_HU, armor_compositeskirt_VNL);
            armor_commmandershatchCompositearmor_HU.RhaeMultiplierCe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 3.6f; //default composite skirt 1.5
            armor_commmandershatchCompositearmor_HU.RhaeMultiplierKe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 3f; //default composite skirt 0.8
            armor_commmandershatchCompositearmor_HU.Name = "Abrams HU commander's hatch special composite";

            armor_codex_commmandershatchCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
            armor_codex_commmandershatchCompositearmor_HU.name = "Abrams HU commander's hatch special composite";
            armor_codex_commmandershatchCompositearmor_HU.ArmorType = armor_commmandershatchCompositearmor_HU;
            armor_commmandershatchCompositearmor_HU = new ArmorType();

            armor_loadershatchCompositearmor_HU = new ArmorType();
            Util.ShallowCopy(armor_loadershatchCompositearmor_HU, armor_compositeskirt_VNL);
            armor_loadershatchCompositearmor_HU.RhaeMultiplierCe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 3.6f; //default composite skirt 1.5
            armor_loadershatchCompositearmor_HU.RhaeMultiplierKe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 3f; //default composite skirt 0.8
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
            armor_turretringCompositearmor_HU.RhaeMultiplierCe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 5f; //default composite skirt 1.5
            armor_turretringCompositearmor_HU.RhaeMultiplierKe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 5f; //default composite skirt 0.8
            armor_turretringCompositearmor_HU.Name = "Abrams HU turret ring special composite";

            armor_codex_turretringCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
            armor_codex_turretringCompositearmor_HU.name = "Abrams HU turret ring special composite";
            armor_codex_turretringCompositearmor_HU.ArmorType = armor_turretringCompositearmor_HU;
            armor_turretringCompositearmor_HU = new ArmorType();

            armor_gunmantletfaceCompositearmor_HU = new ArmorType();
            Util.ShallowCopy(armor_gunmantletfaceCompositearmor_HU, armor_compositeskirt_VNL);
            armor_gunmantletfaceCompositearmor_HU.RhaeMultiplierCe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 23f; //default composite skirt 1.5
            armor_gunmantletfaceCompositearmor_HU.RhaeMultiplierKe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 18f; //default composite skirt 0.8
            armor_gunmantletfaceCompositearmor_HU.Name = "Abrams HU gun mantlet face special composite";

            armor_codex_gunmantletfaceCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
            armor_codex_gunmantletfaceCompositearmor_HU.name = "Abrams HU gun mantlet face special composite";
            armor_codex_gunmantletfaceCompositearmor_HU.ArmorType = armor_gunmantletfaceCompositearmor_HU;
            armor_gunmantletfaceCompositearmor_HU = new ArmorType();

            armor_trackSpecialarmor_HU = new ArmorType();
            Util.ShallowCopy(armor_trackSpecialarmor_HU, armor_tracks_VNL);
            armor_trackSpecialarmor_HU.RhaeMultiplierCe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 10f; //default composite skirt 1.5
            armor_trackSpecialarmor_HU.RhaeMultiplierKe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 10f; //default composite skirt 0.8
            armor_trackSpecialarmor_HU.Name = "Abrams HU special track armor";

            armor_codex_trackSpecialarmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
            armor_codex_trackSpecialarmor_HU.name = "Abrams HU special track armor";
            armor_codex_trackSpecialarmor_HU.ArmorType = armor_trackSpecialarmor_HU;
            armor_trackSpecialarmor_HU = new ArmorType();

            armor_gunbarrelImprovedarmor_HU = new ArmorType();
            Util.ShallowCopy(armor_gunbarrelImprovedarmor_HU, armor_gunsteel_VNL);
            armor_gunbarrelImprovedarmor_HU.RhaeMultiplierCe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 7f; //default composite skirt 1.5
            armor_gunbarrelImprovedarmor_HU.RhaeMultiplierKe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 7f; //default composite skirt 0.8
            armor_gunbarrelImprovedarmor_HU.Name = "Abrams HU Improved barrel armor";

            armor_codex_gunbarrelImprovedarmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
            armor_codex_gunbarrelImprovedarmor_HU.name = "Abrams HU Improved barrel armor";
            armor_codex_gunbarrelImprovedarmor_HU.ArmorType = armor_gunbarrelImprovedarmor_HU;
            armor_gunbarrelImprovedarmor_HU = new ArmorType();

            armor_bustleImprovedfirewall_HU = new ArmorType();
            Util.ShallowCopy(armor_bustleImprovedfirewall_HU, armor_compositeskirt_VNL);
            armor_bustleImprovedfirewall_HU.RhaeMultiplierCe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 2.667f; //default composite skirt 1.5
            armor_bustleImprovedfirewall_HU.RhaeMultiplierKe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 2.667f; //default composite skirt 0.8
            armor_bustleImprovedfirewall_HU.Name = "Abrams HU bustle spall lining";

            armor_codex_bustleImprovedfirewall_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
            armor_codex_bustleImprovedfirewall_HU.name = "Abrams HU bustle spall lining";
            armor_codex_bustleImprovedfirewall_HU.ArmorType = armor_bustleImprovedfirewall_HU;
            armor_bustleImprovedfirewall_HU = new ArmorType();

            armor_blowoutpanelCompositearmor_HU = new ArmorType();
            Util.ShallowCopy(armor_blowoutpanelCompositearmor_HU, armor_compositeskirt_VNL);
            armor_blowoutpanelCompositearmor_HU.RhaeMultiplierCe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 18f; //default composite skirt 1.5
            armor_blowoutpanelCompositearmor_HU.RhaeMultiplierKe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 15f; //default composite skirt 0.8
            armor_blowoutpanelCompositearmor_HU.Name = "Abrams HU Composite blowout panel";

            armor_codex_blowoutpanelCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
            armor_codex_blowoutpanelCompositearmor_HU.name = "Abrams HU Composite blowout panel";
            armor_codex_blowoutpanelCompositearmor_HU.ArmorType = armor_blowoutpanelCompositearmor_HU;
            armor_blowoutpanelCompositearmor_HU = new ArmorType();

            armor_turretrearSpecialarray_HU = new ArmorType();
            Util.ShallowCopy(armor_turretrearSpecialarray_HU, armor_specialarmor_VNL);
            armor_turretrearSpecialarray_HU.RhaeMultiplierCe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 40f; //default special armor 1
            armor_turretrearSpecialarray_HU.RhaeMultiplierKe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 20f; //default special armor 1
            armor_turretrearSpecialarray_HU.Name = "Abrams HU Special armor turret rear";

            armor_codex_turretrearSpecialarray_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
            armor_codex_turretrearSpecialarray_HU.name = "Abrams HU Special armor turret rear";
            armor_codex_turretrearSpecialarray_HU.ArmorType = armor_turretrearSpecialarray_HU;
            armor_turretrearSpecialarray_HU = new ArmorType();

            armor_GPSImprovedhousing_HU = new ArmorType();
            Util.ShallowCopy(armor_GPSImprovedhousing_HU, armor_compositeskirt_VNL);
            armor_GPSImprovedhousing_HU.RhaeMultiplierCe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 5f; //default composite skirt 1.5
            armor_GPSImprovedhousing_HU.RhaeMultiplierKe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 5f; //default composite skirt 0.8
            armor_GPSImprovedhousing_HU.Name = "Abrams HU GPS housing composite";

            armor_codex_GPSImprovedhousing_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
            armor_codex_GPSImprovedhousing_HU.name = "Abrams HU GPS housing composite";
            armor_codex_GPSImprovedhousing_HU.ArmorType = armor_GPSImprovedhousing_HU;
            armor_GPSImprovedhousing_HU = new ArmorType();

            armor_GPSImproveddoor_HU = new ArmorType();
            Util.ShallowCopy(armor_GPSImproveddoor_HU, armor_compositeskirt_VNL);
            armor_GPSImproveddoor_HU.RhaeMultiplierCe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 5f; //default composite skirt 1.5
            armor_GPSImproveddoor_HU.RhaeMultiplierKe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 5f; //default composite skirt 0.8
            armor_GPSImproveddoor_HU.Name = "Abrams HU GPS door composite";

            armor_codex_GPSImproveddoor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
            armor_codex_GPSImproveddoor_HU.name = "Abrams HU GPS door composite";
            armor_codex_GPSImproveddoor_HU.ArmorType = armor_GPSImproveddoor_HU;
            armor_GPSImproveddoor_HU = new ArmorType();

            armor_turretbottomCompositearmor_HU = new ArmorType();
            Util.ShallowCopy(armor_turretbottomCompositearmor_HU, armor_compositeskirt_VNL);
            armor_turretbottomCompositearmor_HU.RhaeMultiplierCe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 14f; //default composite skirt 1.5
            armor_turretbottomCompositearmor_HU.RhaeMultiplierKe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 12f; //default composite skirt 0.8
            armor_turretbottomCompositearmor_HU.Name = "Abrams HU turret bottom composite";

            armor_codex_turretbottomCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
            armor_codex_turretbottomCompositearmor_HU.name = "Abrams HU turret bottom composite";
            armor_codex_turretbottomCompositearmor_HU.ArmorType = armor_turretbottomCompositearmor_HU;
            armor_turretbottomCompositearmor_HU = new ArmorType();

            armor_semireadyrackdoorCompositearmor_HU = new ArmorType();
            Util.ShallowCopy(armor_semireadyrackdoorCompositearmor_HU, armor_compositeskirt_VNL);
            armor_semireadyrackdoorCompositearmor_HU.RhaeMultiplierCe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 5f; //default composite skirt 1.5
            armor_semireadyrackdoorCompositearmor_HU.RhaeMultiplierKe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 5f; //default composite skirt 0.8
            armor_semireadyrackdoorCompositearmor_HU.Name = "Abrams HU semiready rack composite";

            armor_codex_semireadyrackdoorCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
            armor_codex_semireadyrackdoorCompositearmor_HU.name = "Abrams HU semiready rack composite";
            armor_codex_semireadyrackdoorCompositearmor_HU.ArmorType = armor_semireadyrackdoorCompositearmor_HU;
            armor_semireadyrackdoorCompositearmor_HU = new ArmorType();

            armor_readyrackdoorCompositearmor_HU = new ArmorType();
            Util.ShallowCopy(armor_readyrackdoorCompositearmor_HU, armor_compositeskirt_VNL);
            armor_readyrackdoorCompositearmor_HU.RhaeMultiplierCe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 5f; //default composite skirt 1.5
            armor_readyrackdoorCompositearmor_HU.RhaeMultiplierKe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 5f; //default composite skirt 0.8
            armor_readyrackdoorCompositearmor_HU.Name = "Abrams HU ready rack composite";

            armor_codex_readyrackdoorCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
            armor_codex_readyrackdoorCompositearmor_HU.name = "Abrams HU ready rack composite";
            armor_codex_readyrackdoorCompositearmor_HU.ArmorType = armor_readyrackdoorCompositearmor_HU;
            armor_readyrackdoorCompositearmor_HU = new ArmorType();

            armor_trunnionCompositearmor_HU = new ArmorType();
            Util.ShallowCopy(armor_trunnionCompositearmor_HU, armor_compositeskirt_VNL);
            armor_trunnionCompositearmor_HU.RhaeMultiplierCe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 1.5f; //default composite skirt 1.5
            armor_trunnionCompositearmor_HU.RhaeMultiplierKe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 1.5f; //default composite skirt 0.8
            armor_trunnionCompositearmor_HU.Name = "Abrams HU trunnion composite";

            armor_codex_trunnionCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
            armor_codex_trunnionCompositearmor_HU.name = "Abrams HU trunnion composite";
            armor_codex_trunnionCompositearmor_HU.ArmorType = armor_trunnionCompositearmor_HU;
            armor_trunnionCompositearmor_HU = new ArmorType();

            armor_lowerflontplateCompositearmor_HU = new ArmorType();
            Util.ShallowCopy(armor_lowerflontplateCompositearmor_HU, armor_compositeskirt_VNL);
            armor_lowerflontplateCompositearmor_HU.RhaeMultiplierCe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 3.333f; //default composite skirt 1.5
            armor_lowerflontplateCompositearmor_HU.RhaeMultiplierKe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 3.333f; //default composite skirt 0.8
            armor_lowerflontplateCompositearmor_HU.Name = "Abrams HU lower front composite";

            armor_codex_lowerfrontplateCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
            armor_codex_lowerfrontplateCompositearmor_HU.name = "Abrams HU lower front composite";
            armor_codex_lowerfrontplateCompositearmor_HU.ArmorType = armor_lowerflontplateCompositearmor_HU;
            armor_lowerflontplateCompositearmor_HU = new ArmorType();

            armor_hullfrontbackingplateCompositearmor_HU = new ArmorType();
            Util.ShallowCopy(armor_hullfrontbackingplateCompositearmor_HU, armor_compositeskirt_VNL);
            armor_hullfrontbackingplateCompositearmor_HU.RhaeMultiplierCe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 2.5f; //default composite skirt 1.5
            armor_hullfrontbackingplateCompositearmor_HU.RhaeMultiplierKe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 2.5f; //default composite skirt 0.8
            armor_hullfrontbackingplateCompositearmor_HU.Name = "Abrams HU hull front backing composite";

            armor_codex_hullfrontbackingplateCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
            armor_codex_hullfrontbackingplateCompositearmor_HU.name = "Abrams HU hull front backing composite";
            armor_codex_hullfrontbackingplateCompositearmor_HU.ArmorType = armor_hullfrontbackingplateCompositearmor_HU;
            armor_hullfrontbackingplateCompositearmor_HU = new ArmorType();

            armor_turretcheekfaceCompositearmor_HU = new ArmorType();
            Util.ShallowCopy(armor_turretcheekfaceCompositearmor_HU, armor_compositeskirt_VNL);
            armor_turretcheekfaceCompositearmor_HU.RhaeMultiplierCe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 1.6f; //default composite skirt 1.5
            armor_turretcheekfaceCompositearmor_HU.RhaeMultiplierKe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 1.6f; //default composite skirt 0.8
            armor_turretcheekfaceCompositearmor_HU.Name = "Abrams HU cheek face composite";

            armor_codex_turretcheekfaceCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
            armor_codex_turretcheekfaceCompositearmor_HU.name = "Abrams HU cheek face composite";
            armor_codex_turretcheekfaceCompositearmor_HU.ArmorType = armor_turretcheekfaceCompositearmor_HU;
            armor_turretcheekfaceCompositearmor_HU = new ArmorType();

            armor_turretcheekbackingplateCompositearmor_HU = new ArmorType();
            Util.ShallowCopy(armor_turretcheekbackingplateCompositearmor_HU, armor_compositeskirt_VNL);
            armor_turretcheekbackingplateCompositearmor_HU.RhaeMultiplierCe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 3f; //default composite skirt 1.5
            armor_turretcheekbackingplateCompositearmor_HU.RhaeMultiplierKe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 3f; //default composite skirt 0.8
            armor_turretcheekbackingplateCompositearmor_HU.Name = "Abrams HU cheek backing composite";

            armor_codex_turretcheekbackingplateCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
            armor_codex_turretcheekbackingplateCompositearmor_HU.name = "Abrams HU cheek backing composite";
            armor_codex_turretcheekbackingplateCompositearmor_HU.ArmorType = armor_turretcheekbackingplateCompositearmor_HU;
            armor_turretcheekbackingplateCompositearmor_HU = new ArmorType();

            armor_turretsidebackingplateCompositearmor_HU = new ArmorType();
            Util.ShallowCopy(armor_turretsidebackingplateCompositearmor_HU, armor_compositeskirt_VNL);
            armor_turretsidebackingplateCompositearmor_HU.RhaeMultiplierCe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 3f; //default composite skirt 1.5
            armor_turretsidebackingplateCompositearmor_HU.RhaeMultiplierKe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 3f; //default composite skirt 0.8
            armor_turretsidebackingplateCompositearmor_HU.Name = "Abrams HU side backing composite";

            armor_codex_turretsidebackingplateCompositearmor_HU = ScriptableObject.CreateInstance<ArmorCodexScriptable>();
            armor_codex_turretsidebackingplateCompositearmor_HU.name = "Abrams HU side backing composite";
            armor_codex_turretsidebackingplateCompositearmor_HU.ArmorType = armor_turretsidebackingplateCompositearmor_HU;
            armor_turretsidebackingplateCompositearmor_HU = new ArmorType();

            armor_turretsidefaceCompositearmor_HU = new ArmorType();
            Util.ShallowCopy(armor_turretsidefaceCompositearmor_HU, armor_compositeskirt_VNL);
            armor_turretsidefaceCompositearmor_HU.RhaeMultiplierCe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 2.667f; //default composite skirt 1.5
            armor_turretsidefaceCompositearmor_HU.RhaeMultiplierKe = M1A1AbramsAMPMod.demigodArmor.Value ? 100f : 2.667f; //default composite skirt 0.8
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
        }
    }
}
