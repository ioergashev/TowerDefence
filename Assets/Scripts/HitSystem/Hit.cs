using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public int Damage = 10;
    [HideInInspector]
    public IHitable hitable;
    [HideInInspector]
    public IHitter hitter;
}
