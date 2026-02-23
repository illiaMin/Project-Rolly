using UnityEngine;

public class DashCreatorContext
{
    public readonly SO_AllModules AllModules;
    public readonly Dash Prefab;
    public readonly Transform RobotBody;

    public DashCreatorContext(
        SO_AllModules allModules, 
        Dash prefab, 
        Transform robotBody)
    {
        AllModules = allModules;
        Prefab = prefab;
        RobotBody = robotBody;
    }
}
