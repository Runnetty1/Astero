using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.ItemSystem.ItemTypes.CargoItems.Modules.Internal
{
    [CreateAssetMenu(fileName = "Hangarbay", menuName = "Astero/Item/Modules/Internal/Hangarbay", order = 1)]
    public class HangarBay : InventoryModule
    {
        
        public override string ModuleType
        {
            get
            {
                return typeof(HangarBay).Name;
            }
        }
       
    }
}