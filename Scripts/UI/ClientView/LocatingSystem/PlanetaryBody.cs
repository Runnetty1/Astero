
using UnityEngine;

namespace Assets.Scripts.LocatingSystem
{
    class PlanetaryBody : SystemBody
    {
        #pragma warning disable CS0649 // Add readonly modifier
        public SystemBody OrbitingParent;
        #pragma warning restore CS0649 // Add readonly modifier    
        
        public bool habitable=false;
        public bool terraformable=false;
        public bool hasSurface=false;
        public enum Size { Small, Medium, Large};
        public Size size=Size.Small;

    }
}
