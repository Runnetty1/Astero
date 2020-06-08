using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ItemSystem.ItemTypes
{
    [CreateAssetMenu(fileName = "RawItem", menuName = "Astero/Item/Raw", order = 1)]
    [System.Serializable]
    public class Raw : Item
    {
        Raw()
        {
            description = "Needs to be refined for further use.";
        }
    }
}