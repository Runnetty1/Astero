using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RRG.InventorySystem
{
    public class ItemEvents
    {
        public delegate void ItemHover(Item item);
        public static event ItemHover OnItemHover;

        public void ItemHoverEvent(Item g) => OnItemHover?.Invoke(g);

        public delegate void ItemStopedHover();
        public static event ItemStopedHover OnItemStopHover;

        public void ItemStopedHoverEvent() => OnItemStopHover?.Invoke();
    }
}