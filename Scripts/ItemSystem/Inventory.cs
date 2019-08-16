using Scripts.ItemSystem.Events;
using Scripts.ItemSystem.ItemTypes.CargoItems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.ItemSystem
{
    [System.Serializable]
    public class Inventory
    {
        
        public double defMaxSize;
        public double addedMaxSize;


        private double currentInventorySize;

        public delegate void InventoryUpdate(Inventory inv);
        public static event InventoryUpdate OnInventoryUpdate;

        public void InventoryUpdateEvent(Inventory inv) => OnInventoryUpdate?.Invoke(this);

        /* Inventory START */
        [SerializeField]
        private List<ItemInstance> itemList;

        public List<ItemInstance> ItemList
        {
            get => itemList; set
            {
                itemList = value;
               //OnInventoryUpdate?.Invoke(this);
            }
        }

        public double GetTotalMaxInventorySize()
        {
            return defMaxSize + addedMaxSize;
        }

        public double CurrentInventorySize
        {
            get {
                double t = 0;

                foreach (ItemInstance a in ItemList)
                {
                    t += a.amount;
                }

                currentInventorySize = t;
                return currentInventorySize;
            } set
            {
                currentInventorySize = value;
               
            }
        }

        public List<ItemInstance> GetInventory()
        {
            List<ItemInstance> list = itemList;
            return list;
        }

        public void AddItem(ItemInstance item, bool useStack)
        {
            if (HasSpace(item.amount))
            {
                if (useStack && ItemList.Count > 0)
                {
                    GetItemByName(item.item.itemName).amount += item.amount;
                    OnInventoryUpdate?.Invoke(this);
                }
                else
                {
                    ItemList.Add(item);
                    OnInventoryUpdate?.Invoke(this);
                }
            }
            else
            {
                //error: No Space
                Debug.Log("Not enough space in inventory");
            }
        }


        public void RemoveInstalledModule(Module mod)
        {
            List<ItemInstance> t = GetInventory();
            for (int i = 0; i < t.Count; i++)
            {
                ItemInstance item = t[i];
                if (item.item == mod)
                {
                    t.Remove(item);
                }
            }
            ItemList = t;
            OnInventoryUpdate?.Invoke(this);

        }

        public bool HasSpace(double amount)
        {
            
            if ((amount + CurrentInventorySize) > GetTotalMaxInventorySize())
            {
                return false;
            }
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
        }

        public void RemoveItem(ItemInstance item)
        {
            if (ItemList.Contains(item))
            {
                //Drop Item as physical cargo
                Debug.Log("Droping: " + item.item.itemName);

                //remove item from list
                ItemList.Remove(item);
            }
        }


    }
}