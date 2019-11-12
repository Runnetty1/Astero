using Scripts.ItemSystem.Events;
using Scripts.ItemSystem.ItemTypes.CargoItems.Modules;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Scripts.ItemSystem.UI
{
    public class ItemVisualizer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
    {
        public ItemInstance item;

        public Image image;
        public Text amountText;

        public bool canDrag;

        public void Instantiate()
        {
            if (item != null)
            {
                //U+00B3 = small 3
                image.sprite = item.item.sprite;
                amountText.text = "" + item.amount + " m3";
            }

        }

        //This should not be updated often
        public void LateUpdate()
        {
            if (item != null)
            {
                image.sprite = item.item.sprite;
                amountText.text = "" + item.amount + " m3";
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            new ItemEvents().ItemHoverEvent(item);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            new ItemEvents().ItemStopedHoverEvent();
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                Debug.Log("Right Mouse Button Clicked on: " + item.item.itemName);
                new ItemEvents().ItemRightClickEvent(item,this.transform.position);
            }
            if(eventData.button == PointerEventData.InputButton.Left)
            {
                if (eventData.clickCount == 2)
                {
                    Debug.Log("Using item");
                }
            }
        }

        public delegate void ItemVisualDragStart(ItemInstance item,Inventory inv,bool split);
        public static event ItemVisualDragStart OnItemDrag;

        public void ItemBeginDrag(ItemInstance item, Inventory inv,bool split) => OnItemDrag?.Invoke(item, inv,split);

        public delegate void ItemVisualDragStop();
        public static event ItemVisualDragStop OnItemDragStop;

        public static void ItemDragStop() => OnItemDragStop?.Invoke();

        public void OnBeginDrag(PointerEventData eventData)
        {
            //show item is being draged by aplying alpha
            image.color = new Color(1, 1, 1, 0.5f);
            
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Debug.Log("Spliting");
                ItemInstance it = new ItemInstance(item.item,item.amount/2);
                item.amount /= 2;
                ItemBeginDrag(it, GetComponentInParent<InventoryView>().inventory,true);
            }
            else
            {
                ItemBeginDrag(item, (GetComponentInParent<InventoryView>().inventory),false);
            }  
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            //show item is being draged by aplying alpha
            image.color = new Color(1, 1, 1, 1f);
            ItemDragStop();
            //if item was
            //if()
        }

        public void OnDrag(PointerEventData eventData)
        {
            
        }

        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("dropping on item");
            Debug.Log("this item: " + item.item + ", item dragged: " + ItemTokenView.ite.item);
            /*
            if(item.item.itemName == ItemTokenView.ite.item.itemName)
            {
                //Same Name ok to merge amounts
                //Does this inventory have space?

                (GetComponentInParent<InventoryView>().internalModule as InventoryModule).UpdateInventorySize();
                if ((GetComponentInParent<InventoryView>().internalModule as InventoryModule).HasSpace(ItemTokenView.ite.amount))
                {
                    (GetComponentInParent<InventoryView>().internalModule as InventoryModule).AddItem(ItemTokenView.ite,true);
                    if (!ItemTokenView.spliting)
                    {
                        ItemTokenView.parentMod.RemoveItem(ItemTokenView.ite);
                    }
                    
                }
            }
            else
            {
                Debug.Log("not same item");
                //But we should add it to the inventory
                //Fix that -^
                if((GetComponentInParent<InventoryView>().internalModule as InventoryModule).HasSameName(ItemTokenView.ite.item.itemName))
                {
                    Debug.Log("but has same name, merging");
                    (GetComponentInParent<InventoryView>().internalModule as InventoryModule).AddItem(ItemTokenView.ite, true);
                }
            }
            
            ItemDragStop();
            */
        }
    }
}