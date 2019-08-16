using Scripts.ItemSystem.ItemTypes.CargoItems;
using Scripts.ItemSystem.ItemTypes.CargoItems.Modules;
using Scripts.ItemSystem.Slots;

using System.Collections.Generic;

namespace Scripts.ItemSystem
{
    [System.Serializable]
    public class ModuleSlots {

        public enum SlotType { Internal,External };

        public List<InternalSlot> internalSlots;
        public List<ExternalSlot> externalSlots;

        public void InstallModule(Module module,int id)
        {
            if (module is InternalModule)
            {
                //if a internal slot is of 
                internalSlots[id].InstallModule(module as InternalModule);
            }
            if (module is ExternalModule)
            {
                externalSlots[id].InstallModule(module as ExternalModule);
            }
        }

        public bool HasModuleSlot(Module mod)
        {
            foreach (InternalSlot slot in internalSlots)
            {
                if (mod.GetType().ToString() == slot.spesifficType.ToString())
                {

                }
            }
            return false;
        }

        public bool UninstallModule(Module mod)
        {
            foreach (InternalSlot slot in internalSlots)
            {
                if (mod == slot.module)
                {
                    slot.UninstallModule();
                    return true;
                }
            }
            foreach (ExternalSlot slot in externalSlots)
            {
                if (mod == slot.module)
                {
                    slot.UninstallModule();
                    return true;
                }
            }
            return false;
        }
    }
}
