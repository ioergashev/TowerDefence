using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NavigatedBehavior : MonoBehaviour
{
    public abstract void SetTarget(Transform target);
    public abstract void SetTarget(Vector3 target);
}
