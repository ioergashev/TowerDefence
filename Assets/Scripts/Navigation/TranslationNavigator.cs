using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationNavigator : MonoBehaviour, INavigated
{
    private Transform TargetTransform;
    private Vector3 TargetPosition = Vector3.zero;
    private Speed speed;

    private void Awake()
    {
        speed = GetComponent<Speed>();
    }

    private void Update()
    {
        Vector3 targetPosition = TargetTransform != null ? TargetTransform.position : TargetPosition;
        Vector3 translation = (targetPosition - transform.position).normalized * Time.deltaTime * speed.speed;

        transform.Translate(translation, Space.World);
    }

    public void SetTarget(Transform target)
    {
        TargetTransform = target;
    }

    public void SetTarget(Vector3 target)
    {
        TargetTransform = null;
        TargetPosition = target;
    }
}
