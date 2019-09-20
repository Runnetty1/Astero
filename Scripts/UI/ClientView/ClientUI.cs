
using Scripts.ItemSystem.UI;
using UnityEngine;

namespace Scripts.UI
{
    
    public class ClientUI : MonoBehaviour
    {
        
        public Actor player;
        public ItemInfoPanel mouseHoverPanel;
        public InteractionMenuPanel interactionMenu;
        public ItemTokenView itemToken;
        public InventoryView cargoView;
        public InventoryView hangarView;
        public InventoryView orebayView;
        public InventoryView droneBayView;

        private void OnEnable()
        {
            Instantiate();
        }

        public void Instantiate()
        {
            if (player != null)
            {
                cargoView.inventory = player.controllingShip.cargoBay;
                hangarView.inventory = player.controllingShip.hangarBay;
                orebayView.inventory = player.controllingShip.oreBay;
                droneBayView.inventory = player.controllingShip.droneBay;

                cargoView.Instantiate();
                droneBayView.Instantiate();
                //Enable/disable view
                if (player.controllingShip.hasOreBay)
                {
                    //orebayView.gameObject.SetActive(true);
                    orebayView.Instantiate();
                }
                else
                {
                    //orebayView.gameObject.SetActive(false);
                }
                //Enable/disable view
                if (player.controllingShip.hasHangar)
                {
                    //hangarView.gameObject.SetActive(true);
                    hangarView.Instantiate();
                }
                else
                {
                    //hangarView.gameObject.SetActive(false);
                }

                //Enable/disable view
                if (player.controllingShip.hasDroneBay)
                {
                    //droneBayView.gameObject.SetActive(true);

                }
                else
                {
                    droneBayView.gameObject.SetActive(false);
                }
            }
        }
    }
}