using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RRG.InventorySystem
{
    [System.Serializable]
    public class Module : Item, IModule
    {
        
        private int moduleSize;
    
        public int ModuleSize
        {
            get
            {
                return moduleSize;
            }

            set
            {
                moduleSize = value;
            }
        }
        
        public virtual string ModuleType
        {
            get
            {
                return typeof(Module).Name;
            }
        }

    }
}
