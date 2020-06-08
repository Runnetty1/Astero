using UnityEngine;

namespace Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Turret.Base
{
    public class TurretBase : MonoBehaviour
    {
        public TurretItem turretData;
        public int maxSize;
        public GameObject firePoint;

        public virtual void Start()
        {
            if (turretData != null)
            {
                if (this.GetComponent<SpriteRenderer>() != null)
                {
                    this.GetComponent<SpriteRenderer>().sprite = turretData.TurretBase;
                }
                if (transform.GetChild(0).GetComponent<SpriteRenderer>() !=null)
                {
                    transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = turretData.TurretBarrel;
                }
            }
        }

        public virtual void Activate()
        {

        }
        public virtual void DeActivate()
        {

        }

        public virtual void InstallTurret(TurretItem item)
        {
            turretData = item;

            if (this.GetComponent<SpriteRenderer>() != null)
            {
                this.GetComponent<SpriteRenderer>().sprite = turretData.TurretBase;
            }
            if (transform.GetChild(0).GetComponent<SpriteRenderer>() != null)
            {
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = turretData.TurretBarrel;
            }
        }

    }
}
