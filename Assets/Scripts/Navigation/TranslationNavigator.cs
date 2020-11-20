using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationNavigator : NavigatedBehavior
{
    [SerializeField]
    private Transform TargetTransform;
    private Vector3 TargetPosition = Vector3.zero;
    public float Speed = 1;   

    private void Update()
    {
        Vector3 targetPosition = TargetTransform != null ? TargetTransform.position : TargetPosition;
        Vector3 translation = (targetPosition - transform.position).normalized * Time.deltaTime * Speed;

        transform.Translate(translation);
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
