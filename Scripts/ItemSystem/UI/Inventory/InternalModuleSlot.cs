using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem.EventSystem;
using InventorySystem.Core;
using UnityEngine.EventSystems;

namespace InventorySystem
{
    public class InternalModuleSlot : Slot
    {
        // public enum
        public enum ModuleSlotType {BACK,GADGET,MOUNT,JEWELERY,PET,VANITY,SIGIL}
        public ModuleSlotType accessorySlotType;

        public InternalModuleSlot()
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
