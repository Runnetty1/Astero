
using UnityEngine;

namespace Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Turret
{   
    public class TurretItem : CargoItem
    {
        [SerializeField]
        private int size;

        public int Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
            }
        }

        //Visual Data
        public Sprite TurretBase;
        public Sprite TurretBarrel;
        public bool canRotate;
        public float turretTurnSpeed;

    }
}
