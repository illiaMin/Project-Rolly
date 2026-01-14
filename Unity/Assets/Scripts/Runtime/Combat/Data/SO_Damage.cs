using UnityEngine;

[CreateAssetMenu(fileName = "SO_Damage", menuName = "Scriptable Objects/SO_Damage")]
public class SO_Damage : ScriptableObject
{
    public float BasicDmg;
    public float FireDmg;
    public float PhysicDmg;
    public float ElectricDmg;
}
