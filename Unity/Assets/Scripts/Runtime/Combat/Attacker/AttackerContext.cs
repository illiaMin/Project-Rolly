using UnityEngine;

public class AttackerContext
{
    public PlayerEvents PlayerEvents;
    public GameObject ProjectilePrefab;
    public ProjectilesPool  ProjectilesPool;
    public float Distance = 0.6f;
    public SO_Projectile ProjectileInfo;
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
