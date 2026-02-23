using UnityEngine;
using UnityEngine.UI;

public sealed class BMenuCreator : MonoBehaviour
{
    SO_AllModules _allModules;
    public BMenu Create(BMenuCreatorContext bmc, ModuleName bMenuName)
    {
        _allModules = bmc.AllModules;
        BMenu bMenu = Instantiate(bmc.PrefabBMenu, bmc.RobotBody, false);
        bMenu.name = "BMenu";
        bMenu.transform.localPosition = Vector3.zero;
        GetInfoAboutBMenu(bMenuName, out SO_BMenu info);
        bMenu.GetSpriteRenderer().sprite = info.Image;
        BMenuInput input = bMenu.GetComponent<BMenuInput>();

        input.Init(bmc.TextBMenu, bmc.TextMainGun, bmc.TextSecondGun, bmc.TextActiveWheels, bmc.TextAuxiliary);
        input.ChangeMainGun(bmc.SavingSystem.GetPlayerSetup().GetCurrentMainGunName());
        input.ChangeSecondGun(bmc.SavingSystem.GetPlayerSetup().GetCurrentSecondGunName());
        input.ChangeActiveWheels(bmc.SavingSystem.GetPlayerSetup().GetCurrentActiveWheels());
        input.ChangeActiveAuxiliary(bmc.SavingSystem.GetPlayerSetup().GetCurrentAuxiliaryModuleName());
        bMenu.Init(input, bmc);

        return bMenu;
    }

    private void GetInfoAboutBMenu(ModuleName bMenuName, out SO_BMenu info)
    {
        info = _allModules.Modules.Get(bMenuName) as SO_BMenu;
    }
}