using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystemScaler : MonoBehaviour
{
#if UNITY_EDITOR
    [Header("Debug")]
#pragma warning disable CS0649 // Add readonly modifier
    public bool UpdateChildList;
    public List<SystemObject> children;
    
    public bool scaleSystem;
    public float systemScale;
#pragma warning restore CS0649 // Add readonly modifier

    private void OnDrawGizmos()
    {
        if (UpdateChildList)
        {
            children = new List<SystemObject>();
            GetChildren();
            UpdateChildList = false;
        }

        if (scaleSystem)
        {
            MoveChildren();
        }
        
    }

    public void MoveChildren()
    {
        for(int i =0;i<children.Count;i++)
        {
            Vector3 X = children[i].child.transform.localPosition;
            X.x = (children[i].acctualDist/children[i].distChangeValue) / (systemScale);
            X.y = 0;
            X.z = 0;
            children[i].child.transform.localPosition = X;

            Vector3 rot= children[i].main.transform.localRotation.eulerAngles;
            rot.z = children[i].rotation;
            rot.x = 0;
            rot.y = 0;
            Quaternion t = Quaternion.identity;
            t.eulerAngles = rot;
            children[i].main.transform.localRotation = t;
        }
    }

    public void GetChildren()
    {
        
        
        for(int i = 0; i< transform.childCount; i++)
        {
            children.Add(new SystemObject(transform.GetChild(i).GetChild(0),transform.GetChild(i)));
        }
    }

#endif
}
