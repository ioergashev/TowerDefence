using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleHitable : MonoBehaviour, IHitable
{
    private Health health;
    private IKillable killable;

    private void Awake()
    {
        health = GetComponent<Health>();
        killable = GetComponent<IKillable>();
    }

    public void RecieveHit(Hit hit)
    {
        health.health -= hit.Damage;
        if (health.health <= 0)
            killable?.Kill();
    }
}
