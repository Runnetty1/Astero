using Assets.Scripts.Data;
using Assets.Scripts.ItemSystem.Events;
using Assets.Scripts.ItemSystem.ItemTypes.CargoItems;
using Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Modules;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.ItemSystem.UI
{
    public class ItemInfoPanel : MonoBehaviour
    {
        public Vector2 offset;

        public Text nameBox,Desc,Amount,rarity;
        public GameObject visualizer;
        public ItemInstance visualItem;

        public GameObject AttributeParent;
        public GameObject AttributeObj;

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
            foreach (Transform child in AttributeParent.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            if (item == visualItem)
            {
                visualizer.gameObject.SetActive(true);
                if (item.item is UpgradeModule)
                {
                    if ((item.item as UpgradeModule).attributes.Count > 0)
                    {
                        SpawnAttributeViews();

                    }
                }
            }
            else
            {
                visualItem = item;
                nameBox.text = item.item.itemName;
                Desc.text = item.item.description;
                Amount.text = ""+item.amount+" m3";
                rarity.text = "" + item.item.rarity;
                if(item.item is UpgradeModule)
                {
                    if((item.item as UpgradeModule).attributes.Count > 0)
                    {
                        SpawnAttributeViews();
                        
                    }
                }
                
                visualizer.gameObject.SetActive(true);
            }
        }

        private void Update()
        {
            Vector2 mousePos = Input.mousePosition;
            this.transform.position = mousePos + offset;
        }

        public void SpawnAttributeViews()
        {
            foreach (Transform child in AttributeParent.transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            foreach (Attribute attribute in (visualItem.item as UpgradeModule).attributes)
            { 
                if (attribute != null)
                {
                    GameObject obj = (GameObject)Instantiate(AttributeObj, AttributeParent.transform.position, Quaternion.identity, AttributeParent.transform);
                    obj.GetComponent<Text>().text = attribute._value + " " + attribute._name;
                }
            }

        }
    }
}