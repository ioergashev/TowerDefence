using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellInitializer : MonoBehaviour
{
    private Speed speed;
    public bool UsePhysics;

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
        }
    }
}
