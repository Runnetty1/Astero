using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RRG.InventorySystem
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Orebay", menuName = "Astero/Item/Modules/Internal/Orebay", order = 1)]
    public class OreBay : InternalModule
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