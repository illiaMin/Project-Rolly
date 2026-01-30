using UnityEngine;

public class EnergySystem : MonoBehaviour
{
    private Turret _turret;
    private PlayerEvents _playerEvents;

    public void Init(Turret turret, Battery battery, PlayerEvents playerEvents)
    {
        _turret = turret;
        _playerEvents = playerEvents;

        _playerEvents.AddListenerToOnBatteryLow(OnLowBattery);
        _playerEvents.AddListenerToOnBatteryRecovered(OnBatteryRecovered);
    }

    private void OnLowBattery()
    {
        _turret.SetCanShot(false);
    }

    private void OnBatteryRecovered()
    {
        _turret.SetCanShot(true);
    }
}