
using Scripts.ItemSystem.ItemTypes.CargoItems;
using Scripts.ItemSystem.ItemTypes.CargoItems.Modules;

namespace Scripts.ItemSystem.Events
{
    public class ModuleEvents
    {
        public delegate void ModuleHover(Module item);
        public static event ModuleHover OnModuleHover;

        public void ModuleHoverEvent(Module g) => OnModuleHover?.Invoke(g);

        public delegate void ModuleStopedHover();
        public static event ModuleStopedHover OnModuleStopHover;

        public void ModuleStopedHoverEvent() => OnModuleStopHover?.Invoke();


        public delegate void ModuleInstallSuccsess(Module item);
        public static event ModuleInstallSuccsess OnModuleInstallSuccsess;

        public void ModuleInstallSuccsessEvent(Module g) => OnModuleInstallSuccsess?.Invoke(g);

        public delegate void ModuleInstallFail(Module item);
        public static event ModuleInstallFail OnModuleInstallFail;

        public void ModuleInstallFailEvent(Module g) => OnModuleInstallFail?.Invoke(g);

        /*
        public delegate void InventoryItemAdd(InventoryModule module, ItemInstance item, bool useStack);
        public static event InventoryItemAdd OnModuleItemAdd;

        public void ModuleAddItem(InventoryModule module, ItemInstance item, bool useStack) => OnModuleItemAdd?.Invoke(module, item, useStack);
        */

        public delegate void ModuleUninstall(InventoryModule module, ItemInstance item);
        public static event ModuleUninstall OnModuleUninstall;

        public void ModuleUninstallEvent(InventoryModule module, ItemInstance item) => OnModuleUninstall?.Invoke(module, item);
    }
}