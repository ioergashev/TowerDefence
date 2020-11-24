using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHited : MonoBehaviour
{
    private IHitter hitter;

    private void Awake()
    {
        hitter = GetComponent<IHitter>();
    }

    private void Start()
    {
        hitter.OnHit.AddListener(HitHandler);
    }

    private void HitHandler(Hit hit)
    {
        Destroy(gameObject);
    }
}
