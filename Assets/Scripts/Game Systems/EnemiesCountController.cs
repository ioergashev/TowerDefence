using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesCountController : MonoBehaviour
{
    private IAutoSpawning spawner;

    private void Awake()
    {
        spawner = GetComponent<IAutoSpawning>();
    }

    private void Update()
    {
        if (Game.Instance.EnemiesContainer.Enemies.Count >= Game.Instance.Settings.MaxEnemiesCount && spawner.AutoSpawnActive)
            spawner.AutoSpawnActive = false;
        else if (Game.Instance.EnemiesContainer.Enemies.Count < Game.Instance.Settings.MaxEnemiesCount && !spawner.AutoSpawnActive)
            spawner.AutoSpawnActive = true;
    }
}
