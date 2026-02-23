using UnityEngine;

public class ShieldCreatorContext
{
    public readonly SO_AllModules AllModules;
    public readonly Shield Prefab;
    public readonly Transform RobotBody;

    public ShieldCreatorContext(
        SO_AllModules allModules, 
        Shield prefab, 
        Transform robotBody)
    {
        AllModules = allModules;
        Prefab = prefab;
        RobotBody = robotBody;
    }
}
