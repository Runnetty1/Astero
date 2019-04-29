using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RRG.InventorySystem
{
    
    [CreateAssetMenu(fileName = "Orebay", menuName = "Astero/Item/Modules/Internal/Orebay", order = 1)]
    public class OreBay : InternalModule
    {
        public double maxInventorySize;
        public double currentInventorySize;

        public List<Item> Ores;

        public override string ModuleType
        {
            get
            {
                return typeof(OreBay).Name;
            }
        }

        public bool hasSpace(double amount)
        {
            if ((currentInventorySize + amount) > maxInventorySize)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void AddToOreOfSameType() {

        }
    }
}