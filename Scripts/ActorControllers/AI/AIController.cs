
using UnityEngine;

namespace Assets.Scripts.AI
{
    class AIController:MonoBehaviour
    {

#if UNITY_EDITOR
        [Header("Debug")]
#pragma warning disable CS0649 // Add readonly modifier
        public bool debug;
#pragma warning restore CS0649 // Add readonly modifier
#endif

        [Header("Sensor settings")]
        public float maxSensorRange =0;
        public float approachRange = 0;
        public float attackRange=0;

        
        public enum Personality { Hostile,Defensive,Passive}
        [Header("personality settings")]
        public Personality personality = Personality.Passive;

        public void Awareness() {


        }

        private void Update()
        {
            Awareness();
            if (personality == Personality.Hostile)
            {
                //when in range attack
            } 
            else if (personality == Personality.Defensive)
            {
                //if shot at, retaliate
            }
            else if (personality == Personality.Passive) {
                //leave
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            if (debug)
            {
                Gizmos.color = Color.white;
                Gizmos.DrawWireSphere(transform.position, maxSensorRange);
                
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(transform.position, approachRange);
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position, attackRange);
            }
        }
#endif
    }


}
