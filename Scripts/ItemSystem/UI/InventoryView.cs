using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RRG.InventorySystem
{
    public class InventoryView : MonoBehaviour
    {
        public InternalModule internalModule;
        public GameObject contentObj;
        public GameObject itemPanel;
        public GameObject SizeText;
        // Start is called before the first frame update
        void Start()
        {
            if(internalModule.ModuleType == "Cargobay")
            {
                Debug.Log("Is Cargobay");
            }
            if (internalModule.ModuleType == "Hangarbay")
            {
                Debug.Log("Is Hangarbay");
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}