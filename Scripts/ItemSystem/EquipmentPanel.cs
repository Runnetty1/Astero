using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem;

namespace InventorySystem
{
    
    public class EquipmentPanel : MonoBehaviour
    {
        [SerializeField]
        public ExternalModuleSlot head;
        [SerializeField]
        public ExternalModuleSlot body;
        [SerializeField]
        public ExternalModuleSlot legs;
    }
}