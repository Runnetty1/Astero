using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

namespace RRG.InventorySystem
{
    [System.Serializable]
    public class InventoryModule : InternalModule
    {
        public double maxInventorySize;
        public double currentInventorySize;
        
        /* Inventory START */
        public List<ItemInstance> inventory;


        // Insert an item, return the index where it was inserted.  -1 if error.
        public bool InsertItem(ItemInstance item)
        {
            if (HasSpace(item))
            {
                Debug.Log("Has space");
                if (GetItemOfSameName(item.item.itemName) != null && inventory.Count>0)
                {
                    Debug.Log("Has same item. Merging");
                    GetItemOfSameName(item.item.itemName).amount += item.amount;
                }
                else
                {
                    Debug.Log("no such item in inventory");
                    inventory.Add(item);
                }
                UpdateInventorySize();
                
                return true;
            }
            Debug.Log("No Space for item");
            // Couldn't find a free slot.
            return false;
        }

        public bool HasSpace(ItemInstance item)
        {
            if (item.amount + currentInventorySize > maxInventorySize)
            {
                return false;
            }
            return true;
        }
       

        public ItemInstance GetItemOfSameName(string name)
        {
            foreach(ItemInstance a in inventory)
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
            currentInventorySize = 0;
            foreach (ItemInstance a in inventory)
            {
                currentInventorySize += a.amount;
            }
        }

        public void DropInventory()
        {
            if (inventory.Count != 0)
            {
                for (int i = 0; i <= inventory.Count; i++)
                {
                    inventory.RemoveAt(0);
                }
            }
            UpdateInventorySize();
        }
        
    }
}