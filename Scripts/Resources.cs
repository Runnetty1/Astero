using UnityEngine;
using System.Collections;

public class Resources : MonoBehaviour {


	public int _metal;
	public int _maxMetal;
	public int _food;
	public int _maxFood;
	public int _tech;
	public int _maxTech;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	#region Count Get
	public int getCountMetal(){return this._metal;}
	public int getCountFood(){return this._food;}
	public int getCountTech(){return this._tech;}

	//MAXCOUNT
	public int getCountMaxMetal(){return 0;}
		public int getCountMaxFood(){return 0;}
		public int getCountMaxTech(){return 0;}
	#endregion

	#region add
	public void addtMetal(){}
	public void addFood(){}
	public void addTech(){}
	#endregion

	#region remove
	public void remMetal(){}
	public void remFood(){}
	public void remTech(){}
	#endregion
}
