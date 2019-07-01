using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RRG.InventorySystem
{
    [System.Serializable]
    public class Inventory
    {
        
        public double defMaxSize;
        public double addedMaxSize;
        private double currentInventorySize;

        /* Inventory START */
        //[HideInInspector]
        private List<ItemInstance> itemList;

        public List<ItemInstance> ItemList
        {
            get => itemList; set
            {
                itemList = value;
               OnInventoryUpdate?.Invoke(this);
            }
        }

        public double CurrentInventorySize
        {
            get => currentInventorySize; set
            {
                currentInventorySize = value;
               OnInventoryUpdate?.Invoke(this);
            }
        }

        public List<ItemInstance> GetInventory()
        {
            return ItemList;
        }

        public virtual void AddItem(ItemInstance item, bool useStack)
        {
            UpdateInventorySize();
            if (HasSpace(item.amount))
            {
                
                if (useStack && ItemList.Count > 0)
                {
                    GetItemByName(item.item.itemName).amount += item.amount;
                }
                else
                {
                    ItemList.Add(item);
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


        public delegate void InventoryModuleUpdate(Inventory inv);
        public static event InventoryModuleUpdate OnInventoryUpdate;

        //public void ModuleUpdate(InventoryModule module) => OnModuleUpdate?.Invoke(this);

        private void OnEnable()
        {
            ItemList = new List<ItemInstance>();
            ItemEvents.OnItemRemoved += RemoveItem;
        }

        public bool HasSpace(double amount)
        {
            /*
            if ((amount + CurrentInventorySize) > maxInventorySize)
            {
                return false;
            }*/
            return true;
        }

        public ItemInstance GetItemByName(string name)
        {
            foreach (ItemInstance a in ItemList)
            {
                if (a.item.itemName == name)
                {
                    return a;
                }
            }
            return null;
        }

        public void UpdateInventorySize()
        {
            double t = 0;

            foreach (ItemInstance a in ItemList)
            {
                t += a.amount;
            }

            CurrentInventorySize = t;
        }

        internal bool HasItem(ItemInstance ite)
        {
            foreach (ItemInstance a in ItemList)
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
            if (GetItemByName(s) != null)
            {
                return true;
            }
            return false;

        }

        public void RemoveInventory()
        {
            if (ItemList.Count != 0)
            {
                for (int i = 0; i <= ItemList.Count; i++)
                {
                    ItemList.RemoveAt(0);
                }
            }
            UpdateInventorySize();
        }

        public void RemoveItem(ItemInstance item)
        {
            if (ItemList.Contains(item))
            {
                //Drop Item as physical cargo
                Debug.Log("Droping: " + item.item.itemName);

                //remove item from list
                ItemList.Remove(item);
                UpdateInventorySize();
            }
        }


    }
}