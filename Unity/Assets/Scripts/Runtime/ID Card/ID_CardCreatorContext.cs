using UnityEngine;
using UnityEngine.UI;

public class ID_CardCreatorContext
{
    public readonly SO_AllModules AllModules;
    public readonly ID_Card Prefab;
    public readonly Transform RobotBody;
    public readonly Text IDCardText;

    public ID_CardCreatorContext(
        SO_AllModules allModules, 
        ID_Card prefab, 
        Transform robotBody,
        Text UIText)
    {
        AllModules = allModules;
        Prefab = prefab;
        RobotBody = robotBody;
        IDCardText = UIText;
    }
}
