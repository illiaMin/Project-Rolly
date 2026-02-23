using UnityEngine;

public class ID_CardCreator : MonoBehaviour
{
    SO_AllModules _allModules;
    private ID_Card _idCard;

    public ID_Card Create(ID_CardCreatorContext idcc, ModuleName moduleName)
    {
        _allModules = idcc.AllModules;
        SO_ID_Card info = _allModules.Modules.Get(moduleName) as SO_ID_Card;
        ID_Card idCard = Instantiate(idcc.Prefab, idcc.RobotBody, false);
        _idCard = idCard;
        ID_CardUI ui = idCard.GetIDCardUI();
        ui.SetIDCardText(idcc.IDCardText);
        ui.UpdateIDCardText(info.Name + info.Number);
        return idCard;
    }

    public void InitializeNewIdCard(ModuleName n)
    {
        SO_ID_Card info = _allModules.Modules.Get(n) as SO_ID_Card;
        ID_CardUI ui = _idCard.GetIDCardUI();
        ui.UpdateIDCardText(info.Name + info.Number);
    }
}
