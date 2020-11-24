using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMover : MonoBehaviour
{
    private Speed speed;

    private void Awake()
    {
        speed = GetComponent<Speed>();
    }

    private void Update()
    {
        Vector3 translation = Vector3.forward * Time.deltaTime * speed.speed;

        transform.Translate(translation);
    }
}
