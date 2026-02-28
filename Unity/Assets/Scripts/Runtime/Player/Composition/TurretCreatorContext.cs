using UnityEngine;

public class TurretCreatorContext
{
    public readonly SO_AllModules AllModules;
    public readonly Turret Prefab;
    public readonly PlayerEvents PlayerEvents;
    public readonly Transform AimTarget;
    public readonly ProjectilesPool  ProjectilesPool;
    public int TurretHP;
    public readonly ProgressRepository ProgressRepository;

    public TurretCreatorContext
        (SO_AllModules allModules, 
            Turret prefab, 
            PlayerEvents playerEvents,
            Transform aimTarget,
            ProjectilesPool  projectilesPool,
            ProgressRepository progressRepository)
    {
        AllModules = allModules;
        Prefab = prefab;
        PlayerEvents = playerEvents;
        AimTarget = aimTarget;
        ProjectilesPool = projectilesPool;
        ProgressRepository = progressRepository;
    }
}
