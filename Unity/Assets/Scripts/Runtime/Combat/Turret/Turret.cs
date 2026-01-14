using System;
using UnityEngine;

public class Turret : MonoBehaviour
{
    bool _readyToFire = false;
    PlayerEvents _playerEvents;
    private float _reloadTime = 0;
    private float _timeBeforeNextShot = 0;
    
    public void Initialize(SO_PlayerTurret SO, PlayerEvents playerEvents)
    {
        _playerEvents = playerEvents;
        _reloadTime = SO.ReloadTime;
        _readyToFire = true;
    }

    private void Update()
    {
        if (!_readyToFire)
        {
            _timeBeforeNextShot -= Time.deltaTime;
            if (_timeBeforeNextShot <= 0)
            {
                _readyToFire = true;
            }
        }
    }

    public void TryShot()
    {
        if (_readyToFire)
        {
            _playerEvents.InvokeOnShot(transform);
            ReloadGun();
        }
    }

    private void ReloadGun()
    {
        _readyToFire = false;
        _timeBeforeNextShot = _reloadTime;
    }
}