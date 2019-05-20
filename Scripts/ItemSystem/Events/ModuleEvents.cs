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
    }
}