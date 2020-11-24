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
        // If there are enought enemies
        if (Game.Instance.EnemiesContainer.Enemies.Count >= Game.Instance.Settings.MaxEnemiesCount && spawner.AutoSpawnActive)
            // Stop spawning
            spawner.AutoSpawnActive = false;

        // If there are not enought enemies
        else if (Game.Instance.EnemiesContainer.Enemies.Count < Game.Instance.Settings.MaxEnemiesCount && !spawner.AutoSpawnActive)
            // Start spawning
            spawner.AutoSpawnActive = true;
    }
}
