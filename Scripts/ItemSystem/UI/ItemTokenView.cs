using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RRG.InventorySystem
{
    public class ItemTokenView : MonoBehaviour
    {
        public Transform itemView;
        public static ItemInstance ite;
        public static InventoryModule parentMod;
        public static bool spliting;
        public Vector2 offset;

        private void OnEnable()
        {
            ItemVisualizer.OnItemDrag += SetItemView;
            ItemVisualizer.OnItemDragStop += HideItemView;
        }


        public void SetItemView(ItemInstance item,InventoryModule modParent,bool splitting)
        {
            itemView.GetComponent<ItemVisualizer>().item = item;
            ite = item;
            parentMod = modParent;
            itemView.gameObject.SetActive(true);
        }

        public void HideItemView()
        {
            itemView.gameObject.SetActive(false);
        }

        private void Update()
        {
            var screenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = mousePos + offset;
        }
    }
}