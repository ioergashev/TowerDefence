using UnityEngine;

public class ChangeTargetOnFire : MonoBehaviour
{
    private IDetector detector;
    public float Delay = 0.5f;

    private void Awake()
    {
        detector = GetComponent<IDetector>();
    }

    // Calls by SendMessage
    public void OnShootTarget(Transform target)
    {
        Invoke(nameof(SelectNextTarget), Delay);
    }

    private void SelectNextTarget()
    {
        detector.SelectNextTarget();
    }
}
