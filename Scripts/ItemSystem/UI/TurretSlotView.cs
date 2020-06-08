using Assets.Scripts.ItemSystem.Events;
using Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Turret;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.ItemSystem.UI
{
    public class TurretSlotView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public Image background, foreground, typeImg, image;
        public ItemInstance item;


        public void Instantiate()
        {
            if (item != null)
            {
                if (item.item != null)
                {
                    if (item.item.sprite != null)
                    {
                        image.sprite = item.item.sprite;
                    }
                }
            }

        }

        //This should not be updated often
        public void LateUpdate()
        {
            if (item != null)
            {
                if (item.item != null)
                {
                    if (item.item.sprite != null)
                    {
                        image.sprite = item.item.sprite;
                        foreground.color = new Color(255f, 255f, 255f);
                    }
                }
            }
            else
            {
                foreground.color = new Color(128f, 128f, 128f);
            }

        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (item != null)
            {
                if (item.item != null)
                {
                    new ItemEvents().ItemHoverEvent(item);
                }
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (item != null)
            {
                if (item.item != null)
                {
                    new ItemEvents().ItemStopedHoverEvent();
                }
            }
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            if (item != null)
            {
                if (item.item != null)
                {
                    if (eventData.button == PointerEventData.InputButton.Right)
                    {
                        //Debug.Log("Right Mouse Button Clicked on: " + item.item.itemName);
                        new ItemEvents().ItemRightClickEvent(item, this.transform.position, "turretView");
                    }
                    if (eventData.button == PointerEventData.InputButton.Left)
                    {
                        if (eventData.clickCount == 2)
                        {
                            if (item.item is TurretItem)
                            {
                                new TurretEvents().TurretUninstallEvent(item.item as TurretItem);
                            }


                            //transform.parent.parent.parent.parent.GetComponent<ShipSystemsView>().master.gameObject.GetComponent<ModuleUpgradeMaster>().UninstallModule(item.item as Module);
                            item = null;
                            Instantiate();
                        }
                    }
                }
            }
        }

    }
}
