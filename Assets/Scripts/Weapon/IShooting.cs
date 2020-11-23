using UnityEngine;

public interface IShooting
{
    Transform ShootingPoint { get; }
    bool IsReadyToShoot { get; }
    void Shoot(Transform target);
}
