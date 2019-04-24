using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using InventorySystem.EventSystem;
using InventorySystem.Core;
using System;


namespace InventorySystem
{
    public class Inventory : MonoBehaviour, IHasChanged
    {
        [SerializeField]
        public List<Item> itemList;

        public Transform slotHolder;
        public int maxInventorySize;

        public EquipmentPanel equipment;
        public AccessoryPanel accessory;
        public HotbarPanel hotbar;

        private void Start()
        {
            //fill slots from save?

            HasChanged();
        }

        public void HasChanged()
        {
            itemList.Clear();
            foreach (Transform slot in slotHolder)
            {
                GameObject item = slot.GetComponent<Slot>().Item;
                if (item)
                {
                    itemList.Add(slot.GetComponent<Slot>().Item.GetComponent<Item>());
                }
            }
            //Debug.Log("has changed");
        }

        public bool AddItem(Item item)
        {
            foreach (Transform slot in slotHolder)
            {
                GameObject itemInSlot = slot.GetComponent<Slot>().Item;
                if (!itemInSlot)
                {
                    item.transform.SetParent(slot.transform);
                    ExecuteEvents.ExecuteHierarchy<IHasChanged>(this.gameObject, null, (x, y) => x.AddedItem());
                    return true;
                }
                else if (itemInSlot.GetComponent<Item>().itemName == item.itemName && itemInSlot.GetComponent<Item>().StackHasSpace(item.Amount))
                {
                    itemInSlot.GetComponent<Item>().AddToStack(item);
                    ExecuteEvents.ExecuteHierarchy<IHasChanged>(this.gameObject, null, (x, y) => x.AddedItem());
                    return true;
                }
            }

            throw new EventSystem.Event(EventSystem.Event.InventoryFull());
            
        }

        void IHasChanged.AddedItem()
        {
            HasChanged();
        }

        public void RemoveSpecifficItem(Item item)
        {
            Destroy(item.gameObject);
            ExecuteEvents.ExecuteHierarchy<IHasChanged>(this.gameObject, null, (x, y) => x.RemovedItem());
        }

        public void RemoveOneItemFromStackItem(Item item)
        {
            if ((item.Amount -1)==0)
            {
                Destroy(item.gameObject);
                ExecuteEvents.ExecuteHierarchy<IHasChanged>(this.gameObject, null, (x, y) => x.RemovedItem());
            }
            else
            {
                item.Amount--;
                ExecuteEvents.ExecuteHierarchy<IHasChanged>(this.gameObject, null, (x, y) => x.RemovedItem());
            }
        }
        public void RemoveItemAmountFromStackItem(Item item, int amount)
        {
            if ((item.Amount - amount) <= 0)
            {
                Destroy(item.gameObject);
                ExecuteEvents.ExecuteHierarchy<IHasChanged>(this.gameObject, null, (x, y) => x.RemovedItem());
            }
            else
            {
                item.Amount-= amount;
                ExecuteEvents.ExecuteHierarchy<IHasChanged>(this.gameObject, null, (x, y) => x.RemovedItem());
            }
        }
        void IHasChanged.RemovedItem()
        {
            HasChanged();
            //throw new NotImplementedException();
        }
    }

}



namespace InventorySystem.EventSystem
{
    public interface IHasChanged : IEventSystemHandler
    {
        void HasChanged();
        void AddedItem();
        void RemovedItem();
    }
}
