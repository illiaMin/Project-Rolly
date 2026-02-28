using UnityEngine;
using UnityEngine.UI;

public class VisionModule : MonoBehaviour
{
    SO_VisionModule _info;
    VisionModuleCondition _condition = 
        VisionModuleCondition.NotBrocken;

    private HP _hp;
    
    private Image _maskImage;
    public void Init(SO_VisionModule info, Image maskImage)
    {
        _info = info;
        _maskImage = maskImage;

        SetImageAccordingToStage(VisionModuleCondition.NotBrocken);
    }

    private void SetImageAccordingToStage(
        VisionModuleCondition condition)
    {
        Sprite sprite;
        if (condition != VisionModuleCondition.DoesntWorks)
        {
            sprite = condition switch
            {
                VisionModuleCondition.NotBrocken => _info.StateMask1,
                VisionModuleCondition.BrokenLittleBit => _info.StateMask2,
                VisionModuleCondition.AlmostComplitelyBroken => _info.StateMask3,
                _ => null
            };
            _maskImage.sprite = sprite;
        }
        else
        {
            _maskImage.gameObject.SetActive(false);
        }
    }
    public ref HP GetHP()
    {
        return ref _hp;
    }

    public void SetHP(HP hp)
    {
        _hp = hp;
    }
}
