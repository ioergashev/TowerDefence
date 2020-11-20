using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerBehavior : MonoBehaviour, ITriggerIn
{
    public List<Transform> Targets;

    public abstract bool InTrigger { get; }
}
