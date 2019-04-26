using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RRG.InventorySystem
{
    [CreateAssetMenu(fileName = "Cargobay", menuName = "Astero/Item/Modules/Internal/Cargobay", order = 1)]
    public class CargoBay : InternalModule
    {
        public CargoBay()
        {

        }

        public override string ModuleType
        {
            get
            {
                return typeof(CargoBay).Name;
            }
        }
    }
}