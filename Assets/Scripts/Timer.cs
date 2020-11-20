using UnityEngine.Events;

public abstract class Timer 
{
    public float TimerDuration;

    public UnityEvent OnTimer = new UnityEvent();
}
