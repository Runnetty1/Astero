using UnityEngine;

namespace Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Turret
{
    [CreateAssetMenu(fileName = "MiningTurret", menuName = "Astero/Item/Turret/MiningTurret", order = 1)]
    public class MiningTurret : ToolTurret
    {
        //Visual Data
        public UnityEngine.Material LaserMaterial;
        public double extractionAmount;
        public float miningSpeed;

        public AudioClip miningSound;
        
    }
}
