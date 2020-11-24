using UnityEngine;

public class LinearShootWeapon : ShootingBehavior
{
    private ProjectileFactory projectileFactory;
    private IChargable chargable;

    public override bool IsReadyToShoot => chargable.Charged;

    private void Awake()
    {
        projectileFactory = GetComponent<ProjectileFactory>();
        chargable = GetComponent<IChargable>();
    }

    public override void Shoot(Transform target)
    {
        if (IsReadyToShoot)
        {
            // Create projectile
            projectileFactory.Velocity = ShootPoint.forward * ShotSpeed;
            projectileFactory.CreateProjectile(ShootPoint.position, ShootPoint.rotation);
           
            // Discharge weapon
            chargable.Discharge();
        }
    }
}
