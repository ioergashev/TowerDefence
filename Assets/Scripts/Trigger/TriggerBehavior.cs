using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class TriggerEvent : UnityEvent<GameObject> { }
public abstract class TriggerBehavior : MonoBehaviour
{
    [HideInInspector]
    /// <summary> Objects to detect </summary>
    public List<Transform> Targets;

    [HideInInspector]
    public TriggerEvent TriggerEnterEvent = new TriggerEvent();

    /// <summary> True if any target in trigger </summary>
    public virtual bool InTrigger { get; }

    public abstract bool TargetInTrigger(Transform target);
}
