using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.UI.Generic
{
    public interface IWindow
    {

        void VisibilityState(string windowName, bool a);


        void OnEnable();
        void OnDisable();
    }
}