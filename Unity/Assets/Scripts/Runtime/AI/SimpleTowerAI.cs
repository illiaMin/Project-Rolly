using System;
using UnityEngine;

public class SimpleTowerAI : MonoBehaviour
{
    [SerializeField] private float _agroDistance;
    [SerializeField] private Transform _target;
    [SerializeField] Turret _prefabTurret;
    [SerializeField] Turret _turret;
    [SerializeField] SO_PlayerTurret _info;
    [SerializeField] RobotEvents _robotEvents;
    [SerializeField] private bool _playerOnAgroField;
    [SerializeField] Transform _player;
    
    [SerializeField] ProjectilesPool _projectilesPool;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        InitTurret();
    }
    void Update()
    {
        if (Vector2.Distance(
                _target.position, transform.position) < _agroDistance) 
            _playerOnAgroField = true;
        else 
            _playerOnAgroField = false;

        if (_playerOnAgroField) _target.position = _player.position;
        else _target.position = transform.up * 2;
    }
    public void InitTurret()
    {
        _turret = 
            Instantiate(_prefabTurret, transform, false);
        Setup(_turret, _info);

        InitializeTurretAim(_turret, _info);

        CreateAttacker(_info, out Attacker attacker);
        InitAttacker(attacker, _info);
    }
    private void InitializeTurretAim(Turret turret, SO_PlayerTurret info)
    {
        TurretAim tAim = 
            turret.GetComponent<TurretAim>();
        tAim.Init(_target, info.TurnSpeedDegreesPerSecond, turret.GetGun());
    }
    void CreateAttacker(SO_PlayerTurret info, out Attacker attacker)
    {
        attacker = Instantiate(info.Attacker, _turret.transform, false);
    }
    void Setup(Turret turret, SO_PlayerTurret info)
    {
        turret.name = "Turret";
        turret.Initialize(info, _robotEvents);
        turret.transform.localPosition = Vector3.zero;
        SpriteRenderer renderer = turret.GetSpriteRendererGun();
        renderer.sprite = info.SpriteGun;
            
    }
    void InitAttacker(Attacker attacker, SO_PlayerTurret info)
    {
        AttackerContext ac = new AttackerContext(
            _robotEvents,
            _projectilesPool,
            0.6f,
            info.ProjectileInfo);

        attacker.Init(ac);
    }

    public void Fire()
    {
        _turret.TryShot();
    }
    
}
