using UnityEngine;
using UnityEngine.UI;

public sealed class BMenuCreator : MonoBehaviour
{
    public BMenu Create(BMenuCreatorContext bcc)
    {
        BMenu bMenu = Instantiate(bcc.PrefabBMenu, bcc.RobotBody, false);
        bMenu.name = "BMenu";
        bMenu.transform.localPosition = Vector3.zero;

        BMenuInput input = bMenu.GetComponent<BMenuInput>();

        input.Init(bcc.TextBMenu);
        bMenu.Init(input);

        return bMenu;
    }
}