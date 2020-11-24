using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CannonTowerInitializer : MonoBehaviour
{
    private List<ShootingBehavior> shootings = new List<ShootingBehavior>();

    public bool UsePhysics = false;

    private void Awake()
    {
        shootings = GetComponentsInChildren<ShootingBehavior>().ToList();
    }

    private void Start()
    {
        if (UsePhysics)
        {
            var navigation = GetComponent<TowerNavigation>();
            navigation.AimCalculator = new ParabolicAimCalculator();

            var shooting = shootings.Find(s => s is PhysicalShootWeapon);
            navigation.shooting = shooting;

            GetComponent<ShootingTower>().Shooting = shooting;
        }
        else
        {
            var navigation = GetComponent<TowerNavigation>();
            navigation.AimCalculator = new LinearAimCalculator();

            var shooting = shootings.Find(s => s is LinearShootWeapon);
            navigation.shooting = shooting;

            GetComponent<ShootingTower>().Shooting = shooting;
        }
        
    }
}
