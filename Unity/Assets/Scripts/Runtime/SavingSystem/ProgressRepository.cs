using System;
using UnityEngine;

public class ProgressRepository : MonoBehaviour
{
    SavingSystem _savingSystem;

    public void Init(SavingSystem ss)
    {
        _savingSystem = ss;
    }
    public ModuleName GetMainGunModuleName()
    {
        if (PlayerPrefs.HasKey(nameof(KeysForPlayerPrefs.MainGun)))
        {
            var ps = _savingSystem.GetPlayerSetup();
            return Enum.Parse<ModuleName>(ps.GetCurrentMainGunName());
        }

        return ModuleName.Rifle;
    }
    public ModuleName GetSecondGunModuleName()
    {
        if (PlayerPrefs.HasKey(nameof(KeysForPlayerPrefs.SecondGun)))
        {
            var ps = _savingSystem.GetPlayerSetup();
            return Enum.Parse<ModuleName>(ps.GetCurrentSecondGunName());
        }

        return ModuleName.Rifle;
    }
    public ModuleName GetWheelsModuleName()
    {
        if (PlayerPrefs.HasKey(nameof(KeysForPlayerPrefs.ActiveWheels)))
        {
            var ps = _savingSystem.GetPlayerSetup();
            return Enum.Parse<ModuleName>(ps.GetCurrentActiveWheels());
        }
        return ModuleName.Tracks;
    } 
    public void GetBatteryModuleInfo(out int charge)
    {
        PlayerSetup ps = _savingSystem.GetPlayerSetup();
        charge = ps.GetInstalledBatteryCharge();
    }

    public ModuleName GetCurrentAuxiliaryName()
    {
        if (PlayerPrefs.HasKey(nameof(KeysForPlayerPrefs.Auxiliary)))
        {
            var ps = _savingSystem.GetPlayerSetup();
            return Enum.Parse<ModuleName>(ps.GetCurrentAuxiliaryModuleName());
        }
        return ModuleName.Shield;
    }
    public ModuleName GetBMenuModuleName() => ModuleName.B_menu;
    public ModuleName GetVisionModuleName() => ModuleName.Vision;
    
    public ModuleName GetIDCardModuleName()
    {
        if (PlayerPrefs.HasKey(nameof(KeysForPlayerPrefs.IDCard)))
        {
            var ps = _savingSystem.GetPlayerSetup();
            return Enum.Parse<ModuleName>(ps.GetCurrentIDCard());
        }
        return ModuleName.IdCardRolly;
    } 
}
