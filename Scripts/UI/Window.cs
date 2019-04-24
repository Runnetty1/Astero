using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RRG.InputHandling.player;

namespace RRG.UI.Generic
{
    public class Window : MonoBehaviour, IWindow
    {
        public string WindowName;

        public void VisibilityState(string n,bool a)
        {
            if(n==WindowName|| n=="all")
                this.gameObject.SetActive(a);  
        }

        public virtual void OnEnable()
        {
            //throw new NotImplementedException();
            InputController.OnWindowVisibilityEvent += VisibilityState;

        }

        public virtual void OnDisable()
        {
            //throw new NotImplementedException();
            //InputController.OnWindowVisibilityEvent -= VisibilityState;
        }

        

    }
}
