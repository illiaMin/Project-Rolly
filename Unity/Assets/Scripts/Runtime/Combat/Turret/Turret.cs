using System;
using UnityEngine;

public class Turret : MonoBehaviour
{
    bool _readyToFire = false;
    RobotEvents _playerEvents;
    private float _reloadTime = 0;
    private float _timeBeforeNextShot = 0;
    private int _energyPerShot;
    private HP _hp;
    TypeOfDamageble _typeOfDamageble = TypeOfDamageble.Gun;

    [SerializeField] SpriteRenderer _spriteRendererTurret;
    [SerializeField] SpriteRenderer _spriteRendererGun;
    public Transform GetGun() => _spriteRendererGun.transform;
    public bool CanShot { get; private set; } = true;
    
    public SpriteRenderer GetSpriteRendererTurret() => _spriteRendererTurret;
    public SpriteRenderer GetSpriteRendererGun() => _spriteRendererGun;
    public void SetCanShot(bool canShot) => CanShot = canShot;

    public void Initialize(SO_PlayerTurret info, RobotEvents playerEvents)
    {
        _playerEvents = playerEvents;
        _reloadTime = info.ReloadTime;
        _readyToFire = true;
        _energyPerShot = info.CostOfShot;
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
        if (_readyToFire && CanShot)
        {
            OnShotEventContext context = CreateContext();
            _playerEvents.InvokeOnShot(context);
            ReloadGun();
        }
    }

    private OnShotEventContext CreateContext()
    {
        return new 
            OnShotEventContext(transform, 
                _energyPerShot, 
                transform.root.GetComponentInChildren<Collider2D>());
    }

    private void ReloadGun()
    {
        _readyToFire = false;
        _timeBeforeNextShot = _reloadTime;
    }

    public ref HP GetHP()
    {
        return ref _hp;
    }
    public TypeOfDamageble GetTypeOfDamageble() => _typeOfDamageble;

    public void SetHP(HP newHp)
    {
        _hp = newHp;
    }
}