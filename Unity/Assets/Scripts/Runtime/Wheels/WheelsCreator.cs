using UnityEngine;

public class WheelsCreator : MonoBehaviour
{
    Transform _robotBody;
    Wheels _prefabWheels;
    PlayerDrive _playerDrive;
    SO_AllModules _allModules;
    Wheels _wheels;
    PlayerEvents _playerEvents;
    ProgressRepository _progressRepository;
    public void InitializeNewWheels(ModuleName moduleName)
    {
        Destroy(_wheels.gameObject);
        _wheels = CreateModule(moduleName);
    }
    public Wheels Init(WheelsCreatorContext wcc, ModuleName wheelsName)
    {
        _robotBody = wcc.RobotBody;
        _prefabWheels = wcc.PrefabWheels;
        _playerDrive = wcc.PlayerDrive;
        _allModules = wcc.AllModules;
        _playerEvents = wcc.PlayerEvents;
        _progressRepository = wcc.ProgressRepository;
        Wheels wheels = CreateModule(wheelsName);
        return wheels;
    }

    public Wheels CreateModule(ModuleName wheelsName)
    {
        GetInfoAboutWheels(wheelsName, out SO_Wheels info);
        Wheels wheels = CreateWheels();
        _wheels = wheels;
        HP newLeftHP = new HP (info.HP.Max);
        newLeftHP.SetCurrent(_progressRepository.GetWheelsLeftHP());
        HP newRightHP = new HP (info.HP.Max);
        newLeftHP.SetCurrent(_progressRepository.GetWheelsRightHP());
        Setup(wheels, info, newLeftHP, newRightHP);
        
        _playerEvents.InvokeOnWheelsChanged(wheels);
        return wheels;
    }
    void GetInfoAboutWheels(ModuleName wheelsName, out SO_Wheels info)
    {
        info = _allModules.Modules.Get(wheelsName) as SO_Wheels;
    }
    Wheels CreateWheels()
    {
        Wheels wheels = 
            Instantiate(_prefabWheels, _robotBody, false);
        return wheels;
    }
    void Setup(Wheels wheels, SO_Wheels info, HP newLeftHP, HP newRightHP)
    {
        wheels.SetLeftHP(newLeftHP);
        wheels.SetRightHP(newRightHP);
        wheels.name = "Wheels";
        wheels.Init(info, _robotBody, _playerDrive);
        wheels.transform.localPosition = Vector3.zero;

        
        SpriteRenderer side
            = wheels.GetLeftSide();
        side.sprite = info.LeftSide;
        
        side = wheels.GetRightSide();
        side.sprite = info.RightSide;
    }
}