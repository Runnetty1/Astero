using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RRG.InventorySystem
{
    public class ModuleEvents
    {
        public delegate void ModuleHover(Module item);
        public static event ModuleHover OnModuleHover;

        public void ModuleHoverEvent(Module g) => OnModuleHover?.Invoke(g);

        public delegate void ModuleStopedHover();
        public static event ModuleStopedHover OnModuleStopHover;

        public void ModuleStopedHoverEvent() => OnModuleStopHover?.Invoke();

        public delegate void ModuleInstall(Module item);
        public static event ModuleInstall OnModuleInstall;

        public void ModuleInstallEvent(Module g) => OnModuleInstall?.Invoke(g);

        public delegate void InventoryItemAdd(InventoryModule module, ItemInstance item, bool useStack);
        public static event InventoryItemAdd OnModuleItemAdd;

        public void ModuleAddItem(InventoryModule module, ItemInstance item, bool useStack) => OnModuleItemAdd?.Invoke(module, item, useStack);

        public delegate void InventoryItemRemove(InventoryModule module, ItemInstance item);
        public static event InventoryItemRemove OnModuleItemRemove;

        public void ModuleRemoveItem(InventoryModule module, ItemInstance item) => OnModuleItemRemove?.Invoke(module, item);
    }
}