using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationNavigator : NavigatedBehavior
{
    private Transform TargetTransform;
    private Vector3 TargetPosition = Vector3.zero;
    public bool useAxisX = true;
    public bool useAxisY = true;
    public bool useAxisZ = true;

    [Tooltip("Approximately the time it will take to reach the target. A smaller value will reach the target faster.")]
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        TargetTransform = transform;
        TargetPosition = transform.position;
    }

    private void Update()
    {
        Vector3 targetPosition = TargetTransform != null? TargetTransform.position : TargetPosition;

        if (!useAxisX)
            targetPosition.x = transform.position.x;
        if (!useAxisY)
            targetPosition.y = transform.position.y;
        if (!useAxisZ)
            targetPosition.z = transform.position.z;

        transform.LookAt(targetPosition);
    }

    public override void SetTarget(Transform target)
    {
        TargetTransform = target;
    }

    public override void SetTarget(Vector3 target)
    {        
        TargetTransform = null;

        // Smooth moving
        TargetPosition = Vector3.SmoothDamp(TargetPosition, target, ref velocity, smoothTime);
    }
}
