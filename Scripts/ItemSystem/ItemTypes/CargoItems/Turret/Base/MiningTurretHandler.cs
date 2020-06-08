
using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Interactables;
using UnityEngine;

namespace Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Turret.Base
{
    class MiningTurretHandler:TurretRotatorHandler
    {
        public LineRenderer laserRender;
        public float LaserMaxDist;
        public LayerMask layerMask;

        public Transform otherPos;

        public List<ItemInstance> oreMined;

        public GameObject laserExplotion;
        private bool isFiring;
        

        public MiningTurretHandler(LineRenderer laserRender, float laserMaxDist, LayerMask layerMask, Transform otherPos, List<ItemInstance> oreMined)
        {
            this.laserRender = laserRender;
            LaserMaxDist = laserMaxDist;
            this.layerMask = layerMask;
            this.otherPos = otherPos;
            this.oreMined = oreMined;
        }

        public MiningTurretHandler()
        {
        }

        public override void Activate()
        {
            
            Quaternion rotat = firePoint.transform.rotation;
            laserRender.SetPosition(0,firePoint.transform.position);
            
            Vector2 dir = otherPos.position - firePoint.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            
            // Cast a ray straight down.
            RaycastHit2D hit = Physics2D.Raycast(firePoint.transform.position, dir, LaserMaxDist, layerMask,-Mathf.Infinity, Mathf.Infinity);


            //Debug.DrawLine(firePoint.transform.position, dir*LaserMaxDist);
            //laserRender.SetPosition(1, firePoint.transform.TransformPoint(Vector3.right * LaserMaxDist));
            // If it hits something...
            if (hit.collider !=null)
            {
                laserRender.SetPosition(1, hit.point);
                Debug.Log("Hit "+ hit.collider.name);
                ItemInstance ore = hit.transform.gameObject.GetComponent<Asteroid>().MineAsteroid((turretData as MiningTurret).extractionAmount, (turretData as MiningTurret).miningSpeed);
                if (ore != null)
                {
                    oreMined.Add(ore);
                }
                Vector3 incomingVec = hit.point - (Vector2)firePoint.transform.position;
                Vector3 reflectVec = Vector3.Reflect(incomingVec, hit.normal);
                Instantiate(laserExplotion, hit.point, Quaternion.Euler(reflectVec));
            }
            else
            {
                laserRender.SetPosition(1, otherPos.position);

                // Debug.Log("no hit");
            }
        }

        public override void DeActivate()
        {
           
                laserRender.SetPosition(0, firePoint.transform.position);
                laserRender.SetPosition(1, firePoint.transform.position);
                 
        }

        public override void OnEnable()
        {
            base.OnEnable();
            
        }

        public override void Update()
        {
            base.Update();
            
        }

        public override void InstallTurret(TurretItem item)
        {
            base.InstallTurret(item);
            laserRender.material= ((item as MiningTurret).LaserMaterial);
        }

        public bool HasOre()
        {
            return oreMined.Count > 0 && oreMined!=null;
        }

        public ItemInstance GetOre()
        {
            if (oreMined != null)
            {
                ItemInstance t = oreMined[0];
                oreMined.RemoveAt(0);
                return t;
            }
            return null;
        }
    }
}
