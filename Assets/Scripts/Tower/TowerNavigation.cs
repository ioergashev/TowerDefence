using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerNavigation : MonoBehaviour
{
    private TriggerBehavior enemyTrigger;
    private List<INavigated> navigators = new List<INavigated>();
    public Speed WeaponShotSpeed;
    public Transform ShootPoint;
    private IAimCalculator aimCalculator;

    private void Awake()
    {
        enemyTrigger = GetComponent<TriggerBehavior>();
        aimCalculator = GetComponent<IAimCalculator>();
        navigators = GetComponentsInChildren<INavigated>().ToList();
    }

    void Update()
    {
        // If any enemy in target
        if(enemyTrigger.InTrigger)
        {
            // Find nearest enemy
            var nearest = enemyTrigger.Targets.OrderBy(t => Vector3.Distance(t.position, transform.position)).FirstOrDefault();
            if (nearest != null)
            {
                // Calculate lead
                if (aimCalculator.Aim(nearest, ShootPoint.position, WeaponShotSpeed.speed, out Vector3 shellDirection))
                {
                    // Navigate to intersection
                    Vector3 targetPositon = ShootPoint.position + shellDirection * WeaponShotSpeed.speed;
                    navigators.ForEach(t => t.SetTarget(targetPositon));
                }             
            }
        }
    }
}
