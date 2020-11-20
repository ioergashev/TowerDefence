using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExpectedPositionCalculator
{
    Vector3 Delta { get; }
    Vector3 CalculateExpectedPosition();
}
