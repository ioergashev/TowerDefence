using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary> Setup attached trigger to detect enemies </summary>
public class EnemyDetector : MonoBehaviour, IDetector
{
    private TriggerBehavior trigger;
    public bool FixTarget = true;
    private Transform fixedTarget;

    private void Awake()
    {
        trigger = GetComponent<TriggerBehavior>();
    }

    private void Update()
    {
        trigger.Targets = Game.Instance.EnemiesContainer.Enemies.Select(e => e.transform).ToList();
    }

    public Transform GetTarget()
    {
        Transform target = null;

        // If any target in trigger
        if (trigger.InTrigger)
        {
            // If some target fixed
            if (FixTarget && fixedTarget != null && trigger.TargetInTrigger(fixedTarget))
                target = fixedTarget;          
            else
                // Find new target
                target = trigger.Targets.OrderBy(t => Vector3.Distance(t.position, transform.position)).FirstOrDefault();
        }

        // Fix selected target
        fixedTarget = target;

        return target;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (fixedTarget != null)
            Gizmos.DrawSphere(fixedTarget.position, 0.75f);
    }
}
