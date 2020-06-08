using UnityEngine;
using System.Collections;
using Assets.Scripts;

using Assets.Scripts.Util;
using Assets.Scripts.ItemSystem.Events;
using Assets.Scripts.Data;

/*
 * Marked as outdated/ To be rewritten
 * Spesifficly:
 *  - Turret Controll
 *  - Cruise Animations
 */

public class ShipControll : MonoBehaviour {


	public float accel;
    public float addedAccel;
	public float turnSpeed;
    public float addedTurnSpeed;
    public double warpMultiplier;
    public float addedWarpMultiplier;
    public GameObject LargeTrail;

	
	
	public float timer;
    

	public enum ForceMode { Impulse, accel};
    public ForceMode fmode;
    public GameObject cruiseTarget;
    public float initialTargetDistance;
    public float targetDistance;
    public bool cruisingToTarget;

    public GameObject[] CruiseAnim;
    public bool warpMove;

    public delegate void ShipWarpEvent(bool a);
    public static event ShipWarpEvent OnShipWarpEvent;
    public Vector3 startPos;
    public double startTime;
    public double speed;
    public string speed2;

    public ForceMode2D forcemode;

    public void OnEnable()
    {
        AttributeEvents.OnAttributeChanged += AttributeEvents_OnAttributeChanged;
    }

    public virtual void AttributeEvents_OnAttributeChanged(ActorData ship)
    {
        if (ship != this.GetComponent<ActorData>())
        {
            return;
        }
        addedAccel += ship.GetAttribute(Attribute.AttributeName.Acceleration)._value;
        addedTurnSpeed += ship.GetAttribute(Attribute.AttributeName.TurnSpeed)._value;
        addedWarpMultiplier+= ship.GetAttribute(Attribute.AttributeName.WarpSpeed)._value;
        
    }

    /// <summary>
    /// TODO:
    /// STOP CRUISE MID CRUISE
    /// STOP TARGET BUTTONS FROM BEING PRESSED WHILE CRUISING
    /// </summary>
    // Update is called once per frame
    void Update () {
        if (cruiseTarget != null && warpMove)
        {
            targetDistance = Vector3.Distance(cruiseTarget.transform.position, transform.position);
            if (targetDistance < 70f)
            {
                Camera.main.GetComponent<CameraController>().shakeCamera = false;
                //Arived at target
                warpMove = false;
                cruisingToTarget = false;
                this.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
                GetComponent<CircleCollider2D>().enabled = true;
                StartCoroutine(DisableCruiseParticles());
                OnShipWarpEvent?.Invoke(false);
            }
            ParticleSystem ps = CruiseAnim[1].GetComponent<ParticleSystem>();
            var forceDir = ps.forceOverLifetime;
            float var = transform.GetComponent<Rigidbody2D>().velocity.sqrMagnitude;
            //var = Mathf.Clamp(var,1000f,7000000f);
            //EmissionDir
            var dir = cruiseTarget.transform.position - this.gameObject.transform.position;

            //forceDir.x = dir.y;
            //forceDir.y = dir.x;
            //forceDir.z = dir.z;
            speed2 = ValueConvert.Instance.getConvertedValue(var*10);
        }

        if (cruisingToTarget)
        {
            LookAtCruiseTarget();
            if (warpMove && targetDistance > 70f)
            {
                this.transform.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * Time.smoothDeltaTime * ((accel + addedAccel) * GetComponent<Rigidbody2D>().mass * ((float)warpMultiplier+addedWarpMultiplier)), ForceMode2D.Force);
            }
        }
	}

	/////////////////////////////////
	/// Ship Control;
    public void Forward()
    {
        this.transform.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * Time.smoothDeltaTime * ((accel+addedAccel) * GetComponent<Rigidbody2D>().mass * 10), forcemode);
        //this.transform.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * Time.smoothDeltaTime * (accel / GetComponent<Rigidbody2D>().mass ), ForceMode2D.Force);
    }


    public void Backward()
    {
        this.transform.GetComponent<Rigidbody2D>().AddRelativeForce(-Vector2.right * Time.smoothDeltaTime * (accel + addedAccel) * GetComponent<Rigidbody2D>().mass * 3, forcemode);
    }

    public void Left()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, this.transform.rotation.eulerAngles.z + Time.deltaTime * (turnSpeed + addedTurnSpeed));
    }

    public void Right()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, this.transform.rotation.eulerAngles.z - Time.deltaTime * (turnSpeed + addedTurnSpeed));
    }

    
    /////////////////////////////////

    public void EnableCruiseToTarget ()
    {
        initialTargetDistance = Vector3.Distance(cruiseTarget.transform.position, transform.position);
        //cannot jump if distance is to small
        if (initialTargetDistance >= 100f)
        {

            cruisingToTarget = true;
            OnShipWarpEvent?.Invoke(true);

            GetComponent<CircleCollider2D>().enabled = false;
            StartCoroutine(EnableCruiseParticles());
        }
    }

    public void LookAtCruiseTarget ()
    {
        
        Vector3 dir = cruiseTarget.transform.position - this.gameObject.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        this.transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.smoothDeltaTime * (turnSpeed + addedTurnSpeed));
    }

    public void SetCruiseTarget (GameObject target)
    {
        if(!warpMove)
            cruiseTarget = target;
    }

    IEnumerator EnableCruiseParticles ()
    {
        yield return new WaitForSeconds(1);
       
        ParticleSystem ps = CruiseAnim[0].GetComponent<ParticleSystem>();
        var emission = ps.emission;
        emission.enabled = true;

        yield return new WaitForSeconds(1);
        ///emission.enabled = false;

       // ps = CruiseAnim[1].GetComponent<ParticleSystem>();
        emission = ps.emission;
        //emission.enabled = true;
        LargeTrail.gameObject.SetActive(true);
        warpMove = true;
        Camera.main.GetComponent<CameraController>().shakeCamera = true;
    }

    IEnumerator DisableCruiseParticles ()
    {
        ParticleSystem ps = CruiseAnim[2].GetComponent<ParticleSystem>();
        var emission = ps.emission;
        emission.enabled = true;
        ps= CruiseAnim[0].GetComponent<ParticleSystem>();
        emission = ps.emission;
        emission.enabled = false;
        yield return new WaitForSeconds(.5f);

        ps = CruiseAnim[2].GetComponent<ParticleSystem>();
        emission = ps.emission;
        emission.enabled = false;
        LargeTrail.gameObject.SetActive(false);
    }
}


