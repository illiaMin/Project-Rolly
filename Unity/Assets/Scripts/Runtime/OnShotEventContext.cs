using UnityEngine;

public class OnShotEventContext
{
    public readonly Transform Turret;
    public readonly int EnergyPerShot;
    public OnShotEventContext(
        Transform turret, 
        int energyPerShot)
    {
        Turret = turret;
        EnergyPerShot = energyPerShot;
    }
}
