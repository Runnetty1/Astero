using Assets.Scripts.UI.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ItemSystem.UI
{
    class StationWindow : Window
    {
        public static StationWindow Instance { get; private set; } // static singleton

        private void Start()
        {
            if (Instance == null) { Instance = this; }
            else
            {
                if (Instance != StationWindow.Instance)
                    Destroy(gameObject);
            }

        }
    }
}
