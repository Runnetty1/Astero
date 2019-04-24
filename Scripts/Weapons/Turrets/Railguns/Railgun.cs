using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RRG.ControlledObjects.Weapon;

namespace RRG.ControlledObjects.Weapon.Turret.Railgun
{
    public class Railgun : TurretRotatorBase
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