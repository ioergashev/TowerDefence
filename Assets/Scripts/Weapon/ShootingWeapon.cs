using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingWeapon : MonoBehaviour, IShooting
{
    public GameObject ProjectilePrefab;
    public Transform ShootingPoint;

    private IChargable chargable;

    public bool IsReadyToShot => chargable.Charged;

    private void Awake()
    {
        chargable = GetComponent<IChargable>();
    }
        
    public void Shoot(Transform target)
    {
        if (chargable.Charged)
        {
            var projectile = Instantiate(ProjectilePrefab, ShootingPoint.position, ShootingPoint.rotation);
            projectile.GetComponent<INavigated>()?.SetTarget(target);
            chargable.Discharge();
        }
    }
}
