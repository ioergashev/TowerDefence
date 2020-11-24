using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityCalculator : MonoBehaviour, IVelocityCalculator
{
    IExpectedPositionCalculator expectedPositionCalculator;

    public Vector3 Velocity => expectedPositionCalculator.Delta/ Time.fixedDeltaTime;

    private void Awake()
    {
        expectedPositionCalculator = GetComponent<IExpectedPositionCalculator>();
    }
}
