using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.VFX
{
    public class ShipThrusterController : MonoBehaviour
    {
        public enum MainThrusterLayout { Double, Single, DoubleManouvering };
        public MainThrusterLayout mainLayout = MainThrusterLayout.Single;

        public enum ShipMoveDir { Left, Right, RotLeft, RotRight, none };
        public ShipMoveDir shipMovementDirection = ShipMoveDir.none;
        public enum ShipMove { Forward, Backward, none };
        public ShipMove state = ShipMove.none;
        public GameObject[] MainLeft, MainRight, front;
        public GameObject[] backLeft, backRight, frontRight, frontLeft;

        public GameObject MainThrusterSound;
        public GameObject SideThrusterSound;

        public float thrusterDeadZone = 0.5f;

        public void Thruster(GameObject[] thrusters, bool state)
        {
            foreach (GameObject g in thrusters)
            {
                g.SetActive(state);
            }
        }
        public Vector2 localMoveSpeed;

        public void Update()
        {
            localMoveSpeed = (Vector2)transform.InverseTransformDirection(transform.GetComponent<Rigidbody2D>().velocity);


            if (shipMovementDirection == ShipMoveDir.Left)
            {
                Thruster(backLeft, true);
                Thruster(frontRight, true);

            }
            else
            {
                Thruster(backLeft, false);
                Thruster(frontRight, false);
            }
            if (shipMovementDirection == ShipMoveDir.Right)
            {
                Thruster(backRight, true);
                Thruster(frontLeft, true);

            }
            else
            {
                Thruster(backRight, false);
                Thruster(frontLeft, false);

            }

            if (localMoveSpeed.y > thrusterDeadZone && shipMovementDirection != ShipMoveDir.Left)
            {
                Thruster(backLeft, true);
                Thruster(frontLeft, true);

            }
            else if (localMoveSpeed.y < -thrusterDeadZone && shipMovementDirection != ShipMoveDir.Right)
            {
                Thruster(frontRight, true);
                Thruster(backRight, true);

            }
            else if (shipMovementDirection == ShipMoveDir.none)
            {
                Thruster(backLeft, false);
                Thruster(frontLeft, false);
                Thruster(frontRight, false);
                Thruster(backRight, false);

            }

            if (state == ShipMove.Forward)
            {
                Thruster(MainLeft, true);
                Thruster(MainRight, true);
                Thruster(front, false);

            }
            else if (localMoveSpeed.x > thrusterDeadZone && state != ShipMove.Forward)
            {
                Thruster(front, true);
                Thruster(MainLeft, false);
                Thruster(MainRight, false);

            }
            else if (state == ShipMove.Backward)
            {
                Thruster(front, true);
                Thruster(MainLeft, false);
                Thruster(MainRight, false);
            }
            else if (localMoveSpeed.x < -thrusterDeadZone && state != ShipMove.Backward)
            {
                Thruster(MainLeft, true);
                Thruster(MainRight, true);
                Thruster(front, false);
            }
            else
            {
                Thruster(MainLeft, false);
                Thruster(MainRight, false);
                Thruster(front, false);
            }
            AudioUpdate();

        }
        public void AudioUpdate()
        {

            if (state == ShipMove.Forward && !MainThrusterSound.GetComponent<AudioSource>().isPlaying)
            {
                //mainthuster

                MainThrusterSound.GetComponent<AudioSource>().Play();
            }
            else if (state != ShipMove.Forward)
            {
                MainThrusterSound.GetComponent<AudioSource>().Stop();
            }


            if (shipMovementDirection != ShipMoveDir.none && !SideThrusterSound.GetComponent<AudioSource>().isPlaying)
            {
                //side thrusters
                SideThrusterSound.GetComponent<AudioSource>().Play();
            }
            else if (shipMovementDirection == ShipMoveDir.none)
            {
                SideThrusterSound.GetComponent<AudioSource>().Stop();
            }
        }

    }
}