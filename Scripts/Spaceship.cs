using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RRG.InventorySystem;

namespace RRG.ControlledObjects
{
    [System.Serializable]
    public class Spaceship : MonoBehaviour
    {
        public InstalledModules installedModules;
        public Item toAdd;
        //Eventually move Ship Controll here;
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (installedModules.internalModules[0] != null)
                {
                    if (installedModules.internalModules[0] is OreBay)
                    {
                        ((OreBay)installedModules.internalModules[0]).Ores.Add(toAdd);
                    }

                }
            }
        }
    }
}