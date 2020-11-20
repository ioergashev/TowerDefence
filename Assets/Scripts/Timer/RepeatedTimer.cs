using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RepeatedTimer : MonoBehaviour, ITimer
{
    private float lastCycleTime;

    [SerializeField]
    private float timerDuration = 1;

    public float TimerDuration { get => timerDuration; set => timerDuration = value; }
    public UnityEvent OnTimer { get; set; } = new UnityEvent();

    private void Update()
    {
        if (Time.time > lastCycleTime + TimerDuration)
        {
            lastCycleTime = Time.time;
            OnTimer?.Invoke();
        }
    }
}
