using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExpectedPositionCalculator
{
    /// <summary> Translstion delta by fixedDeltaTime </summary>
    Vector3 Delta { get; }
    Vector3 CalculateExpectedPosition();
}
