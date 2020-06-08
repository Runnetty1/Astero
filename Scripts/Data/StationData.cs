using Assets.Scripts.Interactables;
using Assets.Scripts.ItemSystem.UI;
using Assets.Scripts.LocatingSystem;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public class StationData : BeaconObject
    {
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Player") {
            /*
            if (collision.gameObject.GetComponent<ActorData>().owner.playerName == Game.GameHandler.Instance.Player.playerName)
            {*/
                RefineryView.Instance.SetStation(this);
            }
            
        }

        private void OnMouseDown()
        {
            StationWindow.Instance.ToggleChildVisibility();
        }
    }
}
