using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerNavigation : MonoBehaviour
{
    private TriggerBehavior enemyTrigger;
    private List<INavigated> navigators = new List<INavigated>();
    public Speed WeaponShotSpeed;
    public Transform ShootPoint;
    public float FreeWalkDuration = 1;

    private void Awake()
    {
        enemyTrigger = GetComponent<TriggerBehavior>();
        navigators = GetComponentsInChildren<INavigated>().ToList();
    }

    void Update()
    {
        if(enemyTrigger.InTrigger)
        {
            var nearest = enemyTrigger.Targets.OrderBy(t => Vector3.Distance(t.position, transform.position)).FirstOrDefault();

            if (nearest != null)
            {
                Vector3 targetPositon = nearest.transform.position;

                // Calculate lead
                var expectedPositionCalculator = nearest.GetComponent<IExpectedPositionCalculator>();
                if (expectedPositionCalculator != null)
                {
                    Vector3 delta = expectedPositionCalculator.Delta;
                    targetPositon += delta/Time.fixedDeltaTime * FreeWalkDuration;

                    float shootSpeed = (targetPositon - ShootPoint.position).magnitude / FreeWalkDuration;
                    WeaponShotSpeed.speed = shootSpeed;
                }
                
                navigators.ForEach(t => t.SetTarget(targetPositon));
            }
        }
    }
}
