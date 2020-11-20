using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : TriggerBehavior
{
    private void OnTriggerEnter(Collider other)
    {
        if (Targets.Exists(t => t == other.transform))
            TriggerEnterEvent?.Invoke(other.gameObject);
    }
}
