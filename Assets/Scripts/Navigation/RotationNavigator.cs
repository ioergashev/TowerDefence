using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationNavigator : MonoBehaviour, INavigated
{
    private Transform TargetTransform;
    private Vector3 TargetPosition = Vector3.zero;
    public bool useAxisX = true;
    public bool useAxisY = true;
    public bool useAxisZ = true;

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

    public void SetTarget(Transform target)
    {
        TargetTransform = target;
    }

    public void SetTarget(Vector3 target)
    {        
        TargetTransform = null;
        TargetPosition = Vector3.SmoothDamp(TargetPosition, target, ref velocity, smoothTime);
    }
}
