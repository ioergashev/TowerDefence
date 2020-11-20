using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingWeapon : MonoBehaviour, IShooting
{
    public GameObject ProjectilePrefab;
    public Transform ShootingPoint;
    private IChargable chargable;
    private Speed shotSpeed;

    public bool IsReadyToShot => chargable.Charged;

    private void Awake()
    {
        chargable = GetComponent<IChargable>();
        shotSpeed = GetComponent<Speed>();
    }
        
    public void Shoot(Transform target)
    {
        if (chargable.Charged)
        {
            var projectile = Instantiate(ProjectilePrefab, ShootingPoint.position, ShootingPoint.rotation);
            projectile.GetComponent<INavigated>()?.SetTarget(target);
            var projectileSpeed = projectile.GetComponent<Speed>();
            if (projectileSpeed != null)
                projectileSpeed.speed = shotSpeed.speed;
            chargable.Discharge();
        }
    }
}
