using UnityEngine;

namespace Assets.Scripts.Data
{
   
    [System.Serializable]
    public class Attribute
    {
        [SerializeField]
        public enum AttributeName {
            Acceleration,
            TurnSpeed,
            CargoCapacity,
            OreCapacity,
            HangarCapacity,
            WarpSpeed,
            RadarRange,
            DroneCapacity,
            DroneRange,
            Shield,
            Hull,
            SensorRange
            };
        public AttributeName _name;
        public float _value;

        public Attribute(AttributeName name, float value)
        {
            _name = name;
            _value = value;
        }

        public Attribute()
        {
        }
    }
}
