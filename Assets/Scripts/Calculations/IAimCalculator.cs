using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAimCalculator 
{
    bool CalculateIntersection(Transform target, Vector3 origin, float shellSpeed, out Vector3 shellDirection);
}
