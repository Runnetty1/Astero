using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.ItemSystem.ItemTypes.CargoItems.Modules.Internal
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
        

    }
}