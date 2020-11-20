using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMover : MonoBehaviour
{
    public Speed speed;

    private void Awake()
    {
        speed = GetComponent<Speed>();
    }

    private void Update()
    {
        Vector3 translation = transform.forward * Time.deltaTime * speed.speed;

        transform.Translate(translation, Space.World);
    }
}
