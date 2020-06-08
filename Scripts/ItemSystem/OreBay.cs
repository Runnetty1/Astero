
using UnityEngine;
using Assets.Scripts.ItemSystem.ItemTypes;
using Assets.Scripts.Data;

namespace Assets.Scripts.ItemSystem
{
    class OreBay:Inventory
    {
        public override void AddItem(ItemInstance item, bool useStack)
        {
            if (item.item is Raw)
            {
                base.AddItem(item, useStack);
            }
            else
            {
                Debug.Log("Can not add a non Ore item to orebay");
            }
        }

        public override void ItemPickupCheck(ItemInstance item, GameObject owner)
        {
            if (item.item is Raw)
            {
                base.ItemPickupCheck(item, owner);
            }
        }

        public override void AttributeEvents_OnAttributeChanged(ActorData ship)
        {
            base.AttributeEvents_OnAttributeChanged(ship);
            this.addedMaxSize += ship.GetAttribute(Data.Attribute.AttributeName.OreCapacity)._value;
        }
    }
}
