using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RRG.InventorySystem
{
    public class ItemVisualizer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public Item item;

        public Image image;
        public Text amountText;

        public void Instantiate()
        {
            image.sprite = item.sprite;
            amountText.text = ""+item.amount+" m3";
            
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            new ItemEvents().ItemHoverEvent(item);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            new ItemEvents().ItemStopedHoverEvent();
        }
    }
}