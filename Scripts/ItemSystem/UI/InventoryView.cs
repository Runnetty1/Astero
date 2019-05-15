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
            foreach (Transform child in contentObj.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            if (internalModule != null)
            {
                if (internalModule is OreBay)
                {
                    foreach (ItemInstance item in ((OreBay)internalModule).inventory)
                    {
                        if (item != null)
                        {
                            GameObject module = (GameObject)Instantiate(itemPanel, contentObj.transform.position, Quaternion.identity, contentObj.transform);
                            module.GetComponent<ItemVisualizer>().item = item;
                            module.GetComponent<ItemVisualizer>().Instantiate();
                            //cargoSize += item.amount;
                        }
                    }
                    SizeText.text = "" + (internalModule as OreBay).currentInventorySize+ " / " + (internalModule as OreBay).maxInventorySize+ " m3";
                    nameText.text = internalModule.itemName;
                    
                }
                
            }
        }

        public void Update()
        {
            this.GetComponent<LayoutElement>().minHeight = 34 + contentObj.GetComponent<RectTransform>().sizeDelta.y + padding;
            if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.U))
            {
                Instantiate();
            }
        }
    }
}
