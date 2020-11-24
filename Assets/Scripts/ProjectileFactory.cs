using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFactory: MonoBehaviour
{
    public GameObject Prefab;
    public Transform Parent;
    public bool UsePhysics;

    [HideInInspector]
    public Vector3 Velocity;
    [HideInInspector]
    public Transform Target;

    public GameObject CreateProjectile(Vector3 position, Quaternion rotation)
    {
        var instance = GameObject.Instantiate(Prefab, position, rotation, Parent);

        if (UsePhysics)
        {
            var rb = instance.GetComponent<Rigidbody>();
            rb.velocity = Velocity;
        }
        else
        {
            var speed = instance.AddComponent<Speed>();
            speed.speed = Velocity.magnitude;

            instance.AddComponent<ForwardMover>();
        }

        return instance;
    }
}
