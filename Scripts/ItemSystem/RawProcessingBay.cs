
using UnityEngine;
using Assets.Scripts.ItemSystem.ItemTypes;


namespace Assets.Scripts.ItemSystem
{
    class RawProcessingBay : Inventory
    {

        public override void AddItem(ItemInstance item, bool useStack)
        {
            if (item.item is Raw)
            {
                base.AddItem(item, useStack);
            }
            else
            {
                Debug.Log("Can not add a non Raw Item to bay");
            }
        }
    }
}
