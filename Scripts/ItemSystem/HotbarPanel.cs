using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem.GameUI;

namespace InventorySystem
{
    public class HotbarPanel : MonoBehaviour {

        private HotbarSlot selected;
        public HotbarWindow window;

        public HotbarSlot Selected
        {
            get
            {
                
                    return window.selected;
                

            }

            set
            {
                selected = value;
            }
        }
    }
}