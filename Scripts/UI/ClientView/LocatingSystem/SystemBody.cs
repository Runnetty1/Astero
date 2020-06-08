using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.LocatingSystem
{
    class SystemBody:ScanableObject
    {
        public float TemperatureC=0;
        //compared to earth
        public float Radius=0;
        public float EarthMass=0;

        public bool knownObject=false;
    }
}
