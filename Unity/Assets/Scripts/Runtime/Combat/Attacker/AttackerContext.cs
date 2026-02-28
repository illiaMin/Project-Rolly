using UnityEngine;

public class AttackerContext
{
    public readonly RobotEvents Events;
    public readonly ProjectilesPool  ProjectilesPool;
    public readonly float Distance = 0.6f;
    public readonly SO_Projectile ProjectileInfo;
    
    public AttackerContext(
        RobotEvents events,
        ProjectilesPool projectilesPool,
        float distance,
        SO_Projectile projectileInfo)
    {
        Events = events;
        ProjectilesPool = projectilesPool;
        Distance = distance;
        ProjectileInfo = projectileInfo;
    }
}
