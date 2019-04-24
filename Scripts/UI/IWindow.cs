using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWindow {

    void VisibilityState(string windowName,bool a);
    

    void OnEnable();
    void OnDisable();
}
