using Assets.Scripts.Data;
using UnityEngine;
namespace Assets.Scripts.ItemSystem.Events
{
    public class AttributeEvents
    {
        public delegate void AttributeChanged(ActorData ship);
        public static event AttributeChanged OnAttributeChanged;

        public void AttributeChangedEvent(ActorData ship) => OnAttributeChanged?.Invoke(ship);

    }
}
