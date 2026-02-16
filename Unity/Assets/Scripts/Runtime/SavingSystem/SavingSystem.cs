using System;
using System.Collections.Generic;
using UnityEngine;

public class SavingSystem : MonoBehaviour
{
    PlayerSetup _playerSetup = new PlayerSetup();
    public PlayerSetup GetPlayerSetup() => _playerSetup;
    
    [SerializeField] PlayerEvents _playerEvents;
    PlayerPrefsReader _pPReader = new ();
    PlayerPrefsWriter _pPWriter = new ();
    [SerializeField] private string _gameStartedKey = "GameStarted";
    [SerializeField] FirstSavingInfo _firstSavingInfo;
    
    public void Init()
    {
        //PlayerPrefs.DeleteAll();
        if (!CheckIsGameStartedFirstly())
        {
            FillFirstPlayerPrefs();
        }
        SavingInfo savingInfo = new SavingInfo();
        Fill(ref savingInfo);
        Dictionary<KeysForPlayerPrefs, string> modulesByPositions = new();
        Fill(ref modulesByPositions);
        
        _playerSetup.Start(ref savingInfo, ref modulesByPositions);
        _playerEvents.AddListenerToOnBatteryChargePercentChanged(SaveBatteryCharge);
    }

    private void Fill(ref SavingInfo savingInfo)
    {
        var loadedInfo = LoadAllSavedModulesAsList();
        savingInfo.SetModulesList(loadedInfo);
    }
    private void Fill(ref Dictionary<KeysForPlayerPrefs, string> modulesByPositions)
    {
        foreach (KeysForPlayerPrefs key in Enum.GetValues(typeof(KeysForPlayerPrefs)))
        {
            modulesByPositions.Add(key, _pPReader.GetString(key.ToString()));
        }
    }

    private List<SavingModuleInfo> LoadAllSavedModulesAsList()
    {
        List<SavingModuleInfo> result = new();
        foreach (var info in _firstSavingInfo.GetStartModulesList())
        {
            var key = info.GetKey();
            
            var value = _pPReader.GetString(key);
            ConvertValueToInts(value,
                out int playerHas,
                out int playerUnlocked,
                out int currentHp,
                out int hasTwoHp,
                out int currentRightHp,
                out int currentLeftHp,
                out int hasCharge,
                out int charge);
            
            SavingModuleInfo mate = new SavingModuleInfo();
            mate.SetKeyName(key);
            mate.SetValues(
                playerHas, 
                playerUnlocked, 
                currentHp, 
                hasTwoHp, 
                currentRightHp, 
                currentLeftHp, 
                hasCharge, 
                charge);
            result.Add(mate);
        }
        return result;
    }
    private void ConvertValueToInts(
        string value, 
        out int playerHas,
        out int playerUnlocked,
        out int currentHp,
        out int hasTwoHp,
        out int currentRightHp,
        out int currentLeftHp,
        out int hasCharge,
        out int charge)
    {
        string[] parts = value.Split('#');
        playerHas = int.Parse(parts[0]);
        playerUnlocked = int.Parse(parts[1]);
        currentHp = int.Parse(parts[2]);
        hasTwoHp = int.Parse(parts[3]);
        currentRightHp = int.Parse(parts[4]);
        currentLeftHp = int.Parse(parts[5]);
        hasCharge = int.Parse(parts[6]);
        charge = int.Parse(parts[7]);
    }

    public void GetIfo()
    {
        print(_playerSetup.GetCurrentBatteryName());
        print(_pPReader.GetString(_playerSetup.GetCurrentBatteryName()));
    }
    public void SaveBatteryCharge(int currentCharge)
    {
        string str = _pPReader.GetString(_playerSetup.GetCurrentBatteryName());
        string[] parts = str.Split('#');
        parts[parts.Length - 1] = currentCharge.ToString();
        str = string.Join("#", parts);
        _pPWriter.Write(_playerSetup.GetCurrentBatteryName(), str);
    }
    bool CheckIsGameStartedFirstly()
    {
        if (_pPReader.HasKey(_gameStartedKey))
        {
            return true;
        }
        return false;
    }

    void FillFirstPlayerPrefs()
    {
        _pPWriter.Write(_gameStartedKey, 1); ;
        SaveAllModulesFirstTime();
        SaveInfoAboutModulesPositions();
    }
    void SaveAllModulesFirstTime()
    {
        List<SavingModuleInfo> list = _firstSavingInfo.GetStartModulesList();
        for (int i = 0; i < list.Count; i++)
        {
            string key = list[i].GetKey();
            list[i].GetValues(
                out int pHas, 
                out int pUnlock,
                out int currentHp, 
                out int hasTwoHp,
                out int currentLeftHp,
                out int currentRightHp,
                out int hasCharge, 
                out int charge);
            string value = 
                $"{pHas}#{pUnlock}#{currentHp}" +
                $"#{hasTwoHp}#{currentLeftHp}" +
                $"#{currentRightHp}#{hasCharge}#{charge}";
            
            _pPWriter.Write(key,value);  
        }
    }

    void SaveInfoAboutModulesPositions()
    {
        SaveMainGun();
        SaveSecondGun();
        SaveActiveWheels();
        SaveBattery();
        void SaveMainGun()
        {
            _pPWriter.Write(
                nameof(KeysForPlayerPrefs.MainGun), nameof(ModuleName.Rifle));
        }
        void SaveSecondGun()
        {
            _pPWriter.Write(
                nameof(KeysForPlayerPrefs.SecondGun), nameof(ModuleName.Rifle));
        }
        void SaveActiveWheels()
        {
            _pPWriter.Write(
                nameof(KeysForPlayerPrefs.ActiveWheels), nameof(ModuleName.Tracks));
        }
        void SaveBattery()
        {
            _pPWriter.Write(
                nameof(KeysForPlayerPrefs.Battery), nameof(ModuleName.Battery) + "_1");
        }
    }
}