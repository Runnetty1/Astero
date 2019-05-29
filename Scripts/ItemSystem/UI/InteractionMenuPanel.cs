using RRG.ControlledObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace RRG.InventorySystem
{
    public class InteractionMenuPanel : MonoBehaviour
    {
        public Transform panel;
        public Button Install;
        public Button Drop;
        public Button Split;
        public InputField splitInput;
        public Slider splitSlider;
        

        public ItemInstance item;
        public Vector2 offset;

        public Spaceship ship;

        private void OnEnable()
        {
            ItemEvents.OnItemRightClick += ShowMenu;
        }

        public void ShowMenu(ItemInstance item,Vector2 pos)
        {
            panel.gameObject.SetActive(true);
            this.transform.position = pos+offset;
            this.item = item;
        }

        public void SplitStack()
        {
            
            ItemInstance split = new ItemInstance(item.item,item.amount/2);
            item.amount /= 2;
            ship.AddItemToInventory(split,false);
            Debug.Log("split button clicked");
        }

        public void DropItem()
        {
            new ItemEvents().ItemDropedEvent(item);
        }

        
    }
}