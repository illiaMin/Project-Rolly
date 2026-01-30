using UnityEngine;

public class ProgressRepository : MonoBehaviour
{
    public ModuleName GetMainGunModuleName() => ModuleName.Rifle;
    public ModuleName GetWheelsModuleName() => ModuleName.Tracks;
    public ModuleName GetBatteryModuleName() => ModuleName.Battery;
    public ModuleName GetBMenuModuleName() => ModuleName.B_menu;
    public ModuleName GetVisionModuleName() => ModuleName.Vision;
}
