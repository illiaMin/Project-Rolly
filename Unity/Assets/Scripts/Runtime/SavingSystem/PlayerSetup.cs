using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class PlayerSetup
{
    SavingInfo _savingInfo;
    
    private Dictionary<KeysForPlayerPrefs, string> _playerHas = new ();
    
    private Dictionary<string, int> _indexesInSavingInfo = new();
    public void Start(
        ref SavingInfo savingInfo, 
        ref Dictionary<KeysForPlayerPrefs, string> playerHas)
    {
        _savingInfo = savingInfo;
        _playerHas = playerHas;
        
        for (int i = 0; i < _savingInfo.GetModulesList().Count; i++)
        {
            _indexesInSavingInfo.Add(_savingInfo.GetModulesList()[i].GetKey(), i);
        }
    }
    
    public string GetCurrentBatteryName()
    {
        return _playerHas[KeysForPlayerPrefs.Battery];
    }

    public int GetInstalledBatteryCharge()
    {
        string name = _playerHas[KeysForPlayerPrefs.Battery];
        int index = _indexesInSavingInfo[name];
        int charge = _savingInfo.GetModulesList()[index].GetCharge();
        return charge;
    }
}
