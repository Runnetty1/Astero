using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.LocatingSystem
{
    class SystemBody:ScanableObject
    {
        public float TemperatureC;
        //compared to earth
        public float Radius;
        public float EarthMass;

        public bool knownObject;
    }
}
