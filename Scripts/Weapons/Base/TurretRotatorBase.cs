using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RRG.InputHandling.player;

namespace RRG.ControlledObjects.Weapon
{
    public class TurretRotatorBase : TurretBase
    {
        public GameObject goTarget;
        public enum TurretMode {AUTO,MANUAL};
        public TurretMode turretMode = TurretMode.AUTO;
        public float turnSpeed;

        public Vector2 mousePos;
        public Vector2 TargetPos;


        public void TurnToTarget ()
        {
    
            if (turretMode == TurretMode.AUTO && goTarget!=null)
            {
                AutoTurnTowardTarget();
            }
            else if(turretMode ==TurretMode.MANUAL)
            {
                ManualTurnTowardTarget();
            }  
        }

        public override void OnEnable()
        {
            base.OnEnable();
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
            Debug.DrawLine(goTarget.transform.position, transform.position);

            Vector3 dir = goTarget.transform.position - this.gameObject.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            this.transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.smoothDeltaTime * turnSpeed);

        }

        void ManualTurnTowardTarget ()
        {
            var screenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.DrawLine(screenPos, transform.position);

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 dir = screenPos - this.gameObject.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            this.transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.smoothDeltaTime * turnSpeed);
            
            
        }

        private void OnDrawGizmos()
        {
            if (turretMode == TurretMode.AUTO)
            {
                Gizmos.DrawWireSphere(goTarget.transform.position, 1f);
            }
            else if (turretMode == TurretMode.MANUAL)
            {
                Gizmos.DrawSphere(mousePos, 0.4f);
            }
            
        }
    }
}