using System;
using UnityEngine;

public abstract class Attacker : MonoBehaviour
{
    protected PlayerEvents PlayerEvents;
    protected GameObject ProjectilePrefab;
    protected ProjectilesPool  ProjectilesPool;
    protected float Distance = 0.6f;
    protected SO_Projectile ProjectileInfo;

    public void Init(AttackerContext ac)
    {
        PlayerEvents = ac.PlayerEvents;
        ProjectilePrefab = ac.ProjectilePrefab;
        ProjectilesPool = ac.ProjectilesPool;
        Distance = ac.Distance;
        ProjectileInfo = ac.ProjectileInfo;
        
        PlayerEvents.AddListenerToOnShot(Attack);
    }
    protected abstract void Attack(Transform turret);
    
    private void OnDisable()
    {
        if (PlayerEvents != null)
        {
            PlayerEvents.RemoveListenerFromOnShot(Attack);
        }
    }
}
