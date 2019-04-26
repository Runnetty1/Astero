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
            foreach(InternalModule  imod in spaceship.installedModules.internalModules)
            {
                
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}