using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RRG.InventorySystem
{
    [System.Serializable]
    public class InstalledModules {

        public int maxInternalModules;
        public int maxExternalModules;

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

        public OreBay GetOreBayBySpace(double amount)
        {
            foreach(InternalModule mod in internalModules)
            {
                if(mod is OreBay)
                {
                    if((mod as OreBay).HasSpace(amount))
                    {
                        return mod as OreBay;
                    }
                }
            }
            return null;
        }
        public CargoBay GetCargoBayBySpace(double amount)
        {
            foreach (InternalModule mod in internalModules)
            {
                if (mod is CargoBay)
                {
                    if ((mod as CargoBay).HasSpace(amount))
                    {
                        return mod as CargoBay;
                    }
                }
            }
            return null;
        }

        public bool InstallModule(Module module)
        {
            string error = "";
            if(module is InternalModule)
            {
                if (internalModules.Count < maxInternalModules)
                {
                    internalModules.Add(module as InternalModule);
                    Debug.Log("Added internal Module: "+module.itemName);
                    new ModuleEvents().ModuleInstallEvent(module);
                    return true;
                }
                else
                {
                    error = "Max Amount of Internal Modules, max: "+maxInternalModules;
                }
            }
            if(module is ExternalModule)
            {
                if (externalModules.Count < maxExternalModules)
                {
                    externalModules.Add(module as ExternalModule);
                    Debug.Log("Added internal Module: " + module.itemName);
                    new ModuleEvents().ModuleInstallEvent(module);
                    return true;
                }
                else
                {
                    error = "Max Amount of External Modules, max: "+maxExternalModules;
                }
            }

            Debug.LogError("Unable to Install: "+module.itemName+", Reason: "+error);
            return false;
        }

        public bool AddItemToAInternalInventoryModule(ItemInstance item,bool useStack)
        {
            if (item.item is Ore)
            {
                OreBay bay = GetOreBayBySpace(item.amount);
                if (bay != null)
                {
                    bay.InsertItem(item,useStack);
                }
            }

            if ((item.item is CargoItem))
            {
                CargoBay bay = GetCargoBayBySpace(item.amount);
                if (bay != null)
                {
                    bay.InsertItem(item,useStack);
                }
            }
            return false;
        }
    }
}
