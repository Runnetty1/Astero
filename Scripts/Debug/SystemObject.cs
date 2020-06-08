using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SystemObject
{
    [HideInInspector]
    public Transform child;
    
    public Transform main;

    
    public float acctualDist=1;
    public float distChangeValue=10000;
    public float rotation = 0;

    public SystemObject(Transform child,Transform main)
    {
        this.child = child;
        this.main = main;
    }
}
