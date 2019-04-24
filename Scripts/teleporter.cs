using UnityEngine;
using System.Collections;

public class teleporter : MonoBehaviour {
	public Transform spawn;
	void OnTriggerExit2D(Collider2D collision) {
		if(collision.tag == "player"){
			Debug.Log ("left Area");
			collision.transform.position = spawn.transform.position;
		}
	}
}
