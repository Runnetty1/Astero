
using UnityEngine;
using Assets.Scripts.ItemSystem.ItemTypes;

namespace Assets.Scripts.ItemSystem
{
    class ProcessedBay : Inventory
    {
        public override void AddItem(ItemInstance item, bool useStack)
        {
            if (item.item is CargoItem)
            {
                base.AddItem(item, useStack);
            }
            else
            {
                Debug.Log("Can not add a non CargoItem to bay");
            }
        }
    }
}
