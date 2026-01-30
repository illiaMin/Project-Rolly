using UnityEngine;

public class WheelsCreatorContext
{
    public readonly Transform RobotBody;
    public readonly Wheels PrefabWheels;
    public readonly PlayerDrive PlayerDrive;
    public readonly SO_AllModules AllModules;
    public WheelsCreatorContext(
        SO_AllModules allModules,
        Transform robotBody,
        Wheels prefabWheels,
        PlayerDrive playerDrive)
    {
        AllModules = allModules;
        RobotBody = robotBody;
        PrefabWheels = prefabWheels;
        PlayerDrive = playerDrive;
        
    }
}
