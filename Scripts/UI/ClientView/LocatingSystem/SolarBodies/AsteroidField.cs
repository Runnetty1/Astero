using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.LocatingSystem.SolarBodies
{
    class AsteroidField : SystemBody
    {
        public enum ResourceType {none,Ice,Iron,Copper,Platinum,Gold}
        public ResourceType main = ResourceType.Copper;
        public ResourceType secondary = ResourceType.none;
        public ResourceType tertiary = ResourceType.none;
    }
}
