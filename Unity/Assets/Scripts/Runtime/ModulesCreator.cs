using UnityEngine;
using UnityEngine.UI;

public class ModulesCreator : MonoBehaviour
{
    private ProgressRepository _repository;
    private SO_AllModules _allModules;
    public void Init(
        ProgressRepository progressRepository, 
        SO_AllModules allModules,  
        SavingSystem savingSystem)
    {
        _repository = progressRepository;
        _allModules = allModules;
        _repository.Init(savingSystem);
    }
    
    public Turret CreateMainTurret(
        TurretCreator turretCreator, TurretCreatorContext tc)
    {
        ModuleName turretName = _repository.GetMainGunModuleName();
        turretCreator.Init(tc);
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
        _repository.GetBatteryModuleInfo(out int charge);
        bcc.SetCharge(charge);
        Battery battery = batteryCreator.Init(bcc, batteryName);
        return battery;
    }

    public BMenu CreateBMenu(BMenuCreator creator, BMenuCreatorContext bcc)
    {
        return creator.Create(bcc);
    }
    public void CreateVisionModule(VisionModuleCreator visionModuleCreator, VisionModuleCreatorContext vc)
    {
        ModuleName visionModuleName = _repository.GetVisionModuleName();
        visionModuleCreator.Init(vc, visionModuleName);
        
    }
}
