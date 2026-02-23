using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_VisionModule", menuName = "Scriptable Objects/SO_VisionModule")]
public class SO_VisionModule : ScriptableObject
{
    public int MinBoundHPFormask1;
    public int MinBoundHPFormask2;
    public int MinBoundHPFormask3;
    
    public Sprite StateMask1;
    public Sprite StateMask2;
    public Sprite StateMask3;
    
    public int MaxHP;
}
