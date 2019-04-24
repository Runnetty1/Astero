using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem.Core;
using UnityEngine.EventSystems;

namespace InventorySystem
{
    public class HotbarSlot : Slot
    {

        /*
         * Hotbar
         * 
         * Allows placement of items with types: Consumable,weapon,placeable
         */

        public HotbarSlot()
        {
            slotType = SlotType.INVENTORY;
        }

        public override void OnDrop(PointerEventData eventData)
        {

            if (Dragable.itemBeingDragged.GetComponent<Item>().itemType.ToString() == "CONSUMABLE"  ||
                Dragable.itemBeingDragged.GetComponent<Item>().itemType.ToString() == "WEAPON"      ||
                Dragable.itemBeingDragged.GetComponent<Item>().itemType.ToString() == "PLACEABLE"    )
            {
                base.OnDrop(eventData);
            }
        }

    }
}