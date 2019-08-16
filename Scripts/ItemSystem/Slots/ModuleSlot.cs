namespace Scripts.ItemSystem.Slots
{
    [System.Serializable]
    public class ModuleSlot
    {
        public int slotSize;

        public ModuleSlot()
        {
        }

        public ModuleSlot(int slotSize)
        {
            this.slotSize = slotSize;
        }
    }
}