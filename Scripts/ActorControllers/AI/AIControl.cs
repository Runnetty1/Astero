using UnityEngine;
using System.Collections;


/*
 * Marked as outdated/Not in use/ To be rewritten
 */


public class AIControl : MonoBehaviour {
	
	public float accel;
	public float turnSpeed;
	public Transform ShipTurret;
	public GameObject target;
	public bool waiting;
	public bool dodge;
	public bool dir;
	public bool has2Players;
	private float turnspi;
    
	public enum State
	{
		manuvering,
		sniping,
		rushing,
		dodgeing
	}

	public State state = State.manuvering;
	private Quaternion Rotation;

	// Use this for initialization
	void Start () {
		//target = GameObject.Find ("player");
		dodge = true;
		dir = true;
		turnspi = turnSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        /*
		if (!waiting) {
			checkForNewStates ();
		}
		if(this.GetState() == State.manuvering){
			manuvering();

		}else
		if(this.GetState() == State.rushing){
			rush();
			ShipTurret.GetComponent<TurretBase>().Fire();
		}else
		if(this.GetState() == State.sniping){
			snipe();
			ShipTurret.GetComponent<TurretBase>().Fire();
		}else
		if(this.GetState() == State.dodgeing){
			avoid();
			//ShipTurret.GetComponent<TurretControl>().Fire();
		}
        */
	}
	void checkForNewStates(){
		waiting = true;
		int a = Random.Range (0,100);
		if (a < 10) {this.SetState(State.manuvering);}
		else if( a > 20 && a < 30){this.SetState(State.rushing);}
		else if( a > 30 && a < 40){this.SetState(State.sniping);}
		else if( a > 40 && a < 50){this.SetState(State.dodgeing);}
		else if( a > 50 && a < 60){this.SetState(this.GetState());}
		//else if( a > 60 && a < 70){target = GameObject.Find ("player");}
		//else if( a > 80 && a < 90 && has2Players){target = GameObject.Find ("player2");}
		StartCoroutine(cooldown());

	}
	IEnumerator cooldown() {
		float a = (float)Random.Range (0.2f, 1f);
		yield return new WaitForSeconds(a);
		waiting = false;
	}
	IEnumerator dodgeCooldown() {
		dodge = false;
		float a = (float)Random.Range (0.2f, 1f);
		yield return new WaitForSeconds(a);
		if(dir){
			dir = false;
		}else{
			dir = true;
		}
		dodge = true;

	}

	void avoid(){
        GetComponent<ShipControll>().Forward();
        this.transform.rotation = Quaternion.Euler (0, 0, this.transform.rotation.eulerAngles.z - Time.smoothDeltaTime * (turnspi * 50));
		if (dodge) {
			if (dir) {
				turnspi = turnSpeed;
				StartCoroutine(dodgeCooldown ());
			} 
			else if (!dir) {
				turnspi = -turnSpeed;
				StartCoroutine(dodgeCooldown ());
			}
		}
	}
	void manuvering(){
		turnspi = turnSpeed;
        GetComponent<ShipControll>().Forward();
		turnTowardTarget ();
	}
	void rush(){
		turnspi = turnSpeed + 10;
        GetComponent<ShipControll>().Forward();
        turnTowardTarget ();
	}
	void snipe(){
		turnspi = turnSpeed;
        GetComponent<ShipControll>().Forward();
        turnTowardTarget ();
	}
	void turnTowardTarget(){
		Vector3 dir = target.transform.position - this.transform.position;
		float angle = Mathf.Atan2(dir.y, dir.x)* Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle+Random.Range(-2,2), Vector3.forward);
		this.transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.smoothDeltaTime * turnspi);
	}
	public State GetState(){
		return this.state;
	}
	
	public void SetState(State newState){
		this.state = newState;
	}
}
