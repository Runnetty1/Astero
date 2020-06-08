
namespace Assets.Scripts.ItemSystem
{
    [System.Serializable]
    public class ItemInstance
    {
        // Reference to scriptable object "template".
        public Item item;
        public double amount;

        public ItemInstance(Item item, double amount)
        {
            this.item = item;
            this.amount = amount;
        } 
    }
}