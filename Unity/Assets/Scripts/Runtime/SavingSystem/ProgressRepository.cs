using System;
using UnityEngine;

public class ProgressRepository : MonoBehaviour
{
    SavingSystem _savingSystem;

    public void Init(SavingSystem ss)
    {
        _savingSystem = ss;
        _savingSystem.Init();
    }
    public ModuleName GetMainGunModuleName()
    {
        if (PlayerPrefs.HasKey(nameof(KeysForPlayerPrefs.MainGun)))
        {
            string s = PlayerPrefs.GetString(nameof(KeysForPlayerPrefs.MainGun));
            ModuleName r =
                (ModuleName)Enum.Parse(typeof(ModuleName), s, true);
            return r;
        }

        return ModuleName.Rifle;
    }
    public ModuleName GetSecondGunModuleName()
    {
        if (PlayerPrefs.HasKey(nameof(KeysForPlayerPrefs.SecondGun)))
        {
            string s = PlayerPrefs.GetString(nameof(KeysForPlayerPrefs.SecondGun));
            ModuleName r =
                (ModuleName)Enum.Parse(typeof(ModuleName), s, true);
            return r;
        }

        return ModuleName.Rifle;
    }
    public ModuleName GetWheelsModuleName()
    {
        if (PlayerPrefs.HasKey(nameof(KeysForPlayerPrefs.ActiveWheels)))
        {
            string s = PlayerPrefs.GetString(nameof(KeysForPlayerPrefs.ActiveWheels));
            ModuleName r =
                (ModuleName)Enum.Parse(typeof(ModuleName), s, true);
            return r;
        }
        
        return ModuleName.Tracks;
    } 
    public void GetBatteryModuleInfo(out int charge)
    {
        PlayerSetup ps = _savingSystem.GetPlayerSetup();
        charge = ps.GetInstalledBatteryCharge();
    }
    public ModuleName GetBMenuModuleName() => ModuleName.B_menu;
    public ModuleName GetVisionModuleName() => ModuleName.Vision;
}
