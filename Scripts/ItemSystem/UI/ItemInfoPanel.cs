using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RRG.InventorySystem
{
    public class ItemInfoPanel : MonoBehaviour
    {
        public Vector2 mouseOffset;

        public Text nameBox,Desc,Amount,rarity;
        public GameObject visualizer;
        public ItemInstance visualItem;

        private void OnEnable()
        {
            ItemEvents.OnItemHover += VisualizeItem;
            ItemEvents.OnItemStopHover += HideVisualizeItem;
        }

        private void HideVisualizeItem()
        {
            visualizer.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            ItemEvents.OnItemHover -= VisualizeItem;
            ItemEvents.OnItemStopHover -= HideVisualizeItem;
        }

        public void VisualizeItem(ItemInstance item)
        {
            if(item == visualItem)
            {
                visualizer.gameObject.SetActive(true);
            }
            else
            {
                visualItem = item;
                nameBox.text = item.item.itemName;
                Desc.text = item.item.description;
                Amount.text = ""+item.amount+" m3";
                rarity.text = "" + item.item.rarity;
                visualizer.gameObject.SetActive(true);
            }
        }

        private void Update()
        {
            var screenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            

            Vector2  mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = mousePos+mouseOffset;
        }
    }
}