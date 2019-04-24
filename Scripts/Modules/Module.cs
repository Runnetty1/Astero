using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RRG.ControlledObjects
{
    public class Module : ScriptableObject, IModule
    {
        
        [SerializeField]
        private string moduleName;
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
        public string ModuleName
        {
            get
            {
                return moduleName;
            }

            set
            {
                moduleName = value;
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
