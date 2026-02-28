using System;
using System.Collections.Generic;
using UnityEngine;

public class SavingSystem : MonoBehaviour
{
    private const char ModuleValueSeparator = '#';
    private const int ModuleNamePartIndex = 0;
    private const int CurrentHpPartIndex = 4;
    private const int LeftHpPartIndex = 6;
    private const int RightHpPartIndex = 7;
    private const int ChargePartIndex = 9;
    private const int PlayerHasPartIndex = 1;
    private const int TypePartIndex = 2;
    private const int PlayerUnlockedPartIndex = 3;
    private const int HasTwoHpPartIndex = 5;
    private const int HasChargePartIndex = 8;

    PlayerSetup _playerSetup = new PlayerSetup();
    ListsForB_Menu _listsForB_Menu = new ListsForB_Menu();
    public PlayerSetup GetPlayerSetup() => _playerSetup;

    PlayerPrefsReader _pPReader = new();
    PlayerPrefsWriter _pPWriter = new();
    [SerializeField] private string _gameStartedKey = "GameStarted";
    [SerializeField] FirstSavingInfo _firstSavingInfo;

    public SavingSystem Init()
    {
        if (!CheckIsGameStartedFirstly())
        {
            FillFirstPlayerPrefs();
        }

        SavingInfo savingInfo = new SavingInfo();
        Fill(ref savingInfo);

        Dictionary<KeysForPlayerPrefs, string> modulesByPositions = new();
        Fill(ref modulesByPositions);

        _playerSetup.Start(ref savingInfo, ref modulesByPositions);
        _listsForB_Menu.Init(savingInfo);
        return this;
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
            string keyName = key.ToString();
            string value = _pPReader.GetString(keyName);

            if (string.IsNullOrEmpty(value))
            {
                value = GetDefaultPositionValue(key);
                _pPWriter.Write(keyName, value);
            }

            modulesByPositions.Add(key, value);
        }
    }

    private List<SavingModuleInfo> LoadAllSavedModulesAsList()
    {
        List<SavingModuleInfo> result = new();
        foreach (var info in _firstSavingInfo.GetStartModulesList())
        {
            var key = info.GetKey();

            var value = _pPReader.GetString(key);
            ConvertValueToInts(
                value,
                info,
                out ModuleName moduleName,
                out int playerHas,
                out TypeOfModule tom,
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
                moduleName,
                playerHas,
                tom,
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
        SavingModuleInfo fallbackInfo,
        out ModuleName moduleName,
        out int playerHas,
        out TypeOfModule tom,
        out int playerUnlocked,
        out int currentHp,
        out int hasTwoHp,
        out int currentRightHp,
        out int currentLeftHp,
        out int hasCharge,
        out int charge)
    {
        fallbackInfo.GetValues(
            out ModuleName fallbackModuleName,
            out int fallbackPlayerHas,
            out TypeOfModule fallbackTom,
            out int fallbackPlayerUnlocked,
            out int fallbackCurrentHp,
            out int fallbackHasTwoHp,
            out int fallbackCurrentRightHp,
            out int fallbackCurrentLeftHp,
            out int fallbackHasCharge,
            out int fallbackCharge);

        moduleName = fallbackModuleName;
        playerHas = fallbackPlayerHas;
        tom = fallbackTom;
        playerUnlocked = fallbackPlayerUnlocked;
        currentHp = fallbackCurrentHp;
        hasTwoHp = fallbackHasTwoHp;
        currentRightHp = fallbackCurrentRightHp;
        currentLeftHp = fallbackCurrentLeftHp;
        hasCharge = fallbackHasCharge;
        charge = fallbackCharge;

        if (string.IsNullOrEmpty(value))
        {
            return;
        }

        string[] parts = value.Split(ModuleValueSeparator);
        if (parts.Length <= ChargePartIndex)
        {
            return;
        }

        if (int.TryParse(parts[ModuleNamePartIndex], out int moduleId)
            && Enum.IsDefined(typeof(ModuleName), moduleId))
        {
            moduleName = (ModuleName)moduleId;
        }
        else if (Enum.TryParse(parts[ModuleNamePartIndex], out ModuleName parsedModuleName))
        {
            moduleName = parsedModuleName;
        }

        if (int.TryParse(parts[PlayerHasPartIndex], out int parsedPlayerHas))
        {
            playerHas = parsedPlayerHas;
        }

        if (int.TryParse(parts[TypePartIndex], out int parsedTom)
            && Enum.IsDefined(typeof(TypeOfModule), parsedTom))
        {
            tom = (TypeOfModule)parsedTom;
        }

        if (int.TryParse(parts[PlayerUnlockedPartIndex], out int parsedPlayerUnlocked))
        {
            playerUnlocked = parsedPlayerUnlocked;
        }

        if (int.TryParse(parts[CurrentHpPartIndex], out int parsedCurrentHp))
        {
            currentHp = parsedCurrentHp;
        }

        if (int.TryParse(parts[HasTwoHpPartIndex], out int parsedHasTwoHp))
        {
            hasTwoHp = parsedHasTwoHp;
        }

        if (int.TryParse(parts[RightHpPartIndex], out int parsedCurrentRightHp))
        {
            currentRightHp = parsedCurrentRightHp;
        }

        if (int.TryParse(parts[LeftHpPartIndex], out int parsedCurrentLeftHp))
        {
            currentLeftHp = parsedCurrentLeftHp;
        }

        if (int.TryParse(parts[HasChargePartIndex], out int parsedHasCharge))
        {
            hasCharge = parsedHasCharge;
        }

        if (int.TryParse(parts[ChargePartIndex], out int parsedCharge))
        {
            charge = parsedCharge;
        }
    }

    public void SaveMainGunAfterGetDmg(int newHP)
    {
        UpdateModuleValue(_playerSetup.GetCurrentMainGunName(), CurrentHpPartIndex, newHP);
        RefreshSetUp();
    }
    public void SaveBatteryAfterGetDmg(int newHP)
    {
        UpdateModuleValue(_playerSetup.GetCurrentBatteryName(), CurrentHpPartIndex, newHP);
        RefreshSetUp();
    }
    public void SaveAuxiliaryAfterGetDmg(int newHP)
    {
        UpdateModuleValue(_playerSetup.GetCurrentAuxiliaryModuleName(), CurrentHpPartIndex, newHP);
        RefreshSetUp();
    }
    public void SaveVisionAfterGetDmg(int newHP)
    {
        UpdateModuleValue(nameof(ModuleName.Vision), CurrentHpPartIndex, newHP);
        RefreshSetUp();
    }
    public void SaveWheelsDmg(int newHPLeft, int newHPRight)
    {
        string wheelsKey = _playerSetup.GetCurrentActiveWheels();
        UpdateModuleValue(wheelsKey, LeftHpPartIndex, newHPLeft);
        UpdateModuleValue(wheelsKey, RightHpPartIndex, newHPRight);
        RefreshSetUp();
    }
    
    public void SaveBatteryCharge(int currentCharge)
    {
        UpdateModuleValue(_playerSetup.GetCurrentBatteryName(), ChargePartIndex, currentCharge);
    }

    private string GetDefaultPositionValue(KeysForPlayerPrefs key)
    {
        switch (key)
        {
            case KeysForPlayerPrefs.MainGun:
                return nameof(ModuleName.Rifle);
            case KeysForPlayerPrefs.SecondGun:
                return nameof(ModuleName.Rifle);
            case KeysForPlayerPrefs.Auxiliary:
                return nameof(ModuleName.Shield);
            case KeysForPlayerPrefs.ActiveWheels:
                return nameof(ModuleName.Tracks);
            case KeysForPlayerPrefs.Battery:
                return nameof(ModuleName.Battery) + "_1";
            case KeysForPlayerPrefs.IDCard:
                return nameof(ModuleName.IdCardRolly);
            case KeysForPlayerPrefs.VisionModule:
                return nameof(ModuleName.Vision);
            case KeysForPlayerPrefs.B_MenuKey:
                return string.Empty;
            default:
                return string.Empty;
        }
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
        _pPWriter.Write(_gameStartedKey, 1);
        SaveAllModulesFirstTime();
        FirstTimeSaveInfoAboutModulesPositions();
    }

    void SaveAllModulesFirstTime()
    {
        List<SavingModuleInfo> list = _firstSavingInfo.GetStartModulesList();
        for (int i = 0; i < list.Count; i++)
        {
            string key = list[i].GetKey();
            list[i].GetValues(
                out ModuleName moduleName,
                out int pHas,
                out TypeOfModule typeOfModule,
                out int pUnlock,
                out int currentHp,
                out int hasTwoHp,
                out int currentLeftHp,
                out int currentRightHp,
                out int hasCharge,
                out int charge);

            string value =
                $"{(int)moduleName}#{pHas}#{(int)typeOfModule}#{pUnlock}#{currentHp}" +
                $"#{hasTwoHp}#{currentLeftHp}" +
                $"#{currentRightHp}#{hasCharge}#{charge}";
            _pPWriter.Write(key, value);
        }
    }

    void FirstTimeSaveInfoAboutModulesPositions()
    {
        SaveMainGun();
        SaveSecondGun();
        SaveActiveWheels();
        SaveBattery();
        SaveAuxiliary();
        SaveIDCard();
        SaveVision();

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

        void SaveAuxiliary()
        {
            _pPWriter.Write(
                nameof(KeysForPlayerPrefs.Auxiliary), nameof(ModuleName.Shield));
        }

        void SaveIDCard()
        {
            _pPWriter.Write(
                nameof(KeysForPlayerPrefs.IDCard), nameof(ModuleName.IdCardRolly));
        }
        
        void SaveVision()
        {
            _pPWriter.Write(
                nameof(KeysForPlayerPrefs.VisionModule), nameof(ModuleName.Vision));
        }
    }

    public void SaveMainGun(ModuleName moduleName)
    {
        _pPWriter.Write(
            nameof(KeysForPlayerPrefs.MainGun), moduleName.ToString());
        RefreshSetUp();
    }

    public void SaveSecondGun(ModuleName moduleName)
    {
        _pPWriter.Write(
            nameof(KeysForPlayerPrefs.SecondGun), moduleName.ToString());
        RefreshSetUp();
    }

    public void SaveActiveWheels(ModuleName moduleName)
    {
        _pPWriter.Write(
            nameof(KeysForPlayerPrefs.ActiveWheels), moduleName.ToString());
        RefreshSetUp();
    }

    public void SaveAuxiliary(ModuleName moduleName)
    {
        _pPWriter.Write(
            nameof(KeysForPlayerPrefs.Auxiliary), moduleName.ToString());
        RefreshSetUp();
    }
    public void SaveIDCard(ModuleName moduleName)
    {
        _pPWriter.Write(
            nameof(KeysForPlayerPrefs.IDCard), moduleName.ToString());
        RefreshSetUp();
    }
    public void SaveVision(ModuleName moduleName)
    {
        _pPWriter.Write(
            nameof(KeysForPlayerPrefs.VisionModule), moduleName.ToString());
        RefreshSetUp();
    } 

    private bool TryGetDefaultModuleValue(string key, out string value)
    {
        List<SavingModuleInfo> defaults = _firstSavingInfo.GetStartModulesList();
        for (int i = 0; i < defaults.Count; i++)
        {
            SavingModuleInfo info = defaults[i];
            if (info.GetKey() != key) continue;

            info.GetValues(
                out ModuleName moduleName,
                out int playerHas,
                out TypeOfModule typeOfModule,
                out int playerUnlocked,
                out int currentHp,
                out int hasTwoHp,
                out int currentLeftHp,
                out int currentRightHp,
                out int hasCharge,
                out int charge);

            value =
                $"{(int)moduleName}#{playerHas}#{(int)typeOfModule}#{playerUnlocked}#{currentHp}" +
                $"#{hasTwoHp}#{currentLeftHp}#{currentRightHp}#{hasCharge}#{charge}";
            return true;
        }

        value = string.Empty;
        return false;
    }

    void UpdateModuleValue(string key, int index, int value)
    {
        string raw = _pPReader.GetString(key);

        if (string.IsNullOrEmpty(raw) && TryGetDefaultModuleValue(key, out string defaultRaw))
        {
            raw = defaultRaw;
            _pPWriter.Write(key, raw);
        }

        if (string.IsNullOrEmpty(raw)) return;

        string[] parts = raw.Split(ModuleValueSeparator);
        if (index < 0 || index >= parts.Length) return;

        parts[index] = value.ToString();
        _pPWriter.Write(key, string.Join(ModuleValueSeparator, parts));
    }

    public ListsForB_Menu GetListsFoBMenu() => _listsForB_Menu;
    void RefreshSetUp()
    {
        SavingInfo savingInfo = new SavingInfo();
        Fill(ref savingInfo);

        Dictionary<KeysForPlayerPrefs, string> modulesByPositions = new();
        Fill(ref modulesByPositions);

        _playerSetup.UpdateSetUp(ref savingInfo, ref modulesByPositions);
    }


}
