using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : TriggerBehavior
{
    private List<Transform> targetsIn = new List<Transform>();

    public override bool TargetInTrigger(Transform target)
    {
        return targetsIn.Contains(target);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Targets.Exists(t => t == other.transform))
        {
            targetsIn.Add(other.transform);
            TriggerEnterEvent?.Invoke(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Targets.Exists(t => t == other.transform))
        {
            targetsIn.Remove(other.transform);
        }
    }
}
