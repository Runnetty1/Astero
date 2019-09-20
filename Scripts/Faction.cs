using UnityEngine;
using System.Collections;

[System.Serializable]
public class Faction {

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

	public Color GetColorOfFaction(Factions a,Factions b)
    {
        if (a == b)
        {
            return _friendly;
        }
        else if(a!=b)
        {
            if (b == Factions.Pirate)
            {
                return _enemy;
            }
        }
        return _neutral;
    }
}
