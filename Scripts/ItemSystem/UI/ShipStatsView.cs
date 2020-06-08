using Assets.Scripts.Data;
using Assets.Scripts.ItemSystem.Events;
using Assets.Scripts.ItemSystem.ItemTypes.CargoItems;
using Assets.Scripts.UI.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * For some reason Unity doesnt recognize the module events
 * It works without the GetAttributesToString()....
 * 
 * It got fixed by using the uninstall button in the interaction menu panel (IMP), calling Instantiate here.
 * For some reason that works fine no bugs...
 * but via the event, the same button in the IMP that fires the event, it doesnt like the GetAttributesToString()
 */
namespace Assets.Scripts.ItemSystem.UI
{
    public class ShipStatsView : Window
    {
        public GameObject statsText;
        public ActorData actorData;

        public void Instantiate()
        {
            string a = "" + actorData._name + " \n" + actorData.shipClass.ToString() +
                "\n" + actorData.GetComponent<Rigidbody2D>().mass +
                "\n" + actorData.GetComponent<ModuleUpgradeMaster>().slots.Count +
                "\n\n"+actorData.GetAttributesToString();

            statsText.GetComponent<Text>().text = a;
        }
        public override void OnEnable()
        {
            ModuleEvents.OnModuleInstallSuccsess += ModuleEvents_OnModuleInstallSuccsess;
            
            ModuleEvents.OnModuleUninstall += ModuleEvents_OnModuleUninstall;
            if (actorData != null)
            {
                Instantiate();
            }
        }

        public void ModuleEvents_OnModuleUninstall(Module item)
        {
            Instantiate();///??not working as intended??see above
        }

        public void ModuleEvents_OnModuleInstallSuccsess(Module item, ActorData ship)
        {
            Instantiate();///??not working as intended??see above
        }
    }
}
