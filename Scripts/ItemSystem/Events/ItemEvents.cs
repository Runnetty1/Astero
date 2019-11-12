
using UnityEngine;

namespace Scripts.ItemSystem.Events
{
    public class ItemEvents
    {
        public delegate void ItemHover(ItemInstance item);
        public static event ItemHover OnItemHover;

        public void ItemHoverEvent(ItemInstance itemInstance) => OnItemHover?.Invoke(itemInstance);

        public delegate void ItemStopedHover();
        public static event ItemStopedHover OnItemStopHover;

        public void ItemStopedHoverEvent() => OnItemStopHover?.Invoke();

        public delegate void ItemAdded(ItemInstance item);
        public static event ItemAdded OnItemAdded;

        public void ItemAddedEvent(ItemInstance itemInstance) => OnItemAdded?.Invoke(itemInstance);

        public delegate void ItemMerged(ItemInstance item);
        public static event ItemMerged OnItemMerge;

        public void ItemMergedEvent(ItemInstance itemInstance) => OnItemMerge?.Invoke(itemInstance);

        public delegate void ItemRightClick(ItemInstance item,Vector2 pos);
        public static event ItemRightClick OnItemRightClick;

        public void ItemRightClickEvent(ItemInstance itemInstance,Vector2 pos) => OnItemRightClick?.Invoke(itemInstance,pos);

        public delegate void ItemRemoved(ItemInstance item);
        public static event ItemRemoved OnItemRemoved;

        public void ItemRemovedEvent(ItemInstance itemInstance) => OnItemRemoved?.Invoke(itemInstance);


    }
}