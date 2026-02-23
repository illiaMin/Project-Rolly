using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class PlayerSetup
{
    SavingInfo _savingInfo;
    
    private Dictionary<KeysForPlayerPrefs, string> _playerHasInstalled = new ();
    
    private Dictionary<string, int> _indexesInSavingInfo = new();
    
    public void Start(
        ref SavingInfo savingInfo, 
        ref Dictionary<KeysForPlayerPrefs, string> playerHas)
    {
        _savingInfo = savingInfo;
        _playerHasInstalled = playerHas;
        
        for (int i = 0; i < _savingInfo.GetModulesList().Count; i++)
        {
            _indexesInSavingInfo.Add(_savingInfo.GetModulesList()[i].GetKey(), i);
        }
    }

    public void UpdateSetUp(ref SavingInfo savingInfo, 
        ref Dictionary<KeysForPlayerPrefs, string> playerHas)
    {
        _savingInfo = savingInfo;
        _playerHasInstalled = playerHas;
        _indexesInSavingInfo.Clear();
        for (int i = 0; i < _savingInfo.GetModulesList().Count; i++)
        {
            _indexesInSavingInfo.Add(_savingInfo.GetModulesList()[i].GetKey(), i);
        }
    }
    public string GetCurrentMainGunName()
    {
        return _playerHasInstalled[KeysForPlayerPrefs.MainGun];
    }
    public string GetCurrentSecondGunName()
    {
        return _playerHasInstalled[KeysForPlayerPrefs.SecondGun];
    }
    public string GetCurrentBatteryName()
    {
        return _playerHasInstalled[KeysForPlayerPrefs.Battery];
    }
    public string GetCurrentActiveWheels()
    {
        return _playerHasInstalled[KeysForPlayerPrefs.ActiveWheels];
    }
    public int GetInstalledBatteryCharge()
    {
        string name = _playerHasInstalled[KeysForPlayerPrefs.Battery];
        int index = _indexesInSavingInfo[name];
        int charge = _savingInfo.GetModulesList()[index].GetCharge();
        return charge;
    }
    public string GetCurrentAuxiliaryModuleName()
    {
        return _playerHasInstalled[KeysForPlayerPrefs.Auxiliary];
    }

    public string GetCurrentIDCard()
    {
        return _playerHasInstalled[KeysForPlayerPrefs.IDCard];
    }
}
