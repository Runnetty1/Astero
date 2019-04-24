using UnityEngine;
using System.Collections;

public class PointDedacter : MonoBehaviour {

	public GUIText _myPoints;
	public int _points;


	void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log ("hit");
		if (collision.transform.tag == "bullet"){
			_points++;
			_myPoints.text = "" + _points;
		}
	}

	// Update is called once per frame
	void Update () {
		if (_points <= 0){
			//End game
			//Reset
		}
	}
}
