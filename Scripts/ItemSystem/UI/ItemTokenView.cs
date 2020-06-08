using Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Modules;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ItemSystem.UI
{
    public class ItemTokenView : MonoBehaviour
    {
        public Transform itemView;
        public static ItemInstance ite;
        public static Inventory parentMod;
        public static bool spliting;
        public Vector2 offset;

        private void OnEnable()
        {
            ItemVisualizer.OnItemDrag += SetItemView;
            ItemVisualizer.OnItemDragStop += HideItemView;
        }


        public void SetItemView(ItemInstance item,Inventory modParent,bool splitting)
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
            Vector2 mousePos = Input.mousePosition;
            this.transform.position = mousePos + offset;
        }
    }
}