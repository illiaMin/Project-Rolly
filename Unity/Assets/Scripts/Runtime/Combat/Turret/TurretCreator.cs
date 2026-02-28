using System;
using UnityEngine;

public class TurretCreator : MonoBehaviour
{
    SO_AllModules _allModules;
    Turret _prefab;
    PlayerEvents _playerEvents;
    Transform _aimTarget;
    ProjectilesPool  _projectilesPool;
    Turret _turret;
    ProgressRepository _progressRepository;
    
    [SerializeField] private float _distance = 0.6f;
    public void Init(TurretCreatorContext tcc)
    {
        _allModules = tcc.AllModules;
        _prefab = tcc.Prefab;
        _playerEvents = tcc.PlayerEvents;
        _aimTarget = tcc.AimTarget;
        _projectilesPool = tcc.ProjectilesPool;
        _progressRepository = tcc.ProgressRepository;
    }

    public void InitializeNewTurret(ModuleName moduleName)
    {
        Destroy(_turret.gameObject);
        _turret = CreateTurret(moduleName);
    }
    public Turret CreateTurret(ModuleName turretName)
    {
        GetInfoAboutTurret(turretName, out SO_PlayerTurret info);
        CreateTurret(out Turret turret);
        _turret = turret;

        HP newHP = new HP(info.HpMax);
        newHP.SetCurrent(_progressRepository.GetTurretHP());
        Setup(turret, info, newHP);

        InitializeTurretAim(turret, info);

        CreateAttacker(info, out Attacker attacker);
        InitAttacker(attacker, info);
        
        _playerEvents.InvokeOnTurretChanged(turret);
        
        _turret = turret;
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
    void Setup(Turret turret, SO_PlayerTurret info, HP newHP)
    {
        turret.name = "Turret";
        turret.Initialize(info, _playerEvents);
        turret.transform.localPosition = Vector3.zero;
        turret.SetHP(newHP);
        SpriteRenderer renderer
            = turret.GetSpriteRendererTurret();
        renderer.sprite = info.SpriteTurret;
        
        renderer = turret.GetSpriteRendererGun();
        renderer.sprite = info.SpriteGun;
    }
    void InitializeTurretAim(Turret turret, SO_PlayerTurret info)
    {
        TurretAim tAim = 
            turret.GetComponent<TurretAim>();
            tAim.Init(_aimTarget, info.TurnSpeedDegreesPerSecond, turret.GetGun());
            
    }
    void CreateAttacker(SO_PlayerTurret info, out Attacker attacker)
    {
        attacker = Instantiate(info.Attacker, _turret.transform, false);
    }
    void InitAttacker(Attacker attacker, SO_PlayerTurret info)
    {
        AttackerContext ac = new AttackerContext(
            _playerEvents,
            _projectilesPool,
            _distance,
            info.ProjectileInfo);

        attacker.Init(ac);
    }
}
