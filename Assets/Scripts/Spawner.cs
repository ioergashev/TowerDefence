using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{
	public GameObject Prefab;
	private Timer timer;
    public Transform SpawnPoint;

    private void Awake()
    {
		timer = GetComponent<Timer>();
    }

    private void Start()
    {
        timer.OnTimer.AddListener(TimerHandler);
    }

    private void TimerHandler()
    {
        Instantiate(Prefab, SpawnPoint.position, SpawnPoint.rotation);
    }
}
