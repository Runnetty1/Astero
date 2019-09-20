
using UnityEngine;

namespace Assets.Scripts.LocatingSystem
{
    class PlanetaryBody : SystemBody
    {
        public SystemBody OrbitingParent;
        
        public bool habitable;
        public bool terraformable;
        public bool hasSurface;
        public enum Size { Small, Medium, Large};
        public Size size;

    }
}
