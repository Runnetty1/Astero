using Assets.Scripts.Data;
using Assets.Scripts.ItemSystem;
using Assets.Scripts.ItemSystem.Events;
using Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Turret;
using Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Turret.Base;
using Assets.Scripts.ItemSystem.Slots;
using Assets.Scripts.LocatingSystem;
using Assets.Scripts.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ActorControllers
{
    public class TurretMaster : MonoBehaviour
    {
        public List<TurretGroup> groups;

        public List<TurretSlot> turretSlots;
        public GameObject turretParent;


        public float PointDefenseRange = 100;
        //not in use yet
        public float AutoDefenseRange = 200;
        public bool HostileCheckCooldown,OreCheckCoolDown;
        public ScanableObject Target;

        public List<ScanableObject> HostilesInPointDefenseRange;

        public delegate void TurretFiringEvent(bool fire);
        public static event TurretFiringEvent OnTurretFiringEvent;
        public void Fire(bool fire) => OnTurretFiringEvent?.Invoke(fire);

        public void Start()
        {
            turretSlots.Clear();
            foreach(Transform child in turretParent.transform)
            {
                turretSlots.Add(child.gameObject.GetComponent<TurretSlot>());
            }
            
        }

        public void InstallTurret(TurretItem turretItem, ActorData ship)
        {
            if (ship == GetComponent<ActorData>())
            {
                foreach (TurretSlot slot in turretSlots)
                {
                    if (slot.turret==null)
                    {
                        slot.InstallTurret(turretItem,GetComponent<ActorData>());
                        break;
                    }
                }
            }
        }

        public void UninstallTurret(TurretItem turretItem)
        {
            foreach (TurretSlot slot in turretSlots)
            {
                if (turretItem == slot.turret)
                {
                    slot.UninstallTurret(GetComponent<ActorData>());
                }
            }

        }




        private void Update()
        {
            if (!HostileCheckCooldown)
            {
                HostileCheckCooldown = true;
                HostilesInPointDefenseRange = GetComponent<Radar>().GetHostileObjectsInRange(PointDefenseRange);
                StartCoroutine(CheckForHostileTick());
            }

            //Might need a check on if the hostile list has changed then set the targets
            if (HostilesInPointDefenseRange.Count > 0)
            {
                foreach(TurretGroup group in groups)
                {
                    if(group.Enabled && group.firemode == TurretGroup.FireMode.PointDefense)
                    {
                        group.HostilesInRange = HostilesInPointDefenseRange;// Might be to often and laggy-
                        group.SetTargets(); // Might be to often and laggy-
                        group.ActivateTurrets(); //has no inpackt on fps because the fire method checks for when it can fire
                    }
                }
            }
            if (!OreCheckCoolDown)
            {
                OreCheckCoolDown = true;
                foreach (TurretSlot b in turretSlots)
                {
                    if (b.turretObj is MiningTurretHandler)
                    {
                        if ((b.turretObj as MiningTurretHandler).HasOre())
                        {
                            ItemInstance minedOre = (b.turretObj as MiningTurretHandler).GetOre();
                            if (minedOre != null) {
                                GetComponent<OreBay>().AddItem(minedOre, true);
                            }
                        }
                    }
                }
                StartCoroutine(TransferOreTick());
            }
        }

        private void OnEnable()
        {
            OnTurretFiringEvent += ActivateTurrets;
            TurretEvents.OnTurretUninstall += UninstallTurret;
        }

        public void ActivateTurrets(bool fire)
        {
            
            if (groups != null && groups.Count > 0)
            {
                foreach (TurretGroup group in groups)
                {
                    if (group.Enabled && group.firemode != TurretGroup.FireMode.PointDefense)
                    {
                        group.HostilesInRange.Add(Target);// Might be to often and laggy-

                        if (fire) {
                            group.ActivateTurrets(); //has no inpackt on fps because the fire method checks for when it can fire
                        }
                        else
                        {
                            //group.De
                        }
                    }
                }
            }
            else
            {
                if (turretSlots.Count > 0)
                {
                    foreach (TurretSlot slot in turretSlots)
                    {
                        if (slot.turretObj is TurretRotatorHandler)
                        {
                            if (Target != null)
                            {
                                (slot.turretObj as TurretRotatorHandler).targetObject = Target.gameObject;
                            }
                        }
                        if (fire)
                        {
                            if (slot.turretObj != null)
                            {
                                slot.turretObj.Activate();
                            }
                        }
                        else
                        {
                            if (slot.turretObj != null)
                            {
                                slot.turretObj.DeActivate();
                            }
                        }
                    }
                }
            }
        }


        IEnumerator CheckForHostileTick()
        {
            //set update tick as a constant
            yield return new WaitForSeconds(2);
            HostileCheckCooldown = false;
        }

        IEnumerator TransferOreTick()
        {
            //set update tick as a constant
            yield return new WaitForSeconds(0.01f);
            OreCheckCoolDown = false;
        }

        public float GetDistance(Transform a, Transform b)
        {
            return Vector3.Distance(a.position, b.position);
        }

    }
}
