using Assets.Scripts.ItemSystem;
using Assets.Scripts.ItemSystem.ItemTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Interactables
{
    public class Asteroid : Clickable
    {

        /*
         * Make Asteroids in cluster have same type  of resource
         */

        //Public Ore;
        public double oreAmount = 100;
        public double oreGain = .5;

        public float maxStress = 50;
        public double stress = 0;
        public double stressGain = 0.2;
        public double stressLoose = 0.1f;

        public float tickUpdate = 2;

        public bool waitingForStressTick, waitingForMiningTick;

        //Get the GameObject’s mesh renderer to access the GameObject’s material and color
        public SpriteRenderer m_Renderer;
        public float scaledValue;

        public List<Raw> ores;

        private void Start()
        {
            int amountOfOretypesInRock = Random.Range(0, GetAmountOfOreTypes());
            for(int i = 0; i <= amountOfOretypesInRock; i++)
            {
                ores.Add(GetRandomOretype());
            }
        }

        private void Update()
        {
            if (!waitingForStressTick)
            {
                waitingForStressTick = true;
                StartCoroutine(StressLooseDelay());
            }

            Color m_MouseOverColor;
            scaledValue = (float)stress / ((float)maxStress);
            m_MouseOverColor = new Color(1f, 1f, 1f, scaledValue);
            // show the stress
            m_Renderer.material.color = m_MouseOverColor;
        }

        public ItemInstance MineAsteroid(double amountMined,float speed)
        {
            if (!waitingForMiningTick)
            {
                waitingForMiningTick = true;
                
                StartCoroutine(MineDelay(amountMined,speed));
                return new ItemInstance(GetRandomFromList(), amountMined);
            }
            return null;
        }

        IEnumerator MineDelay(double  mined,float speed)
        {
            yield return new WaitForSeconds(speed);
            waitingForMiningTick = false;
            stress += stressGain;

            //Calculate amount of ore to give;
            oreAmount -= mined;

            if (stress > maxStress || oreAmount <= 0f)
            {
                //Explode
                Destroy(this.gameObject);
            }

        }


        IEnumerator StressLooseDelay()
        {
            yield return new WaitForSeconds(tickUpdate);
            stress -= stressLoose;
            stress = Mathf.Clamp((float)stress, 0, maxStress * 2);
            waitingForStressTick = false;
        }

        private Raw GetRandomOretype()
        {
            Object[] OreTypes = Resources.LoadAll("Items/Raw",typeof(Raw));
            return OreTypes[Random.Range(0,OreTypes.Length)]as Raw;
        }

        private int GetAmountOfOreTypes()
        {
            Object[] OreTypes = Resources.LoadAll("Items/Raw", typeof(Raw));
            return OreTypes.Length;
        }

        private Raw GetRandomFromList()
        {
            int a = Random.Range(0, ores.Count);
            Debug.Log("Returning: " +ores[a].itemName);
            return ores[a];
        }

    }
}