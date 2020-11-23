using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerNavigation : MonoBehaviour
{
    private IDetector targetDetector;
    private List<INavigated> navigators = new List<INavigated>();
    public Speed WeaponShotSpeed;
    public Transform ShootPoint;
    private IAimCalculator aimCalculator;

    private void Awake()
    {
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
            if (aimCalculator.CalculateIntersection(target, ShootPoint.position, WeaponShotSpeed.speed, out Vector3 intersectionPoint))
            {
                // Navigate to intersection point
                navigators.ForEach(t => t.SetTarget(intersectionPoint));
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(ShootPoint.position, ShootPoint.position + ShootPoint.forward * 10);
    }
}
