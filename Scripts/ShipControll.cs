using UnityEngine;
using System.Collections;
using Assets.Scripts;
using Scripts.ControlledObjects.Weapon;

public class ShipControll : MonoBehaviour {


	public float accel;
	public float turnSpeed;
    public GameObject LargeTrail;
	public TurretBase[] ShipTurret;
    public GameObject turretParent;
	
	private float i;
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

    private void OnEnable()
    {
        ShipTurret = turretParent.GetComponentsInChildren<TurretBase>();
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
            targetDistance = (cruiseTarget.transform.position - transform.position).sqrMagnitude;
            if (targetDistance < 100f)
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
            float var = ((transform.GetComponent<Rigidbody2D>().velocity.sqrMagnitude) * (transform.GetComponent<Rigidbody2D>().velocity.sqrMagnitude)) / 20f;
            var = Mathf.Clamp(var,1000f,7000f);
            //EmissionDir
            var dir = cruiseTarget.transform.position - this.gameObject.transform.position;
            
            forceDir.x = dir.y;
            forceDir.y = dir.x;
            forceDir.z = dir.z;
        }

        if (!cruisingToTarget)
        {
            //DetectInput();
            
        }
        else
        {
            LookAtCruiseTarget();
            if (warpMove && (cruiseTarget.transform.position - transform.position).sqrMagnitude > 2000f)
            {
                this.transform.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * Time.smoothDeltaTime * (accel * GetComponent<Rigidbody2D>().mass * 30), ForceMode2D.Force);
            }
        }
	}

	/////////////////////////////////
	/// Ship Control;
    public void Forward()
    {
        this.transform.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * Time.smoothDeltaTime * (accel * GetComponent<Rigidbody2D>().mass * 10), ForceMode2D.Force);
    }

    public void Backward()
    {
        this.transform.GetComponent<Rigidbody2D>().AddRelativeForce(-Vector2.right * Time.smoothDeltaTime * accel * GetComponent<Rigidbody2D>().mass * 3, ForceMode2D.Force);
    }

    public void Left()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, this.transform.rotation.eulerAngles.z + Time.deltaTime * turnSpeed);
    }

    public void Right()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, this.transform.rotation.eulerAngles.z - Time.deltaTime * turnSpeed);
    }

    public void Fire()
    {
        for (int i = 0; i < ShipTurret.Length; i++)
        {
            ShipTurret[i].Fire();
        }
    }
    /////////////////////////////////

    public void EnableCruiseToTarget ()
    {
        cruisingToTarget = true;
        OnShipWarpEvent?.Invoke(true);
        initialTargetDistance =(cruiseTarget.transform.position - transform.position).magnitude;
        GetComponent<CircleCollider2D>().enabled = false;
        StartCoroutine(EnableCruiseParticles());
        
    }

    public void LookAtCruiseTarget ()
    {
        
        Vector3 dir = cruiseTarget.transform.position - this.gameObject.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        this.transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.smoothDeltaTime * turnSpeed);
    }

    public void SetCruiseTarget (GameObject target)
    {
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

        ps = CruiseAnim[1].GetComponent<ParticleSystem>();
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
