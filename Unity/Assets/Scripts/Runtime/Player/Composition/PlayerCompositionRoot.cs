using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCompositionRoot : MonoBehaviour
{
    [SerializeField] PlayerEvents _playerEvents;
    [SerializeField] Camera _camera;
    [SerializeField] Transform _target;
    [SerializeField] InputModule _inputModule;
    
    [SerializeField] EnergySystem _energySystem;
    
    [SerializeField] ProjectilesPool _projectilesPool;
    [SerializeField] Turret _turretPrefab;
    [SerializeField] TurretCreator _turretCreator;
    [SerializeField] GameObject _projectilePrefab;
    
    [SerializeField] ModulesCreator _modulesCreator;
    [SerializeField] SO_AllModules _allModules;
    [SerializeField] ProgressRepository _progressRepository;

    [SerializeField] Wheels _prefabWheels;
    [SerializeField] PlayerDrive _playerDrive;
    [SerializeField] WheelsCreator _wheelsCreator;
    
    [SerializeField] BatteryUI _batteryUI;
    [SerializeField] Battery _prefabBattery;
    [SerializeField] BatteryCreator _batteryCreator;

    [SerializeField] BMenu _prefabBMenu;
    [SerializeField] BMenuCreator _bMenuCreator;
    [SerializeField] Text _bMenuTextField;
    
    [SerializeField] VisionModuleCreator _visionModuleCreator;
    [SerializeField] VisionModule _prefabVisionModule;
    [SerializeField] Image _visionModuleMaskImage;
    
    private void Awake()
    {
        InputContext inputContext = CreateInputContext();
        _inputModule.Init(inputContext);
        
        _modulesCreator.Init(_progressRepository, _allModules);

        
        TurretCreatorContext tc = CreateTurretContext();
        Turret turret = _modulesCreator.
            CreateMainTurret(_turretCreator, tc);
        
        WheelsCreatorContext wcc = CreateWheelsContext();
        Wheels wheels = _modulesCreator.
            CreateWheels(_wheelsCreator, wcc);

        _batteryUI.Init(_playerEvents);
        
        BatteryCreatorContext bcc = CreateBatteryContext();
        Battery battery = _modulesCreator.
            CreateBattery(_batteryCreator, bcc);
        _playerEvents.AddListenerToOnShot(
            context => battery.ConsumeCharge(context.EnergyPerShot));
        
        
        BMenuCreatorContext bmcc = CreateBMenuContext();
        BMenu bMenu = _modulesCreator.CreateBMenu(_bMenuCreator, bmcc);
        BMenuInput bMenuInput = bMenu.GetComponent<BMenuInput>();
        _playerEvents.AddListenerToOnBMenuToggle(bMenuInput.Toggle);

        
        _energySystem.Init(turret, battery, _playerEvents);

        VisionModuleCreatorContext vc = CreateVisionContext();
        _modulesCreator.
            CreateVisionModule(_visionModuleCreator, vc);
    }

    InputContext CreateInputContext()
    {
        InputContext ic = 
            new InputContext(
                _playerEvents, 
                _camera, 
                _target);
        return ic;
    }
    
    TurretCreatorContext CreateTurretContext()
    {
        TurretCreatorContext tc 
            = new TurretCreatorContext
            (_allModules, _turretPrefab, 
                _playerEvents, _target, 
                _projectilesPool,
                _projectilePrefab);
        return tc;
    }
    WheelsCreatorContext CreateWheelsContext()
    {
        WheelsCreatorContext wcc =
            new WheelsCreatorContext(
                _allModules,
                transform,
                _prefabWheels,
                _playerDrive
            );
        return wcc;
    }
    BatteryCreatorContext CreateBatteryContext()
    {
        BatteryCreatorContext bcc =
            new BatteryCreatorContext(
                _allModules,
                transform,
                _prefabBattery,
                _playerEvents
                );
        return bcc;
    }
    VisionModuleCreatorContext CreateVisionContext()
    {
        VisionModuleCreatorContext vc = new VisionModuleCreatorContext(
            _visionModuleMaskImage,
            _prefabVisionModule,
            transform,
            _allModules);
        return vc;
    }
    BMenuCreatorContext CreateBMenuContext()
    {
        return new BMenuCreatorContext(
            transform, 
            _prefabBMenu,
            _bMenuTextField,
            _playerEvents
            );
    }
}

