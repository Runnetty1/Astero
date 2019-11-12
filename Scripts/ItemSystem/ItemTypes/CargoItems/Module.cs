using Scripts.ItemSystem.Interfaces;
using UnityEngine;

namespace Scripts.ItemSystem.ItemTypes.CargoItems
{
    [System.Serializable]
    public class Module : CargoItem, IModule
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
