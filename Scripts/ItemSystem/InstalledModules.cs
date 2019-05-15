using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RRG.InventorySystem
{
    [System.Serializable]
    public class InstalledModules {


        public List<InternalModule> internalModules;
        public List<ExternalModule> externalModules;


        public List<InternalModule> GetModulesByType(string type)
        {
            List<InternalModule> list = new List<InternalModule>();
            foreach(InternalModule mod in internalModules)
            {
                if(mod.ModuleType == type)
                {
                    list.Add(mod);
                }
            }
            return list;
        }

        public OreBay GetOreBayBySpace(List<InternalModule> mods,ItemInstance item)
        {
            foreach(InternalModule mod in mods)
            {
                if(mod is OreBay)
                {
                    if((mod as OreBay).HasSpace(item))
                    {
                        return mod as OreBay;
                    }
                }
            }
            return null;
        }
        public CargoBay GetCargoBayBySpace(List<InternalModule> mods, ItemInstance item)
        {
            foreach (InternalModule mod in mods)
            {
                if (mod is CargoBay)
                {
                    /*
                    if ((mod as CargoBay).HasSpace(item))
                    {
                        return mod as CargoBay;
                    }
                    */
                }
            }
            return null;
        }
    }
}
