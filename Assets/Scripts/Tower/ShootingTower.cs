using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShootingTower : MonoBehaviour
{
	private IShooting shooting;
	private TriggerBehavior enemyTrigger;

	private void Awake()
	{
		shooting = GetComponent<IShooting>();
		enemyTrigger = GetComponent<TriggerBehavior>();
	}

	void Update()
	{
		if (enemyTrigger.InTrigger)
		{
			if (shooting.IsReadyToShot)
			{
				var nearest = enemyTrigger.Targets.OrderBy(t => Vector3.Distance(t.position, transform.position)).First();
				shooting.Shoot(nearest);
			}
		}
	}
}
