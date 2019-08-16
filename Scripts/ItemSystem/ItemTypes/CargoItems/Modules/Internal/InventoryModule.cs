using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;
using System;

namespace Scripts.ItemSystem.ItemTypes.CargoItems.Modules.Internal
{
    [System.Serializable]
    public abstract class InventoryModule : InternalModule
    {
        public double sizeUpgrade;

        public override string ModuleType
        {
            get
            {
                return typeof(InternalModule).Name;
            }
        }
    }
}