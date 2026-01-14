using System;
using UnityEngine;

public class PlayerCompositionRoot : MonoBehaviour
{
    [SerializeField] PlayerEvents _playerEvents;
    [SerializeField] Camera _camera;
    [SerializeField] Transform _target;
    [SerializeField] InputModule _inputModule;
    
    [SerializeField] ProjectilesPool _projectilesPool;
    [SerializeField] SO_AllTurrets _allTurrets;
    [SerializeField] Turret _turretPrefab;
    [SerializeField] TurretCreator _turretCreator;
    [SerializeField] GameObject _projectilePrefab;
    
    private void Start()
    {
        InputContext inputContext 
            = new InputContext(_playerEvents, _camera, _target);
        _inputModule.Init(inputContext);

        TurretCreatorContext tc 
            = new TurretCreatorContext
                (_allTurrets, _turretPrefab, 
                    _playerEvents, _target, 
                    _projectilesPool,
                    _projectilePrefab);
        
        _turretCreator.Init(tc);
    }
    
}

