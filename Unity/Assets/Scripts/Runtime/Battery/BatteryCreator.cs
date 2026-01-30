using System.Runtime.CompilerServices;
using UnityEngine;

public class BatteryCreator : MonoBehaviour
{
    public Battery Init(BatteryCreatorContext bcc, ModuleName batteryName)
    {
        SO_Battery info = 
            bcc.AllModules.Modules.Get(batteryName) as SO_Battery;

        var battery = 
            Instantiate(bcc.PrefabBattery, bcc.RobotBody, false);
        battery.name = "Battery";
        battery.transform.localPosition = Vector3.zero;

        battery.Init(info, bcc.PlayerEvents);
        return battery;
    }
}