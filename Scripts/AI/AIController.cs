
using UnityEngine;

namespace Assets.Scripts.AI
{
    class AIController:MonoBehaviour
    {
        [Header("Debug")]
        public bool debug;


        [Header("Sensor settings")]
        public float maxSensorRange;
        public float approachRange;
        public float attackRange;

        
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
