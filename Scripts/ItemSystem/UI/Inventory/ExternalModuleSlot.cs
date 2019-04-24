using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem.EventSystem;
using InventorySystem.Core;
using UnityEngine.EventSystems;

namespace InventorySystem
{
    public class ExternalModuleSlot : Slot
    {

        /*
         * EquipmentSlot
         * 
         * Allows placement of items with types: Head,body,leg
         */

        public enum ModuleType {HEAD,BODY,LEG}
        public ModuleType externalModuleType;

        public ExternalModuleSlot()
        {
            slotType = SlotType.EQUIPMENT;
        }


        public override void OnDrop(PointerEventData eventData)
        {

            if(Dragable.itemBeingDragged.GetComponent<Item>().itemType.ToString() == externalModuleType.ToString())
            {
                base.OnDrop(eventData);
            }
        }
    }
}