using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RRG.ControlledObjects.Weapon;

namespace RRG.ControlledObjects.Weapon.Turret.Railgun
{
    public class MiningLaser : TurretRotatorBase
    {
        private void Update()
        {
            TurnToTarget();
        }


        public override void OnEnable()
        {
            base.OnEnable();
        }
    }
}