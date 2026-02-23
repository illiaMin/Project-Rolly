using UnityEngine;

[CreateAssetMenu(fileName = "SO_Dash", menuName = "Scriptable Objects/SO_Dash")]
public class SO_Dash : ScriptableObject
{
    public float PowerOfDash;
    public float Cooldown;
    public int HP;
    public Sprite Image;
}