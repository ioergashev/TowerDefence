using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerHitter : MonoBehaviour, IHitter
{
    private TriggerBehavior trigger;
    private Hit hit;
    public HitEvent OnHit { get; } = new HitEvent();

    private void Awake()
    {
        trigger = GetComponent<TriggerBehavior>();
        hit = GetComponent<Hit>();
    }

    private void Start()
    {
        trigger.TriggerEnterEvent.AddListener(TriggerEnterHandler);
    }

    private void TriggerEnterHandler(GameObject target)
    {
        var hitable = target.GetComponent<IHitable>();
        Hit(hitable);
    }

    public void Hit(IHitable hitable)
    {
        hit.hitter = this;
        hit.hitable = hitable;

        hitable.RecieveHit(hit);
        OnHit?.Invoke(hit);
    }
}
