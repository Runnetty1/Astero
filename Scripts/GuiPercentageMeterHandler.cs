using UnityEngine;
using System.Collections;

public class GuiPercentageMeterHandler : MonoBehaviour {

	public Transform[] _heatGui;

	public double _currentHeat=0;
	public int maxHeat=1000;
	public string nameOfEngine;
	public bool _powerOn;
	public bool preheater;
	public bool engineStart;
	public bool engineIsOn;
	public bool coolEngine;
	public int engineStartmin = 530;


	public int amoutOfLinesToShow;
	public int maxHeatDividedByElements;

	
	// Update is called once per frame
	void Update () {

		//get the amount of lines to show. 
		maxHeatDividedByElements = maxHeat / _heatGui.Length;
		amoutOfLinesToShow = (int)_currentHeat / maxHeatDividedByElements;
		ShowLines(amoutOfLinesToShow);

		//cool down the engine when we power down
		if(!_powerOn)
		{
			coolEngine = true;
		}

		/* this controls the on state of the ship
		 * and its components, such as the start sequence
		 * for the ship.
		 */

		if(_powerOn)
		{
			//Duh....
			checkForheat();

			//turn the cooling off while we use the preheater
			if(preheater)
			{
				coolEngine=false;
				selectrandomheat();
			}

			//as long as the current heat is warm enough and the player turned the ignition
			//allow engine to start
			if(_currentHeat > engineStartmin && engineStart)
			{
				//Debug.Log("[Notice] Engine: "+nameOfEngine+" is starting.");
				engineIsOn = true;
				preheater = false;
				engineStart = false;
			}
			//if player tries to turn the engine on while its too cold
			// do not allow it to start
			else if(engineStart && _currentHeat < engineStartmin-30f)
			{
				engineStart = false;
			}
			//turn the enine off when its too cold 
			else if (_currentHeat < engineStartmin-30)
			{
				engineIsOn = false;
				//powerdown
			}

			//generate a random amount of heat
			if(engineIsOn)
			{
				enginerandomheat();
			}

		}

		//Turn all power-using components off 
		if(!_powerOn && engineIsOn 
		   || !_powerOn && preheater 
		   || !_powerOn && engineStart
		   )
		{
			engineIsOn = false;
			preheater = false;
			engineStart = false;
		}

		//cool the engine as long as its not allready 0  
		if(coolEngine && _currentHeat >=1f)
		{
			enginerandomcool();
		}
	}

	//checks and outputs debug text for each heatstate
	void checkForheat()
	{
		if(_currentHeat > engineStartmin && _currentHeat < 620)
		{
			//Debug.Log("[Notice] Engine: "+nameOfEngine+"'s heat is Good.");
		}

		if(_currentHeat > 790 && _currentHeat < 940)
		{
			//Debug.Log("[Warning] Engine: "+nameOfEngine+" is close to overheating!");
		}

		if(_currentHeat > 1000)
		{
			//Debug.Log("[Warning] OverHeat on engine: "+nameOfEngine+"!");
		}
	}

	//a random amount of heat 
	void selectrandomheat()
	{

		if(_currentHeat<500)
		{
			_currentHeat += Random.Range(0.01f,0.09f);
		}
		else if (_currentHeat > 500 && _currentHeat < 1000)
		{
			_currentHeat += Random.Range(0.001f,0.03f);
		}
	}

	//a random amount of cooling
	void enginerandomcool()
	{
		_currentHeat -= Random.Range(0.01f,0.17f);
	}

	//when engine is on generate heat
	//when too cold heat more
	//when to warm cool down
	void enginerandomheat()
	{
		//too cold: warm up
		if(_currentHeat < 500)
		{
			_currentHeat += Random.Range(0.01f,0.17f);
		}
		//Good zone: random up or down
		else if(_currentHeat>500&&_currentHeat < 790)
		{
			//randomly add or remove heat
			int i = (int)Random.Range(1f,100f);
			if(i < 52)
			{
				_currentHeat += Random.Range(0.01f,0.19f);
			}
			else
			{
				_currentHeat -= Random.Range(0.01f,0.19f);
			}
		}
		//to warm: heat up
		else if (_currentHeat > 790)
		{
			_currentHeat -= Random.Range(0.01f,0.17f);
		}
	}

	//enables and diables gui elements by
	// enabling all bellow the amount of lines
	// and disabling  above the amount of lines
	void ShowLines(int lines)
	{
		//enable
		for(int i = 0; i < lines ;i++)
		{
			_heatGui[i].gameObject.SetActive(true);
		}
		//disable
		for(int i = lines; i < _heatGui.Length ;i++)
		{
			_heatGui[i].gameObject.SetActive(false);
		}
	}

	//Disables all lines, so none shows.
	void resetLines()
	{
		for(int i = 0; i < _heatGui.Length ;i++)
		{
			_heatGui[i].gameObject.SetActive(false);
		}
	}
}