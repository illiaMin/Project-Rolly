using UnityEngine;

public class TurretCreatorContext
{
    public readonly SO_AllTurrets AllTurrets;
    public readonly Turret Prefab;
    public readonly PlayerEvents PlayerEvents;
    public readonly Transform AimTarget;
    public readonly ProjectilesPool  ProjectilesPool;
    public readonly GameObject ProjectilePrefab;
    
    public TurretCreatorContext
        (SO_AllTurrets allTurrets, 
            Turret prefab, 
            PlayerEvents playerEvents,
            Transform aimTarget,
            ProjectilesPool  projectilesPool,
            GameObject projectile)
    {
        AllTurrets = allTurrets;
        Prefab = prefab;
        PlayerEvents = playerEvents;
        AimTarget = aimTarget;
        ProjectilesPool = projectilesPool;
        ProjectilePrefab = projectile;
    }
}
