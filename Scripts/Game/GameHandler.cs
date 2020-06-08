using Assets.Scripts.ActorControllers;
using Assets.Scripts.Data;
using Assets.Scripts.UI;
using Assets.Scripts.Util;
using UnityEngine;

namespace Assets.Scripts.Game
{
    class GameHandler: MonoBehaviour
    {
        //client vars
        [SerializeField]
#pragma warning disable CS0649 // Add readonly modifier
        private GameObject playerAsset;
        [SerializeField]
        private GameObject clientUIAsset;
        [SerializeField]
        private GameObject cameraAsset;
        #pragma warning restore CS0649 // Add readonly modifier

        public UserData Player;
        public GameObject SceneClientUIObj;
        public GameObject SceneCameraObj;

        #pragma warning disable CS0649 // Add readonly modifier
        public Faction faction;
#pragma warning restore CS0649 // Add readonly modifier
        public static GameHandler Instance { get; private set; } // static singleton


        private void Start()
        {
            if (Instance == null) { Instance = this; }
            else { Destroy(gameObject); }

            UserData p = GameObject.Find("Player").GetComponent<UserData>();
            if (p == null)
            {
                //spawn
                p = Instantiate(playerAsset).GetComponent<UserData>();
                Debug.Log("No Player Object in scene: Spawning one");
            }
            Debug.Log("Player Set");
            Player = p;

            GameObject C = GameObject.Find("Main Camera");
            if (C == null)
            {
                //spawn
                C = Instantiate(cameraAsset);

                Debug.Log("No main camera in scene: Spawning one");
            }

            SceneCameraObj = C;
            SceneCameraObj.GetComponent<InputController>().player = Player;
            
            if (Player.GetComponent<UserData>().controllingShip != null)
            {
                //Debug.Log("player is controlling ship, setting the follow target to it.");
                C.GetComponent<CameraController>()._target = Player.controllingShip.transform;
            }

            GameObject CUI = GameObject.Find("ClientUI");
            if (CUI == null)
            {
                Debug.Log("No ClientUI in scene: Spawning one");
                //spawn
                CUI = Instantiate(clientUIAsset);
                CUI.GetComponent<ClientUI>().player = Player;
            }
            CUI.GetComponent<ClientUI>().Instantiate();
            SceneClientUIObj = CUI;
        }
    }
}
