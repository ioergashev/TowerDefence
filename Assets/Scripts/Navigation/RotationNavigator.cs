using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationNavigator : MonoBehaviour, INavigated
{
    [SerializeField]
    private Transform TargetTransform;
    private Vector3 TargetPosition = Vector3.zero;
    public bool useAxisX = true;
    public bool useAxisY = true;
    public bool useAxisZ = true;

    private void Awake()
    {
        TargetTransform = transform;
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
        TargetPosition = target;
    }
}
