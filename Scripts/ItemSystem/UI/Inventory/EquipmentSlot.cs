using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem.EventSystem;
using InventorySystem.Core;
using UnityEngine.EventSystems;

namespace InventorySystem
{
    public class EquipmentSlot : Slot
    {

        /*
         * EquipmentSlot
         * 
         * Allows placement of items with types: Head,body,leg
         */

        public enum EquipmentSlotType {HEAD,BODY,LEG}
        public EquipmentSlotType equipmentSlotType;
        public EquipmentSlot()
        {
            slotType = SlotType.EQUIPMENT;
        }


        public override void OnDrop(PointerEventData eventData)
        {

            if(Dragable.itemBeingDragged.GetComponent<Item>().itemType.ToString() == equipmentSlotType.ToString())
            {
                base.OnDrop(eventData);
            }
        }
    }
}