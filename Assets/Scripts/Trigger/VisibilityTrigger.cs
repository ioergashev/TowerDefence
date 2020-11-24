using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VisibilityTrigger : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent BecameVisibleEvent = new UnityEvent();
    [HideInInspector]
    public UnityEvent BecameInvisibleEvent = new UnityEvent();

    private void OnBecameVisible()
    {
        BecameVisibleEvent?.Invoke();
    }

    private void OnBecameInvisible()
    {
        BecameInvisibleEvent?.Invoke();
    }
}
