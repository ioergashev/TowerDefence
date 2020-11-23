using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Detector : MonoBehaviour, IDetector
{
    private TriggerBehavior trigger;
    public bool FixTarget = true;
    private Transform fixedTarget;
    private List<Transform> passedTargets = new List<Transform>();

    private void Awake()
    {
        trigger = GetComponent<TriggerBehavior>();
    }

    private void Update()
    {
        passedTargets.RemoveAll(t => t == null);
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
                target = trigger.Targets.OrderBy(t => Vector3.Distance(t.position, transform.position))
                    .FirstOrDefault(t => !passedTargets.Contains(t));
        }

        // Fix selected target
        fixedTarget = target;

        return target;
    }

    public Transform FindNext()
    {
        var current = GetTarget();
        if (current != null)
            passedTargets.Add(current);

        return GetTarget();
    }
}
