using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMover : MonoBehaviour
{
    public float Speed = 10;

    private void Update()
    {
        Vector3 translation = transform.forward * Time.deltaTime * Speed;

        transform.Translate(translation, Space.World);
    }
}
