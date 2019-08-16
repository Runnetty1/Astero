using Scripts.ItemSystem.ItemTypes.CargoItems.Modules;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Scripts.ItemSystem.Slots
{
    [System.Serializable]
    public class ExternalSlot : ModuleSlot
    {
        public enum SpesifficType {Universal,Laser,Railgun,Kinetic,Missile,Torpedo,Sensor }
        public SpesifficType spesifficType;
        public ExternalModule module;

        public ExternalSlot()
        {
        }

        public ExternalSlot(int slotSize, SpesifficType spesifficType) : base(slotSize)
        {
            this.spesifficType = spesifficType;
        }

        public void InstallModule(ExternalModule module)
        {
            if (module.ModuleSize != slotSize)
            {
                Debug.Log("Can install");
                return;
            }
            if (module.GetType().ToString() == spesifficType.ToString() || spesifficType==SpesifficType.Universal)
            {
                Debug.Log("Can install");
            }
            else
            {
                Debug.Log("Cant install: " + module.GetType().ToString() + " On module type: " + spesifficType.ToString());
            }
        }

        public void UninstallModule()
        {
            module = null;
            
        }
    }
}