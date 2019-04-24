using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.GameUI
{
    public class GameWindow : MonoBehaviour, IGameWindow
    {
        public enum WindowType {inventory,hotbar,crafting};
        protected WindowType windowType = WindowType.inventory;
        public void Visible()
        {
            this.gameObject.SetActive(true);
            if (OnWindowVisibilityEvent != null)
            {
                OnWindowVisibilityEvent(windowType, true);
            }
        }

        public void Hidden()
        {
            this.gameObject.SetActive(false);

            if (OnWindowVisibilityEvent != null)
            {
                OnWindowVisibilityEvent(windowType, false);
            }
        }

        public virtual void OnEnable()
        {
            //throw new NotImplementedException();
        }

        public virtual void OnDisable()
        {
            //throw new NotImplementedException();

        }

        public delegate void GameWindowVisibilityEvent(WindowType type, bool visiblityState);
        public static event GameWindowVisibilityEvent OnWindowVisibilityEvent;

    }
}
