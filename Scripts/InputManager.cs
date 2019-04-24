using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using InventorySystem.Core;

namespace InventorySystem.GameUI
{
    public class InputManager : MonoBehaviour
    {

        public InventoryWindow inventoryWindow;
        //public CraftingBookWindow craftingWindow;
        public enum ScrollDirection { UP, DOWN };
        public delegate void ScrolledEvent(ScrollDirection dir);
        public static event ScrolledEvent OnScrollEvent;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                
                Debug.developerConsoleVisible= !Debug.developerConsoleVisible;
            }
                if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (inventoryWindow.gameObject.activeSelf)
                {
                    inventoryWindow.Hidden();
                }
                else
                {
                    inventoryWindow.Visible();
                }
            }
            /*
            if (Input.GetKey(KeyCode.Q))
            {
    
                GameObject g = Instantiate((GameObject)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Resources/Items/" + "Ore" + ".prefab", typeof(GameObject)), Vector3.zero, Quaternion.identity);
                Item it = g.GetComponent<Item>();
                it.Amount = 1;
                inventoryWindow.Inventory.AddItem(it);
                //Destroy(g)

            }*/
            /*
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (craftingWindow.gameObject.activeSelf)
                {
                    craftingWindow.Hidden();
                }
                else
                {
                    craftingWindow.Visible();
                }
            }
            */
            if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
            {
                if (OnScrollEvent != null)
                {
                    OnScrollEvent(ScrollDirection.DOWN);
                }
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
            {
                if (OnScrollEvent != null)
                {
                    OnScrollEvent(ScrollDirection.UP);
                }
            }
        }
    }
}