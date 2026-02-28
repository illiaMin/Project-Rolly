using System;
using UnityEngine;

public abstract class Attacker : MonoBehaviour
{
    protected RobotEvents Events;
    protected ProjectilesPool  ProjectilesPool;
    protected float Distance = 1f;
    protected SO_Projectile ProjectileInfo;

    public void Init(AttackerContext ac)
    {
        Events = ac.Events;
        ProjectilesPool = ac.ProjectilesPool;
        Distance = ac.Distance;
        ProjectileInfo = ac.ProjectileInfo;
        
        Events.AddListenerToOnShot(Attack);
        
    }
    protected abstract void Attack(OnShotEventContext context);
    
    private void OnDisable()
    {
        if (Events != null)
        {
            Events.RemoveListenerFromOnShot(Attack);
        }
    }
}
