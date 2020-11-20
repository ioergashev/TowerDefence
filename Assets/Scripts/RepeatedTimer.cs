using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RepeatedTimer : Timer
{
    private float lastCycleTime;

    private void Update()
    {
        if (Time.time > lastCycleTime + TimerDuration)
            OnTimer?.Invoke();
    }
}
