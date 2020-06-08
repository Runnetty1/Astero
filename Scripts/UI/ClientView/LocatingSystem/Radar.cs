using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Util;
using Assets.Scripts.Data;
using Assets.Scripts.ItemSystem.Events;

namespace Assets.Scripts.LocatingSystem
{
    public class Radar:MonoBehaviour
    {
        public float defaultRange=500;
        public float addedRange;
        public float currentRadarRange;
        
        public List<ScanableObject> objInRange;

        public bool RedrawRadarView = false;
        public bool RedrawRadarList = false;

        private void LateUpdate()
        {
            currentRadarRange = defaultRange + addedRange;
            HasNewObjInRange();
        }

        public bool HasNewObjInRange()
        {
            List<ScanableObject> t = GetScanableObjectsInRange();

            if (objInRange.Count != t.Count)
            {
                objInRange = GetScanableObjectsInRange();
                RedrawRadarView = true;
                return true;
            }
            else
            {
                foreach (ScanableObject item in t)
                {
                    if (!objInRange.Contains(item))
                    {
                        RedrawRadarView = true;
                        return true;
                    }
                }
            }
            return false;
        }


        public List<ScanableObject> GetScanableObjectsInRange()
        {
            List<ScanableObject> t = GameObject.FindObjectsOfType<ScanableObject>().ToList<ScanableObject>();
            List<ScanableObject> a = new List<ScanableObject>();
            for (int i = 0; i < t.Count; i++)
            {
                if (GetDistance(t[i].transform, transform) <= currentRadarRange && t[i].transform !=transform)
                {
                    a.Add(t[i]);
                }
            }
            return a;
        }



        
        public List<ScanableObject> GetKnownObjects()
        {
            List<ScanableObject> t = GameObject.FindObjectsOfType<ScanableObject>().ToList<ScanableObject>();
            List<ScanableObject> a = new List<ScanableObject>();
            for (int i = 0; i < t.Count; i++)
            {
                if (t[i] is SystemBody)
                {
                    if ((t[i] as SystemBody).knownObject && t[i].transform != transform)
                    {
                        a.Add(t[i]);
                    }
                }
            }
            return a;
        }

        public List<ScanableObject> GetBeaconLitObjects()
        {
            List<ScanableObject> t = GameObject.FindObjectsOfType<ScanableObject>().ToList<ScanableObject>();
            List<ScanableObject> a = new List<ScanableObject>();
            for (int i = 0; i < t.Count; i++)
            {
                if (t[i] is BeaconObject)
                {
                    if ((t[i] as BeaconObject).BeaconIsOn && t[i].transform != transform)
                    {
                        a.Add(t[i]);
                    }
                }
            }
            return a;
        }

        public List<ScanableObject> GetBeaconHiddenObjectsInRange()
        {
            List<ScanableObject> t = GameObject.FindObjectsOfType<ScanableObject>().ToList<ScanableObject>();
            List<ScanableObject> a = new List<ScanableObject>();
            for (int i = 0; i < t.Count; i++)
            {
                if (t[i] is BeaconObject)
                {
                    if (!(t[i] as BeaconObject).BeaconIsOn && GetDistance(t[i].transform, transform) <= currentRadarRange && t[i].transform != transform)
                    {
                        a.Add(t[i]);
                    }
                }
            }
            return a;
        }

        public List<ScanableObject> GetHostileObjectsInRange(float range)
        {
            List<ScanableObject> t = GameObject.FindObjectsOfType<ScanableObject>().ToList<ScanableObject>();
            List<ScanableObject> a = new List<ScanableObject>();
            for (int i = 0; i < t.Count; i++)
            {
                if (t[i] is BeaconObject)
                {
                    if (GetDistance(t[i].transform, transform) <= range && t[i].transform != transform)
                    {
                        if (new Faction().IsHostileFaction(t[i].faction))
                        {
                            a.Add(t[i]);
                        }
                        
                    }
                }
            }
            return a;
        }


        public float GetDistance(Transform a, Transform b)
        {
            return Vector3.Distance(a.position, b.position);
        }

        public void UpgradeRadar(float amount)
        {
            addedRange += amount;
           
        }

        public virtual void AttributeEvents_OnAttributeChanged(ActorData ship)
        {
            if (ship != this.GetComponent<ActorData>())
            {
                return;
            }
            addedRange += ship.GetAttribute(Attribute.AttributeName.RadarRange)._value;
        }

        public virtual void OnEnable()
        {
            AttributeEvents.OnAttributeChanged += AttributeEvents_OnAttributeChanged;
        }
    }
}
