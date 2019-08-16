using Scripts.ItemSystem.ItemTypes.CargoItems.Modules;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Scripts.ItemSystem.UI
{
    public class InventoryView : MonoBehaviour, IDropHandler
    {
        //Set by Client UI
        [SerializeField]
        public Inventory inventory;
        //Where to place item panels
        public GameObject contentObj;
        //What itemView
        public GameObject itemPanel;
        //Size of inventory
        public Text SizeText;
        
        //padding between items
        public float padding;
        
        public void Instantiate()
        {
            SizeText.text = ""+inventory.CurrentInventorySize+" / "+inventory.GetTotalMaxInventorySize()+" m3";

            foreach (Transform child in contentObj.transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            if (inventory != null)
            {
                foreach (ItemInstance item in inventory.GetInventory())
                {
                    if (item != null)
                    {
                        GameObject module = (GameObject)Instantiate(itemPanel, contentObj.transform.position, Quaternion.identity, contentObj.transform);
                        module.GetComponent<ItemVisualizer>().item = item;
                        module.GetComponent<ItemVisualizer>().Instantiate();
                        
                    }
                }

            }

        }

        private void OnEnable()
        {
           Inventory.OnInventoryUpdate += UpdateInventoryView;
            
        }

        public void UpdateInventoryView(Inventory mod)
        {
            if(mod==this.inventory)
                Instantiate(); 
        }
        public void Update()
        {
            //this.GetComponent<LayoutElement>().minHeight = 34 + contentObj.GetComponent<RectTransform>().sizeDelta.y + padding;
            
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
