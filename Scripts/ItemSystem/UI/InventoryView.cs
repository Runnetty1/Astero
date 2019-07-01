using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RRG.InventorySystem
{
    public class InventoryView : MonoBehaviour, IDropHandler
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
                    /*
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
                    */

                }

            }

            //SizeText.text = "" + (internalModule as InventoryModule).CurrentInventorySize + " / " + (internalModule as InventoryModule).maxInventorySize + " m3";
            nameText.text = internalModule.itemName;
        }

        private void OnEnable()
        {
            //InventoryModule.OnModuleUpdate += UpdateInventoryView;
        }

        public void UpdateInventoryView(ItemInstance item)
        {
            Instantiate();
            Debug.Log("updatingInventroyView");
        }

        public void UpdateInventoryView(InventoryModule mod)
        {
            if (mod == (internalModule is InventoryModule))
            {
                Instantiate();
            }
        }
        public void Update()
        {
            this.GetComponent<LayoutElement>().minHeight = 34 + contentObj.GetComponent<RectTransform>().sizeDelta.y + padding;
            
        }

        public void OnDrop(PointerEventData eventData)
        {/*
            Debug.Log("dropping into inventory");
            if (!(internalModule as InventoryModule).HasItem(ItemTokenView.ite))
            {
                (internalModule as InventoryModule).UpdateInventorySize();
                if ((internalModule as InventoryModule).HasSpace(ItemTokenView.ite.amount))
                {
                    (internalModule as InventoryModule).AddItem(ItemTokenView.ite, false);
                    if (!ItemTokenView.spliting)
                    {
                        ItemTokenView.parentMod.RemoveItem(ItemTokenView.ite);
                    }
                    
                }
            }else
            {
                //i have this item already...
                Debug.Log("I have this item already");
                
            }
            ItemVisualizer.ItemDragStop();
            */
        }
    }
}
