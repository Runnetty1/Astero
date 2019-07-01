using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RRG.InventorySystem
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Orebay", menuName = "Astero/Item/Modules/Internal/Orebay", order = 1)]
    public class OreBay : InventoryModule
    {

        public override string ModuleType
        {
            get
            {
                return typeof(OreBay).Name;
            }
        }
        
        public override void AddItem(ItemInstance item, bool useStack)
        {
            if (item.item is Ore)
            {
                Debug.Log("item is ore");
                base.AddItem(item, useStack);
            }
            else
            {
                //error: item is not ore
                Debug.LogError("Item is not ore");
            }
        }
    }
}