using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RRG.InventorySystem;
using System;

namespace RRG.ControlledObjects
{
    [System.Serializable]
    public class Spaceship : MonoBehaviour
    {
        public InstalledModules installedModules;
        //ShipMovement
        //Ship Turrets
        //Ship scanner


        //Test Objects
        public Item item;
        public Item item2;
        public OreBay bay;
        public CargoBay bay2;


        public void Start()
        {
            //installedModules.internalModules.Add(OreBay.Instantiate(bay));
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.I) )
            {
                AddItemToInventory(new ItemInstance(item, .5),true);
            }

            if (Input.GetKeyDown(KeyCode.U))
            {
                AddItemToInventory(new ItemInstance(item2, 5.5),true);
            }


            if (Input.GetKeyDown(KeyCode.O))
            {
                if (installedModules.internalModules != null && installedModules.internalModules.Count>0)
                {
                    if (installedModules.internalModules[0] is OreBay)
                    {
                        Debug.Log("clearing inventory");

                        ((OreBay)installedModules.internalModules[0]).DropInventory();
                    }

                }
                else
                {
                    Debug.LogError("Theres no inventory to drop.");
                }
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                
                installedModules.InstallModule(OreBay.Instantiate(bay));
            }
            if (Input.GetKeyDown(KeyCode.L))
            {

                installedModules.InstallModule(CargoBay.Instantiate(bay2));
            }
        }

        public bool AddItemToInventory(ItemInstance item,bool useStack)
        {
            //Not working
            if (installedModules.internalModules.Count != 0 && installedModules.internalModules != null)
            {
                Debug.Log("AddItemToInventory: trying to add item to inventory");
                installedModules.AddItemToAInternalInventoryModule(item, useStack);
                return true;
            }
            //if(item.item is Material)
            Debug.LogError("Ship has no inventory, please add one.");
            return false;
        }
    }
}