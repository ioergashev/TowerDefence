using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnInvisible : MonoBehaviour
{
    private VisibilityTrigger trigger;

    private void Awake()
    {
        trigger = GetComponent<VisibilityTrigger>();
    }

    private void Start()
    {
        trigger.BecameInvisibleEvent.AddListener(OnBecameInvisibleHandler);
    }

    private void OnBecameInvisibleHandler()
    {
        Destroy(gameObject);
    }
}
