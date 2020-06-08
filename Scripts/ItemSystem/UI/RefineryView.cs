using Assets.Scripts.Data;
using Assets.Scripts.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ItemSystem.UI
{
    class RefineryView : Scripts.UI.Generic.Window
    {
        public StationData station;

        public static RefineryView Instance { get; private set; } // static singleton

        public InventoryView rawProcessingBayView,processedBayView,playerOreBayView;

        public UserData user;

        

        internal StationData GetStation()
        {
            return station;
        }

        internal void SetStation(StationData value)
        {
            station = value;
        }

        private void Start()
        {
            if (Instance == null ) { Instance = this; }
            else {
                if(Instance !=RefineryView.Instance)
                Destroy(gameObject); }
            
        }
        
        public void UpdateViews()
        {
            if (station != null)
            {
                rawProcessingBayView.inventory = station.GetComponent<RawProcessingBay>();
                rawProcessingBayView.Instantiate();

                processedBayView.inventory = station.GetComponent<ProcessedBay>();
                processedBayView.Instantiate();
            }
            playerOreBayView.inventory = GameHandler.Instance.Player.controllingShip.GetComponent<OreBay>();
            playerOreBayView.Instantiate();
        }
    }
}
