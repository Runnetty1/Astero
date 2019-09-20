using Assets.Scripts.Game;
using Assets.Scripts.Util;
using Scripts;

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Assets.Scripts.LocatingSystem
{
    public class RadarListItem : MonoBehaviour
    {
        public ScanableObject scnObj;

        public Actor player;
        public Image icon;
        public Text nameText;
        public Text distanceText;


        public IEnumerator Tick()
        {
            double dist = Vector3.Distance(scnObj.gameObject.transform.position, player.controllingShip.transform.position);

            distanceText.text = "" + ValueConvert.Instance.getConvertedValue(dist * 10000);

            yield return new WaitForSeconds(0.5f);
            StartCoroutine(Tick());
        }

        public void SetData(ScanableObject obj)
        {
            icon.sprite = obj.icon;
            GameHandler g = GameObject.Find("GameHandler").GetComponent<GameHandler>();
            icon.color = g.faction.GetColorOfFaction(g.ScenePlayerObj.GetComponent<Actor>().faction, obj.faction);
            nameText.text = obj._name;
            scnObj = obj;

            player = g.ScenePlayerObj.GetComponent<Actor>();
            UnityEngine.Events.UnityAction action = () => { player.controllingShip.GetComponent<ShipControll>().SetCruiseTarget(obj.gameObject); };
            GetComponent<Button>().onClick.AddListener(action);
            StartCoroutine(Tick());
        }


            
        
    }
}