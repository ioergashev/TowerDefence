using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerNavigation : MonoBehaviour
{
    private TriggerBehavior enemyTrigger;
    public List<INavigated> navigators;

    private void Awake()
    {
        enemyTrigger = GetComponent<TriggerBehavior>();
    }

    void Update()
    {
        var nearest = enemyTrigger.Targets.OrderBy(t => Vector3.Distance(t.position, transform.position)).FirstOrDefault();
        if (nearest != null)
            navigators.ForEach(t => t.SetTarget(transform));
    }
}
