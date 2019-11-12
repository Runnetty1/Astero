using Scripts;

using UnityEngine;

namespace Assets.Scripts.LocatingSystem
{
    class RadarView:MonoBehaviour
    {
        public Actor player;
        public GameObject contentObj;
        public GameObject objectView;

        private void Start()
        {
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

            foreach (ScanableObject item in player.controllingShip.radar.objInRange)
            {
                if (item != null)
                {
                    var screenPos = Camera.main.WorldToScreenPoint(item.gameObject.transform.position);

                    Vector3 dir = this.gameObject.transform.position - screenPos;
                    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

                    GameObject ite = (GameObject)Instantiate(objectView, contentObj.transform.position, q, contentObj.transform);
                    ite.GetComponent<LocationVisualiser>().SetTarget(item.gameObject);
                    ite.GetComponent<LocationVisualiser>().SetIcon(item.icon,player.faction,item.faction);
                    

                }
            }
        }

    }
}
