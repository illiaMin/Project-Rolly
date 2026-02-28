using UnityEngine;

public class ModulesCreator : MonoBehaviour
{
    public struct AuxiliaryCreationResult
    {
        public AuxiliaryModule Module;
        public Shield Shield;
        public HP Hp;
    }

    private ProgressRepository _repository;
    private SO_AllModules _allModules;
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

    public AuxiliaryCreationResult CreateAuxiliary(
        DashCreator dashCreator,
        DashCreatorContext dashContext,
        MiniMapCreator miniMapCreator,
        MinimapCreatorConrext miniMapContext,
        ShieldCreator shieldCreator,
        ShieldCreatorContext shieldContext)
    {
        ModuleName auxiliaryName = _repository.GetCurrentAuxiliaryName();
        int currentAuxHp = _repository.GetAuxiliaryHP();

        AuxiliaryCreationResult result = new AuxiliaryCreationResult();
        switch (auxiliaryName)
        {
            case ModuleName.Dash:
                result.Module = CreateDashAuxiliary(dashCreator, dashContext);
                break;
            case ModuleName.Minimap:
                result.Module = CreateMiniMapAuxiliary(miniMapCreator, miniMapContext);
                break;
            case ModuleName.Shield:
                result.Module = CreateShieldAuxiliary(shieldCreator, shieldContext, out Shield shield);
                result.Shield = shield;
                break;
            default:
                result.Module = CreateShieldAuxiliary(shieldCreator, shieldContext, out Shield defaultShield);
                result.Shield = defaultShield;
                break;
        }

        int maxHp = ResolveAuxiliaryMaxHp(auxiliaryName, currentAuxHp);
        result.Hp = new HP(maxHp);
        result.Hp.SetCurrent(currentAuxHp);

        return result;
    }

    private Dash CreateDashAuxiliary(DashCreator dashCreator, DashCreatorContext dashContext)
    {
        return dashCreator.Create(dashContext);
    }

    private MiniMap CreateMiniMapAuxiliary(MiniMapCreator miniMapCreator, MinimapCreatorConrext miniMapContext)
    {
        return miniMapCreator.Create(miniMapContext);
    }

    private Shield CreateShieldAuxiliary(ShieldCreator shieldCreator, ShieldCreatorContext shieldContext, out Shield shield)
    {
        shield = shieldCreator.Create(shieldContext);
        return shield;
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

    private int ResolveAuxiliaryMaxHp(ModuleName auxiliaryName, int fallbackMaxHp)
    {
        ScriptableObject moduleInfo = _allModules.Modules.Get(auxiliaryName);

        if (moduleInfo is SO_Dash dashInfo)
        {
            return dashInfo.HP;
        }

        if (moduleInfo is SO_Minimap minimapInfo)
        {
            return minimapInfo.HP;
        }

        if (moduleInfo is SO_Shield shieldInfo)
        {
            return shieldInfo.HP;
        }

        return fallbackMaxHp;
    }
}
