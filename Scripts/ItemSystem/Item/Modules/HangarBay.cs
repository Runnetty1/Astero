using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RRG.InventorySystem
{
    [CreateAssetMenu(fileName = "Hangarbay", menuName = "Astero/Item/Modules/Internal/Hangarbay", order = 1)]
    public class HangarBay : InternalModule
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