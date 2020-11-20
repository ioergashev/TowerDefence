using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Game
{
    public EnemiesContainer EnemiesContainer;
}

public class EnemiesContainer : MonoBehaviour
{
    [HideInInspector]
    public List<GameObject> Enemies = new List<GameObject>();
    public SpawnerBehavior EnemySpawner;

    private void Start()
    {
        EnemySpawner.OnSpawned.AddListener(EnemySpawnedHandler);
    }

    private void EnemySpawnedHandler(GameObject spawned)
    {
        Enemies.Add(spawned);
        var killable = spawned.GetComponent<IKillable>();
        killable.OnKilled.AddListener(() => EnemyKilledHandler(spawned));
    }

    private void EnemyKilledHandler(GameObject enemy)
    {
        if (Enemies.Contains(enemy))
            Enemies.Remove(enemy);
    }
}
