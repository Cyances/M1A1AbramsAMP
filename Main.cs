using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using M1A1AMP;
using GHPC.State;
using System.Collections;
using UnityEngine;
using GHPC.Camera;
using GHPC.Player;
using M1A1AbramsAMP;
using GHPC.Vehicle;

[assembly: MelonInfo(typeof(AbramsAMPMod), "ZZ M1A1 Abrams AMP", "2.7.5", "Cyance, ATLAS and Schweiz")]
[assembly: MelonGame("Radian Simulations LLC", "GHPC")]

namespace M1A1AMP
{
    public class AbramsAMPMod : MelonMod
    {

        public static Vehicle[] vics;
        public static GameObject gameManager;
        public static CameraManager camManager;
        public static PlayerInput playerManager;


        public IEnumerator GetVics(GameState _)
        {
            vics = GameObject.FindObjectsByType<Vehicle>(FindObjectsSortMode.None);

            yield break;
        }

        public override void OnInitializeMelon()
        {
            MelonPreferences_Category cfg = MelonPreferences.CreateCategory("M1A1AMPConfig");
            M1A1AbramsAMPMod.Config(cfg);
        }

        public override void OnSceneWasLoaded(int idx, string scene_name)
        {
            if (scene_name == "MainMenu2_Scene" || scene_name == "LOADER_MENU" || scene_name == "LOADER_INITIAL" || scene_name == "t64_menu" || scene_name == "MainMenu2-1_Scene") return;

            gameManager = GameObject.Find("_APP_GHPC_");
            camManager = gameManager.GetComponent<CameraManager>();
            playerManager = gameManager.GetComponent<PlayerInput>();

            StateController.RunOrDefer(GameState.GameReady, new GameStateEventHandler(GetVics), GameStatePriority.Medium);
            AmmoArmor.Init();
            CITV.Init();
            CROWS.Init();
            M1A1AbramsAMPMod.Init();
            ProxyFuzeAMP.Init();
            ProxyFuzeMPAT.Init();
        }
    }
}
