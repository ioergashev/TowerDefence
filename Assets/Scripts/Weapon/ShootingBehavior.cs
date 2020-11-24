using UnityEngine;

public abstract class ShootingBehavior :MonoBehaviour
{
    public Transform ShootPoint;
    public float ShotSpeed;
    public abstract bool IsReadyToShoot { get; }
    public abstract void Shoot(Transform target = null);
}
