using Scripts.ControlledObjects;
using Scripts.ItemSystem.Events;
using Scripts.ItemSystem.ItemTypes.CargoItems;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.ItemSystem.UI
{
    public class InteractionMenuPanel : MonoBehaviour
    {
        public Transform panel;
        public Transform splitPanel;
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
            
            this.item = item;

            var screenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.DrawLine(screenPos, transform.position);

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = mousePos + offset;
        }

        public void SplitStack()
        {
            //Splitting  a item makes it fall into another inventory...
            ItemInstance split = new ItemInstance(item.item,item.amount/2);
            item.amount /= 2;
            
            //ship.installedModules.AddItemToAInternalInventoryModule(split,false);
            Debug.Log("split button clicked");
            HidePanel();
        }

        public void DropItem()
        {
            new ItemEvents().ItemRemovedEvent(item);
            HidePanel();
        }

        

        public void HidePanel()
        {
            panel.gameObject.SetActive(false);
            splitPanel.gameObject.SetActive(false);
        }

        public void InstallModuleToShip()
        {
            ship.InstallModule(item.item as Module,0);
            HidePanel();
        }


    }
}