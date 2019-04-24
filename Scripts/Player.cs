using UnityEngine;
using System.Collections;
using RRG.ControlledObjects;
using System.Collections.Generic;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public string playerName;
	public Faction.Factions faction = Faction.Factions.Terra;
    //public Spaceship mySpaceship;

    public Text oreDisplay;

    public double ore;


    void Update()
    {
        if(oreDisplay!=null)
            oreDisplay.text = "Raw Ore: "+ore;
    }
}
