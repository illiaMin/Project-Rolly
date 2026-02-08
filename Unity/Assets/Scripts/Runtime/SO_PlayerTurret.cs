using UnityEngine;

[CreateAssetMenu(fileName = "SO_PlayerTurret", menuName = "Scriptable Objects/SO_PlayerTurret")]
public class SO_PlayerTurret : ScriptableObject
{
    public float TurnSpeedDegreesPerSecond;
    public SO_Projectile ProjectileInfo;
    public Sprite SpriteTurret;
    public Sprite SpriteGun;
    public float ReloadTime = 0;
    public Attacker Attacker;

    public int CostOfShot = 2;
    
    public bool CanBeDamaged = true;
    public int HpMax = 100;
}
