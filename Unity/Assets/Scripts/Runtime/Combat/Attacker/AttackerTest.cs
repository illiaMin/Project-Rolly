using UnityEngine;

public class AttackerTest : Attacker
{
    protected override void Attack(OnShotEventContext context)
    {
        var turret = context.Turret;
        ProjectilesPool.TryGet(out Projectile newProjectile);
        newProjectile.gameObject.SetActive(true);
        newProjectile.transform.position = turret.transform.position;
        newProjectile.transform.up = turret.transform.up;
        newProjectile.transform.localPosition += turret.transform.up * Distance;
        newProjectile.GetComponent<SpriteRenderer>().sprite = ProjectileInfo.Sprite;

        newProjectile.SetInfo(ProjectileInfo, ProjectilesPool);
        newProjectile.GetRigidbody2D().
            AddForce(turret.transform.up * ProjectileInfo.Speed,  ForceMode2D.Impulse);
    }
}
