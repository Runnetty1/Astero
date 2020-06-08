using UnityEngine;
using System.Collections;

namespace Assets.Scripts.ItemSystem.ItemTypes.CargoItems
{
    [CreateAssetMenu(fileName = "ComponentItem", menuName = "Astero/Item/Component", order = 1)]
    [System.Serializable]
    public class Component : CargoItem
    {
        Component()
        {
            description = "Parts made from processed materials. Ready to be used in further construction.";
        }
    }
}