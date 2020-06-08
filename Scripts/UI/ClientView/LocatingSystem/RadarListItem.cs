using Assets.Scripts.Game;
using Assets.Scripts.Util;

using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Data;

namespace Assets.Scripts.LocatingSystem
{
    public class RadarListItem : MonoBehaviour
    {
        public ScanableObject scnObj;

        public UserData player;
        public Image icon;
        public Text nameText;
        public Text distanceText;

        public void SetData(ScanableObject obj)
        {
            if (obj != null) {
                icon.sprite = obj.icon;
                GameHandler g = GameHandler.Instance;
                if (g != null)
                {
                    icon.color = g.faction.GetColorOfFaction(g.Player.faction, obj.faction);
                
                    nameText.text = obj._name;
                    scnObj = obj;

                    player = g.Player;
                    UnityEngine.Events.UnityAction action = () => { player.controllingShip.GetComponent<ShipControll>().SetCruiseTarget(obj.gameObject); };
                    GetComponent<Button>().onClick.AddListener(action);
                    double dist = Vector3.Distance(scnObj.gameObject.transform.position, player.controllingShip.transform.position);

                    distanceText.text = "" + ValueConvert.Instance.getConvertedValue(dist * 10000);
                }
            }
        }




    }
}