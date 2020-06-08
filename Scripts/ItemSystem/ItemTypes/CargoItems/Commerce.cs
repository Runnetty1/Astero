using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.ItemSystem.ItemTypes.CargoItems
{
    [CreateAssetMenu(fileName = "CommerceItem", menuName = "Astero/Item/commerce", order = 1)]
    [System.Serializable]
    public class Commerce : CargoItem
    {
        Commerce()
        {
            description = "Can't be used in crafting. Exlusivly used to gain income. Creates no offproduct.";
        }
    }
}
