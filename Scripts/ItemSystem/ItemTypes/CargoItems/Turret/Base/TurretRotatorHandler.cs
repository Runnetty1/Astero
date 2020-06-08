using UnityEngine;
using Assets.Scripts.ActorControllers;

namespace Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Turret.Base
{
    public class TurretRotatorHandler : TurretBase
    {
        public GameObject targetObject;
        public enum TurretMode {AUTO,MANUAL};
        public TurretMode turretMode = TurretMode.AUTO;
        
        public Vector2 mousePos;
        public Vector2 TargetPos;


        public virtual void Update ()
        {

            if (turretData.canRotate)
            {
                if (turretMode == TurretMode.AUTO && targetObject != null)
                {
                    AutoTurnTowardTarget();
                }
                else if (turretMode == TurretMode.MANUAL)
                {
                    ManualTurnTowardTarget();
                }
            }
            else
            {
                //Aim forward
                Debug.Log("cant turn"); 
            }
        }

        public override void Start()
        {
            base.Start();
            
            
        }

        public virtual void OnEnable()
        {
           
            if (transform.parent.tag != "ai")
            {
                InputController.OnAutoTurretModeSwitchEvent += SetTurretMode;
            }
        }

        private void SetTurretMode()
        {
            if(turretMode == TurretMode.AUTO)
            {
                turretMode = TurretMode.MANUAL;
            }
            else
            {
                turretMode = TurretMode.AUTO;
            }
        }


        /// <summary>
        /// ////////////////////FIX ROTATION ISSUE
        /// </summary>
        void AutoTurnTowardTarget ()
        {
            Debug.DrawLine(targetObject.transform.position, transform.position);

            Vector3 dir = targetObject.transform.position - this.gameObject.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            this.transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.smoothDeltaTime * turretData.turretTurnSpeed);

        }

        void ManualTurnTowardTarget ()
        {
            var screenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.DrawLine(screenPos, transform.position);

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 dir = screenPos - this.gameObject.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
           
            this.transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.smoothDeltaTime * turretData.turretTurnSpeed);
 
        }

        private void OnDrawGizmos()
        {
            if (turretMode == TurretMode.AUTO  && targetObject!=null)
            {
                Gizmos.DrawWireSphere(targetObject.transform.position, 1f);
            }
            else if (turretMode == TurretMode.MANUAL)
            {
                Gizmos.DrawSphere(mousePos, 0.4f);
            }
            
        }
    }
}