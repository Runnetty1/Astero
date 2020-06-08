using UnityEngine;
using System.Collections;

namespace Assets.Scripts.ItemSystem.ItemTypes.CargoItems
{
    [CreateAssetMenu(fileName = "RefinedItem", menuName = "Astero/Item/Refined", order = 1)]
    [System.Serializable]
    public class Refined : CargoItem
    {
        Refined()
        {
            description = "Processed materials ready to be used.";
        }
    }
}