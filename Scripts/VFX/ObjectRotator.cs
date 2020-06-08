using UnityEngine;
using System.Collections;

namespace Assets.Scripts.VFX
{
    public class ObjectRotator : MonoBehaviour
    {
        public Transform[] sunmoon;
        public float dayCycleInMinutes = 1;
        public bool _rotateOnX;
        public bool _rotateOnY;
        public bool _rotateOnZ;
        public bool _rotateMinusX;
        public bool _rotateMinusY;
        public bool _rotateMinusZ;
        private const float _sec = 1;
        private const float _min = 60 * _sec;
        private const float _hour = 60 * _min;
        private const float _day = 24 * _hour;

        private const float _degPerSec = 360 / _day;

        private float _degRot;


        void Start()
        {
            _degRot = _degPerSec * _day / (dayCycleInMinutes * _min);
        }

        void Update()
        {
            _degRot = _degPerSec * _day / (dayCycleInMinutes * _min);
            if (_rotateOnX)
            {
                for (int i = 0; i < sunmoon.Length; i++)
                {
                    sunmoon[i].Rotate(new Vector3(_degRot, 0, 0) * Time.deltaTime);
                }
            }
            if (_rotateOnY)
            {
                for (int i = 0; i < sunmoon.Length; i++)
                {
                    sunmoon[i].Rotate(new Vector3(0, _degRot, 0) * Time.deltaTime);
                }
            }
            if (_rotateOnZ)
            {
                for (int i = 0; i < sunmoon.Length; i++)
                {
                    sunmoon[i].Rotate(new Vector3(0, 0, _degRot) * Time.deltaTime);
                }
            }
            if (_rotateMinusX)
            {
                for (int i = 0; i < sunmoon.Length; i++)
                {
                    sunmoon[i].Rotate(new Vector3(-_degRot, 0, 0) * Time.deltaTime);
                }
            }
            if (_rotateMinusY)
            {
                for (int i = 0; i < sunmoon.Length; i++)
                {
                    sunmoon[i].Rotate(new Vector3(0, -_degRot, 0) * Time.deltaTime);
                }
            }
            if (_rotateMinusZ)
            {
                for (int i = 0; i < sunmoon.Length; i++)
                {
                    sunmoon[i].Rotate(new Vector3(0, 0, -_degRot) * Time.deltaTime);
                }
            }
        }
    }
}