using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyOnKilled : MonoBehaviour, IKillable
{
    public UnityEvent OnKilled { get; } = new UnityEvent();

    public void Kill()
    {
        Destroy(gameObject);
        OnKilled?.Invoke();
    }
}
