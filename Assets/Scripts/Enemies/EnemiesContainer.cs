using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class Game
{
    public EnemiesContainer EnemiesContainer;
}

public class EnemiesContainer : MonoBehaviour
{
    private List<GameObject> enemies = new List<GameObject>();

    public List<GameObject> Enemies => enemies.Where(e => e != null).ToList();
    public SpawnerBehavior EnemySpawner;

    private void Start()
    {
        EnemySpawner.OnSpawned.AddListener(EnemySpawnedHandler);
    }

    private void EnemySpawnedHandler(GameObject spawned)
    {
        enemies.Add(spawned);
        var killable = spawned.GetComponent<IKillable>();
        killable.OnKilled.AddListener(() => EnemyKilledHandler(spawned));
    }

    private void Update()
    {
        enemies.RemoveAll(e => e == null);
    }

    private void EnemyKilledHandler(GameObject enemy)
    {
        if (enemies.Contains(enemy))
            enemies.Remove(enemy);
    }
}
