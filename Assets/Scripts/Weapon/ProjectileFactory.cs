using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFactory: MonoBehaviour
{
    public GameObject Prefab;
    public Transform Parent;
    public bool UsePhysics;
    public bool Navigated;

    [HideInInspector]
    public Vector3 Velocity;
    [HideInInspector]
    public Transform Target;

    public GameObject CreateProjectile(Vector3 position, Quaternion rotation)
    {
        var instance = Instantiate(Prefab, position, rotation, Parent);

        if (UsePhysics)
        {
            var rb = instance.AddComponent<Rigidbody>();
            rb.velocity = Velocity;
        }
        else if(Navigated)
        {
            instance.AddComponent<Speed>();
            instance.AddComponent<TranslationNavigator>().SetTarget(Target);
            instance.AddComponent<RotationNavigator>().SetTarget(Target);
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
