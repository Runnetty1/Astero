
namespace Assets.Scripts.LocatingSystem.SolarBodies
{
    class Star : SystemBody
    {
        public enum Type { Blue,White,Yellow,Orange,Red};
        public enum SizeClass { Dwarf, Normal, Giant, SuperGiant };
        public Type type;
        public SizeClass sizeClass;

    }
}
