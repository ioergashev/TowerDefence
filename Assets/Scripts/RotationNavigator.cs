using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationNavigator : MonoBehaviour
{
    public Transform Target;
    public bool useAxisX = true;
    public bool useAxisY = true;
    public bool useAxisZ = true;

    private void Update()
    {
        Vector3 target_position = new Vector3(
            useAxisX ? Target.transform.position.x : transform.position.x,
            useAxisY ? Target.transform.position.y : transform.position.y,
            useAxisZ ? Target.transform.position.z : transform.position.z
            );

        transform.LookAt(target_position);
    }
}
