
using UnityEngine;
using Assets.Scripts.ItemSystem.ItemTypes;
using Assets.Scripts.Data;

namespace Assets.Scripts.ItemSystem
{
    class DroneBay : Inventory
    {
        public float droneRange;
        public float addedDroneRange;
        public override void AddItem(ItemInstance item, bool useStack)
        {
            if (item.item is DroneItem)
            {
                base.AddItem(item, useStack);
            }
            else
            {
                Debug.Log("Can not add a non DroneItem to dronebay");
            }
        }
        public override void AttributeEvents_OnAttributeChanged(ActorData ship)
        {
            base.AttributeEvents_OnAttributeChanged(ship);
            this.addedMaxSize += ship.GetAttribute(Data.Attribute.AttributeName.DroneCapacity)._value;
            this.addedDroneRange += ship.GetAttribute(Data.Attribute.AttributeName.DroneRange)._value;
        }
    }
}
