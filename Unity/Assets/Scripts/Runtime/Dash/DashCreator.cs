using UnityEngine;

public class DashCreator : MonoBehaviour
{
    public Dash Create(DashCreatorContext dcc)
    {
        SO_AllModules allModules =  dcc.AllModules;
        Dash dash = Instantiate(dcc.Prefab, dcc.RobotBody, false);
        dash.name = "Dash";
        dash.transform.localPosition = Vector3.zero;
        SO_Dash info = allModules.Modules.Get(ModuleName.Dash) as SO_Dash;
        SetUpDash(dash, info, dcc);
        return dash;
    }

    private void SetUpDash(Dash dash, SO_Dash info, DashCreatorContext dcc)
    {
        dash.SetPowerOfDash(info.PowerOfDash);
        dash.SetRigidBody(dcc.RobotBody.GetComponent<Rigidbody2D>());
        dash.GetSpriteRenderer().sprite = info.Image;
    }
}
