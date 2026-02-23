using UnityEngine;

public class MiniMapCreator : MonoBehaviour
{
    public MiniMap Create(MinimapCreatorConrext mmcc)
    {
        SO_AllModules allModules =  mmcc.AllModules;
        MiniMap minimap = Instantiate(mmcc.Prefab, mmcc.RobotBody, false);
        minimap.name = "MiniMap";
        minimap.transform.localPosition = Vector3.zero;
        SO_Minimap info = allModules.Modules.Get(ModuleName.Minimap) as SO_Minimap;
        SetUpMiniMap(minimap, info);
        return minimap;
    }
    private void SetUpMiniMap(MiniMap minimap, SO_Minimap info)
    {
        minimap.GetSpriteRenderer().sprite = info.Image;
    }
}
