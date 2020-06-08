using Assets.Scripts.Data;
using Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Turret;
using UnityEngine;
namespace Assets.Scripts.ItemSystem.Events
{
    public class TurretEvents
    {
        public delegate void TurretInstallSuccsess(TurretItem item, ActorData ship);
        public static event TurretInstallSuccsess OnTurretInstallSuccsess;

        public void TurretInstallSuccsessEvent(TurretItem g, ActorData s) => OnTurretInstallSuccsess?.Invoke(g, s);

        public delegate void TurretInstallFail(TurretItem item);
        public static event TurretInstallFail OnTurretInstallFail;

        public void TurretInstallFailEvent(TurretItem g) => OnTurretInstallFail?.Invoke(g);

        public delegate void TurretUninstall(TurretItem item);
        public static event TurretUninstall OnTurretUninstall;

        public void TurretUninstallEvent(TurretItem g) => OnTurretUninstall?.Invoke(g);

        public delegate void TurretUninstallSuccsess(TurretItem item);
        public static event TurretUninstallSuccsess OnTurretUninstallSuccsess;

        public void TurretUninstallSuccsessEvent(TurretItem g) => OnTurretUninstallSuccsess?.Invoke(g);

    }
}
