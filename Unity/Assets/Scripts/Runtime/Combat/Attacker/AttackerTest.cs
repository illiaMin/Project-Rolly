using UnityEngine;

public class AttackerTest : Attacker
{
    [SerializeField] GameObject _particlePrefab;
    
    protected override void Attack(OnShotEventContext context)
    {
        var turret = context.Turret.GetComponent<Turret>();
        
        var goprs = Instantiate(_particlePrefab);
        goprs.transform.position = turret.GetGun().position;
        goprs.transform.up = turret.GetGun().right;
        goprs.transform.position += turret.GetGun().up * Distance;
        goprs.GetComponent<ParticleSystem>().Play();
        
        
        
        ProjectilesPool.TryGet(out Projectile newProjectile);
        newProjectile.gameObject.SetActive(true);
        newProjectile.transform.position = turret.GetGun().position;
        newProjectile.transform.up = turret.GetGun().up;
        newProjectile.transform.localPosition += turret.GetGun().up * Distance;
        newProjectile.GetComponent<SpriteRenderer>().sprite = ProjectileInfo.Sprite;

        newProjectile.SetInfo(ProjectileInfo, ProjectilesPool);
        
        newProjectile.GetRigidbody2D().
            AddForce(turret.GetGun().up * ProjectileInfo.Speed,  ForceMode2D.Impulse);
    }
}
