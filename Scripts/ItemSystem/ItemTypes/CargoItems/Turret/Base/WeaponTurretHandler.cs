using UnityEngine;
using System.Collections;
using Assets.Scripts.ActorControllers;


namespace Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Turret.Base
{
    public class WeaponTurretHandler : TurretRotatorHandler
    {
        
        public float currentBullet;

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
                    if (newState == TurretState.fireing && currentBullet > 1)
                    {
                        this.state = newState;
                        currentBullet--;
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


        public override void OnEnable()
        {
            base.OnEnable();
            InputController.OnInputStateChangeEvent += DisableTurret;
            
        }
        public virtual void OnDisable()
        {
            
                InputController.OnInputStateChangeEvent -= DisableTurret;
            
        }


        private void DisableTurret(bool disabled)
        {
            if (disabled)
            {
                this.state = TurretState.offline;
            }
            else
            {
                this.state = TurretState.idle;
            }
        }

        public override void Activate ()
        {
            
            if (turretData != null)
            {
                if (turretData is WeaponTurret)
                {
                    if (this.GetState() == TurretState.idle)
                    {
                        this.SetState(TurretState.fireing);
                        Quaternion rotat = firePoint.transform.rotation;
                        rotat.z += Random.Range(-(turretData as WeaponTurret).spread, (turretData as WeaponTurret).spread);
                        GameObject clone = (GameObject)Instantiate((turretData as WeaponTurret).bullet, firePoint.transform.position, rotat);
                        clone.transform.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * (turretData as WeaponTurret).speed, ForceMode2D.Impulse);

                    }
                }
            }
        }

        IEnumerator StartCooldown ()
        {
            yield return new WaitForSeconds((turretData as WeaponTurret).firingCooldownTime);
            this.SetState(TurretState.idle);
        }

        IEnumerator ReloadingTime ()
        {
            yield return new WaitForSeconds((turretData as WeaponTurret).reloadTime);
            currentBullet = (turretData as WeaponTurret).magazineSize;
            this.SetState(TurretState.idle);
        }

        public override void InstallTurret(TurretItem item)
        {
            base.InstallTurret(item);
            
        }


    }
}