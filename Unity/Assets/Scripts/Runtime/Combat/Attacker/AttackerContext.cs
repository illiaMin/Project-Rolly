using UnityEngine;

public class AttackerContext
{
    public readonly PlayerEvents PlayerEvents;
    public readonly GameObject ProjectilePrefab;
    public readonly ProjectilesPool  ProjectilesPool;
    public readonly float Distance = 0.6f;
    public readonly SO_Projectile ProjectileInfo;
    
    public AttackerContext(
        PlayerEvents playerEvents,
        GameObject projectilePrefab,
        ProjectilesPool projectilesPool,
        float distance,
        SO_Projectile projectileInfo)
    {
        PlayerEvents = playerEvents;
        ProjectilePrefab = projectilePrefab;
        ProjectilesPool = projectilesPool;
        Distance = distance;
        ProjectileInfo = projectileInfo;
    }
}
