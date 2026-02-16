using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : MonoBehaviour
{
    #region OnShot
    
        private readonly UnityEvent<OnShotEventContext> _onShot 
            = new UnityEvent<OnShotEventContext>();

        public void InvokeOnShot(OnShotEventContext context) 
            => _onShot.Invoke(context);
        public void AddListenerToOnShot(UnityAction<OnShotEventContext> listener) 
            => _onShot.AddListener(listener);
        
        public void RemoveListenerFromOnShot(UnityAction<OnShotEventContext> listener) 
            => _onShot.RemoveListener(listener);

    
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
    
    #region OnBatteryLow

    private readonly UnityEvent _onBatteryLow = new UnityEvent();

    public void InvokeOnBatteryLow() => _onBatteryLow.Invoke();
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
}