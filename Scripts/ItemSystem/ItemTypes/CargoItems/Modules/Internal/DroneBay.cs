using Scripts.ItemSystem.ItemTypes.CargoItems.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Modules.Internal
{
    [CreateAssetMenu(fileName = "DroneBay", menuName = "Astero/Item/Modules/Internal/DroneBay", order = 1)]
    class DroneBay : InternalModule
    {
        public override string ModuleType
        {
            get
            {
                return typeof(DroneBay).Name;
            }
        }
    }
}
