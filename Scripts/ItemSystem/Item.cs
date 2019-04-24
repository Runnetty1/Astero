using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem.Core
{
    public class Item : Stackable
    {
        public string itemName;
        public Sprite sprite;
        public enum ItemRarity {Common,Uncommon,Rare, }
        public enum ItemType {ITEM,WEAPON,CONSUMABLE,PLACEABLE,MOUNT,BACK,JEWELERY,SIGIL,VANITY,GADGET,PET,HEAD,BODY,LEG}
        public ItemType itemType = ItemType.ITEM;
        public string description;
        public GameObject worldItem;

        public bool HasSameName(string toTest)
        {
            if (itemName.ToLower() == toTest.ToLower())
            {
                return true;
            }
            return false;
        }

        public override void Start()
        {
            base.Start();
            //this.GetComponent<Item>
        }
    }
}