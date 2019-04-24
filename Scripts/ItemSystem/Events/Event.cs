using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.EventSystem
{
    public class Event : System.Exception
    {
        public Event(string exeption)
        {
            Debug.LogError(exeption);
        }
        public static string InventoryFull()
        {
            return "InventoryFull";
        }
    }
}