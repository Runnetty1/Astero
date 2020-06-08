using Assets.Scripts.ActorControllers;
using Assets.Scripts.Data;
using Assets.Scripts.ItemSystem.Events;
using Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Turret;
using Assets.Scripts.ItemSystem.Slots;
using Assets.Scripts.UI.Generic;
using UnityEngine;
namespace Assets.Scripts.ItemSystem.UI
{
    public class TurretSystemsView : Window
    {
        public TurretMaster master;

        public GameObject slotParent;
        public GameObject TurretSlotObj;


        public void Instantiate()
        {

            foreach (Transform child in slotParent.transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            if (master.turretSlots != null)
            {
                foreach (TurretSlot slot in master.turretSlots)
                {
                    GameObject turr = (GameObject)Instantiate(TurretSlotObj, slotParent.transform.position, Quaternion.identity, slotParent.transform);
                    if (slot != null)
                    {
                        
                        if (slot.turret != null)
                        {
                            turr.GetComponent<TurretSlotView>().item = new ItemInstance(slot.turret, 1);
                            turr.GetComponent<TurretSlotView>().Instantiate();
                        }
                        else
                        {
                            turr.GetComponent<TurretSlotView>().typeImg.sprite = Resources.LoadAll<Sprite>("UI/SlotTypes/" + slot.spesifficType.ToString() + "")[0];
                        }
                    }
                }

            }

        }

        public override void OnEnable()
        {

            TurretEvents.OnTurretInstallSuccsess += TurretEvents_OnTurretInstallSuccsess;
            //Instantiate();  
            TurretEvents.OnTurretUninstallSuccsess += TurretEvents_OnTurretUninstall;
        }

        private void TurretEvents_OnTurretUninstall(TurretItem item)
        {
            Instantiate();
        }

        private void TurretEvents_OnTurretInstallSuccsess(TurretItem item, ActorData ship)
        {
            Instantiate();
        }
    }

}

