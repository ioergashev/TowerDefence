using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyInitSystem : MonoBehaviour
{
    private SpawnerBehavior spawner;

    private void Awake()
    {
        spawner = GetComponent<SpawnerBehavior>();
    }

    private void Start()
    {
        spawner.OnSpawned.AddListener(SpawnedHandler);
    }

    private void SpawnedHandler(GameObject spawned)
    {
        spawned.GetComponents<INavigated>().ToList().ForEach(n => n.SetTarget(Game.Instance.Castle.transform));
    }
}
