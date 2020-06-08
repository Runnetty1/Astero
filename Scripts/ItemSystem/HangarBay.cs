
using UnityEngine;
using Assets.Scripts.ItemSystem.ItemTypes;
using Assets.Scripts.Data;

namespace Assets.Scripts.ItemSystem
{
    class HangarBay:Inventory
    {
        public override void AddItem(ItemInstance item, bool useStack)
        {
            if (item.item is HangarItem)
            {
                base.AddItem(item, useStack);
            }
            else
            {
                Debug.Log("Can not add a non Hangar item to Hangarbay");
            }
        }

        public override void ItemPickupCheck(ItemInstance item, GameObject owner)
        {
            if (item.item is HangarItem)
            {
                base.ItemPickupCheck(item, owner);
            }
        }
        public override void AttributeEvents_OnAttributeChanged(ActorData ship)
        {
            base.AttributeEvents_OnAttributeChanged(ship);
            this.addedMaxSize += ship.GetAttribute(Data.Attribute.AttributeName.HangarCapacity)._value;
        }
    }
}
