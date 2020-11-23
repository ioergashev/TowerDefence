using UnityEngine;

public class LinearAimCalculator : MonoBehaviour, IAimCalculator
{
    public bool Aim(Transform target, Vector3 origin, float shellSpeed, out Vector3 shellDirection)
    {
        shellDirection = Vector3.zero;

        if (shellSpeed == 0)
            return false;
        if (target.position == origin)
            return false;

        var velocityCalculator = target.GetComponent<IVelocityCalculator>();
        if (velocityCalculator == null)
            return false;

        Vector3 targetVelocity = velocityCalculator.Velocity;
        float targetSpeed = targetVelocity.magnitude;
        Vector3 origin2target = target.position - origin;
        float angle = Vector3.Angle(targetVelocity, -origin2target) * Mathf.Deg2Rad;

        float crossingTime = (origin2target.magnitude * targetSpeed * Mathf.Cos(angle))
                           / (shellSpeed* shellSpeed - targetSpeed * targetSpeed);

        crossingTime = Mathf.Abs(crossingTime);

        Vector3 intersectionPoint = targetVelocity.normalized * crossingTime;

        shellDirection = (intersectionPoint - origin).normalized;
        return true;
    }
}
