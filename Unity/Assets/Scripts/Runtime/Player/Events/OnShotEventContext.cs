using UnityEngine;

public class OnShotEventContext
{
    public readonly Transform Turret;
    public readonly int EnergyPerShot;
    public readonly Collider2D Shooter;
    public OnShotEventContext(
        Transform turret, 
        int energyPerShot,
        Collider2D shooter
        )
    {
        Turret = turret;
        EnergyPerShot = energyPerShot;
        Shooter = shooter;
    }
}
