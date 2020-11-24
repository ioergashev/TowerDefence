using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> Provides access to the target </summary>
public interface IDetector 
{
    Transform GetCurrentTarget();
    Transform SelectNextTarget();
}
