using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RRG.InventorySystem
{
    public interface IModule {
        int ModuleSize { get; set; }
        string ModuleType { get; }
    }
}

