using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnEnter : MonoBehaviour
{
    private TriggerBehavior trigger;

    private void Awake()
    {
        trigger = GetComponent<TriggerBehavior>();
    }

    private void Start()
    {
        trigger.TriggerEnterEvent.AddListener(TriggerEnterHandler);
    }

    private void TriggerEnterHandler(GameObject target)
    {
        Destroy(target);
    }
}
