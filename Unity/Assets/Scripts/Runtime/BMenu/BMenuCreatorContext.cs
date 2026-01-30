using UnityEngine;
using UnityEngine.UI;

public class BMenuCreatorContext
{
    public readonly Transform RobotBody;
    public readonly BMenu PrefabBMenu;
    public readonly Text TextBMenu;
    public readonly PlayerEvents PlayerEvents;

    public BMenuCreatorContext(
        Transform robotBody,
        BMenu prefabBMenu,
        Text textBMenu,
        PlayerEvents playerEvents)
    {
        RobotBody = robotBody;
        PrefabBMenu = prefabBMenu;
        TextBMenu = textBMenu;
        PlayerEvents = playerEvents;
    }
}
