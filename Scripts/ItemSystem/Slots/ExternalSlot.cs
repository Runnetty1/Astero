using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RRG.InventorySystem
{
    [System.Serializable]
    public class ExternalSlot : ModuleSlot
    {
        public enum SpesifficType {any,radar,laser,railgun,kinetic,missile,torpedo }
        public SpesifficType spesifficType;
        public ExternalModule module;
    }
}