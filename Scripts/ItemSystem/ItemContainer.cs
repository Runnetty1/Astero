using Assets.Scripts.ItemSystem.Events;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.ItemSystem
{
    public class ItemContainer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public ItemInstance item;
        public Image itemImg;

        private void Start()
        {
            if (item != null)
            {
                itemImg.sprite = item.item.sprite;
            }
        }


        public void AddItem(ItemInstance ite)
        {
            item = ite;
            itemImg.sprite = ite.item.sprite;
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Item")
            {
                if (collision.GetComponent<ItemContainer>().item.item.itemName == item.item.itemName)
                {
                    item.amount += collision.GetComponent<ItemContainer>().item.amount;
                    Destroy(collision.gameObject);
                }
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("enter");
            new ItemEvents().ItemHoverEvent(item);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            new ItemEvents().ItemStopedHoverEvent();
        }
    }
}
