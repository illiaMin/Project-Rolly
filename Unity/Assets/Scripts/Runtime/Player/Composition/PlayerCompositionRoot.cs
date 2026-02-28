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
    [SerializeField] SavingSystem _savingSystem;
    
    [SerializeField] Wheels _prefabWheels;
    [SerializeField] PlayerDrive _playerDrive;
    [SerializeField] WheelsCreator _wheelsCreator;
    
    [SerializeField] BatteryUI _batteryUI;
    [SerializeField] Battery _prefabBattery;
    [SerializeField] BatteryCreator _batteryCreator;

    [SerializeField] BMenuEvents _bMenuEvents;
    [SerializeField] BMenu _prefabBMenu;
    [SerializeField] BMenuCreator _bMenuCreator;
    [SerializeField] Text _bMenuTextField;
    [SerializeField] Text _mainGunTextField;
    [SerializeField] Text _secondGunTextField;
    [SerializeField] Text _activeWheelsTextField;
    [SerializeField] Text _auxiliaryTextField;
    
    [SerializeField] Dash _prefabDash;
    [SerializeField] DashCreator _dashCreator;

    [SerializeField] Shield _prefabShield;
    [SerializeField] ShieldCreator _shieldCreator;
    
    [SerializeField] MiniMap _prefabMiniMap;
    [SerializeField] MiniMapCreator _minimapCreator;
    private AuxiliaryModule _currentAuxiliaryModule;
    
    [SerializeField] VisionModuleCreator _visionModuleCreator;
    [SerializeField] VisionModule _prefabVisionModule;
    [SerializeField] Image _visionModuleMaskImage;
    
    [SerializeField] ID_Card _iDCardPrefab;
    [SerializeField] ID_CardCreator _iDCardCreator;
    [SerializeField] Text _iDCardText;
    
    [SerializeField] PlayersHP _playersHP;
    [SerializeField] HPUIConteineer _hpUI;
    [SerializeField] HPOwner _hpOwner;
    private HPSetter _hpSetter;
    
    private void Awake()
    {
        InputContext inputContext = CreateInputContext();
        _inputModule.Init(inputContext);

        _savingSystem = _modulesCreator.InitSavingSystem(_savingSystem);
        _playerEvents.AddListenerToOnBatteryChargePercentChanged(
                _savingSystem.SaveBatteryCharge);
        
        _modulesCreator.Init(_allModules, _progressRepository, _savingSystem);
        _hpSetter = new HPSetter(_hpOwner);
        
        TurretCreatorContext tc = CreateTurretContext();
        _playerEvents.AddListenerToOnTurretChanged(_hpSetter.OnTurretChanged);
        Turret turret = _modulesCreator.
            CreateMainTurret(_turretCreator, tc);
        _playerEvents.AddListenerToOnChangeTurretTo(_turretCreator.InitializeNewTurret);
        
        
        _playerEvents.AddListenerToOnWheelsChanged(_hpSetter.OnWheelsChanged);
        WheelsCreatorContext wcc = CreateWheelsContext();
        Wheels wheels = _modulesCreator.
            CreateWheels(_wheelsCreator, wcc);
        _playerEvents.AddListenerToOnChangeWheelsTo(_wheelsCreator.InitializeNewWheels);

        
        _energySystem.Init(turret, _playerEvents);
        
        
        _batteryUI.Init(_playerEvents);
        
        _playerEvents.AddListenerToOnBatteryChanged(_hpSetter.OnBatteryChanged);
        BatteryCreatorContext bcc = CreateBatteryContext();
        Battery battery = _modulesCreator.
            CreateBattery(_batteryCreator, bcc);
        _playerEvents.AddListenerToOnShot(
            context => battery.ConsumeCharge(context.EnergyPerShot));
        
        CreateAuxiliaryModule();
        //_hpSetter.SetHpToOwner(
         //   ref _currentAuxiliaryModule.GetHP(), TypeOfDamageble.Auxiliary);
        _playerEvents.AddListenerToOnAuxiliaryModuleChanged(_hpSetter.OnAuxiliaryChanged);
        _playerEvents.AddListenerToOnChangeAuxiliaryTo(CreateAuxiliaryModule);
        
        BMenuCreatorContext bmcc = CreateBMenuContext();
        BMenu bMenu = _modulesCreator.CreateBMenu(_bMenuCreator, bmcc);
        BMenuInput bMenuInput = bMenu.GetComponent<BMenuInput>();
        _playerEvents.AddListenerToOnBMenuToggle(bMenu.Toggle);
        _bMenuEvents.AddListenerToOnBMenuToggleRMB(bMenu.SwapMainAndSecondGun);
        _bMenuEvents.AddListenerToOnBMenuUpdateText(bMenuInput.Show);

        VisionModuleCreatorContext vc = CreateVisionContext();
        VisionModule visionModule = _modulesCreator.
            CreateVisionModule(_visionModuleCreator, vc);
        _hpSetter.SetHpToOwner(
            ref visionModule.GetHP(), TypeOfDamageble.Vision);
        
        ID_CardCreatorContext idcc = CreateIDCardCreatorContext();
        ID_Card idCard = _modulesCreator.
            CreateIDCard(_iDCardCreator,  idcc);
        _playerEvents.AddListenerToOnChangeIdCardTo(_iDCardCreator.InitializeNewIdCard);


        
        _playersHP.Init(_savingSystem.GetPlayerSetup(), _hpUI, _hpOwner);
        _playerEvents.AddListenerToOnDMGRecieved(_playersHP.ShowHPs);
    }

    #region Contexts

    InputContext CreateInputContext()
    {
        InputContext ic = 
            new InputContext(
                _playerEvents, 
                _camera, 
                _target,
                _bMenuEvents);
        return ic;
    }
    
    TurretCreatorContext CreateTurretContext()
    {
        TurretCreatorContext tc 
            = new TurretCreatorContext
            (_allModules, _turretPrefab, 
                _playerEvents, _target, 
                _projectilesPool, _progressRepository);
        return tc;
    }
    WheelsCreatorContext CreateWheelsContext()
    {
        WheelsCreatorContext wcc =
            new WheelsCreatorContext(
                _allModules,
                transform,
                _prefabWheels,
                _playerDrive,
                _playerEvents,
                _progressRepository
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
            _allModules,
            _progressRepository);
        return vc;
    }
    BMenuCreatorContext CreateBMenuContext()
    {
        return new BMenuCreatorContext(
            _allModules,
            transform, 
            _prefabBMenu,
            _bMenuTextField,
            _mainGunTextField,
            _secondGunTextField,
            _activeWheelsTextField,
            _auxiliaryTextField,
            _playerEvents,
            _savingSystem.GetListsFoBMenu(),
            _bMenuEvents,
            _savingSystem
        );
    }

    DashCreatorContext CreateDashContext()
    {
        return new DashCreatorContext(_allModules, _prefabDash, transform);
    }

    MinimapCreatorConrext CreateMinimapCreatorContext()
    {
        return new MinimapCreatorConrext(_allModules, _prefabMiniMap, transform);
    }
    ShieldCreatorContext CreateShieldContext()
    {
        return new ShieldCreatorContext(_allModules, _prefabShield, transform);
    }
    ID_CardCreatorContext CreateIDCardCreatorContext()
    {
        return new ID_CardCreatorContext(_allModules, _iDCardPrefab, transform, _iDCardText);
    }
    #endregion
    
    void CreateAuxiliaryModule()
    {
        if (_currentAuxiliaryModule is Dash previousDash)
        {
            _playerEvents.RemoveListenerFromOnDashToggle(previousDash.Toggle);
        }

        if (_currentAuxiliaryModule != null) Destroy(_currentAuxiliaryModule.gameObject);

        DashCreatorContext dashContext = CreateDashContext();
        MinimapCreatorConrext miniMapContext = CreateMinimapCreatorContext();
        ShieldCreatorContext shieldContext = CreateShieldContext();

        ModulesCreator.AuxiliaryCreationResult auxiliary = _modulesCreator.CreateAuxiliary(
            _dashCreator,
            dashContext,
            _minimapCreator,
            miniMapContext,
            _shieldCreator,
            shieldContext);

        _currentAuxiliaryModule = auxiliary.Module;
        _hpOwner.SetShield(auxiliary.Shield);
        _hpOwner.Add(auxiliary.Hp, TypeOfDamageble.Auxiliary);

        if (_currentAuxiliaryModule is Dash dash)
        {
            _playerEvents.AddListenerToOnDashToggle(dash.Toggle);
        }

        _playerEvents.InvokeOnAuxiliaryModuleChanged(_currentAuxiliaryModule);
    }
    
}
