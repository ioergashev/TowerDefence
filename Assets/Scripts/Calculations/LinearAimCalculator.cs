using UnityEngine;

public class LinearAimCalculator : MonoBehaviour, IAimCalculator
{
    public bool Aim(Transform target, Vector3 origin, float shellSpeed, out AimInfo aimInfo)
    {
        aimInfo = new AimInfo
        {
            RequiredShellVelocity = (target.position - origin).normalized * shellSpeed,
            FlightDuration = (target.position - origin).magnitude/ shellSpeed,
            ImpactPoint = target.position
        };

        var velocityCalculator = target.GetComponent<IVelocityCalculator>();
        if (velocityCalculator == null)
            return false;

        var speed = target.GetComponent<Speed>();
        if (speed == null)
            return false;

        Vector3 targetVelocity = velocityCalculator.Velocity.normalized;
        float targetSpeed = speed.speed;
        Vector3 origin2target = target.position - origin;
        float angle = Vector3.Angle(targetVelocity, -origin2target) * Mathf.Deg2Rad;

        if (shellSpeed == targetSpeed)
            return false;

        float flightDuration = origin2target.magnitude * (targetSpeed * Mathf.Cos(angle) - Mathf.Sqrt(shellSpeed * shellSpeed - Mathf.Sin(angle) * Mathf.Sin(angle) * targetSpeed * targetSpeed))
                           / (shellSpeed* shellSpeed - targetSpeed * targetSpeed);

        flightDuration = Mathf.Abs(flightDuration);

        Vector3 impactPoint = target.position + (targetVelocity * targetSpeed * flightDuration);
        Vector3 resultShellVelocity = (impactPoint - origin)/ flightDuration;

        aimInfo.FlightDuration = flightDuration;
        aimInfo.RequiredShellVelocity = resultShellVelocity;
        aimInfo.ImpactPoint = impactPoint;

        return true;
    }
}
