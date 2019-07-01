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


        //Debug inputs for the inventorySystem
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {

            }
                if (Input.GetKeyDown(KeyCode.I) )
            {
                installedModules.AddItemToAInternalInventoryModule(new ItemInstance(item, .5),true);
            }

            if (Input.GetKeyDown(KeyCode.U))
            {
                installedModules.AddItemToAInternalInventoryModule(new ItemInstance(item2, 5.5),true);
            }


            if (Input.GetKeyDown(KeyCode.O))
            {
                if (installedModules.internalModules != null && installedModules.internalModules.Count>0)
                {
                    if (installedModules.internalModules[0] is OreBay)
                    {
                        Debug.Log("clearing inventory");

                        ((OreBay)installedModules.internalModules[0]).RemoveInventory();
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

        public void AddItem(ItemInstance item,bool useStack)
        {
            installedModules.AddItemToAInternalInventoryModule(item,useStack);
        }
    }
}