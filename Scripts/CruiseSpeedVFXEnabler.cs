using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruiseSpeedVFXEnabler : MonoBehaviour {

    public GameObject[] cruiseParticles;
    public GameObject ship;
    [SerializeField]
    public float CruiseSpeed;
    public bool cruising;
    public float shipVelocity;

    public float MachSpeed;

    // Update is called once per frame
    void Update () {
        shipVelocity = ship.GetComponent<Rigidbody2D>().velocity.magnitude;
        if (ship.GetComponent<Rigidbody2D>().velocity.magnitude > CruiseSpeed && ship.GetComponent<Rigidbody2D>().velocity.magnitude < MachSpeed && !cruising)
        {
            cruising = true;
            foreach(GameObject g in cruiseParticles)
            {
                ParticleSystem ps = g.GetComponent<ParticleSystem>();
                var emission = ps.emission;
                emission.enabled = true;
            }
        }

        else if (ship.GetComponent<Rigidbody2D>().velocity.magnitude < CruiseSpeed && cruising) {
            cruising = false;
            foreach (GameObject g in cruiseParticles)
            {
                ParticleSystem ps = g.GetComponent<ParticleSystem>();
                var emission = ps.emission;
                emission.enabled = false;
            }
        }
	}
}
