using UnityEngine;
using UnityEngine.UI;

public class VisionModuleCreatorContext
{
    public readonly Image MaskImage;
    public readonly VisionModule Prefab;
    public readonly Transform Transform;
    public readonly SO_AllModules AllModules;
    public VisionModuleCreatorContext(
        Image maskImage,
        VisionModule prefab,
        Transform transform,
        SO_AllModules allModules
        )
    {
        MaskImage = maskImage;
        Prefab = prefab;
        Transform = transform;
        AllModules = allModules;
    }
}
