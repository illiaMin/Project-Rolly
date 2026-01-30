using UnityEngine;
using UnityEngine.UI;

public sealed class BatteryUI : MonoBehaviour
{
    [SerializeField] private Text _percentText;

    private PlayerEvents _playerEvents;

    public void Init(PlayerEvents playerEvents)
    {
        _playerEvents = playerEvents;

        _playerEvents.AddListenerToOnBatteryChargePercentChanged(UpdateUI);
        _playerEvents.AddListenerToOnBatteryRecovered(OnBatteryRecovered);
    }

    private void UpdateUI(int percent)
    {
        if (_percentText != null)
            _percentText.text = "Battery charge is " + percent + "%";
    }
    private void OnBatteryRecovered()
    {

    }
    private void OnDestroy()
    {
        if (_playerEvents == null)
            return;

        _playerEvents.RemoveListenerFromOnBatteryChargePercentChanged(UpdateUI);
        _playerEvents.RemoveListenerFromOnBatteryRecovered(OnBatteryRecovered);
    }
}