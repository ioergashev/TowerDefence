using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSpawner : SpawnerBehavior, IAutoSpawning
{
    private ITimer timer;

    public GameObject Prefab;   
    public Transform SpawnPoint;

    public bool AutoSpawnActive { get; set; }

    private void Awake()
    {
        timer = GetComponent<ITimer>();
    }

    private void Start()
    {
        timer.OnTimer.AddListener(TimerHandler);
    }

    private void TimerHandler()
    {
        if (AutoSpawnActive)
            Spawn(Prefab);
    }

    public override GameObject Spawn(GameObject prefab)
    {
        var spawned = Instantiate(prefab, SpawnPoint.position, SpawnPoint.rotation);
        OnSpawned?.Invoke(spawned);

        return spawned;
    }
}
