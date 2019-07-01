using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;
using System;

namespace RRG.InventorySystem
{
    [System.Serializable]
    public abstract class InventoryModule : InternalModule
    {
        public double maxInventorySize;
        //[HideInInspector]
        private double currentInventorySize;

        /* Inventory START */
        //[HideInInspector]
        private List<ItemInstance> inventory;

        public List<ItemInstance> Inventory
        {
            get => inventory; set
            {
                inventory = value;
                OnModuleUpdate?.Invoke(this);
            }
        }

        public double CurrentInventorySize
        {
            get => currentInventorySize; set
            {
                currentInventorySize = value;
                OnModuleUpdate?.Invoke(this);
            }
        }

        public List<ItemInstance> GetInventory()
        {
            return Inventory;
        }

        public virtual void AddItem(ItemInstance item,bool useStack)
        {
            UpdateInventorySize();
            if (HasSpace(item.amount))
            {
                Debug.Log("Has Space so i continue");
                if (useStack && Inventory.Count > 0)
                {
                    GetItemByName(item.item.itemName).amount += item.amount;
                }
                else
                {
                    Inventory.Add(item);
                }
                UpdateInventorySize();
            }
            else
            {
                //error: No Space
                Debug.Log("Not enough space in inventory");
            }
        }

        public virtual void MergeItem(ItemInstance item)
        {

        }


        public delegate void InventoryModuleUpdate(InventoryModule module);
        public static event InventoryModuleUpdate OnModuleUpdate;

        //public void ModuleUpdate(InventoryModule module) => OnModuleUpdate?.Invoke(this);

        private void OnEnable()
        {
            Inventory = new List<ItemInstance>();
            ItemEvents.OnItemRemoved += RemoveItem;
        }
        
        public bool HasSpace(double amount)
        {
            if ((amount + CurrentInventorySize) > maxInventorySize)
            {
                return false;
            }
            return true;
        }
       
        public ItemInstance GetItemByName(string name)
        {
            foreach(ItemInstance a in Inventory)
            {
                if(a.item.itemName == name)
                {
                    return a;
                }
            }
            return null;
        }

        public void UpdateInventorySize()
        {
            double t = 0;

            foreach (ItemInstance a in Inventory)
            {
                t += a.amount;
            }

            CurrentInventorySize = t;
        }

        internal bool HasItem(ItemInstance ite)
        {
            foreach (ItemInstance a in Inventory)
            {
                if (a == ite)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasSameName(string s)
        {
            if (GetItemByName(s)!=null)
            {
                return true;
            }
            return false;

        }

        public void RemoveInventory()
        {
            if (Inventory.Count != 0)
            {
                for (int i = 0; i <= Inventory.Count; i++)
                {
                    Inventory.RemoveAt(0);
                }
            }
            UpdateInventorySize();
        }
        
        public void RemoveItem(ItemInstance item)
        {
            if (Inventory.Contains(item))
            {
                //Drop Item as physical cargo
                Debug.Log("Droping: "+item.item.itemName);

                //remove item from list
                Inventory.Remove(item);
                UpdateInventorySize();
            }
        }

    }
}