using UnityEngine;

public class WheelsCreator : MonoBehaviour
{
    Transform _robotBody;
    Wheels _prefabWheels;
    PlayerDrive _playerDrive;
    SO_AllModules _allModules;
    Wheels _wheels;
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
        
        Wheels wheels = CreateModule(wheelsName);
        return wheels;
    }

    public Wheels CreateModule(ModuleName wheelsName)
    {
        GetInfoAboutWheels(wheelsName, out SO_Wheels info);
        Wheels wheels = CreateWheels();
        _wheels = wheels;
        Setup(wheels, info);
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
    void Setup(Wheels wheels, SO_Wheels info)
    {
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