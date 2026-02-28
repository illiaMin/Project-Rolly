using UnityEngine;
using UnityEngine.UI;

public class ModulesCreator : MonoBehaviour
{
    private ProgressRepository _repository;
    private SO_AllModules _allModules;
    private AuxiliaryModule _currentAuxiliaryModule;
    public void Init(
        SO_AllModules allModules,
        ProgressRepository progressRepository,
        SavingSystem savingSystem)
    {
        _allModules = allModules;
        _repository = progressRepository;
        _repository.Init(savingSystem);
    }
    public SavingSystem InitSavingSystem(SavingSystem savingSystem)
    {
        return savingSystem.Init();
    }
    
    public Turret CreateMainTurret(
        TurretCreator turretCreator, TurretCreatorContext tc)
    {
        ModuleName turretName = _repository.GetMainGunModuleName();
        turretCreator.Init(tc);
        tc.TurretHP = _repository.GetTurretHP();
        return turretCreator.CreateTurret(turretName);
    }
    
    public Wheels CreateWheels(
        WheelsCreator wheelsCreator, WheelsCreatorContext wcc)
    {
        ModuleName wheelsName = _repository.GetWheelsModuleName();
        return wheelsCreator.Init(wcc, wheelsName);
    }
    
    public Battery CreateBattery(
        BatteryCreator batteryCreator, BatteryCreatorContext bcc)
    {
        ModuleName batteryName = ModuleName.Battery;
        _repository.GetBatteryModuleCharge(out int charge);
        bcc.SetCharge(charge);
        Battery battery = batteryCreator.Init(bcc, batteryName);
        return battery;
    }

    public BMenu CreateBMenu(BMenuCreator creator, BMenuCreatorContext bcc)
    {
        ModuleName bMenuName = _repository.GetBMenuModuleName();
        return creator.Create(bcc, bMenuName);
    }
    public VisionModule CreateVisionModule(VisionModuleCreator visionModuleCreator, VisionModuleCreatorContext vc)
    {
        ModuleName visionModuleName = _repository.GetVisionModuleName();
        return visionModuleCreator.Init(vc, visionModuleName);
    }

    public Dash CreateDash(DashCreator dashCreator, DashCreatorContext dcc)
    {
        return dashCreator.Create(dcc);
    }

    public Shield CreateShield(ShieldCreator shieldCreator, ShieldCreatorContext scc)
    {
        return shieldCreator.Create(scc);
    }

    public MiniMap CreateMiniMap(MiniMapCreator minimapCreator, MinimapCreatorConrext mmcc)
    {
        return minimapCreator.Create(mmcc);
    }

    public ID_Card CreateIDCard(ID_CardCreator idCardCreator, ID_CardCreatorContext idcc)
    {
        ModuleName name = _repository.GetIDCardModuleName();
        return idCardCreator.Create(idcc, name);
    }
}
