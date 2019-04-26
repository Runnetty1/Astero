using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RRG.InventorySystem
{
    public interface IModule {
        int maxModuleSize { get; set; }
        string ModuleType { get; }
    }
}

