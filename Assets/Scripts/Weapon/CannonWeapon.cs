using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonWeapon : MonoBehaviour, IShooting
{
    public GameObject ProjectilePrefab;
    [SerializeField]
    private Transform shootingPoint;
    private IChargable chargable;
    private Speed shotSpeed;
    private IAimCalculator aimCalculator;
    private ShootingTowerConfigurator configurator;

    public bool IsReadyToShoot => chargable.Charged;

    public Transform ShootingPoint => shootingPoint;

    private void Awake()
    {
        configurator = GetComponent<ShootingTowerConfigurator>();
        chargable = GetComponent<IChargable>();
        shotSpeed = GetComponent<Speed>();
        aimCalculator = GetComponent<IAimCalculator>();
    }
        
    public void Shoot(Transform target)
    {
        if (IsReadyToShoot)
        {
            // Instantiate projectile
            var projectile = Instantiate(ProjectilePrefab, shootingPoint.position, shootingPoint.rotation);

            // Set projectile speed
            var projectileSpeed = projectile.GetComponent<Speed>();
            if (projectileSpeed != null)
            {
                projectileSpeed.speed = shotSpeed.speed;

                // Aim
                if (aimCalculator.Aim(target, ShootingPoint.position, shotSpeed.speed, out AimInfo aimInfo))
                    projectileSpeed.Velocity = aimInfo.RequiredShellVelocity;                
            }

            var mover = projectile.GetComponent<ShellInitializer>();
            if(mover != null)
            {
                mover.UsePhysics = configurator.UsePhysics;
                mover.Init();
            }

            projectile.GetComponent<INavigated>()?.SetTarget(target);

            // Discharge weapon
            chargable.Discharge();
        }
    }
}
