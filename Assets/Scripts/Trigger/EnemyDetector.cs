using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    private TriggerBehavior trigger;

    private void Awake()
    {
        trigger = GetComponent<TriggerBehavior>();
    }

    private void Update()
    {
        trigger.Targets = Game.Instance.EnemiesContainer.Enemies.Select(e => e.transform).ToList();
    }
}
