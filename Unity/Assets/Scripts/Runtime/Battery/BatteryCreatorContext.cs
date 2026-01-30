using UnityEngine;

public class BatteryCreatorContext
{
    public readonly Transform RobotBody;
    public readonly Battery PrefabBattery;
    public readonly SO_AllModules AllModules;
    public readonly PlayerEvents PlayerEvents;
    
    public BatteryCreatorContext(
        SO_AllModules allModules,
        Transform robotBody,
        Battery prefabBattery,
        PlayerEvents playerEvents)
    {
        AllModules = allModules;
        RobotBody = robotBody;
        PrefabBattery = prefabBattery;
        PlayerEvents = playerEvents;
    }
}
