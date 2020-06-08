
using UnityEngine;
using Assets.Scripts.ItemSystem.ItemTypes;
using Assets.Scripts.ItemSystem.Events;
using Assets.Scripts.Data;
using Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Turret;
using System;

namespace Assets.Scripts.ItemSystem
{
    class CargoBay : Inventory
    {
        public override void AddItem(ItemInstance item, bool useStack)
        {
            if (item.item is CargoItem)
            {
                base.AddItem(item, useStack);
            }
            else
            {
                Debug.Log("Can not add a non CargoItem to cargobay");
            }
        }

        public override void ItemPickupCheck(ItemInstance item, GameObject owner)
        {
            if (item.item is CargoItem)
            {
                base.ItemPickupCheck(item, owner);
            }  
        }

        public override void OnEnable()
        {
            ModuleEvents.OnModuleInstallSuccsess += RemoveInstalledItem;
            TurretEvents.OnTurretInstallSuccsess += RemoveInstalledItem;
            base.OnEnable();
        }

        public override void OnDisable()
        {
            ModuleEvents.OnModuleInstallSuccsess -= RemoveInstalledItem;
            TurretEvents.OnTurretInstallSuccsess -= RemoveInstalledItem;
            base.OnDisable();
        }

        public override void AttributeEvents_OnAttributeChanged(ActorData ship)
        {
            base.AttributeEvents_OnAttributeChanged(ship);
            this.addedMaxSize += ship.GetAttribute(Data.Attribute.AttributeName.CargoCapacity)._value;
        }
    }
}
