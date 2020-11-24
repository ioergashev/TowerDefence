using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalShootWeapon : ShootingBehavior
{
    private ProjectileFactory projectileFactory;
    private IChargable chargable;
    private IAimCalculator aimCalculator;

    public override bool IsReadyToShoot => chargable.Charged;

    private void Awake()
    {
        projectileFactory = GetComponent<ProjectileFactory>();
        chargable = GetComponent<IChargable>();
        aimCalculator = new ParabolicAimCalculator();
    }
        
    public override void Shoot(Transform target)
    {
        if (IsReadyToShoot)
        {
            // Create projectile     
            if (aimCalculator.Aim(target, ShootPoint.position, ShotSpeed, out AimInfo aimInfo))
                projectileFactory.Velocity = aimInfo.RequiredShellVelocity;
            else
                projectileFactory.Velocity = ShootPoint.forward * ShotSpeed;
            projectileFactory.CreateProjectile(ShootPoint.position, ShootPoint.rotation);

            // Discharge weapon
            chargable.Discharge();
        }
    }
}
