using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RRG.InventorySystem
{
    public class ItemVisualizer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
    {
        public ItemInstance item;

        public Image image;
        public Text amountText;

        public void Instantiate()
        {
           
            
        }

        public void LateUpdate()
        {
            image.sprite = item.item.sprite;
            amountText.text = "" + item.amount + " m3";
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
        }
    }
}