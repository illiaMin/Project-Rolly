using UnityEngine;

[CreateAssetMenu(fileName = "SO_AllTurrets", menuName = "Scriptable Objects/SO_AllTurrets")]
public class SO_AllTurrets : ScriptableObject
{
    public SerializableStringTurretDictionary Turrets;
}
