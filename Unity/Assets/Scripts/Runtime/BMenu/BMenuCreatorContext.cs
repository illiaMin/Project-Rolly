using UnityEngine;
using UnityEngine.UI;

public class BMenuCreatorContext
{
    public readonly SO_AllModules AllModules;
    public readonly Transform RobotBody;
    public readonly BMenu PrefabBMenu;
    public readonly Text TextBMenu;
    public readonly Text TextMainGun;
    public readonly Text TextSecondGun;
    public readonly Text TextActiveWheels;
    public readonly Text TextAuxiliary;
    public readonly PlayerEvents PlayerEvents;
    public readonly ListsForB_Menu ListsForB_Menu;
    public readonly BMenuEvents BMenuEvents;
    public readonly SavingSystem SavingSystem;

    public BMenuCreatorContext(
        SO_AllModules allModules,
        Transform robotBody,
        BMenu prefabBMenu,
        Text textBMenu,
        Text textMainGun,
        Text textSecondGun,
        Text textActiveWheels,
        Text textAuxiliary,
        PlayerEvents playerEvents,
        ListsForB_Menu listsForB_Menu,
        BMenuEvents bMenuEvents,
        SavingSystem savingSystem)
    {
        AllModules = allModules;
        RobotBody = robotBody;
        PrefabBMenu = prefabBMenu;
        TextBMenu = textBMenu;
        TextMainGun = textMainGun;
        TextSecondGun = textSecondGun;
        TextActiveWheels = textActiveWheels;
        TextAuxiliary = textAuxiliary;
        PlayerEvents = playerEvents;
        ListsForB_Menu = listsForB_Menu;
        BMenuEvents = bMenuEvents;
        SavingSystem = savingSystem;   
    }
}
