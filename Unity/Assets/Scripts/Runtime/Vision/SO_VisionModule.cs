using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_VisionModule", menuName = "Scriptable Objects/SO_VisionModule")]
public class SO_VisionModule : ScriptableObject
{
    public Sprite StateMask1;
    public Sprite StateMask2;
    public Sprite StateMask3;
    public readonly int MaxHP;
}
