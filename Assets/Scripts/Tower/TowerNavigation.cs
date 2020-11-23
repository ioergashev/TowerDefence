using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerNavigation : MonoBehaviour
{
    private IDetector targetDetector;
    private List<INavigated> navigators = new List<INavigated>();
    private Speed WeaponShotSpeed;
    private IShooting shooting;
    private IAimCalculator aimCalculator;

    private void Awake()
    {
        shooting = GetComponent<IShooting>();
        WeaponShotSpeed = GetComponent<Speed>();
        targetDetector = GetComponent<IDetector>();
        aimCalculator = GetComponent<IAimCalculator>();
        navigators = GetComponentsInChildren<INavigated>().ToList();
    }

    void LateUpdate()
    {
        // Find target
        var target = targetDetector.GetTarget();
        if (target != null)
        {
            // Calculate lead
            if (aimCalculator.Aim(target, shooting.ShootingPoint.position, WeaponShotSpeed.speed, out AimInfo aimInfo))
            {
                Vector3 targetPoint = shooting.ShootingPoint.position + aimInfo.RequiredShellVelocity * 10;

                // Navigate tower
                navigators.ForEach(t => t.SetTarget(targetPoint));
            }
        }
    }
}
