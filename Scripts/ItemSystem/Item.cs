using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RRG.InventorySystem
{
    [System.Serializable]
    public abstract class Item : ScriptableObject
    {
        public string itemName;
        public Sprite sprite;
        public enum ItemRarity {Common,Uncommon,Rare};
        public ItemRarity rarity;

        public string description;


        public bool Equals(Item a)
        {
            if (this.itemName == a.itemName)
                return true;
            return false;
        }

        
    }
}