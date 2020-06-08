
using Assets.Scripts.Data;
using Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Turret.Base;
using Assets.Scripts.VFX;
using UnityEngine;


namespace Assets.Scripts.ActorControllers
{
    public class InputController : MonoBehaviour {

        public bool NoInputs;
        public bool WindowsActive;
        public bool ActiveWindow;

        public string leftRight;
        public string upDown;
        public string fire;
        public UserData player;
        
        private bool one_click;
        private float timer_for_double_click;
        public float doubleClickDelay;

        public enum ScrollDirection { UP, DOWN };
        public delegate void ScrolledEvent(ScrollDirection dir);
        public static event ScrolledEvent OnScrollEvent;

        /*
        public delegate void MouseClickEvent();
        public static event MouseClickEvent OnMouseSingleClickEvent;
        */
        public delegate void MouseDoubleClickEvent();
        public static event MouseDoubleClickEvent OnMouseDoubleClickEvent;

        public delegate void InputDisableEvent(bool a);
        public static event InputDisableEvent OnInputStateChangeEvent;

        public delegate void WindowVisibilityEvent(string name, bool visiblityState);
        public static event WindowVisibilityEvent OnWindowVisibilityEvent;

        public delegate void AutoTurretModeSwitchEvent();
        public static event AutoTurretModeSwitchEvent OnAutoTurretModeSwitchEvent;

        public delegate void CameraModeSwitchEvent(CameraController.CameraMode mode);
        public static event CameraModeSwitchEvent OnCameraModeSwitchEvent;
        private bool CamMode;

        private bool fireLock = true;

        // Update is called once per frame
        void Update()
        {
            //CLIENT ONLY
            
            if (!NoInputs && !WindowsActive)
            {
                if (player != null)
                {
                    DetectInput();
                }
                CheckForMouse1ClickEvents();
                if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
                {
                    OnScrollEvent?.Invoke(ScrollDirection.DOWN);
                }
                else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
                {
                    OnScrollEvent?.Invoke(ScrollDirection.UP);
                }

            }

            if (!WindowsActive && Input.GetKeyDown(KeyCode.Tab))
            {
                WindowsActive = true;
                OnInputStateChangeEvent?.Invoke(true);
                //OnWindowVisibilityEvent?.Invoke("all",true);
            }
            if (!WindowsActive && Input.GetKeyDown(KeyCode.I))
            {
                WindowsActive = true;
                OnInputStateChangeEvent?.Invoke(true);
                OnWindowVisibilityEvent?.Invoke("ShipInfoWindow", true);
            }
            if (!ActiveWindow && Input.GetKeyDown(KeyCode.R))
            {
                ActiveWindow = true;
                
                OnWindowVisibilityEvent?.Invoke("RadarList", true);
            }
            else if (ActiveWindow && Input.GetKeyDown(KeyCode.R)) {
                ActiveWindow = false;
                
                OnWindowVisibilityEvent?.Invoke("RadarList", false);
            }

            if (WindowsActive && Input.GetKeyDown(KeyCode.Tab))
            {
                WindowsActive = false;
                OnInputStateChangeEvent?.Invoke(false);
                OnWindowVisibilityEvent?.Invoke("all",false);
            }

        }

        private void OnEnable()
        {
            ShipControll.OnShipWarpEvent += PlayerWarping;
            WindowsActive = false;
            OnInputStateChangeEvent?.Invoke(false);
            OnWindowVisibilityEvent?.Invoke("all", false);
        }

        private void PlayerWarping(bool a)
        {
            NoInputs = a;

        }

        private void CheckForMouse1ClickEvents()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (!this.one_click) // first click no previous clicks
                {
                    this.one_click = true;

                    this.timer_for_double_click = Time.time; // save the current time

                    //Debug.Log("single Click");
                }
                else
                {
                    this.one_click = false; // found a double click, now reset
                    OnMouseDoubleClickEvent?.Invoke();
                    //Debug.Log("Double Click");
                }
            }

            if (one_click)
            {
                // if the time now is delay seconds more than when the first click started. 
                if ((Time.time - this.timer_for_double_click) > doubleClickDelay)
                {
                    //basically if thats true its been too long and we want to reset so the next click is simply a single click and not a double click.
                    one_click = false;
                }
            }
        }

        /////////////////////////////////
        /// Ship Control;
        private void DetectInput()
        {
            ///LEFT
            if (Input.GetAxis(leftRight) < 0f)
            {
                player.controllingShip.gameObject.GetComponent<ShipControll>().Left();
                player.controllingShip.gameObject.GetComponent<ShipThrusterController>().shipMovementDirection = ShipThrusterController.ShipMoveDir.Left;
            }else
            //RIGHT
            if (Input.GetAxis(leftRight) > 0f)
            {
                
                player.controllingShip.gameObject.GetComponent<ShipControll>().Right();
                player.controllingShip.gameObject.GetComponent<ShipThrusterController>().shipMovementDirection = ShipThrusterController.ShipMoveDir.Right;
            }
            else
            {
                player.controllingShip.gameObject.GetComponent<ShipThrusterController>().shipMovementDirection = ShipThrusterController.ShipMoveDir.none;
            }
            ///UP DOWN
            if (Input.GetAxis(upDown) < 0f)
            {
                //Debug.Log("down");
                player.controllingShip.gameObject.GetComponent<ShipControll>().Backward();
                player.controllingShip.gameObject.GetComponent<ShipThrusterController>().state = ShipThrusterController.ShipMove.Backward;
            }
            else if (Input.GetAxis(upDown) > 0f)
            {
                //Debug.Log("up");
                player.controllingShip.gameObject.GetComponent<ShipControll>().Forward();
                player.controllingShip.gameObject.GetComponent<ShipThrusterController>().state = ShipThrusterController.ShipMove.Forward;
            }
            else
            {
                player.controllingShip.gameObject.GetComponent<ShipThrusterController>().state = ShipThrusterController.ShipMove.none;
            }
            if (Input.GetAxis(fire) > 0f)
            {
                //Debug.Log("Fire");
                player.controllingShip.turretMaster.Fire(true);
                fireLock = false;
            }
            else
            {
                if (!fireLock)
                {
                    fireLock = true;
                    player.controllingShip.turretMaster.Fire(false);
                }
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                
                OnAutoTurretModeSwitchEvent?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!CamMode)
                {
                    
                    OnCameraModeSwitchEvent?.Invoke(CameraController.CameraMode.SelfMove);
                    CamMode = true;
                }
                else
                {
                    
                    OnCameraModeSwitchEvent?.Invoke(CameraController.CameraMode.Follow);
                    
                    CamMode = false;
                }
            }
        }
        /////////////////////////////////

        

    }
}