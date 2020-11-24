using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TriggerTargetDetector : MonoBehaviour, IDetector
{
    private TriggerBehavior trigger;

    [Tooltip("Should the selected target be locked while in the trigger")]
    public bool LockTarget = true;
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

    public Transform GetCurrentTarget()
    {
        Transform target = null;

        // If any target in trigger
        if (trigger.InTrigger)
        {
            // If some target locked
            if (LockTarget && fixedTarget != null && trigger.TargetInTrigger(fixedTarget))
                target = fixedTarget;
            else
                // Find new target
                target = trigger.Targets.OrderBy(t => Vector3.Distance(t.position, transform.position))
                    .FirstOrDefault(t => !passedTargets.Contains(t));
        }

        // Lock selected target
        fixedTarget = target;

        return target;
    }

    public Transform SelectNextTarget()
    {
        fixedTarget = null;
        var current = GetCurrentTarget();     
        if (current != null)
            passedTargets.Add(current);

        return GetCurrentTarget();
    }
}
