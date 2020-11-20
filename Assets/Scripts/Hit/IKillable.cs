using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IKillable 
{
    UnityEvent OnKilled { get; }
    void Kill();
}
