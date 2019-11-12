using Scripts;
using Scripts.InputHandling.player;
using Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Game
{
    class GameHandler: MonoBehaviour
    {
        //client vars
        [SerializeField]
        private GameObject Player;
        [SerializeField]
        private GameObject ClientUI;
        [SerializeField]
        private GameObject Camera;

        public GameObject ScenePlayerObj;
        public GameObject SceneClientUIObj;
        public GameObject SceneCameraObj;

        public Faction faction;


        private void Start()
        {
            GameObject p = GameObject.Find("Player");
            if (p == null)
            {
                //spawn
                p = Instantiate(Player);
                Debug.Log("Instantiating playerOBJ");
            }
            else
            {
                Debug.Log("Found player obj");
            }

            ScenePlayerObj = p;

            GameObject C = GameObject.Find("Main Camera");
            if (C == null)
            {
                //spawn
                C = Instantiate(Camera);

                Debug.Log("No main camera");
            }
            else
            {
                Debug.Log("Found main Camera");
            }

            SceneCameraObj = C;
            SceneCameraObj.GetComponent<InputController>().player = ScenePlayerObj.GetComponent<Actor>();
            
            if (ScenePlayerObj.GetComponent<Actor>().controllingShip != null)
            {
                Debug.Log("player is controlling ship, setting the follow target to it.");
                C.GetComponent<CameraController>()._target = ScenePlayerObj.GetComponent<Actor>().controllingShip.transform;
            }

            GameObject CUI = GameObject.Find("ClientUI");
            if (CUI == null)
            {
                Debug.Log("ClientUI not found. instantiating");
                //spawn
                CUI = Instantiate(ClientUI);
                CUI.GetComponent<ClientUI>().player = ScenePlayerObj.GetComponent<Actor>();
            }
            else
            {
                Debug.Log("ClientUI found");
            }
            SceneClientUIObj = CUI;
        }
    }
}
