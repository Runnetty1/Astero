using UnityEngine;
using System.Collections;
using Scripts.ControlledObjects;
using System.Collections.Generic;
using UnityEngine.UI;
using Scripts.ItemSystem;

namespace Scripts
{
    public class Actor : MonoBehaviour
    {

        public string playerName;
        public Faction.Factions faction = Faction.Factions.Terra;
        public Spaceship controllingShip;

        public bool isAI;

    }
}