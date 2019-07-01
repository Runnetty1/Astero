using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RRG.InventorySystem;
using System;

namespace RRG.ControlledObjects
{
    [System.Serializable]
    public class Spaceship : MonoBehaviour
    {
        public ModuleSlots ModuleSlots;
        public Inventory cargoBay;

        public bool hasHangar;
        public Inventory hangarBay;
        public bool hasOreBay;
        public Inventory oreBay;

        

        //ShipMovement
        //Ship Turrets
        //Ship scanner

    }
}