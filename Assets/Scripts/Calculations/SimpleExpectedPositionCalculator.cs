using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SimpleExpectedPositionCalculator : MonoBehaviour, IExpectedPositionCalculator
{
    private Vector3 lastPosition = Vector3.zero;

    public int bufferSize = 10;
    private List<Vector3> deltasBuffer = new List<Vector3>();
    private int currentIndex;
    public Vector3 Delta => AverageDelta;

    private Vector3 AverageDelta
    {
        get
        {
            Vector3 sum = Vector3.zero;
            foreach (Vector3 v in deltasBuffer)
                sum += v;

            return sum / bufferSize;
        }
    }

    private void Awake()
    {
        deltasBuffer = Enumerable.Repeat(Vector3.zero, bufferSize).ToList();
    }

    public Vector3 CalculateExpectedPosition()
    {
        Vector3 result = transform.position + AverageDelta;
        return result;
    }

    private void OnEnable()
    {
        lastPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (currentIndex >= bufferSize)
            return;

        deltasBuffer[currentIndex] = transform.position - lastPosition;
        lastPosition = transform.position;
        currentIndex = (currentIndex + 1) % bufferSize;
    }
}
