
using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.LocatingSystem
{
    public class RadarView:MonoBehaviour
    {
        public UserData player;
#pragma warning disable CS0649 // Add readonly modifier
        public GameObject contentObj;
        public GameObject objectView;
#pragma warning restore CS0649 // Add readonly modifier

        public void Instantiate(UserData p)
        {
            player = p;
        }

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
                    ite.GetComponent<RadarViewItem>().SetTarget(item.gameObject);
                    ite.GetComponent<RadarViewItem>().SetIcon(item.icon,player.faction,item.faction);
                    

                }
            }
        }

    }
}
