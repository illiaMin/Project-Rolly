using UnityEngine;

public class WheelsCreatorContext
{
    public readonly Transform RobotBody;
    public readonly Wheels PrefabWheels;
    public readonly PlayerDrive PlayerDrive;
    public readonly SO_AllModules AllModules;
    public PlayerEvents PlayerEvents;
    public ProgressRepository ProgressRepository;

    public WheelsCreatorContext(
        SO_AllModules allModules,
        Transform robotBody,
        Wheels prefabWheels,
        PlayerDrive playerDrive,
        PlayerEvents playerEvents,
        ProgressRepository progressRepository)
    {
        AllModules = allModules;
        RobotBody = robotBody;
        PrefabWheels = prefabWheels;
        PlayerDrive = playerDrive;
        PlayerEvents = playerEvents;
        ProgressRepository =  progressRepository;
    }
}
