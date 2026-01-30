using UnityEngine;
using UnityEngine.UI;

public class VisionModuleCreator : MonoBehaviour
{
    private VisionModule _prefab;
    private Transform _robotBody;
    private SO_AllModules _allModules;
    
    public void Init(VisionModuleCreatorContext context, ModuleName visionModuleName)
    {
        _prefab = context.Prefab;
        _robotBody = context.Transform;
        _allModules = context.AllModules;
        
        CreateModule(visionModuleName, context.MaskImage);
    }

    public void CreateModule(ModuleName visionModuleName, Image maskImage)
    {
        GetInfo(visionModuleName, out SO_VisionModule info);
        CreateModule(out VisionModule module);
        Setup(module, info, maskImage);
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
    void Setup(VisionModule visionModule, SO_VisionModule info, Image maskImage)
    {
        visionModule.name = "Vision Module";
        visionModule.Init(info, maskImage);
        visionModule.transform.localPosition = Vector3.zero;
    }
}
