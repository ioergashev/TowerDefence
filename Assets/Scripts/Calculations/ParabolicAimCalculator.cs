using UnityEngine;

public class ParabolicAimCalculator : MonoBehaviour, IAimCalculator
{

    Vector3 pos;

    private LinearAimCalculator linearCalculator;

    private void Awake()
    {
        GameObject child = new GameObject("LinearAimCalculator");
        child.transform.SetParent(transform);
        linearCalculator = child.AddComponent<LinearAimCalculator>();
    }

    private void OnDestroy()
    {
        Destroy(linearCalculator.gameObject);
    }

    public bool Aim(Transform target, Vector3 origin, float shellSpeed, out AimInfo aimInfo)
    {
        if(linearCalculator.Aim(target, origin, shellSpeed, out aimInfo))
        {
            float deltaY = (aimInfo.ImpactPoint - origin).y;
            Vector3 verticalDelta = deltaY * new Vector3(0, 1, 0);

            aimInfo.RequiredShellVelocity.y = 0;

            aimInfo.RequiredShellVelocity += -Physics.gravity * aimInfo.FlightDuration / 2 
                                             + verticalDelta/ aimInfo.FlightDuration;
            return true;
        }
        return false;
    }
}
