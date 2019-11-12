
namespace Scripts.ItemSystem.ItemTypes.CargoItems.Modules
{
    [System.Serializable]
    public abstract class InventoryModule : InternalModule
    {
        public double sizeUpgrade;

        public override string ModuleType
        {
            get
            {
                return typeof(InternalModule).Name;
            }
        }
    }
}

