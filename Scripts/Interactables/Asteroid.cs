using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Asteroid : Clickable
{
    public bool CanClick;

    /*
     * Make Asteroids in cluster have same type  of resource
     */

    //Public Ore;
    public double oreAmount = 100;
    public double oreGain = .5;

    public float maxStress  = 50;
    public double stress = 0;
    public double stressGain = 0.2;
    public double stressLoose = 0.1f;

    public float tickUpdate = 100;

    public bool a, w;
    
    //Get the GameObject’s mesh renderer to access the GameObject’s material and color
    public SpriteRenderer m_Renderer;
    public float scaledValue;

    private void Update()
    {
        if (!a)
        {
            a = true;
            StartCoroutine(StressLooseDelay());
        }

        if (Input.GetKey(KeyCode.R))
        {
            MineAsteroid();
        }
        Color m_MouseOverColor;
        scaledValue = (float)stress / ((float)maxStress);
        m_MouseOverColor = new Color(1f, 1f, 1f, scaledValue);
        // show the stress
        m_Renderer.material.color = m_MouseOverColor;
    }

    public void MineAsteroid() {
        if (!w)
        {
            w = true;
            StartCoroutine(MineDelay());
        }
        
    }

    IEnumerator MineDelay()
    {
        yield return new WaitForSeconds(tickUpdate/1000);
        w = false;
        stress += stressGain;

        //Calculate amount of ore to give;
        oreAmount -= oreGain;

        if (stress > maxStress || oreAmount<=0f)
        {
            //Explode
            Destroy(this.gameObject);
        }
        
    }


    IEnumerator StressLooseDelay()
    {
        yield return new WaitForSeconds(tickUpdate/1000);
        stress -= stressLoose;
        stress = Mathf.Clamp((float)stress, 0, maxStress*2);
        a = false;
    }

    
}
