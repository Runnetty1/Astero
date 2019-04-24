using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using InventorySystem.EventSystem;
using InventorySystem.Core;
using UnityEngine.UI;

namespace InventorySystem
{
    public class Slot : MonoBehaviour, IDropHandler
    {

        public Sprite backpackBG;
        public Sprite emptyBG;
        public enum SlotType {INVENTORY,EQUIPMENT,ACCESSORY,HOTBAR};
        public SlotType slotType = SlotType.INVENTORY;

        public GameObject Item
        {
            get
            {
                if (this.transform.childCount > 0)
                {
                    return this.transform.GetChild(transform.childCount - 1).gameObject;
                }
                
                return null;
            }
        }

        public virtual void OnDrop(PointerEventData eventData)
        {
            
            if (Dragable.itemBeingDragged)
            {
                
                if (!Item)
                {
                    
                    Dragable.itemBeingDragged.transform.SetParent(this.transform);
                    Dragable.itemBeingDragged.GetComponent<Item>().state = Dragable.DragState.PLACEABLE;
                    Debug.Log("placed in Empty slot");
                    UpdateFrame();

                }
                else
                {
                    if (transform == Dragable.itemBeingDragged.GetComponent<Item>().startParent)
                    {
                        //Debug.Log("ME-SEPTION! - im placing myself on my parent again");
                        return;
                    }
                    else
                    {
                        if (Item.GetComponent<Item>().HasSameName(Dragable.itemBeingDragged.GetComponent<Item>().itemName) && Item.GetComponent<Item>().isStackable && Dragable.itemBeingDragged.GetComponent<Item>().isStackable && Item.GetComponent<Item>().StackHasSpace(Dragable.itemBeingDragged.GetComponent<Item>().Amount))
                        {
                            //Debug.Log("Im placing myself on a stack");
                            Item.GetComponent<Item>().Amount += Dragable.itemBeingDragged.GetComponent<Item>().Amount;
                            Item.GetComponent<Item>().TextUpdate();
                            Destroy(Dragable.itemBeingDragged);
                        }
                        else if (!Item.GetComponent<Item>().HasSameName(Dragable.itemBeingDragged.GetComponent<Item>().itemName) && Dragable.itemBeingDragged.GetComponent<Item>().state != Dragable.DragState.SPLITDRAG)
                        {
                            //Debug.Log("Different Items switch places");
                            Transform itemParent = transform;//item.transform.parent;
                            Transform dragedParent = Dragable.itemBeingDragged.GetComponent<Item>().startParent;
                            //Debug.Log(itemParent+", "+dragedParent);
                            
                            Item.transform.SetParent(dragedParent);
                            Dragable.itemBeingDragged.transform.SetParent(itemParent);
                            Dragable.itemBeingDragged.GetComponent<Item>().state = Dragable.DragState.IDLE;
                        }else if(Item.GetComponent<Item>().HasSameName(Dragable.itemBeingDragged.GetComponent<Item>().itemName) && !Item.GetComponent<Item>().IsFull)
                        {
                            Debug.Log("is same item, but the one we place on has space to fill");
                            Debug.Log(Dragable.itemBeingDragged.GetComponent<Item>().itemName+", "+ Item.GetComponent<Item>().itemName);
                            Item.GetComponent<Item>().ToppOffWith(Dragable.itemBeingDragged.GetComponent<Item>());
                        }
                        else
                        {
                            //Debug.Log("Not stackable");

                        }
                        UpdateFrame();
                    }
                    UpdateFrame();
                }
                UpdateFrame();
                ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
            }
            UpdateFrame();
        }

        private void Start()
        {
            UpdateFrame();
        }

        public void UpdateFrame()
        {
            if (backpackBG != null && emptyBG != null)
            {
                Dragable.itemBeingDragged.GetComponent<Item>().startParent.GetComponent<Image>().sprite = Dragable.itemBeingDragged.GetComponent<Item>().startParent.GetComponent<Slot>().backpackBG;
                if (this.Item != null)
                {
                    this.GetComponent<Image>().sprite = emptyBG;
                    //this.GetComponent<Image>().sprite = backpackBG;
                    
                }
            }
        }
    }
}