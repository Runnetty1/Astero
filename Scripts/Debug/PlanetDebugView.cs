using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlanetDebugView : MonoBehaviour
{
#if UNITY_EDITOR
    [Header("Debug")]
#pragma warning disable CS0649 // Add readonly modifier
    public bool debug;
    public Transform child;
    public Vector3 planetNameOffset;
    public float planetScale;
#pragma warning restore CS0649 // Add readonly modifier

    private void OnDrawGizmos()
    {
        if (debug)
        {
            child = transform.GetChild(0);
            //Draw Planets rotation space
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position, child.localPosition.x);

            

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(child.position, planetScale);
            
            
            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.red;

            Handles.Label(child.position + planetNameOffset, child.name,style);
            //Gizmos.DrawWireSphere(transform.position, attackRange);
        }
    }
#endif
}
