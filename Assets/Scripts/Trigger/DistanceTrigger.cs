using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DistanceTrigger : TriggerBehavior
{
    public float TriggerDistance = 1;

    public override bool InTrigger => Targets.Any(t => Vector3.Distance(t.position, transform.position) <= TriggerDistance);
}
