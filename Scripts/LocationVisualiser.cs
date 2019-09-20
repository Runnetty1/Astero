using Assets.Scripts.Game;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationVisualiser : MonoBehaviour
{

    public GameObject goTarget;

    public float turnSpeed;

    public GameObject iconOwner;

    void Update()
    {
        TurnTowardTarget();
    }

 

    void TurnTowardTarget()
    {
        var screenPos = Camera.main.WorldToScreenPoint(goTarget.transform.position);

        Vector3 dir = this.gameObject.transform.position - screenPos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        this.transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.smoothDeltaTime * turnSpeed);
    }


    public void SetTarget(GameObject target)
    {
        goTarget = target;
    }
    public GameObject GetTarget ()
    {
        return goTarget;
    }

    internal void SetIcon(Sprite icon,Faction.Factions a, Faction.Factions b)
    {
        iconOwner.GetComponent<Image>().sprite = icon;
        iconOwner.GetComponent<Image>().color = GameObject.Find("GameHandler").GetComponent<GameHandler>().faction.GetColorOfFaction(a,b);
    }
}