using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RRG.InventorySystem
{
    [CreateAssetMenu(fileName = "Hangarbay", menuName = "Astero/Item/Modules/Internal/Hangarbay", order = 1)]
    public class HangarBay : InventoryModule
    {
        public HangarBay ()
        {

        }

        public override string ModuleType
        {
            get
            {
                return typeof(HangarBay).Name;
            }
        }

        public override void AddItem(ItemInstance item, bool useStack)
        {
            if (item.item is HangarItem)
            {
                base.AddItem(item, useStack);
            }
            else
            {
                //error: item is not ore
                Debug.LogError("Item is not a hangar item");
            }
        }
    }
}