
using Assets.Scripts.ItemSystem.ItemTypes.CargoItems;
using Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Modules;
using Assets.Scripts.ItemSystem.Slots;
using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Data;
using Assets.Scripts.ItemSystem.Events;

namespace Assets.Scripts.ItemSystem
{
   [System.Serializable]
    public class ModuleUpgradeMaster : MonoBehaviour {
    
        public List<ModuleSlot> slots;



        public void InstallModule(Module module,ActorData ship)
        {
            if (ship == GetComponent<ActorData>())
            {
                foreach (ModuleSlot slot in slots)
                {
                    if (slot.module == null)
                    {
                        slot.InstallModule(module as UpgradeModule, GetComponent<ActorData>());
                        break;
                    }
                }
            }
        }

        public void UninstallModule(Module mod)
        {
            foreach (ModuleSlot slot in slots)
            {
                if (mod == slot.module)
                {
                    slot.UninstallModule(GetComponent<ActorData>());
                    UpdateShipAttributes(mod, GetComponent<ActorData>());
                    
                }
            }
            new AttributeEvents().AttributeChangedEvent(this.GetComponent<ActorData>());
        }

        private void OnEnable()
        {
            ModuleEvents.OnModuleInstallSuccsess += UpdateShipAttributes;
            ModuleEvents.OnModuleUninstall += UninstallModule;
            Instantiate();
        }

        private void Instantiate()
        {
            List<Attribute> shipAttributes = GetComponent<ActorData>().shipAttributes;
            List<Attribute> DefaultShipAttributes = GetComponent<ActorData>().DefaultShipAttributes;
            for (int i = 0; i < shipAttributes.Count; i++)
            {
                Attribute at = shipAttributes[i];
                at._value = DefaultShipAttributes[i]._value;
                foreach (ModuleSlot slotItem in slots)
                {
                    if (slotItem.module != null)
                    {
                        if (slotItem.module.GetAttribute(at._name) != null)
                        {
                            at._value += slotItem.module.GetAttribute(at._name)._value;
                        }
                    }
                }
            }
        }

        public void UpdateShipAttributes(Module item, ActorData ship)
        {
            List<Attribute> shipAttributes = GetComponent<ActorData>().shipAttributes;
            List<Attribute> DefaultShipAttributes = GetComponent<ActorData>().DefaultShipAttributes;
            for (int i = 0; i < shipAttributes.Count; i++)
            {
                Attribute at = shipAttributes[i];
                at._value = DefaultShipAttributes[i]._value;
                foreach(ModuleSlot slotItem in slots)
                {
                    if (slotItem.module != null)
                    {
                        if (slotItem.module.GetAttribute(at._name) != null)
                        {
                            at._value += slotItem.module.GetAttribute(at._name)._value;
                        }
                    }
                }
            }
            new AttributeEvents().AttributeChangedEvent(ship);
        }
    }
}
