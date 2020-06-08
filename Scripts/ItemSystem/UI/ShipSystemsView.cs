
using UnityEngine;

using Assets.Scripts.ItemSystem.ItemTypes.CargoItems;
using Assets.Scripts.Data;
using System.Collections.Generic;
using Assets.Scripts.ItemSystem.Slots;
using UnityEngine.UI;
using Assets.Scripts.UI.Generic;
using Assets.Scripts.ItemSystem.Events;
using System.Collections;

namespace Assets.Scripts.ItemSystem.UI
{
    public class ShipSystemsView : Window
    {

        public ModuleUpgradeMaster master;

        public GameObject slotParent;
        public GameObject moduleSlotObj;
        

        public void Instantiate()
        {
            
            foreach (Transform child in slotParent.transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            if (master != null)
            {
                if (master.slots != null)
                {
                    foreach (ModuleSlot slot in master.slots)
                    {
                        if (slot != null)
                        {
                            GameObject module = (GameObject)Instantiate(moduleSlotObj, slotParent.transform.position, Quaternion.identity, slotParent.transform);
                            if (slot.module != null)
                            {
                                module.GetComponent<ModuleSlotView>().item = new ItemInstance(slot.module, 1);
                                module.GetComponent<ModuleSlotView>().Instantiate();
                            }
                            else
                            {
                                module.GetComponent<ModuleSlotView>().typeImg.sprite = Resources.LoadAll<Sprite>("UI/SlotTypes/" + slot.spesifficType.ToString() + "")[0];
                            }
                        }
                    }

                }
            }
            
        }
        public override void OnEnable()
        {

            ModuleEvents.OnModuleInstallSuccsess += ModuleEvents_OnModuleInstallSuccsess;
            if (master != null)
            {
                Instantiate();
                
            }
            ModuleEvents.OnModuleUninstallSuccsess += ModuleEvents_OnModuleUninstall;
        }

        private void ModuleEvents_OnModuleUninstall(Module item)
        {
            Instantiate();
            
        }

        private void ModuleEvents_OnModuleInstallSuccsess(Module item, ActorData ship)
        {
            Instantiate();
            
        }
    }
}