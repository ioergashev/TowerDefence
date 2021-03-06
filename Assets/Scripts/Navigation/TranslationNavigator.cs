using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationNavigator : NavigatedBehavior
{
    private Transform TargetTransform;
    private Vector3 TargetPosition = Vector3.zero;
    private Speed speed;
    private const float stopDistance = 0.1f;

    private void Awake()
    {
        speed = GetComponent<Speed>();
    }

    private void Update()
    {
        Vector3 targetPosition = TargetTransform != null ? TargetTransform.position : TargetPosition;
        Vector3 translation = (targetPosition - transform.position).normalized * Time.deltaTime * speed.speed;

        if ((targetPosition - transform.position).magnitude > stopDistance)
            transform.Translate(translation, Space.World);
    }

    public override void SetTarget(Transform target)
    {
        TargetTransform = target;
    }

    public override void SetTarget(Vector3 target)
    {
        TargetTransform = null;
        TargetPosition = target;
    }
}
