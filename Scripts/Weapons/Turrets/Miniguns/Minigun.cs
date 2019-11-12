using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.ControlledObjects.Weapon;

namespace Scripts.ControlledObjects.Weapon.Turret.Railgun
{
    public class Minigun : TurretRotatorBase
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