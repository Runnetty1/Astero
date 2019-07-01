using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RRG.InventorySystem
{
    [CreateAssetMenu(fileName = "Cargobay", menuName = "Astero/Item/Modules/Internal/Cargobay", order = 1)]
    public class CargoBay : InventoryModule
    {

        public override string ModuleType
        {
            get
            {
                return typeof(CargoBay).Name;
            }
        }

        public override void AddItem(ItemInstance item, bool useStack)
        {
            if (item.item is CargoItem)
            {
                base.AddItem(item,useStack);
            }
            else
            {
                //error: item is not ore
                Debug.LogError("Item is not a cargo item");
            }
        }
    }
}