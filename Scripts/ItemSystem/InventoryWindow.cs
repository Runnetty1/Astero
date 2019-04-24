using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem;

namespace InventorySystem.GameUI
{
    public class InventoryWindow : GameWindow
    {
        public Inventory Inventory
        {
            get
            {
                return this.gameObject.GetComponent<Inventory>();
            }
            set
            {
                Inventory = value;
            }
        }

        private void Start()
        {
            this.windowType = GameWindow.WindowType.inventory;
            if (!Inventory)
            {
                gameObject.AddComponent<Inventory>();
            }
            else
            {
                Inventory.GetComponent<Inventory>();
            }
        }
    }
}