using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RRG.InventorySystem
{
    public class Module : Item, IModule
    {
        [SerializeField]
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
