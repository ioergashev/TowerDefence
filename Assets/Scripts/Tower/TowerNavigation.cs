using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary> Controls tower navigation </summary>
public class TowerNavigation : MonoBehaviour
{
    private IDetector targetDetector;
    private List<NavigatedBehavior> navigators = new List<NavigatedBehavior>();
    [HideInInspector]
    public ShootingBehavior shooting;
    public IAimCalculator AimCalculator;

    private void Awake()
    {
        targetDetector = GetComponent<IDetector>();
        navigators = GetComponentsInChildren<NavigatedBehavior>().ToList();
    }

    void LateUpdate()
    {
        // Find target
        var target = targetDetector.GetCurrentTarget();
        if (target != null)
        {
            // Calculate lead
            if (AimCalculator.Aim(target, shooting.ShootPoint.position, shooting.ShotSpeed, out AimInfo aimInfo))
            {
                Vector3 targetPoint = shooting.ShootPoint.position + aimInfo.RequiredShellVelocity * 10;

                // Navigate tower
                navigators.ForEach(t => t.SetTarget(targetPoint));
            }
        }
    }
}
