using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnInvisible : MonoBehaviour
{
    public VisibilityTrigger trigger;

    private void Start()
    {
        trigger.BecameInvisibleEvent.AddListener(OnBecameInvisibleHandler);
    }

    private void OnBecameInvisibleHandler()
    {
        Destroy(gameObject);
    }
}
