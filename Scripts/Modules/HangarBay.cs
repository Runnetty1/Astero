using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RRG.ControlledObjects
{
    [CreateAssetMenu(fileName = "Hangarbay", menuName = "Astero/Modules/Internal/Hangarbay", order = 1)]
    public class HangarBay : Module
    {
        public HangarBay ()
        {

        }

        public override string ModuleType
        {
            get
            {
                return typeof(HangarBay).Name;
            }
        }
    }
}