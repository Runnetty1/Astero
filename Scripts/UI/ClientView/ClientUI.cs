
using Assets.Scripts.LocatingSystem;
using Assets.Scripts.ItemSystem.UI;
using UnityEngine;
using Assets.Scripts.Data;
using Assets.Scripts.ItemSystem;
using Assets.Scripts.ActorControllers;

namespace Assets.Scripts.UI
{
    
    public class ClientUI : MonoBehaviour
    {
        
        public UserData player;
        public ItemInfoPanel mouseHoverPanel;
        public InteractionMenuPanel interactionMenu;
        public ItemTokenView itemToken;
        public InventoryView cargoView;
        public InventoryView hangarView;
        public InventoryView orebayView;
        public InventoryView droneBayView;
        public RadarListView radarListView;
        public RadarView radarView;
        public ShipSystemsView moduleView;
        public TurretSystemsView turretView;
        public ShipStatsView shipStatsView;



        public void Instantiate()
        {

            if (player != null)
            {
                radarListView.Instantiate(player);
                radarView.Instantiate(player);
                interactionMenu.ship = player.controllingShip;
                cargoView.inventory = player.controllingShip.GetComponent<CargoBay>();
                hangarView.inventory = player.controllingShip.GetComponent<HangarBay>();
                orebayView.inventory = player.controllingShip.GetComponent<OreBay>();
                droneBayView.inventory = player.controllingShip.GetComponent<DroneBay>();
                moduleView.master = player.controllingShip.GetComponent<ModuleUpgradeMaster>();
                shipStatsView.actorData = player.controllingShip;
                turretView.master = player.controllingShip.GetComponent<TurretMaster>();
                cargoView.Instantiate();
                
                moduleView.Instantiate();
                //Enable/disable view

                if (player.controllingShip.GetComponent<OreBay>()!=null)
                {
                    //orebayView.gameObject.SetActive(true);
                    orebayView.Instantiate();
                }
                else
                {
                    //orebayView.gameObject.SetActive(false);
                }
                //Enable/disable view
                if (player.controllingShip.GetComponent<HangarBay>() != null)
                {
                    //hangarView.gameObject.SetActive(true);
                    hangarView.Instantiate();
                }
                else
                {
                    //hangarView.gameObject.SetActive(false);
                }

                //Enable/disable view
                if (player.controllingShip.GetComponent<DroneBay>() != null)
                {
                    //droneBayView.gameObject.SetActive(true);
                    droneBayView.Instantiate();
                }
                else
                {
                    //droneBayView.gameObject.SetActive(false);
                }
            }
            else
            {
                player = Game.GameHandler.Instance.Player;
            }
        }
    }
}