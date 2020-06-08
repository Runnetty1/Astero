using Assets.Scripts.Data;
using Assets.Scripts.ItemSystem.Slots;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Modules
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "UpgradeModule", menuName = "Astero/Ship/Module", order = 1)]
    public class UpgradeModule : Module
    {
        [Header("UpgradeModule")]
        public ModuleSlot.SpesifficType type;
       
        public List<Attribute> attributes;
        

        public bool HasSameAttributeName(Attribute.AttributeName name)
        {
            foreach(Attribute attribute in attributes)
            {
                if (attribute._name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public Attribute GetAttribute(Attribute.AttributeName name)
        {
            foreach (Attribute attribute in attributes)
            {
                if (attribute._name == name)
                {
                    return attribute;
                }
            }
            return null;
        }

    }
}