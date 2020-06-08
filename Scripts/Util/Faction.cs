using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Util
{
    [System.Serializable]
    public class Faction
    {

        public enum Factions
        {
            Terra,
            RysdanRebels,
            Byakua,
            Seryth,
            Pirate,
            none
        }
        public Factions faction = Factions.Terra;


        public Color _enemy; //red
        public Color _friendly;//green
        public Color _owned; // blue
        public Color _neutral; //white

        public Color GetColorOfFaction(Factions a, Factions b)
        {
            if (a == b)
            {
                return _friendly;
            }
            else if (a != b)
            {
                if (b == Factions.Pirate)
                {
                    return _enemy;
                }
            }
            return _neutral;
        }

        public bool IsHostileFaction(Factions other)
        {
            
            if (other == Factions.Pirate)
            {
                return true;
            }
            //Check if the faction is at war with this faction and not just pirates...
            //must be fixed after Relations has been added.
            
            return false;
        }
    }
}