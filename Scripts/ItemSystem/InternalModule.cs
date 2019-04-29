using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RRG.InventorySystem
{
    [System.Serializable]
    public class InternalModule : Module
    {
        public override string ModuleType
        {
            get
            {
                return typeof(InternalModule).Name;
            }
        }
    }
}