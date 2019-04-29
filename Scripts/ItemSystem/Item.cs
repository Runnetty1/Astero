using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RRG.InventorySystem
{
    public class Item : ScriptableObject
    {
        public string itemName;
        public Sprite sprite;
        public enum ItemRarity {Common,Uncommon,Rare};
        public ItemRarity rarity;

        public double amount;
        public string description;
        
    }
}