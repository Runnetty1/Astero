using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using GameEvents;
namespace InventorySystem.GameUI
{
    public class HotbarWindow : GameWindow
    {
        public enum VisibilityState { Allways, OnInteract };
        public VisibilityState visiblityState = VisibilityState.Allways;

        public int selectionID; //0-9
        //the alpha to set on everything "hidden"
        public float minAlpha;
        public float maxAlpha;
        public float currAlpha;

        public float minSlotAlpha;
        public float maxSlotAlpha;
        public float currSlotAlpha;
        public bool inventoryActive;

        public HotbarSlot selected;



        private void Start()
        {
            
            InputManager.OnScrollEvent += ScrollSelect;
            this.windowType = GameWindow.WindowType.hotbar;
            //Debug.Log(GetComponent<Image>().color.r);
            if (visiblityState == VisibilityState.Allways)
            {
                //Unhide
                GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, maxAlpha);
            }
            else if(visiblityState == VisibilityState.OnInteract) {
                //hide
                GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, minAlpha);
                //until interacted with (scroll through,number selected,Inventory visible)
                //register on OnWindowVisibilityEvent
                GameWindow.OnWindowVisibilityEvent += InventoryOpened;
            }
            SetVisiblityOnSlots();
        }


        public override void OnDisable()
        {
            base.OnDisable();
            GameWindow.OnWindowVisibilityEvent -= InventoryOpened;
            InputManager.OnScrollEvent -= ScrollSelect;
        }

        public void InventoryOpened(GameWindow.WindowType type, bool state)
        {
            if (type == GameWindow.WindowType.inventory) {
                if(state)
                {
                    currAlpha = maxAlpha;
                    currSlotAlpha = maxSlotAlpha;
                    GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, currAlpha);
                    SetVisiblityOnSlots();
                }
                else
                {
                    currAlpha = minAlpha;
                    GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, currAlpha);
                    currSlotAlpha = minSlotAlpha;
                    SetVisiblityOnSlots();
                }
            }
            this.inventoryActive = state;
        }

        public void SetVisiblityOnSlots()
        {
            Slot[] childs = GetComponentsInChildren<Slot>();
            for(int i = 0; i < childs.Length; i++)
            {
                //set all children to be hidden exept selected
                if (selectionID == i) {
                    childs[i].GetComponent<Image>().color = new Color(255, 255, 255, maxSlotAlpha);
                    selected = (HotbarSlot)childs[i];
                }
                else
                {
                    childs[i].GetComponent<Image>().color = new Color(255, 255, 255, minSlotAlpha);
                }
            }
           // new HotbarSelectedSwitch(selected);
        }
        
        public void SetSelectionID(int id)
        {
            this.selectionID = id;
            SetVisiblityOnSlots();
        }

        public void ScrollSelect(InputManager.ScrollDirection dir)
        {
            if (!this.inventoryActive)
            {
                if (dir == InputManager.ScrollDirection.UP)
                {
                    SelectNext();
                }
                if (dir == InputManager.ScrollDirection.DOWN)
                {
                    SelectPrev();
                }
            }
        }

        public void SelectNext()
        {
            Slot[] childs = GetComponentsInChildren<Slot>();
            if (this.selectionID < childs.Length - 1)
            {
                this.selectionID++;
            }
            else
            {
                this.selectionID = 0;
            }
            
            SetVisiblityOnSlots();
        }

        public void SelectPrev()
        {
            Slot[] childs = GetComponentsInChildren<Slot>();
            if (this.selectionID > 0)
            {
                this.selectionID--;
            }
            else
            {
                this.selectionID = childs.Length-1;
            }

            SetVisiblityOnSlots();
        }


    }
}