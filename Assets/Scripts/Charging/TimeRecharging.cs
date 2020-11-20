using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRecharging : MonoBehaviour, IChargable
{
    private float lastDischargeTime;
    public float ChargeDuration = 1;
    public bool Charged => Time.time > lastDischargeTime + ChargeDuration;

    private void Awake()
    {
        lastDischargeTime = Time.time - ChargeDuration;
    }

    public void Discharge()
    {
        lastDischargeTime = Time.time;
    }
}
