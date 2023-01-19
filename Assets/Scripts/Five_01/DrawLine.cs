using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private float counter;
    private float dist;

    public Transform player;
    public Transform Destination;
    public float lineDrawSpeed = 6f;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0,player.position);
        lineRenderer.SetWidth(0.45f, 0.45f);

        dist = Vector3.Distance(player.position, Destination.position);

    }

    // Update is called once per frame
    void Update()
    {
        if (counter < dist)
        {
            counter += .1f / lineDrawSpeed;
            float x = Mathf.Lerp(0, dist, counter);

            Vector3 pointA = player.position;
            Vector3 pointB = Destination.position;

            Vector3 pointAlongLine = x * Vector3.Normalize(pointB - pointA) + pointA;

            lineRenderer.SetPosition(1, pointAlongLine);
        }
        
    }
}
