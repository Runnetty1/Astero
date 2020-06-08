using Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Modules;
using Assets.Scripts.ItemSystem.Events;
using UnityEngine;
using Assets.Scripts.Data;

namespace Assets.Scripts.ItemSystem.Slots
{
    [System.Serializable]
    public class ModuleSlot
    {
        public enum SpesifficType
        {   Universal,
            Acceleration,
            TurnSpeed,
            CargoCapacity,
            OreCapacity,
            HangarCapacity,
            WarpSpeed,
            RadarRange,
            DroneCapacity,
            DroneRange,
            Shield,
            Hull,
            SensorRange
        }
        public SpesifficType spesifficType;
        public UpgradeModule module;
        public int slotSize;


        public void InstallModule(UpgradeModule moduleUpgrade,ActorData ship)
        {
            if (module != null)
            {
                UninstallModule(ship);
            }

            if(moduleUpgrade.ModuleSize != slotSize)
            {
                Debug.Log("Cant install, wrong size");
                return;
            }
            if (moduleUpgrade.type==spesifficType || spesifficType==SpesifficType.Universal)
            {
                Debug.Log("Can install");
                this.module = moduleUpgrade;
                new ModuleEvents().ModuleInstallSuccsessEvent(moduleUpgrade,ship);
            }
            else
            {
                Debug.Log("Cant install: " + moduleUpgrade.name + " On module type: "+ spesifficType.ToString());
                
            }
        }

        public void UninstallModule(ActorData ship)
        {
            ItemInstance temp = new ItemInstance(module as UpgradeModule, 1);
            new ItemEvents().ItemPickupEvent(temp,ship.gameObject);
            this.module = null;
            new ModuleEvents().ModuleUninstallSuccsessEvent(module);
        }
    }
}