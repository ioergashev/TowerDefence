using UnityEngine;

/// <summary> Contains shooting logic </summary>
public class ShootingTower : MonoBehaviour
{
	public ShootingBehavior Shooting;
	private IDetector targetDetector;

	private void Awake()
	{
		targetDetector = GetComponent<IDetector>();
	}

	void Update()
	{
		if (Shooting.IsReadyToShoot)
		{
			// Find target
			var target = targetDetector.GetCurrentTarget();
			if (target != null)
			{
				// Fire
				Shooting.Shoot(target);

				SendMessage("OnShootTarget", target, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
