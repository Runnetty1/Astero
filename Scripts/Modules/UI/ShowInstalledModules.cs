using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace RRG.ControlledObjects.ModuleView
{
    public class ShowInstalledModules : MonoBehaviour
    {
        public GameObject contentList;
        public GameObject moduleViewObject;
        public Spaceship playersSpaceship;

        void Start ()
        {
            for(int i = 0; i < playersSpaceship.installedModules.modules.Count; i++)
            {
                GameObject t = Instantiate(moduleViewObject, contentList.transform);
                t.GetComponent<ModuleData>().moduleName.text = playersSpaceship.installedModules.modules[i].ModuleName;
                t.GetComponent<ModuleData>().moduleSize.text =""+ playersSpaceship.installedModules.modules[i].ModuleSize;
                t.GetComponent<ModuleData>().moduleType.text = playersSpaceship.installedModules.modules[i].ModuleType;
            }
        }
    }
}
