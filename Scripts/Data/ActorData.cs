
using UnityEngine;

using Assets.Scripts.LocatingSystem;
using Assets.Scripts.ItemSystem;
using Assets.Scripts.ItemSystem.ItemTypes.CargoItems;
using Assets.Scripts.ItemSystem.Events;
using Assets.Scripts.ItemSystem.ItemTypes;
using Assets.Scripts.ActorControllers;
using Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Modules;
using System.Collections.Generic;

namespace Assets.Scripts.Data
{
    [System.Serializable]
    public class ActorData : BeaconObject
    {
        public UserData owner;
        public enum ShipClass
        {
            Drone,
            Pod,
            Gunship,
            Bomber,
            Corvette,
            Frigate,
            Destroyer,
            Cruiser,
            Battleship,
            Carrier,
            Dreadnaught,
            Titan,
            Mining_Small,
            Mining_Large,
            Transport_small,
            Transport_large
        }
        public ShipClass shipClass;
        public List<Attribute> DefaultShipAttributes;
        //public ModuleUpgradeMaster ModuleSlots;

        public GameObject hitAudio;
        public AudioClip[] shipHitAudioClips;

        public Radar radar;
        
        public TurretMaster turretMaster;
        [HideInInspector]
        public List<Attribute> shipAttributes;
        
        

        public Attribute GetAttribute(Attribute.AttributeName name)
        {
            foreach(Attribute at in shipAttributes)
            {
                if(at._name == name)
                {
                    return at;
                }
            }
            return null;
        }
        public string GetAttributesToString()
        {
            string a="";
            foreach(Attribute at in shipAttributes)
            {
                a += at._value + " \n";
            }
            return a;
        }


       

        private void OnEnable()
        {
            radar = GetComponent<Radar>();
            if (radar == null)
            {
                gameObject.AddComponent<Radar>();
                radar = GetComponent<Radar>();
            }


            /*
            ItemEvents.OnItemRemoved += cargoBay.RemoveItem;
            ModuleEvents.OnModuleInstallSuccsess += cargoBay.RemoveInstalledModule;
            ModuleEvents.OnModuleInstallSuccsess += UpgradeModules;
            Inventory.OnInventoryFull += TossOutItem;
            */
        }
        /*
        private void TossOutItem(ItemInstance item)
        {
            GameObject g = Instantiate(Resources.Load("Items/ItemCapsule") as GameObject,transform.position,Quaternion.identity);
            g.GetComponent<ItemContainer>().AddItem(item);
            g.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-20,20), Random.Range(-20, 20));
        }

        
        */

        //Audio
        private void OnCollisionEnter2D(Collision2D collision)
        {
          
            hitAudio.GetComponent<AudioSource>().PlayOneShot(shipHitAudioClips[Random.Range(0, shipHitAudioClips.Length)]);
        }

    }
}