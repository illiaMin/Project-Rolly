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
    
    public void GetBatteryModuleCharge(out int charge)
    {
        PlayerSetup ps = _savingSystem.GetPlayerSetup();
        charge = ps.GetInstalledBatteryCharge();
    }

    public int GetBatteryHP()
    {
        PlayerSetup ps = _savingSystem.GetPlayerSetup();
        return ps.GetInstalledBatteryHP();
    }
    public int GetTurretHP()
    {
        PlayerSetup ps = _savingSystem.GetPlayerSetup();
        return ps.GetInstalledGunHP();
    }
    public int GetAuxiliaryHP()
    {
        PlayerSetup ps = _savingSystem.GetPlayerSetup();
        return ps.GetInstalledAuxiliaryHP();
    }
    public int GetVisionHP()
    {
        PlayerSetup ps = _savingSystem.GetPlayerSetup();
        return ps.GetInstalledVisionHP();
    }

    public int GetWheelsLeftHP()
    {
        PlayerSetup ps = _savingSystem.GetPlayerSetup();
        return ps.GetInstalledLeftWheelsHP();
    }
    public int GetWheelsRightHP()
    {
        PlayerSetup ps = _savingSystem.GetPlayerSetup();
        return ps.GetInstalledRightWheelsHP();
    }
}
