

using System;
using Assets.Scripts.Data;
using Assets.Scripts.ItemSystem.ItemTypes.CargoItems;
using Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Modules;

namespace Assets.Scripts.ItemSystem.Events
{
    public class ModuleEvents
    {

        public delegate void ModuleHover(Module item);
        public static event ModuleHover OnModuleHover;

        public void ModuleHoverEvent(Module g) => OnModuleHover?.Invoke(g);

        public delegate void ModuleStopedHover();
        public static event ModuleStopedHover OnModuleStopHover;

        public void ModuleStopedHoverEvent() => OnModuleStopHover?.Invoke();


        public delegate void ModuleInstallSuccsess(Module item,ActorData ship);
        public static event ModuleInstallSuccsess OnModuleInstallSuccsess;

        public void ModuleInstallSuccsessEvent(Module g,ActorData s) => OnModuleInstallSuccsess?.Invoke(g,s);

        public delegate void ModuleInstallFail(Module item);
        public static event ModuleInstallFail OnModuleInstallFail;

        public void ModuleInstallFailEvent(Module g) => OnModuleInstallFail?.Invoke(g);

        public delegate void ModuleUninstall(Module item);
        public static event ModuleUninstall OnModuleUninstall;

        public void ModuleUninstallEvent(Module g) => OnModuleUninstall?.Invoke(g);

        public delegate void ModuleUninstallSuccsess(Module item);
        public static event ModuleUninstallSuccsess OnModuleUninstallSuccsess;

        public void ModuleUninstallSuccsessEvent(Module g) => OnModuleUninstallSuccsess?.Invoke(g);



        /*
        public delegate void InventoryItemAdd(InventoryModule module, ItemInstance item, bool useStack);
        public static event InventoryItemAdd OnModuleItemAdd;

        public void ModuleAddItem(InventoryModule module, ItemInstance item, bool useStack) => OnModuleItemAdd?.Invoke(module, item, useStack);
        */


    }
}