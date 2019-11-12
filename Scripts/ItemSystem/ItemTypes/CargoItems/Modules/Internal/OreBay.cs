using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.ItemSystem.ItemTypes.CargoItems.Modules.Internal
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
    }
}