using UnityEngine;
using UnityEngine.UI;

public class VisionModuleCreator : MonoBehaviour
{
    private VisionModule _prefab;
    private Transform _robotBody;
    private SO_AllModules _allModules;
    ProgressRepository _progressRepository;

    
    public VisionModule Init(VisionModuleCreatorContext context, ModuleName visionModuleName)
    {
        _prefab = context.Prefab;
        _robotBody = context.Transform;
        _allModules = context.AllModules;
        _progressRepository = context.ProgressRepository;
        return CreateModule(visionModuleName, context.MaskImage);
    }

    public VisionModule CreateModule(ModuleName visionModuleName, Image maskImage)
    {
        GetInfo(visionModuleName, out SO_VisionModule info);
        CreateModule(out VisionModule module);
        HP newHP = new HP(info.MaxHP);
        newHP.SetCurrent(_progressRepository.GetBatteryHP());
        
        Setup(module, info, maskImage, newHP);
        return module;
    }
    void GetInfo(ModuleName name, out SO_VisionModule info)
    {
        info = _allModules.Modules.Get(name) as SO_VisionModule;
    }
    void CreateModule(out VisionModule visionModule)
    {
        visionModule = 
            Instantiate(_prefab, _robotBody, false);
    }
    void Setup(VisionModule visionModule, SO_VisionModule info, Image maskImage, HP newHP)
    {
        visionModule.name = "Vision Module";
        visionModule.Init(info, maskImage);
        visionModule.transform.localPosition = Vector3.zero;
        visionModule.SetHP(newHP);
    }
}
