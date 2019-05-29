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
        [HideInInspector]
        public double currentInventorySize;

        /* Inventory START */
        //[HideInInspector]
        public List<ItemInstance> inventory;

        private void OnEnable()
        {
            ItemEvents.OnItemDrop += DropItem;
            inventory = new List<ItemInstance>();
        }
        private void OnDisable()
        {
            ItemEvents.OnItemDrop -= DropItem;
        }

        public List<ItemInstance> GetInventory()
        {
            return inventory;
        }


        // Insert an item, return the index where it was inserted.  -1 if error.
        public bool InsertItem(ItemInstance item,bool useStack)
        {
            if (HasSpace(item.amount))
            {
                Debug.Log("theres space for item");
                if (GetItemOfSameName(item.item.itemName) != null && inventory.Count>0)
                {
                    if (useStack)
                    {
                        Debug.Log("Placing item on stack");
                        GetItemOfSameName(item.item.itemName).amount += item.amount;
                        new ItemEvents().ItemMergedEvent(item);
                    }
                    else
                    {
                        Debug.Log("Added item as seperate object");
                        inventory.Add(item);
                        new ItemEvents().ItemAddedEvent(item);
                    }
                }
                else
                {
                    inventory.Add(item);
                    new ItemEvents().ItemAddedEvent(item);
                    Debug.Log("Added new item");
                }
                UpdateInventorySize();
                
                return true;
            }
            Debug.LogError("No Space for item");
            // Couldn't find a free slot.
            return false;
        }

        public bool HasSpace(double amount)
        {
            if (amount + currentInventorySize > maxInventorySize)
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
        
        public void DropItem(ItemInstance item)
        {
            if (inventory.Contains(item))
            {
                //Drop Item as physical cargo
                Debug.Log("Droping: "+item.item.itemName);

                //remove item from list
                inventory.Remove(item);
                UpdateInventorySize();
            }
        }

    }
}