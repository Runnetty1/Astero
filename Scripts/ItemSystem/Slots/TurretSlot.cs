using Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Modules;
using Assets.Scripts.ItemSystem.Events;
using UnityEngine;
using Assets.Scripts.Data;
using Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Turret;
using Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Turret.Base;

namespace Assets.Scripts.ItemSystem.Slots
{
    [System.Serializable]
    public class TurretSlot:MonoBehaviour
    {
        public enum SpesifficType {Universal,ToolTurret,WeaponTurret}
        public SpesifficType spesifficType;
        public TurretItem turret;
        public TurretBase turretObj;
        public int slotSize;

        public TurretSlot()
        {
        }


        public void InstallTurret(TurretItem TurretItem,ActorData ship)
        {
            if (turret != null)
            {
                //theres a turret here allready uninstall it
                UninstallTurret(ship);
            }
            if(TurretItem.Size != slotSize)
            {
                Debug.Log("Cant install, wrong size");
                return;
            }
            if (TurretItem.name==spesifficType.ToString() || spesifficType==SpesifficType.Universal)
            {
                Debug.Log("Can install");
                this.turret = TurretItem;

                new TurretEvents().TurretInstallSuccsessEvent(TurretItem,ship);

                if (TurretItem is WeaponTurret)
                {
                    GameObject g = Instantiate(Resources.Load("Weapons/TurretBaseObjects/WeaponTurretObject") as GameObject, transform);
                    g.GetComponent<WeaponTurretHandler>().InstallTurret(TurretItem as WeaponTurret);
                    turretObj = g.GetComponent<WeaponTurretHandler>();
                }

                if (TurretItem is MiningTurret)
                {
                    GameObject g = Instantiate(Resources.Load("Weapons/TurretBaseObjects/MiningTurretObject") as GameObject, transform);
                    g.GetComponent<MiningTurretHandler>().InstallTurret(TurretItem as MiningTurret);
                    turretObj = g.GetComponent<MiningTurretHandler>();
                }
            }
            else
            {
                Debug.Log("Cant install: " + TurretItem.name + " On Turret slot type: "+ spesifficType.ToString());
                
            }
        }

        public void UninstallTurret(ActorData ship)
        {
            ItemInstance temp = new ItemInstance(turret as TurretItem, 1);
            new ItemEvents().ItemPickupEvent(temp, ship.gameObject);
            this.turret = null;
            Destroy(transform.GetChild(0).gameObject);
            new TurretEvents().TurretUninstallSuccsessEvent(turret);
        }
    }
}