
using Assets.Scripts.Data;
using Assets.Scripts.UI.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.LocatingSystem
{
    public class RadarListView:Window
    {
        public UserData player;

#pragma warning disable CS0649 // Add readonly modifier
        public GameObject contentObj;
        public GameObject objectView;
#pragma warning restore CS0649 // Add readonly modifier

        public List<ScanableObject> knownObjects;
        public List<ScanableObject> beaconLitObjects;
        public List<ScanableObject> hiddenObjectInRange;


        public void Instantiate(UserData p)
        {
            player = p;
        }

        public override void OnEnable()
        {
            StartCoroutine(SlowUpdate());
            base.OnEnable();
        }

        public override void OnDisable()
        {
            StopCoroutine(SlowUpdate());
            base.OnDisable();
        }

        public IEnumerator SlowUpdate()
        {
            //get local objects
            //getBeaconHidden
            beaconLitObjects = player.controllingShip.radar.GetBeaconLitObjects();
            hiddenObjectInRange = player.controllingShip.radar.GetBeaconHiddenObjectsInRange();
            ReInstantiateObjects();

            yield return new WaitForSeconds(0.5f);
            StartCoroutine(SlowUpdate());
        }

        private void Start()
        {
            knownObjects = player.controllingShip.radar.GetKnownObjects();
            //beacon can be turned off but wont be changed here. mustfix...
            beaconLitObjects = player.controllingShip.radar.GetBeaconLitObjects();
            hiddenObjectInRange = player.controllingShip.radar.GetBeaconHiddenObjectsInRange();

            ReInstantiateObjects();
        }


        public void ReInstantiateObjects()
        {
            foreach (Transform child in contentObj.transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            SpawnUIItem(hiddenObjectInRange);
            SpawnUIItem(beaconLitObjects);
            SpawnUIItem(knownObjects);
        }

        public void SpawnUIItem(List<ScanableObject> list)
        {
            foreach (ScanableObject item in list)
            {
                if (item != null)
                {
                    GameObject ite = (GameObject)Instantiate(objectView, contentObj.transform.position, Quaternion.identity, contentObj.transform);
                    ite.GetComponent<RadarListItem>().SetData(item);
                }
            }
        }
    }
}
