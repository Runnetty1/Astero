
using UnityEngine;
using Assets.Scripts.ActorControllers;

namespace Assets.Scripts.UI.Generic
{
    public class Window : MonoBehaviour, IWindow
    {
        public string WindowName;

        public bool ignoreWindowEvents;
        public bool ignoreFalse;
        public bool ignoreTrue;
        public bool useChild;
        public Transform child;
        public void VisibilityState(string n,bool a)
        {
            if (!ignoreWindowEvents)
            {
                    if (n == WindowName || n == "all")
                    {
                        if (useChild)
                        {
                            if (child == null)
                            {
                                ToggleChildVisibility();
                            }
                            else
                            {
                                ToggleChildVisibility(child);
                            }
                        }
                        else
                        {
                            this.gameObject.SetActive(a);
                        }
                    }
                
            }
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

        public void ToggleChildVisibility()
        {
            transform.GetChild(0).gameObject.SetActive(!transform.GetChild(0).gameObject.activeInHierarchy);
        }

        public void ToggleChildVisibility(Transform child)
        {
            child.gameObject.SetActive(!transform.GetChild(0).gameObject.activeInHierarchy);
        }

        public void SetChildVisibility(bool visible)
        {
            transform.GetChild(0).gameObject.SetActive(visible);
        }

    }
}
