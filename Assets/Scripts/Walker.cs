using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    [SerializeField]
    private Vector3[] locations = new Vector3[0];
    [SerializeField]
    private float speed = 0.1f;
    [SerializeField]
    private bool walkOnStart = true;

    private bool dissapearOnArrive = false;

    private Vector3 destination;
    private const float proximity = 0.1f;
    private int destinationIndex = -1;

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
        else //arrived
        {
            if (dissapearOnArrive)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void WalkTo(int locIndex, bool dissapear = false)
    {
        destination = locations[locIndex];
        destinationIndex = locIndex;
        dissapearOnArrive = dissapear;
    }

    public void WalkToNext(bool dissapear = false)
    {
        destinationIndex++;
        if(destinationIndex >= locations.Length)
        {
            destinationIndex = 0;
        }
        WalkTo(destinationIndex, dissapear);
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
