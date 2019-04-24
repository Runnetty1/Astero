using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RRG.ControlledObjects {
    public interface IModule {
        string ModuleName { get; set; }
        int ModuleSize { get; set; }
        string ModuleType { get; }
    }
}

