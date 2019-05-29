using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RRG.InventorySystem
{
    public class InventoryView : MonoBehaviour
    {
        public InternalModule internalModule;
        public GameObject contentObj;
        public GameObject itemPanel;
        public Text SizeText, nameText;
        private double cargoSize;
        public float padding;
        // Start is called before the first frame update
        public void Instantiate()
        {
            foreach (Transform child in contentObj.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            if (internalModule != null)
            {
                if (internalModule is InventoryModule)
                {
                    if (((InventoryModule)internalModule).GetInventory()!=null)
                    {
                        foreach (ItemInstance item in ((InventoryModule)internalModule).GetInventory())
                        {
                            if (item != null)
                            {
                                GameObject module = (GameObject)Instantiate(itemPanel, contentObj.transform.position, Quaternion.identity, contentObj.transform);
                                module.GetComponent<ItemVisualizer>().item = item;
                                module.GetComponent<ItemVisualizer>().Instantiate();
                                //cargoSize += item.amount;
                            }
                        }
                    }

                }

            }
            SizeText.text = "" + (internalModule as InventoryModule).currentInventorySize + " / " + (internalModule as InventoryModule).maxInventorySize + " m3";
            nameText.text = internalModule.itemName;
        }

        private void OnEnable()
        {
            ItemEvents.OnItemAdded += UpdateInventoryView;
            ItemEvents.OnItemMerge += UpdateInventoryView;
            ItemEvents.OnItemDrop += UpdateInventoryView;
        }

        public void UpdateInventoryView(ItemInstance item)
        {
            Instantiate();
        }

        public void Update()
        {
            this.GetComponent<LayoutElement>().minHeight = 34 + contentObj.GetComponent<RectTransform>().sizeDelta.y + padding;
            
        }
    }
}
