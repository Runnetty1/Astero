using UnityEngine;
using System.Collections;
using RRG.InputHandling.player;

namespace RRG.ControlledObjects.Weapon
{
    public class TurretBase : MonoBehaviour
    {

        public GameObject bullet;
        public GameObject firePoint;
        public float shootCooldown, reloadTime, clipSize, currbul;
        public float spread;
        public float bulletSpeed;


        public enum TurretState
        {
            idle,
            fireing,
            coolDown,
            reloading,
            offline
        }

        public TurretState state = TurretState.idle;

        public TurretState GetState ()
        {
            return this.state;
        }

        public bool SetState (TurretState newState)
        {
            switch (this.state)
            {
                case TurretState.idle:
                    if (newState == TurretState.fireing && currbul > 1)
                    {
                        this.state = newState;
                        currbul--;
                        this.SetState(TurretState.coolDown);
                        return true;
                    }
                    else
                    {
                        this.state = TurretState.reloading;
                        StartCoroutine(ReloadingTime());
                    }
                    return this.state == newState;
                case TurretState.fireing:
                    if (newState == TurretState.coolDown)
                    {
                        this.state = newState;
                        StartCoroutine(StartCooldown());
                        return true;
                    }
                    return this.state == newState;
                case TurretState.reloading:
                    if (newState == TurretState.idle)
                    {
                        this.state = newState;
                        return true;
                    }
                    return this.state == newState;
                case TurretState.coolDown:
                    if (newState == TurretState.idle)
                    {
                        this.state = newState;
                        return true;
                    }
                    return this.state == newState;
                default:
                    return false;
            }
        }


        public virtual void OnEnable()
        {
            
                InputController.OnInputStateChangeEvent += DisableTurret;
            
        }
        public virtual void OnDisable()
        {
            
                InputController.OnInputStateChangeEvent -= DisableTurret;
            
        }


        private void DisableTurret(bool a)
        {
            if (a)
            {
                this.state = TurretState.offline;
            }
            else
            {
                this.state = TurretState.idle;
            }
        }

        public void Fire ()
        {
            if (this.GetState() == TurretState.idle)
            {
                this.SetState(TurretState.fireing);
                Quaternion rotat = firePoint.transform.rotation;
                rotat.z += Random.Range(-spread, spread);
                GameObject clone = (GameObject)Instantiate(bullet,  firePoint.transform.position, rotat);
                clone.transform.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);

            }
        }

        IEnumerator StartCooldown ()
        {
            yield return new WaitForSeconds(shootCooldown);
            this.SetState(TurretState.idle);
        }

        IEnumerator ReloadingTime ()
        {
            yield return new WaitForSeconds(reloadTime);
            currbul = clipSize;
            this.SetState(TurretState.idle);
        }
    }
}