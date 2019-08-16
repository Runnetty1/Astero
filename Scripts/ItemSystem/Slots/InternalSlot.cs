using Scripts.ItemSystem.ItemTypes.CargoItems.Modules;
using Scripts.ItemSystem.Events;
using UnityEngine;

namespace Scripts.ItemSystem.Slots
{
    [System.Serializable]
    public class InternalSlot : ModuleSlot
    {
        public enum SpesifficType {Universal,Shield,Cargobay,Orebay,Hangarbay,Factorybay,Prosessorbay}
        public SpesifficType spesifficType;
        public InternalModule module;

        public InternalSlot()
        {
        }

        public InternalSlot(int slotSize, SpesifficType spesifficType) : base(slotSize)
        {
            this.spesifficType = spesifficType;
        }

        public void InstallModule(InternalModule module)
        {
            if(module.ModuleSize != slotSize)
            {
                Debug.Log("Cant install, wrong size");
                return;
            }
            if (module.name==spesifficType.ToString() || spesifficType==SpesifficType.Universal)
            {
                Debug.Log("Can install");
                this.module = module;
                new ModuleEvents().ModuleInstallSuccsessEvent(module);
            }
            else
            {
                Debug.Log("Cant install: " + module.name + " On module type: "+ spesifficType.ToString());
                
            }
        }
        public void UninstallModule()
        {
            module = null;
        }
    }
}