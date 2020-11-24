using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct AimInfo
{
    public Vector3 RequiredShellVelocity;
    public float FlightDuration;
    public Vector3 ImpactPoint;
}
public interface IAimCalculator 
{
    bool Aim(Transform target, Vector3 origin, float shellSpeed, out AimInfo aimInfo);
}
