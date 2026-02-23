using System.Collections.Generic;
using UnityEngine;

public class ListsForB_Menu
{
    private SavingInfo _savingInfo;

    public void Init(SavingInfo savingInfo)
    {
        _savingInfo = savingInfo;

        RefreshLists();
        
        FillModuleNamesByType();
    }
    
    #region AbleTypes

    List<TypeOfModule> _ableTypes = new();

    public void SetAbleType(TypeOfModule type)
    {
        if (_ableTypes.Contains(type)) return;
        _ableTypes.Add(type);
    }
    public List<TypeOfModule> GetAbleTypes() => _ableTypes;

    #endregion

    #region AbleNames

    Dictionary<TypeOfModule, List<ModuleName>> _moduleNamesByType = new();
    
    public List<ModuleName> GetModuleNamesByType(TypeOfModule type) 
        => _moduleNamesByType.ContainsKey(type) ? _moduleNamesByType[type] : null;
    
    List<ModuleName> _gunsModuleNames = new List<ModuleName>();
    List<ModuleName> _riflesModuleNames = new List<ModuleName>();
    List<ModuleName> _auxiliaryModuleNames = new List<ModuleName>();
    List<ModuleName> _wheelsModuleNames = new List<ModuleName>();
    List<ModuleName> _idCardModuleNames = new List<ModuleName>();
    List<ModuleName> _battareisModuleNames = new List<ModuleName>();
    
    public void RefreshLists()
    {
        ClearAllLists();
        FillAbleTypes();
        FillGunsModuleNames();
        FillRiflesModuleNames();
        FillAuxiliaryModuleNames();
        FillWheelsModuleNames();
        FillIdCardModuleNames();
        FillBattareisModuleNames();
    }

    void ClearAllLists()
    {
        _gunsModuleNames.Clear();
        _riflesModuleNames.Clear();
        _auxiliaryModuleNames.Clear();
        _wheelsModuleNames.Clear();
        _idCardModuleNames.Clear();
        _battareisModuleNames.Clear();
    }
    private void FillAbleTypes()
    {
        var list = _savingInfo.GetModulesList();
        foreach (var el in list)
        {
            if (el.IsUnlocked()) SetAbleType(el.GetTypeOfModule());
        }
    }
    private void FillGunsModuleNames()
    {
        var list = _savingInfo.GetModulesList();
        foreach (var el in list)
        {
            if (el.IsUnlocked())
            {
                if (el.GetTypeOfModule() == TypeOfModule.Gun)
                    SetModuleNameTo(_gunsModuleNames, el.GetModuleName());
            }
        }
    }
    
    private void FillRiflesModuleNames()
    {
        var list = _savingInfo.GetModulesList();
        foreach (var el in list)
        {
            if (el.IsUnlocked())
            {
                if (el.GetTypeOfModule() == TypeOfModule.Gun 
                    && el.GetModuleName() == ModuleName.Rifle)
                    SetModuleNameTo(_riflesModuleNames, el.GetModuleName());
                
                if (el.GetTypeOfModule() == TypeOfModule.Rifle)
                    SetModuleNameTo(_riflesModuleNames, el.GetModuleName());
            }
        }
    }

    private void FillAuxiliaryModuleNames()
    {
        var list = _savingInfo.GetModulesList();
        foreach (var el in list)
        {
            if (el.IsUnlocked())
            {
                if (el.GetTypeOfModule() == TypeOfModule.Auxiliary)
                    SetModuleNameTo(_auxiliaryModuleNames, el.GetModuleName());
            }
        }
    }
    private void FillWheelsModuleNames()
    {
        var list = _savingInfo.GetModulesList();
        foreach (var el in list)
        {
            if (el.IsUnlocked())
            {
                if (el.GetTypeOfModule() == TypeOfModule.Wheels)
                    SetModuleNameTo(_wheelsModuleNames, el.GetModuleName());
            }
        }
    }
    private void FillIdCardModuleNames()
    {
        var list = _savingInfo.GetModulesList();
        foreach (var el in list)
        {
            if (el.IsUnlocked())
            {
                if (el.GetTypeOfModule() == TypeOfModule.IdCard)
                    SetModuleNameTo(_idCardModuleNames, el.GetModuleName());
            }
        }
    }
    private void FillBattareisModuleNames()
    {
        var list = _savingInfo.GetModulesList();
        foreach (var el in list)
        {
            if (el.IsUnlocked())
            {
                if (el.GetTypeOfModule() == TypeOfModule.Battery)
                    SetModuleNameTo(_battareisModuleNames, el.GetModuleName());
            }
        }
    }
    public void SetModuleNameTo(List<ModuleName> list, ModuleName moduleName)
    {
        if (list.Contains(moduleName)) return;
        list.Add(moduleName);
    }
    private void FillModuleNamesByType()
    {
        _moduleNamesByType.Add(TypeOfModule.Gun, _gunsModuleNames);
        _moduleNamesByType.Add(TypeOfModule.Rifle, _riflesModuleNames);
        _moduleNamesByType.Add(TypeOfModule.Auxiliary, _auxiliaryModuleNames);
        _moduleNamesByType.Add(TypeOfModule.Wheels, _wheelsModuleNames);
        _moduleNamesByType.Add(TypeOfModule.IdCard, _idCardModuleNames);
        _moduleNamesByType.Add(TypeOfModule.Battery, _battareisModuleNames);
    }
    
    #endregion
}
