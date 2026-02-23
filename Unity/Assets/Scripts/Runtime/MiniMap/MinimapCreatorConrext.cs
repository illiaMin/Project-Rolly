using UnityEngine;

public class MinimapCreatorConrext
{
    public readonly SO_AllModules AllModules;
    public readonly MiniMap Prefab;
    public readonly Transform RobotBody;

    public MinimapCreatorConrext(
        SO_AllModules allModules, 
        MiniMap prefab, 
        Transform robotBody)
    {
        AllModules = allModules;
        Prefab = prefab;
        RobotBody = robotBody;
    }
}
