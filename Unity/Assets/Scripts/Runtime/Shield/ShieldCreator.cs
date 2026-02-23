using UnityEngine;

public class ShieldCreator : MonoBehaviour
{
    public Shield Create(ShieldCreatorContext scc)
    {
        SO_AllModules allModules =  scc.AllModules;
        Shield shied = Instantiate(scc.Prefab, scc.RobotBody, false);
        shied.name = "Shield";
        shied.transform.localPosition = Vector3.zero;
        SO_Shield info = allModules.Modules.Get(ModuleName.Shield) as SO_Shield;
        SetUpShield(shied, info);
        return shied;
    }

    private void SetUpShield(Shield shield, SO_Shield info)
    {
        shield.GetSpriteRenderer().sprite = info.Image;
    }
}
