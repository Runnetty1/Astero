﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RRG.InventorySystem
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