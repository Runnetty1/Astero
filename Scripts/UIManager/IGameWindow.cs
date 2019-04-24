using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameWindow {

    void Visible();
    void Hidden();

    void OnEnable();
    void OnDisable();
}
