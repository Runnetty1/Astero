

using Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Turret.Base;
using Assets.Scripts.LocatingSystem;
using System.Collections.Generic;

namespace Assets.Scripts.Util
{
    public class TurretGroup
    {
        public bool Enabled;
        public enum FireMode { Manual, Auto, PointDefense};
        public FireMode firemode = FireMode.Manual;
        
        public List<TurretBase> turrets;

        public List<ScanableObject> HostilesInRange;
        public int currentHostile = 0;

        public void ActivateTurrets()
        { 
            foreach(TurretBase turret in turrets)
            {
                turret.Activate();
            }  
        }

        public void SetTargets()
        {
            //Go throug each turret and assign enemies
            //one turret per enemy, unless there are more turrets than enemies
            //but if there is more enemies than turrets we wont assign new targets until the list has changed.
            foreach (TurretBase turret in turrets)
            {
                if (turret is TurretRotatorHandler)
                {
                    if ((currentHostile + 1) < HostilesInRange.Count)
                    {
                        currentHostile++;
                    }
                    else
                    {
                        currentHostile = 0;
                    }
                    (turret as TurretRotatorHandler).targetObject = HostilesInRange[currentHostile].gameObject;
                }

            }
        }
    }
}
