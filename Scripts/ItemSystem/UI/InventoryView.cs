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
        public Text SizeText,nameText;
        private double cargoSize;
        public float padding;
        // Start is called before the first frame update
        public void Instantiate()
        {
            if (internalModule != null)
            {
                if (internalModule is OreBay)
                {
                    foreach (Item item in ((OreBay)internalModule).Ores)
                    {
                        if (item != null)
                        {
                            GameObject module = (GameObject)Instantiate(itemPanel, contentObj.transform.position, Quaternion.identity, contentObj.transform);
                            module.GetComponent<ItemVisualizer>().item = item;
                            module.GetComponent<ItemVisualizer>().Instantiate();
                            cargoSize += item.amount;
                        }
                    }
                    SizeText.text = "" + cargoSize + " / " + internalModule.maxModuleSize+" m3";
                    nameText.text = internalModule.itemName;
                    
                }
                
            }
        }

        public void Update()
        {
            this.GetComponent<LayoutElement>().minHeight = 34 + contentObj.GetComponent<RectTransform>().sizeDelta.y + padding;
        }
    }
}