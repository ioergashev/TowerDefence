using UnityEngine;

public class LinearAimCalculator : MonoBehaviour, IAimCalculator
{
    private Vector3 targetPos = Vector3.zero;

    public bool CalculateIntersection(Transform target, Vector3 origin, float shellSpeed, out Vector3 intersectionPoint)
    {
        intersectionPoint = Vector3.zero;

        if (target.position == origin)
            return false;

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

        float crossingTime = origin2target.magnitude * (targetSpeed * Mathf.Cos(angle) - Mathf.Sqrt(shellSpeed * shellSpeed - Mathf.Sin(angle) * Mathf.Sin(angle) * targetSpeed * targetSpeed))
                           / (shellSpeed* shellSpeed - targetSpeed * targetSpeed);

        crossingTime = Mathf.Abs(crossingTime);

        intersectionPoint = target.position + (targetVelocity * targetSpeed * crossingTime);
        targetPos = intersectionPoint;

        return true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(targetPos, 0.5f);
    }
}
