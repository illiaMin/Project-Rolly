using UnityEngine;
using UnityEngine.UI;

public class ModulesCreator : MonoBehaviour
{
    private ProgressRepository _repository;
    private SO_AllModules _allModules;
    public void Init(ProgressRepository progressRepository, SO_AllModules allModules)
    {
        _repository = progressRepository;
        _allModules = allModules;
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
        ModuleName batteryName = _repository.GetBatteryModuleName();
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
