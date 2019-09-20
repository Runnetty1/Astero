using Scripts;
using Scripts.UI.Generic;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.LocatingSystem
{
    class RadarListView:Window
    {
        public Actor player;

        public GameObject contentObj;
        public GameObject objectView;

        public List<ScanableObject> knownObjects;
        public List<ScanableObject> beaconLitObjects;
        public List<ScanableObject> hiddenObjectInRange;

        private void Start()
        {
            knownObjects = player.controllingShip.radar.GetKnownObjects();
            //beacon can be turned off but wont be changed here. mustfix...
            beaconLitObjects = player.controllingShip.radar.GetBeaconLitObjects();
            hiddenObjectInRange = player.controllingShip.radar.GetBeaconHiddenObjectsInRange();

            ReInstantiateObjects();
        }

        private void LateUpdate()
        {
            if (player.controllingShip.radar.RedrawRadarView)
            {
                player.controllingShip.radar.RedrawRadarView = false;
                ReInstantiateObjects();
            }
        }


        public void ReInstantiateObjects()
        {
            foreach (Transform child in contentObj.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
           
            foreach (ScanableObject item in knownObjects)
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
