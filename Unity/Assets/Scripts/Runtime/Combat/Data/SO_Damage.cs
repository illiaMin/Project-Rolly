using UnityEngine;

[CreateAssetMenu(fileName = "SO_Damage", menuName = "Scriptable Objects/SO_Damage")]
public class SO_Damage : ScriptableObject
{
    public int BasicDmg;
    public int FireDmg;
    public int PhysicDmg;
    public int ElectricDmg;
    public int NanoDmg;
}
