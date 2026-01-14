using UnityEngine;

[CreateAssetMenu(fileName = "SO_PlayerTurret", menuName = "Scriptable Objects/SO_PlayerTurret")]
public class SO_PlayerTurret : ScriptableObject
{
    public float TurnSpeedDegreesPerSecond;
    public SO_Projectile ProjectileInfo;
    public Sprite Sprite;
    public float ReloadTime = 0;
    public Attacker Attacker;
}
