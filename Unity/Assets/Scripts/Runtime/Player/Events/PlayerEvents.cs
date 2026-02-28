using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : RobotEvents
{
    
    #region OnChangeTurretTo
    
    private readonly UnityEvent<ModuleName> _onChangeTurretTo
        = new UnityEvent<ModuleName>();
    public void InvokeOnChangeTurretTo(ModuleName mname) 
        => _onChangeTurretTo.Invoke(mname);
    public void AddListenerToOnChangeTurretTo(UnityAction<ModuleName> listener) 
        => _onChangeTurretTo.AddListener(listener);
        
    public void RemoveListenerFromOnChangeTurretTo(UnityAction<ModuleName> listener) 
        => _onChangeTurretTo.RemoveListener(listener);

    #endregion
    
    #region OnChangeAuxiliaryTo
    
    private readonly UnityEvent _onChangeAuxiliaryTo
        = new UnityEvent();
    public void InvokeOnChangeAuxiliaryTo() 
        => _onChangeAuxiliaryTo.Invoke();
    public void AddListenerToOnChangeAuxiliaryTo(UnityAction listener) 
        => _onChangeAuxiliaryTo.AddListener(listener);
    public void RemoveListenerFromOnChangeAuxiliaryTo(UnityAction listener) 
        => _onChangeAuxiliaryTo.RemoveListener(listener);

    #endregion
    
    #region OnChangeWheelsTo
    
    private readonly UnityEvent<ModuleName> _onChangeWheelsTo
        = new UnityEvent<ModuleName>();
    public void InvokeOnChangeWheelsTo(ModuleName mname) 
        => _onChangeWheelsTo.Invoke(mname);
    public void AddListenerToOnChangeWheelsTo(UnityAction<ModuleName> listener) 
        => _onChangeWheelsTo.AddListener(listener);
        
    public void RemoveListenerFromOnChangeWheelsTo(UnityAction<ModuleName> listener) 
        => _onChangeWheelsTo.RemoveListener(listener);

    #endregion
    
    #region OnChangeIdCardTo
    
    private readonly UnityEvent<ModuleName> _onChangeIdCardTo
        = new UnityEvent<ModuleName>();
    public void InvokeOnChangeIdCardTo(ModuleName mname) 
        => _onChangeIdCardTo.Invoke(mname);
    public void AddListenerToOnChangeIdCardTo(UnityAction<ModuleName> listener) 
        => _onChangeIdCardTo.AddListener(listener);
        
    public void RemoveListenerFromOnChangeIdCardTo(UnityAction<ModuleName> listener) 
        => _onChangeIdCardTo.RemoveListener(listener);

    #endregion
    
    #region OnTurretChanged
    
        private readonly UnityEvent<Turret> _onTurretChanged 
            = new UnityEvent<Turret>();
    
        public void InvokeOnTurretChanged(Turret turret) 
            => _onTurretChanged.Invoke(turret);
        public void AddListenerToOnTurretChanged(UnityAction<Turret> listener) 
            => _onTurretChanged.AddListener(listener);
        
        public void RemoveListenerFromOnTurretChanged(UnityAction<Turret> listener) 
            => _onTurretChanged.RemoveListener(listener);

    #endregion
    
    #region OnWheelsChanged
    
    private readonly UnityEvent<Wheels> _onWheelsChanged 
        = new UnityEvent<Wheels>();
    
    public void InvokeOnWheelsChanged(Wheels wheels) 
        => _onWheelsChanged.Invoke(wheels);
    public void AddListenerToOnWheelsChanged(UnityAction<Wheels> listener) 
        => _onWheelsChanged.AddListener(listener);
        
    public void RemoveListenerFromOnWheelsChanged(UnityAction<Wheels> listener) 
        => _onWheelsChanged.RemoveListener(listener);

    #endregion
    
    #region OnBatteryChanged
    
    private readonly UnityEvent<Battery> _onBatteryChanged 
        = new UnityEvent<Battery>();
    
    public void InvokeOnBatteryChanged(Battery battery) 
        => _onBatteryChanged.Invoke(battery);
    public void AddListenerToOnBatteryChanged(UnityAction<Battery> listener) 
        => _onBatteryChanged.AddListener(listener);
        
    public void RemoveListenerFromOnBatteryChanged(UnityAction<Battery> listener) 
        => _onBatteryChanged.RemoveListener(listener);

    #endregion
    
    #region OnAuxiliaryModuleChanged
    
    private readonly UnityEvent<AuxiliaryModule> _onAuxiliaryModuleChanged 
        = new UnityEvent<AuxiliaryModule>();
    
    public void InvokeOnAuxiliaryModuleChanged(AuxiliaryModule auxiliaryModule) 
        => _onAuxiliaryModuleChanged.Invoke(auxiliaryModule);
    public void AddListenerToOnAuxiliaryModuleChanged(UnityAction<AuxiliaryModule> listener) 
        => _onAuxiliaryModuleChanged.AddListener(listener);
        
    public void RemoveListenerFromOnAuxiliaryModuleChanged(UnityAction<AuxiliaryModule> listener) 
        => _onAuxiliaryModuleChanged.RemoveListener(listener);

    #endregion
    
    #region OnBatteryLow

    private readonly UnityEvent _onBatteryLow = new UnityEvent();

    public void InvokeOnBatteryLow()
    {
        _onBatteryLow.Invoke();
    } 
    public void AddListenerToOnBatteryLow(UnityAction listener) => _onBatteryLow.AddListener(listener);
    public void RemoveListenerFromOnBatteryLow(UnityAction listener) => _onBatteryLow.RemoveListener(listener);

    #endregion

    #region OnBatteryRecovered

    private readonly UnityEvent<int> _onBatteryRecovered = new UnityEvent<int>();

    public void InvokeOnBatteryRecovered(int currentPercent) =>
        _onBatteryRecovered.Invoke(currentPercent);
    public void AddListenerToOnBatteryRecovered(UnityAction<int> listener) =>
        _onBatteryRecovered.AddListener(listener);
    public void RemoveListenerFromOnBatteryRecovered(UnityAction<int> listener) =>
        _onBatteryRecovered.RemoveListener(listener);

    #endregion

    #region OnBatteryEmpty

    private readonly UnityEvent _onBatteryEmpty = new UnityEvent();

    public void InvokeOnBatteryEmpty() => _onBatteryEmpty.Invoke();
    public void AddListenerToOnBatteryEmpty(UnityAction listener) => _onBatteryEmpty.AddListener(listener);
    public void RemoveListenerFromOnBatteryEmpty(UnityAction listener) => _onBatteryEmpty.RemoveListener(listener);

    #endregion
    
    #region OnBatteryChargePercentChanged

    private readonly UnityEvent<int> _onBatteryChargePercentChanged = 
        new UnityEvent<int>();

    public void InvokeOnBatteryChargePercentChanged(int percent)
    {
        _onBatteryChargePercentChanged.Invoke(percent);
    }
    public void AddListenerToOnBatteryChargePercentChanged(
        UnityAction<int> listener)
    {
        _onBatteryChargePercentChanged.AddListener(listener);
    }

    public void RemoveListenerFromOnBatteryChargePercentChanged(
        UnityAction<int> listener)
    {
        _onBatteryChargePercentChanged.RemoveListener(listener);
    }

    #endregion

    #region OnBMenuToggle

    private readonly UnityEvent _onBMenuToggle = new UnityEvent();

    public void InvokeOnBMenuToggle() => _onBMenuToggle.Invoke();
    public void AddListenerToOnBMenuToggle(UnityAction listener) => _onBMenuToggle.AddListener(listener);
    public void RemoveListenerFromOnBMenuToggle(UnityAction listener) => _onBMenuToggle.RemoveListener(listener);

    #endregion
    
    #region OnDashToggle

    private readonly UnityEvent _onDashToggle = new UnityEvent();

    public void InvokeOnDashToggle() => _onDashToggle.Invoke();
    public void AddListenerToOnDashToggle(UnityAction listener) => _onDashToggle.AddListener(listener);
    public void RemoveListenerFromOnDashToggle(UnityAction listener) => _onDashToggle.RemoveListener(listener);

    #endregion
}

