using UnityEngine;

public interface IShooting
{
    bool IsReadyToShot { get; }
    void Shoot(Transform target);
}
