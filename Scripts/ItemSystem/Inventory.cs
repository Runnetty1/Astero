
using Assets.Scripts.Data;
using Assets.Scripts.ItemSystem.Events;
using Assets.Scripts.ItemSystem.ItemTypes.CargoItems;
using Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Turret;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ItemSystem
{
    [System.Serializable]
    public class Inventory : MonoBehaviour
    {
        
        public double defMaxSize;
        public double addedMaxSize;

        private double currentInventorySize;

        public delegate void InventoryUpdate(Inventory inv);
        public static event InventoryUpdate OnInventoryUpdate;

        public void InventoryUpdateEvent(Inventory inv) => OnInventoryUpdate?.Invoke(this);

        public delegate void NoSpaceForNewItem(ItemInstance item);
        public static event NoSpaceForNewItem OnInventoryFull;

        public void NoSpaceForNewItemEvent(ItemInstance item) => OnInventoryFull?.Invoke(item);

        /* Inventory START */
        [SerializeField]
        private List<ItemInstance> itemList;

        public List<ItemInstance> ItemList
        {
            get => itemList; set
            {
                itemList = value;
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

        public virtual void OnEnable()
        {
            ItemEvents.OnItemPickup += ItemPickupCheck;
            AttributeEvents.OnAttributeChanged += AttributeEvents_OnAttributeChanged;
        }

        public virtual void AttributeEvents_OnAttributeChanged(ActorData ship)
        {
            if(ship != this.GetComponent<ActorData>())
            {
                return;
            }
        }

        public virtual void OnDisable()
        {
            ItemEvents.OnItemPickup -= ItemPickupCheck;
        }

        public virtual void ItemPickupCheck(ItemInstance item,GameObject owner)
        {
            if (owner == this.gameObject)
            {
                AddItem(item, true);
                OnInventoryUpdate?.Invoke(this);
            }
        }

        public virtual void AddItem(ItemInstance item, bool useStack)
        {
            OnInventoryUpdate?.Invoke(this);
            if (HasSpace(item.amount))
            {              
                if (useStack && ItemList.Count >= 0)
                {

                    if (HasSameName(item.item.itemName))
                    {
                        GetItemByName(item.item.itemName).amount += item.amount;
                    }
                    else
                    {
                        ItemList.Add(item);
                    }
                }
                else
                {
                    ItemList.Add(item);
                }
            }
            else
            {
                //error: No Space
                Debug.Log("Not enough space in inventory");
                NoSpaceForNewItemEvent(item);
                
            }
        }


        public void RemoveInstalledItem(Module mod,ActorData ship)
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

        public void RemoveInstalledItem(TurretItem turret, ActorData ship)
        {
            List<ItemInstance> t = GetInventory();
            for (int i = 0; i < t.Count; i++)
            {
                ItemInstance item = t[i];
                if (item.item == turret)
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