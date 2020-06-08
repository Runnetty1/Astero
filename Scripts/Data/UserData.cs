using UnityEngine;
using Assets.Scripts.Util;

namespace Assets.Scripts.Data
{
    public class UserData : MonoBehaviour
    {

        public string playerName;
        public Faction.Factions faction = Faction.Factions.Terra;
        public ActorData controllingShip;

        public bool isAI;

    }
}