using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    public Vector3[] locations = new Vector3[0];
    public float speed = 0.1f;
    public bool walkOnStart = true;

    private Vector3 destination;
    private const float proximity = 0.1f;

    private void Awake()
    {
        destination = transform.position;
    }

    private void Start()
    {
        if (walkOnStart)
        {
            WalkTo(0);
        }
    }

    private void Update()
    {
        if (DistanceToDestination() > proximity)
        {
            transform.Translate((destination - transform.position).normalized*speed);
        }
    }

    public void WalkTo(int locIndex)
    {
        destination = locations[locIndex];
    }

    private float DistanceToDestination()
    {
        return DistanceBetween(destination, transform.position);
    }

    private static float DistanceBetween(Vector3 v1, Vector3 v2)
    {
        return Mathf.Abs((v1 - v2).magnitude);
    }
}
