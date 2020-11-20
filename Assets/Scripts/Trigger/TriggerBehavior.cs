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
    public List<Transform> Targets;

    [HideInInspector]
    public TriggerEvent TriggerEnterEvent = new TriggerEvent();

    public virtual bool InTrigger { get; }
}
