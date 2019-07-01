using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RRG.InventorySystem
{
    [System.Serializable]
    public class InternalSlot : ModuleSlot
    {
        public enum SpesifficType {any,shield,cargo,ore,hangar,factory,prosessor}
        public SpesifficType spesifficType;
        public InternalModule module;
    }
}