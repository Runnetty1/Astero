using UnityEngine;
using System.Collections;

public class Faction : MonoBehaviour {

	public enum Factions
	{
		Terra,
		RysdanRebels,
		Byakua,
		Seryth
	}
	public Factions faction = Factions.Terra;


	public Color _enemy;
	public Color _friendly;
	public Color _owned;
	public Color _independent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
