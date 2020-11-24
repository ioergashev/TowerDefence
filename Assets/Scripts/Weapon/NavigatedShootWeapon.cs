using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigatedShootWeapon : ShootingBehavior
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
        if (IsReadyToShoot && target != null)
        {
            // Create projectile
            projectileFactory.Velocity = ShootPoint.forward * ShotSpeed;
            projectileFactory.Target = target;
            projectileFactory.CreateProjectile(ShootPoint.position, ShootPoint.rotation);

            // Discharge weapon
            chargable.Discharge();
        }
    }
}
