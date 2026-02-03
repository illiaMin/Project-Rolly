using System;
using UnityEngine;

public class TurretCreator : MonoBehaviour
{
    SO_AllModules _allModules;
    Turret _prefab;
    PlayerEvents _playerEvents;
    Transform _aimTarget;
    ProjectilesPool  _projectilesPool;
    GameObject _projectilePrefab;
    
    [SerializeField] private float _distance = 0.6f;
    public void Init(TurretCreatorContext tcc)
    {
        _allModules = tcc.AllModules;
        _prefab = tcc.Prefab;
        _playerEvents = tcc.PlayerEvents;
        _aimTarget = tcc.AimTarget;
        _projectilesPool = tcc.ProjectilesPool;
        _projectilePrefab =  tcc.ProjectilePrefab;
    }

    public Turret CreateTurret(ModuleName turretName)
    {
        GetInfoAboutTurret(turretName, out SO_PlayerTurret info);
        CreateTurret(out Turret turret);
        Setup(turret, info);

        InitializeTurretAim(turret, info);

        CreateAttacker(info, out Attacker attacker);
        InitAttacker(attacker, info);
        
        _playerEvents.InvokeOnTurretChanged(turret);
        
        return turret;
    }
    void GetInfoAboutTurret(ModuleName turretName, out SO_PlayerTurret info)
    {
        info = _allModules.Modules.Get(turretName) as SO_PlayerTurret;
    }
    void CreateTurret(out Turret turret)
    {
        turret = 
            Instantiate(_prefab, transform, false);
    }
    void Setup(Turret turret, SO_PlayerTurret info)
    {
        turret.name = "Turret";
        turret.Initialize(info, _playerEvents);
        turret.transform.localPosition = Vector3.zero;
        
        var spriteRenderer 
            = turret.GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = info.Sprite;
    }
    void InitializeTurretAim(Turret turret, SO_PlayerTurret info)
    {
        turret.GetComponent<TurretAim>().Init(_aimTarget, info.TurnSpeedDegreesPerSecond);
    }
    void CreateAttacker(SO_PlayerTurret info, out Attacker attacker)
    {
        attacker = Instantiate(info.Attacker, transform, false);
    }
    void InitAttacker(Attacker attacker, SO_PlayerTurret info)
    {
        AttackerContext ac = new AttackerContext(
            _playerEvents,
            _projectilePrefab,
            _projectilesPool,
            _distance,
            info.ProjectileInfo);

        attacker.Init(ac);
    }
}
