using UnityEngine;

public sealed class Battery : MonoBehaviour, IDamageable
{
    public HP Hp { get; private set; }

    private int _maxCharge;
    private int _currentCharge;

    private PlayerEvents _playerEvents;

    private bool _isLow;
    private bool _isEmpty;

    private const int LOW_BATTERY_PERCENT = 5;

    public int ChargePercent
    {
        get
        {
            if (_maxCharge <= 0) return 0;
            return Mathf.RoundToInt((float)_currentCharge / (float)_maxCharge * 100f);
        }
    }

    public void Init(SO_Battery info, PlayerEvents playerEvents)
    {
        _playerEvents = playerEvents;

        Hp = new HP(info.MaxHP);

        _maxCharge = Mathf.Max(info.MaxCharge, 0);
        _currentCharge = _maxCharge;

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
        bool lowNow = !emptyNow && percent <= LOW_BATTERY_PERCENT;
        if (emptyNow && !_isEmpty)
        {
            _isEmpty = true;
            _isLow = true;
            _playerEvents.InvokeOnBatteryEmpty();
            return;
        }
        if (lowNow && !_isLow)
        {
            _isLow = true;
            _playerEvents.InvokeOnBatteryLow();
            return;
        }
        if (!lowNow && _isLow)
        {
            _isLow = false;
            _playerEvents.InvokeOnBatteryRecovered();
        }
        
        _playerEvents.InvokeOnBatteryChargePercentChanged(ChargePercent);
    }

    public void TakeDmg(SO_Damage damage)
    {
        
    }
}