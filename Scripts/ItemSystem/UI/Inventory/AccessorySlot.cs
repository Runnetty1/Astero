using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem.EventSystem;
using InventorySystem.Core;
using UnityEngine.EventSystems;

namespace InventorySystem
{
    public class AccessorySlot : Slot
    {
        // public enum
        public enum AccessorySlotType {BACK,GADGET,MOUNT,JEWELERY,PET,VANITY,SIGIL}
        public AccessorySlotType accessorySlotType;

        public AccessorySlot()
        {
            slotType = SlotType.ACCESSORY;
        }


        public override void OnDrop(PointerEventData eventData)
        {
            if (Dragable.itemBeingDragged.GetComponent<Item>().itemType.ToString() == accessorySlotType.ToString())
            {
                base.OnDrop(eventData);
            }
        }
    }
}
