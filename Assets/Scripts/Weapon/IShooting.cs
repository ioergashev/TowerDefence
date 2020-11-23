using UnityEngine;

public interface IShooting
{
    bool IsReadyToShoot { get; }
    void Shoot(Transform target);
}
