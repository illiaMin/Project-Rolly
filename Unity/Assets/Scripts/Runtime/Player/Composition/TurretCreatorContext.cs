using UnityEngine;

public class TurretCreatorContext
{
    public readonly SO_AllModules AllModules;
    public readonly Turret Prefab;
    public readonly PlayerEvents PlayerEvents;
    public readonly Transform AimTarget;
    public readonly ProjectilesPool  ProjectilesPool;
    public readonly GameObject ProjectilePrefab;
    
    public TurretCreatorContext
        (SO_AllModules allModules, 
            Turret prefab, 
            PlayerEvents playerEvents,
            Transform aimTarget,
            ProjectilesPool  projectilesPool,
            GameObject projectile)
    {
        AllModules = allModules;
        Prefab = prefab;
        PlayerEvents = playerEvents;
        AimTarget = aimTarget;
        ProjectilesPool = projectilesPool;
        ProjectilePrefab = projectile;
    }
}
