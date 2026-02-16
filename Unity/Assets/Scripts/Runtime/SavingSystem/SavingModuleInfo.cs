using System;
using UnityEngine;

[Serializable]
public class SavingModuleInfo
{
    [SerializeField] private ModuleName _moduleName;
    [SerializeField] String _keyName;
    [SerializeField] [Range(0, 1)] int _playerHas;
    [SerializeField] [Range(0, 1)] int _playerUnlocked;
    [SerializeField] [Range(0, 100)] int _currentHp = 100;
    [SerializeField] [Range(0, 1)] int _hasTwoHp = 0;
    [SerializeField] [Range(0, 100)] int _currentRightHp = 100;
    [SerializeField] [Range(0, 100)] int _currentLeftHp = 100;
    [SerializeField] [Range(0, 1)] int _hasCharge;
    [SerializeField] int _charge;

    public string GetKey() => _keyName;

    public void GetValues(
        out int playerHas,
        out int playerUnlocked,
        out int currentHp,
        out int hasTwoHp,
        out int currentRightHp,
        out int currentLeftHp,
        out int hasCharge,
        out int charge)
    {
        playerHas = _playerHas;
        playerUnlocked = _playerUnlocked;
        currentHp = _currentHp;
        hasTwoHp = _hasTwoHp;
        currentRightHp = _currentRightHp;
        currentLeftHp = _currentLeftHp;
        hasCharge = _hasCharge;
        charge = _charge;
    }
    public void SetKeyName(String keyName) => _keyName = keyName;
    public void SetValues(
        int playerHas,
        int playerUnlocked,
        int currentHp,
        int hasTwoHp,
        int currentRightHp,
        int currentLeftHp,
        int hasCharge,
        int charge)
    {
        _playerHas = playerHas;
        _playerUnlocked = playerUnlocked;
        _currentHp = currentHp;
        _hasTwoHp = hasTwoHp;
        _currentRightHp = currentRightHp;
        _currentLeftHp = _currentLeftHp;
        _hasCharge = hasCharge;
        _charge = charge;
    }
    
    public int GetCharge() => _charge;
}
