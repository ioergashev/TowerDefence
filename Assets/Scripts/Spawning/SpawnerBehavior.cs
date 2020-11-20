using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;

[Serializable]
public class SpawnEvent : UnityEvent<GameObject> { }

public abstract class SpawnerBehavior : MonoBehaviour, ISpawning 
{
    public SpawnEvent OnSpawned = new SpawnEvent();

    public abstract GameObject Spawn(GameObject prefab);
}
