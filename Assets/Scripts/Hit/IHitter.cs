using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitEvent : UnityEvent<Hit> { }

public interface IHitter 
{
    HitEvent OnHit { get; }

    void Hit(IHitable hitable);
}
