using System;
using UnityEngine;

[Serializable]
public class SavingModuleInfo
{
    [SerializeField] private ModuleName _moduleName;
    [SerializeField] TypeOfModule _typeOfModule;
    [SerializeField] string _keyName;
    [SerializeField] [Range(0, 1)] int _playerHas;
    [SerializeField] [Range(0, 1)] int _playerUnlocked;
    [SerializeField] [Range(0, 100)] int _currentHp = 100;
    [SerializeField] [Range(0, 1)] int _hasTwoHp = 0;
    [SerializeField] [Range(0, 100)] int _currentRightHp = 100;
    [SerializeField] [Range(0, 100)] int _currentLeftHp = 100;
    [SerializeField] [Range(0, 1)] int _hasCharge;
    [SerializeField] int _charge;

    public string GetKey() => _keyName;
    public TypeOfModule GetTypeOfModule() => _typeOfModule;
    public bool IsUnlocked() => _playerUnlocked == 1;
    public ModuleName GetModuleName() => _moduleName;
    
    
    
    public void GetValues(
        out ModuleName moduleName,
        out int playerHas,
        out TypeOfModule typeOfModule,
        out int playerUnlocked,
        out int currentHp,
        out int hasTwoHp,
        out int currentRightHp,
        out int currentLeftHp,
        out int hasCharge,
        out int charge)
    {
        moduleName = _moduleName;
        playerHas = _playerHas;
        typeOfModule = _typeOfModule;
        playerUnlocked = _playerUnlocked;
        currentHp = _currentHp;
        hasTwoHp = _hasTwoHp;
        currentRightHp = _currentRightHp;
        currentLeftHp = _currentLeftHp;
        hasCharge = _hasCharge;
        charge = _charge;
    }
    public void SetKeyName(string keyName) => _keyName = keyName;
    public void SetValues(
        ModuleName moduleName,
        int playerHas,
        TypeOfModule typeOfModule,
        int playerUnlocked,
        int currentHp,
        int hasTwoHp,
        int currentRightHp,
        int currentLeftHp,
        int hasCharge,
        int charge)
    {
        _moduleName = moduleName;
        _playerHas = playerHas;
        _typeOfModule = typeOfModule;
        _playerUnlocked = playerUnlocked;
        _currentHp = currentHp;
        _hasTwoHp = hasTwoHp;
        _currentRightHp = currentRightHp;
        _currentLeftHp = currentLeftHp;
        _hasCharge = hasCharge;
        _charge = charge;
    }
    
    public int GetCharge() => _charge;
}
