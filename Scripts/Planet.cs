using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Planet : MonoBehaviour {

	public string planetName;

	void OnTriggerStay2D(Collider2D col){
        //Player Entered  and is not moving to fast
		if (col.tag == "Player" && col.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude<20f)
        {
			//Trigger Window opening
			
		}
        //If the player 
	}
}
