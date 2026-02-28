using UnityEngine;

public sealed class Battery : MonoBehaviour
{
    private int _maxCharge;
    private int _currentCharge;

    private PlayerEvents _playerEvents;

    private bool _isLow;
    private bool _isEmpty;

    private const int LOW_BATTERY_PERCENT = 5;
    
    HP _hp;
    public void SetHp(HP hp)
    {
        _hp = hp;
    }

    public int ChargePercent
    {
        get
        {
            if (_maxCharge <= 0) return 0;
            return Mathf.RoundToInt((float)_currentCharge / (float)_maxCharge * 100f);
        }
    }

    public void Init(SO_Battery info, BatteryCreatorContext bcc)
    {
        _playerEvents = bcc.PlayerEvents;

        _hp = new HP(info.MaxHP);

        _maxCharge = Mathf.Max(info.MaxCharge, 0);
        _currentCharge = bcc.Charge;

        EvaluateThresholds();
    }
    
    public void ConsumeCharge(int amount)
    {
        if (_currentCharge <= 0)
            return;

        _currentCharge -= Mathf.Max(amount, 0);
        if (_currentCharge < 0)
            _currentCharge = 0;

        EvaluateThresholds();
    }

    private void EvaluateThresholds()
    {
        int percent = ChargePercent;

        bool emptyNow = _currentCharge == 0;
        
        bool lowNow = !emptyNow && percent < LOW_BATTERY_PERCENT;
        
        
        if (emptyNow && !_isEmpty)
        {
            _isEmpty = true;
            _isLow = true;
            _playerEvents.InvokeOnBatteryEmpty();
            return;
        }
        if (lowNow)
        {
            _isLow = true;
            _playerEvents.InvokeOnBatteryLow();
        }
        if (!lowNow && _isLow)
        {
            _isLow = false;
            _playerEvents.InvokeOnBatteryRecovered(percent);
        }
        
        _playerEvents.InvokeOnBatteryChargePercentChanged(ChargePercent);
    }
    
    public ref HP GetHP()
    {
        return ref _hp;
    }
}