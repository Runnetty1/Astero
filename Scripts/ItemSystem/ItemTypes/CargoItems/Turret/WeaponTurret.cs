using UnityEngine;

namespace Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Turret
{
    [CreateAssetMenu(fileName = "WeaponTurret", menuName = "Astero/Item/Turret/WeaponTurret", order = 1)]
    public class WeaponTurret : TurretItem
    {
        //Base data
        public GameObject bullet;
        public float firingCooldownTime, reloadTime, magazineSize;
        public float spread;
        public float speed;
        public float dmg;
    }
}
