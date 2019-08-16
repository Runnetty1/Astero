using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Scripts.ItemSystem.ItemTypes.CargoItems.Modules
{
    public class ExternalModule : Module
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