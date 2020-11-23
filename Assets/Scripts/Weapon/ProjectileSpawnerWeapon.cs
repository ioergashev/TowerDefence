using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawnerWeapon : MonoBehaviour, IShooting
{
    public GameObject ProjectilePrefab;
    [SerializeField]
    private Transform shootingPoint;
    private IChargable chargable;
    private Speed shotSpeed;

    public bool IsReadyToShoot => chargable.Charged;

    public Transform ShootingPoint => shootingPoint;

    private void Awake()
    {
        chargable = GetComponent<IChargable>();
        shotSpeed = GetComponent<Speed>();
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
                projectileSpeed.speed = shotSpeed.speed;

            // Set target
            if (target != null)
                projectile.GetComponent<INavigated>()?.SetTarget(target);

            // Discharge weapon
            chargable.Discharge();
        }
    }
}
