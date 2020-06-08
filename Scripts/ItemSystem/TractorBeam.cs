using Assets.Scripts.Data;
using Assets.Scripts.ItemSystem.Events;
using Assets.Scripts.ItemSystem.ItemTypes;
using UnityEngine;

namespace Assets.Scripts.ItemSystem
{
    public class TractorBeam : MonoBehaviour
    {

        void OnTriggerEnter2D(Collider2D col)
        {
            
            if (col.transform.tag == "Item")
            {
                new ItemEvents().ItemPickupEvent(col.gameObject.GetComponent<ItemContainer>().item, transform.parent.gameObject);
                Destroy(col.gameObject);  
            }
        }
    }
}
