
using Assets.Scripts.ActorControllers;
using Assets.Scripts.Data;
using Assets.Scripts.ItemSystem.Events;
using Assets.Scripts.ItemSystem.ItemTypes.CargoItems;
using Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Turret;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.ItemSystem.UI
{
    public class InteractionMenuPanel : MonoBehaviour
    {
        public Transform panel;
        public Transform splitPanel;
        public Button Install;
        public Button Uninstall;
        public Button Drop;
        public Button Split;
        public InputField splitInput;
        public Slider splitSlider;


        public ItemInstance item;
        public Vector2 offset;

        public ActorData ship;

        private void OnEnable()
        {
            ItemEvents.OnItemRightClick += ShowMenu;
            
        }

        public void ShowMenu(ItemInstance item,Vector2 pos,string type)
        {
            panel.gameObject.SetActive(true);
            
            this.item = item;

            Vector2 mousePos = Input.mousePosition;
            this.transform.position = mousePos + offset;
            if(type=="moduleView" || type=="turretView")
            {
                Install.gameObject.SetActive(false);
                Uninstall.gameObject.SetActive(true);
            }
            else
            {
                Install.gameObject.SetActive(true);
                Uninstall.gameObject.SetActive(false);
            }
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

        public void InstallToShip()
        {
            if (item.item is Module)
            {
                ship.GetComponent<ModuleUpgradeMaster>().InstallModule(item.item as Module, ship);
            }
            if(item.item is TurretItem)
            {
                ship.GetComponent<TurretMaster>().InstallTurret(item.item as TurretItem, ship);
            }
            HidePanel();
        }

        public void UninstallItem()
        {
            if (item.item is Module)
            {
                new ModuleEvents().ModuleUninstallEvent(item.item as Module);
            }
            if (item.item is TurretItem)
            {
                new TurretEvents().TurretUninstallEvent(item.item as TurretItem);
                
            }
            
            HidePanel();
        }


    }
}