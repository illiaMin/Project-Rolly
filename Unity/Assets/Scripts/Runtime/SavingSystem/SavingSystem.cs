using System;
using System.Collections.Generic;
using UnityEngine;

public class SavingSystem : MonoBehaviour
{
    PlayerSetup _playerSetup = new PlayerSetup();
    ListsForB_Menu _listsForB_Menu = new ListsForB_Menu();
    public PlayerSetup GetPlayerSetup() => _playerSetup;

    [SerializeField] PlayerEvents _playerEvents;
    PlayerPrefsReader _pPReader = new();
    PlayerPrefsWriter _pPWriter = new();
    [SerializeField] private string _gameStartedKey = "GameStarted";
    [SerializeField] FirstSavingInfo _firstSavingInfo;

    public SavingSystem Init()
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
        string[] parts = value.Split('#');
        moduleName = (ModuleName)int.Parse(parts[0]);
        playerHas = int.Parse(parts[1]);
        tom = (TypeOfModule)int.Parse(parts[2]);
        playerUnlocked = int.Parse(parts[3]);
        currentHp = int.Parse(parts[4]);
        hasTwoHp = int.Parse(parts[5]);
        currentRightHp = int.Parse(parts[6]);
        currentLeftHp = int.Parse(parts[7]);
        hasCharge = int.Parse(parts[8]);
        charge = int.Parse(parts[9]);
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
        _pPWriter.Write(_gameStartedKey, 1);
        ;
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