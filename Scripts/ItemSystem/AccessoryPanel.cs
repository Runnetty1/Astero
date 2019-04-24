using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class AccessoryPanel : MonoBehaviour
    {

        [SerializeField]
        public InternalModuleSlot back;
        [SerializeField]
        public InternalModuleSlot jewelery;
        [SerializeField]
        public InternalModuleSlot gadget;
        [SerializeField]
        public InternalModuleSlot mount;
        [SerializeField]
        public InternalModuleSlot pet;
        [SerializeField]
        public InternalModuleSlot sigil;
        [SerializeField]
        public InternalModuleSlot vanity;
    }
}