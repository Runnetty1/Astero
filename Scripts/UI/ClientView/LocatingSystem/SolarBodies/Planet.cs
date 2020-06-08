

using UnityEngine;

namespace Assets.Scripts.LocatingSystem.SolarBodies
{
    class Planet : PlanetaryBody
    {
        public enum PlanetType { City,Desert,Gas,Ice,Lava,Ocean,Terra};
        public PlanetType planetType = PlanetType.Terra;
        
        void OnTriggerStay2D(Collider2D col)
        {
            //Player Entered  and is not moving to fast
            if (col.tag == "Player" && col.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude < 20f)
            {
                //Trigger Window opening

            }
            //If the player 
        }
    }
}
