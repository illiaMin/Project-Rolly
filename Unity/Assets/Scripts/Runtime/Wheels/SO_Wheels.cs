using UnityEngine;

[CreateAssetMenu(fileName = "SO_Wheels", menuName = "Scriptable Objects/SO_Wheels")]
public class SO_Wheels : ScriptableObject
{
    public float SpeedForward;
    public float SpeedBackward;
    public int TurnSpeed;
    
    public HP HP;
    
    public Sprite Sprite;
}
