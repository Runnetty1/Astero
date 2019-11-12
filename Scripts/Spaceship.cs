
using UnityEngine;
using Scripts.ItemSystem;

using Scripts.ItemSystem.ItemTypes.CargoItems;
using Scripts.ItemSystem.ItemTypes;
using Scripts.ItemSystem.Events;
using Assets.Scripts.ItemSystem.ItemTypes;
using Assets.Scripts.LocatingSystem;

namespace Scripts.ControlledObjects
{
    [System.Serializable]
    public class Spaceship : ScanableObject
    {
        public Actor owner;
        public ModuleSlots ModuleSlots;
        public Inventory cargoBay;

        public bool hasHangar;
        public Inventory hangarBay;
        public bool hasOreBay;
        public Inventory oreBay;

        public bool hasDroneBay;
        public Inventory droneBay;

        public GameObject hitAudio;
        public AudioClip[] clip;

        public Radar radar;

        //ShipMovement
        //Ship Turrets
        //Ship scanner

        public void AddItem(ItemInstance item, bool useStack)
        {
            if(item.item is CargoItem)
            {
                cargoBay.AddItem(item, useStack);
            }
            if(item.item is HangarItem && hasHangar)
            {
                hangarBay.AddItem(item, useStack);
            }
            if(item.item is Ore && hasOreBay)
            {
                oreBay.AddItem(item, useStack);
            }
            if (item.item is DroneItem && hasDroneBay)
            {
                droneBay.AddItem(item, useStack);
            }
        }

        public void RemoveItemsWithName(string name)
        {

        }

        public void InstallModule(Module module,int id)
        {
            ModuleSlots.InstallModule(module,id);

        }

        public void UninstallModule(Module mod)
        {
            ItemInstance item = new ItemInstance(mod, 1);
            ModuleSlots.UninstallModule(mod);
            AddItem(item,false);
        }


        //OnSuccessfulModuleInstall
        private void OnEnable()
        {
            radar = GetComponent<Radar>();
            if (radar == null)
            {
                gameObject.AddComponent<Radar>();
            }
            ItemEvents.OnItemRemoved += cargoBay.RemoveItem;
            ModuleEvents.OnModuleInstallSuccsess += cargoBay.RemoveInstalledModule;
        }
        //OnSuccessfulModuleUninstall

        private void OnCollisionEnter2D(Collision2D collision)
        {
          
            hitAudio.GetComponent<AudioSource>().PlayOneShot(clip[Random.Range(0, clip.Length)]);
        }
    }
}