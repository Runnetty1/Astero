using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RRG.ControlledObjects;

namespace RRG.InventorySystem
{
    public class ShipModuleView : MonoBehaviour
    {

        public Spaceship spaceship;
        public GameObject modulePanel;
        public GameObject contentObj;
        

        // Start is called before the first frame update
        void Start()
        {
            if (spaceship.installedModules.internalModules != null && spaceship.installedModules.internalModules.Count != 0)
            {
                foreach (InternalModule imod in spaceship.installedModules.internalModules)
                {
                    if (imod != null)
                    {
                        AddModuleView(imod);
                    }
                }
            }
        }

        private void OnEnable()
        {
            ModuleEvents.OnModuleInstall += AddModuleView;
        }

        public void AddModuleView(Module mod)
        {
            if(mod != null)
            {
                if (mod is InternalModule)
                {
                    GameObject module = (GameObject)Instantiate(modulePanel, contentObj.transform.position, Quaternion.identity, contentObj.transform);
                    module.GetComponent<InventoryView>().internalModule = mod as InternalModule;
                    module.GetComponent<InventoryView>().Instantiate();
                }
            }
        }
        public void RemoveModuleView()
        {

        }
    }
}