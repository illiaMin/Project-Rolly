using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class BMenu : MonoBehaviour
{
    [SerializeField] SpriteRenderer _image;
    public SpriteRenderer GetSpriteRenderer() => _image;
    private BMenuInput _input;
    private ListsForB_Menu _listsForB_Menu;
    private BMenuEvents _bMenuEvents;
    private PlayerEvents _playerEvents;
    private SavingSystem _savingSystem;
    private string _toShow;
    bool _isTurnedOn = false;
    KeysForPlayerPrefs _currentBMenuChanges;
    

    public void Init(BMenuInput input , BMenuCreatorContext bmc)
    {
        _input = input;
        _listsForB_Menu = bmc.ListsForB_Menu;
        _bMenuEvents = bmc.BMenuEvents;
        _playerEvents = bmc.PlayerEvents;
        _savingSystem = bmc.SavingSystem;
    }

    public void Toggle()
    {
        _isTurnedOn = !_isTurnedOn;
        _input.Toggle(_isTurnedOn);
        if (_isTurnedOn)
        {
            OnBMenuTurnedOn();
        }
        else
        {
            RemoveAllListenersFromAllNumbers();
            _bMenuEvents.InvokeOnBMenuToggleClose();
        }
    }
    public void SwapMainAndSecondGun()
    {
        ModuleName nextMainGun = Enum.Parse<ModuleName>(
            _savingSystem.GetPlayerSetup().GetCurrentSecondGunName());
        ModuleName nextSecondGun = Enum.Parse<ModuleName>(
            _savingSystem.GetPlayerSetup().GetCurrentMainGunName());
        _savingSystem.SaveSecondGun(nextSecondGun);
        _savingSystem.SaveMainGun(nextMainGun);
        _playerEvents.InvokeOnChangeTurretTo(nextMainGun);

        ModuleName name = nextMainGun;
        _currentBMenuChanges = KeysForPlayerPrefs.MainGun;
        UpdateSavingSystem(name);
        UpdateUI(name);
        name = nextSecondGun;
        _currentBMenuChanges = KeysForPlayerPrefs.SecondGun;
        UpdateSavingSystem(name);
        UpdateUI(name);
        _listsForB_Menu.RefreshLists();
        
    }

    void OnBMenuTurnedOn()
    {
        _bMenuEvents.AddListenerToOnBMenuToggle1(SetMainGunMenu);
        _bMenuEvents.AddListenerToOnBMenuToggle2(SetSecondaryGunMenu);
        _bMenuEvents.AddListenerToOnBMenuToggle3(SetAuxiliaryMenu);
        _bMenuEvents.AddListenerToOnBMenuToggle4(ChoseWheelsMenu);
        _bMenuEvents.AddListenerToOnBMenuToggle5(SetBattariesMenu);
        _bMenuEvents.AddListenerToOnBMenuToggle6(SetIdCardsMenu);
        
        _toShow = "\n 1) Main_Gun " +
                  "\n 2) Secondary_Gun " +
                  "\n 3) Auxiliary_Modules " +
                  "\n 4) Moving " +
                  "\n 5) Battaries" +
                  "\n 6) Id_Cards";
        _bMenuEvents.InvokeOnBMenuUpdateText(_toShow);
        _toShow = "";
    }
    void SetMainGunMenu()
    {
        _toShow += " Guns:";
        _currentBMenuChanges = KeysForPlayerPrefs.MainGun;
        SetGunsMenu();
    }
    void SetSecondaryGunMenu()
    {
        _toShow += " Guns:";
        _currentBMenuChanges = KeysForPlayerPrefs.SecondGun;
        SetGunsMenu();
    }
    void SetAuxiliaryMenu()
    {
        _currentBMenuChanges = KeysForPlayerPrefs.Auxiliary;
        _toShow += " Auxiliary_Modules:";
        SetAuxiliaryModulesMenu();
    }
    
    void ChoseWheelsMenu()
    {
        _toShow += " Moving Modules:";
        _currentBMenuChanges = KeysForPlayerPrefs.ActiveWheels;
        SetWheelsMenu();
    }
    void SetBattariesMenu()
    {
        _toShow += "\n Battaries";
        _bMenuEvents.InvokeOnBMenuUpdateText(_toShow);
        RemoveAllListenersFromAllNumbers();
    }
    void SetIdCardsMenu()
    {
        _toShow += "\n Id_Cards:";
        _currentBMenuChanges = KeysForPlayerPrefs.IDCard;
        SetIDCardsMenu();
    }

    void SetGunsMenu()
    {
        RemoveAllListenersFromAllNumbers();
        
        var list = _listsForB_Menu.GetModuleNamesByType(TypeOfModule.Gun);
        if (list.Count > 0)
        {
            SetEventTogglesForGunModules(ref list, ref _toShow);
        }
        _bMenuEvents.InvokeOnBMenuUpdateText(_toShow);
        _toShow = "";
    }
    void SetRiflesMenu()
    {
        RemoveAllListenersFromAllNumbers();
        
        _toShow += " Rifles:";
        
        var list = _listsForB_Menu.GetModuleNamesByType(TypeOfModule.Rifle);
        
        if (list.Count > 0)
        {
            SetEventTogglesForRifleModules(ref list, ref _toShow);
        }
        _bMenuEvents.InvokeOnBMenuUpdateText(_toShow);
        _toShow = "";
    }
    void SetAuxiliaryModulesMenu()
    {
        RemoveAllListenersFromAllNumbers();
        
        var list = _listsForB_Menu.GetModuleNamesByType(TypeOfModule.Auxiliary);
        if (list.Count > 0)
        {
            SetEventTogglesForAuxiliaryModules(ref list, ref _toShow);
        }
        _bMenuEvents.InvokeOnBMenuUpdateText(_toShow);
        _toShow = "";
    }
    void SetWheelsMenu()
    {
        RemoveAllListenersFromAllNumbers();
        
        var list = _listsForB_Menu.GetModuleNamesByType(TypeOfModule.Wheels);
        if (list.Count > 0)
        {
            SetEventTogglesForWheelsModules(ref list, ref _toShow);
        }
        _bMenuEvents.InvokeOnBMenuUpdateText(_toShow);
        _toShow = "";
    }
    void SetIDCardsMenu()
    {
        RemoveAllListenersFromAllNumbers();
        
        var list = _listsForB_Menu.GetModuleNamesByType(TypeOfModule.IdCard);
        if (list.Count > 0)
        {
            SetEventTogglesForIDCards(ref list, ref _toShow);
        }
        _bMenuEvents.InvokeOnBMenuUpdateText(_toShow);
        _toShow = "";
    }

    #region MethodsChangeOn

    void ChangeOnRifle()
    {
        ModuleName name = ModuleName.Rifle;
        
        RemoveAllListenersFromAllNumbers();
        _toShow = "";
        _playerEvents.InvokeOnChangeTurretTo(name);
        UpdateSavingSystem(name);
        UpdateUI(name);
        _listsForB_Menu.RefreshLists();

        Toggle();
    }
    void ChangeOnFireRifle()
    {
        ModuleName name = ModuleName.RifleFire;
        
        RemoveAllListenersFromAllNumbers();
        _toShow = "";
        _playerEvents.InvokeOnChangeTurretTo(name);
        UpdateSavingSystem(name);
        UpdateUI(name);
        _listsForB_Menu.RefreshLists();

        Toggle();
    }
    void ChangeOnElectroRifle()
    {
        ModuleName name = ModuleName.RifleElectro;
        
        RemoveAllListenersFromAllNumbers();
        _toShow = "";
        _playerEvents.InvokeOnChangeTurretTo(name);
        UpdateSavingSystem(name);
        UpdateUI(name);
        _listsForB_Menu.RefreshLists();

        Toggle();
    }
    void ChangeOnPhysicsRifle()
    {
        ModuleName name = ModuleName.RiflePhysic;
        
        RemoveAllListenersFromAllNumbers();
        _toShow = "";
        _playerEvents.InvokeOnChangeTurretTo(name);
        UpdateSavingSystem(name);
        UpdateUI(name);
        _listsForB_Menu.RefreshLists();

        Toggle();
    }

    void ChangeMainGunOnSword()
    {
        ModuleName name = ModuleName.Sword;
        
        RemoveAllListenersFromAllNumbers();
        _toShow = "";
        _playerEvents.InvokeOnChangeTurretTo(name);
        UpdateSavingSystem(name);
        UpdateUI(name);
        _listsForB_Menu.RefreshLists();

        Toggle();
    }
    void ChangeMainGunOnShocker()
    {
        ModuleName name = ModuleName.Shocker;
        
        RemoveAllListenersFromAllNumbers();
        _toShow = "";
        _playerEvents.InvokeOnChangeTurretTo(name);
        UpdateSavingSystem(name);
        UpdateUI(name);
        _listsForB_Menu.RefreshLists();

        Toggle();
    }
    void ChangeMainGunOnFlamethrower()
    {
        ModuleName name = ModuleName.Flamethrower;
        
        RemoveAllListenersFromAllNumbers();
        _toShow = "";
        _playerEvents.InvokeOnChangeTurretTo(name);
        UpdateSavingSystem(name);
        UpdateUI(name);
        _listsForB_Menu.RefreshLists();

        Toggle();
    }
    void ChangeMainGunOnEHG_69()
    {
        ModuleName name = ModuleName.EHG_69;
        
        RemoveAllListenersFromAllNumbers();
        _toShow = "";
        _playerEvents.InvokeOnChangeTurretTo(name);
        UpdateSavingSystem(name);
        UpdateUI(name);
        _listsForB_Menu.RefreshLists();

        Toggle();
    }
    void ChangeMainGunOnFHG_FireBall()
    {
        ModuleName name = ModuleName.FHG_FireBall;
        RemoveAllListenersFromAllNumbers();
        _toShow = "";
        _playerEvents.InvokeOnChangeTurretTo(name);
        UpdateSavingSystem(name);
        UpdateUI(name);
        _listsForB_Menu.RefreshLists();
        
        Toggle();
    }
    void ChangeMainGunOnKHG_Crusher()
    {
        ModuleName name = ModuleName.KHG_Crusher;
        
        RemoveAllListenersFromAllNumbers();
        _toShow = "";
        _playerEvents.InvokeOnChangeTurretTo(name);
        UpdateSavingSystem(name);
        UpdateUI(name);
        _listsForB_Menu.RefreshLists();

        Toggle();
    }
    
    void ChangeAuxiliaryModuleOnShield()
    {
        ModuleName name = ModuleName.Shield;
        
        RemoveAllListenersFromAllNumbers();
        _toShow = "";
        UpdateSavingSystem(name);
        _playerEvents.InvokeOnChangeAuxiliaryTo();
        UpdateUI(name);
        _listsForB_Menu.RefreshLists();

        Toggle();
    }
    void ChangeAuxiliaryModuleOnDash()
    {
        ModuleName name = ModuleName.Dash;
        
        RemoveAllListenersFromAllNumbers();
        _toShow = "";
        UpdateSavingSystem(name);
        _playerEvents.InvokeOnChangeAuxiliaryTo();
        UpdateUI(name);
        _listsForB_Menu.RefreshLists();

        Toggle();
    }
    void ChangeAuxiliaryModuleOnMiniMap()
    {
        ModuleName name = ModuleName.Minimap;
        
        RemoveAllListenersFromAllNumbers();
        _toShow = "";
        UpdateSavingSystem(name);
        _playerEvents.InvokeOnChangeAuxiliaryTo();
        UpdateUI(name);
        _listsForB_Menu.RefreshLists();

        Toggle();
    }

    void ChangeWheelsOnTracks()
    {
        ModuleName name = ModuleName.Tracks;
        
        RemoveAllListenersFromAllNumbers();
        _toShow = "";
        _playerEvents.InvokeOnChangeWheelsTo(name);
        UpdateSavingSystem(name);
        UpdateUI(name);
        _listsForB_Menu.RefreshLists();

        Toggle();
    }
    void ChangeWheelsOnWheels()
    {
        ModuleName name = ModuleName.Wheels;
        
        RemoveAllListenersFromAllNumbers();
        _toShow = "";
        _playerEvents.InvokeOnChangeWheelsTo(name);
        UpdateSavingSystem(name);
        UpdateUI(name);
        _listsForB_Menu.RefreshLists();

        Toggle();
    }
    void ChangeWheelsOnInsect()
    {
        ModuleName name = ModuleName.Insect;
        
        RemoveAllListenersFromAllNumbers();
        _toShow = "";
        _playerEvents.InvokeOnChangeWheelsTo(name);
        UpdateSavingSystem(name);
        UpdateUI(name);
        _listsForB_Menu.RefreshLists();

        Toggle();
    }
    void ChangeIDCardOnRolly()
    {
        ModuleName name = ModuleName.IdCardRolly;
        
        RemoveAllListenersFromAllNumbers();
        _toShow = "";
        _playerEvents.InvokeOnChangeIdCardTo(name);
        UpdateSavingSystem(name);
        UpdateUI(name);
        _listsForB_Menu.RefreshLists();

        Toggle();
    }
    void ChangeIDCardOnNewOne()
    {
        ModuleName name = ModuleName.IdCardNewOne;
        
        RemoveAllListenersFromAllNumbers();
        _toShow = "";
        _playerEvents.InvokeOnChangeIdCardTo(name);
        UpdateSavingSystem(name);
        UpdateUI(name);
        _listsForB_Menu.RefreshLists();

        Toggle();
    }
    
    #endregion
    
    void SetEventTogglesForGunModules(ref List<ModuleName>  list, ref string toShow)
    {
        for (int i = 0; i < list.Count; i++)
        {
            switch (list[i])
            {
                case ModuleName.Rifle:
                    _bMenuEvents.AddListenerToOnBMenuToggle1(SetRiflesMenu);
                    _toShow += $"\n 1) " + list[i].ToString();
                    break;
                case ModuleName.Sword:
                    _bMenuEvents.AddListenerToOnBMenuToggle2(ChangeMainGunOnSword);
                    _toShow += $"\n 2) " + list[i].ToString();
                    break;
                case ModuleName.Shocker:
                    _bMenuEvents.AddListenerToOnBMenuToggle3(ChangeMainGunOnShocker);
                    _toShow += $"\n 3) " + list[i].ToString();
                    break;
                case ModuleName.Flamethrower:
                    _bMenuEvents.AddListenerToOnBMenuToggle4(ChangeMainGunOnFlamethrower);
                    _toShow += $"\n 4) " + list[i].ToString();
                    break;
                case ModuleName.EHG_69:
                    _bMenuEvents.AddListenerToOnBMenuToggle5(ChangeMainGunOnEHG_69);
                    _toShow += $"\n 5) " + list[i].ToString();
                    break;
                case ModuleName.FHG_FireBall:
                    _bMenuEvents.AddListenerToOnBMenuToggle6(ChangeMainGunOnFHG_FireBall);
                    _toShow += $"\n 6) " + list[i].ToString();
                    break;
                case ModuleName.KHG_Crusher:
                    _bMenuEvents.AddListenerToOnBMenuToggle7(ChangeMainGunOnKHG_Crusher);
                    _toShow += $"\n 7) " + list[i].ToString();
                    break;
            }
        }
    }
    void SetEventTogglesForRifleModules(ref List<ModuleName> list, ref string toShow)
    {
        for (int i = 0; i < list.Count; i++)
        {
            switch (list[i])
            {
                case ModuleName.Rifle:
                    _bMenuEvents.AddListenerToOnBMenuToggle1(ChangeOnRifle);
                    _toShow += $"\n 1) " + list[i].ToString();
                    break;
                case ModuleName.RifleFire:
                    _bMenuEvents.AddListenerToOnBMenuToggle2(ChangeOnFireRifle);
                    _toShow += $"\n 2) " + list[i].ToString();
                    break;
                case ModuleName.RifleElectro:
                    _bMenuEvents.AddListenerToOnBMenuToggle3(ChangeOnElectroRifle);
                    _toShow += $"\n 3) " + list[i].ToString();
                    break;
                case ModuleName.RiflePhysic:
                    _bMenuEvents.AddListenerToOnBMenuToggle4(ChangeOnPhysicsRifle);
                    _toShow += $"\n 4) " + list[i].ToString();
                    break;
            }

        }
    }
    void SetEventTogglesForWheelsModules(ref List<ModuleName> list, ref string toShow)
    {
        for (int i = 0; i < list.Count; i++)
        {
            switch (list[i])
            {
                case ModuleName.Tracks:
                    _bMenuEvents.AddListenerToOnBMenuToggle1(ChangeWheelsOnTracks);
                    _toShow += $"\n 1) " + list[i].ToString();
                    break;
                case ModuleName.Wheels:
                    _bMenuEvents.AddListenerToOnBMenuToggle2(ChangeWheelsOnWheels);
                    _toShow += $"\n 2) " + list[i].ToString();
                    break;
                case ModuleName.Insect:
                    _bMenuEvents.AddListenerToOnBMenuToggle3(ChangeWheelsOnInsect);
                    _toShow += $"\n 3) " + list[i].ToString();
                    break;
            }
        }
    }
    void SetEventTogglesForAuxiliaryModules(ref List<ModuleName> list, ref string toShow)
    {
        for (int i = 0; i < list.Count; i++)
        {
            switch (list[i])
            {
                case ModuleName.Shield:
                    _bMenuEvents.AddListenerToOnBMenuToggle1(ChangeAuxiliaryModuleOnShield);
                    _toShow += $"\n 1) " + list[i].ToString();
                    break;
                case ModuleName.Dash:
                    _bMenuEvents.AddListenerToOnBMenuToggle2(ChangeAuxiliaryModuleOnDash);
                    _toShow += $"\n 2) " + list[i].ToString();
                    break;
                case ModuleName.Minimap:
                    _bMenuEvents.AddListenerToOnBMenuToggle3(ChangeAuxiliaryModuleOnMiniMap);
                    _toShow += $"\n 3) " + list[i].ToString();
                    break;
            }
        }
    }
    void SetEventTogglesForIDCards(ref List<ModuleName> list, ref string toShow)
    {
        for (int i = 0; i < list.Count; i++)
        {
            switch (list[i])
            {
                case ModuleName.IdCardRolly:
                    _bMenuEvents.AddListenerToOnBMenuToggle1(ChangeIDCardOnRolly);
                    _toShow += $"\n 1) " + list[i].ToString();
                    break;
                case ModuleName.IdCardNewOne:
                    _bMenuEvents.AddListenerToOnBMenuToggle2(ChangeIDCardOnNewOne);
                    _toShow += $"\n 2) " + list[i].ToString();
                    break;
            }
        }
    }
    
    
    void RemoveAllListenersFromAllNumbers()
    {
        _bMenuEvents.RemoveAllListenersFromOnBMenuToggle1();
        _bMenuEvents.RemoveAllListenersFromOnBMenuToggle2();
        _bMenuEvents.RemoveAllListenersFromOnBMenuToggle3();
        _bMenuEvents.RemoveAllListenersFromOnBMenuToggle4();
        _bMenuEvents.RemoveAllListenersFromOnBMenuToggle5();
        _bMenuEvents.RemoveAllListenersFromOnBMenuToggle6();
        _bMenuEvents.RemoveAllListenersFromOnBMenuToggle7();
    }

    void UpdateSavingSystem(ModuleName name)
    {
        if (_currentBMenuChanges == KeysForPlayerPrefs.MainGun)
        {
            _savingSystem.SaveMainGun(name);
        }
        else if (_currentBMenuChanges == KeysForPlayerPrefs.SecondGun)
        {
            _savingSystem.SaveSecondGun(name);
        }
        else if (_currentBMenuChanges == KeysForPlayerPrefs.ActiveWheels)
        {
            _savingSystem.SaveActiveWheels(name);
        }
        else if (_currentBMenuChanges == KeysForPlayerPrefs.Auxiliary)
        {
            _savingSystem.SaveAuxiliary(name);
        }
        else if (_currentBMenuChanges == KeysForPlayerPrefs.IDCard)
        {
            _savingSystem.SaveIDCard(name);
        }
        
        else throw new Exception("there are no methods to invoke: " + _currentBMenuChanges.ToString());
        
        
    }
    void UpdateUI(ModuleName name)
    {
        if (_currentBMenuChanges == KeysForPlayerPrefs.MainGun)
        {
            _input.ChangeMainGun(name.ToString());
        }
        else if (_currentBMenuChanges == KeysForPlayerPrefs.SecondGun)
        {
            _input.ChangeSecondGun(name.ToString());
        }
        else if (_currentBMenuChanges == KeysForPlayerPrefs.ActiveWheels)
        {
            _input.ChangeActiveWheels(name.ToString());
        }
        else if (_currentBMenuChanges == KeysForPlayerPrefs.Auxiliary)
        {
            _input.ChangeActiveAuxiliary(name.ToString());
        }
        else if (_currentBMenuChanges == KeysForPlayerPrefs.IDCard)
        {
        }
        else throw new Exception("there are no methods to invoke");
    }

    
}