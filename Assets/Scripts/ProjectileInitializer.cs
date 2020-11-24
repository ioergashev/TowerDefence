using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileInitializer : MonoBehaviour
{
    private Speed speed;
    public bool UsePhysics;
    public Vector3 Velocity;
    public Transform Target;

    private void Awake()
    {
        speed = GetComponent<Speed>();
    }

    public void Init()
    {
        if (UsePhysics)
        {
            var rb = gameObject.GetComponent<Rigidbody>();
            rb.velocity = speed.Velocity;
        }
        else
        {
            gameObject.AddComponent<ForwardMover>();
            gameObject.AddComponent<NavigatedBehavior>().SetTarget(Target);
        }
    }
}
