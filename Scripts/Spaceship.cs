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
        //ShipMovement
        //Ship Turrets
        //Ship scanner


        //Test Objects
        public Item item;
        public Item item2;
        public OreBay bay;


        public void Start()
        {
            installedModules.internalModules.Add(OreBay.Instantiate(bay));
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                AddItemToInventory(new ItemInstance(item2, .5));
            }

            if (Input.GetKeyDown(KeyCode.U))
            {
                AddItemToInventory(new ItemInstance(item2, .5));
            }


            if (Input.GetKeyDown(KeyCode.O))
            {
                if (installedModules.internalModules[0] != null)
                {
                    if (installedModules.internalModules[0] is OreBay)
                    {
                        Debug.Log("clearing inventory");

                        ((OreBay)installedModules.internalModules[0]).DropInventory();
                    }

                }
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                Debug.Log("Adding Inventory");
                installedModules.internalModules.Add(OreBay.Instantiate(bay));
            }
        }


        public void AddItemToInventory(ItemInstance item)
        {
            //Not working
            OreBay bay = installedModules.GetOreBayBySpace(installedModules.GetModulesByType(typeof(CargoBay).ToString()),item);
            bay.InsertItem(item);
            //if(item.item is Material)
        }
    }
}