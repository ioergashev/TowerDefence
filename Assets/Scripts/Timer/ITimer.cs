using UnityEngine.Events;

public interface ITimer
{
    float TimerDuration { get; set; }

    UnityEvent OnTimer { get;}
}
