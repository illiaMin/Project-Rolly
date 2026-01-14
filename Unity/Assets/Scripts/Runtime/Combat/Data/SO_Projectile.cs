using UnityEngine;

[CreateAssetMenu(fileName = "SO_Projectile", menuName = "Scriptable Objects/SO_Projectile")]
public class SO_Projectile : ScriptableObject
{
    public SO_Damage Damage;
    public float Speed;
    public float LifeTime;
    public Sprite Sprite;
}
