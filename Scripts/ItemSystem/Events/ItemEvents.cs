using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RRG.InventorySystem
{
    public class ItemEvents
    {
        public delegate void ItemHover(ItemInstance item);
        public static event ItemHover OnItemHover;

        public void ItemHoverEvent(ItemInstance g) => OnItemHover?.Invoke(g);

        public delegate void ItemStopedHover();
        public static event ItemStopedHover OnItemStopHover;

        public void ItemStopedHoverEvent() => OnItemStopHover?.Invoke();
    }
}