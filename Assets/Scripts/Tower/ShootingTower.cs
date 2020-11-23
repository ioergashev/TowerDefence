using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShootingTower : MonoBehaviour
{
	private IShooting shooting;
	private IDetector targetDetector;

	private void Awake()
	{
		shooting = GetComponent<IShooting>();
		targetDetector = GetComponent<IDetector>();
	}

	void Update()
	{
		if (shooting.IsReadyToShoot)
		{
			// Find target
			var target = targetDetector.GetTarget();
			if (target != null)
			{
				shooting.Shoot(target);
				targetDetector.FindNext();
			}
		}
	}
}
