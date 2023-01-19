using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeCast_stage : MonoBehaviour
{
    private Transform tr;
    private Ray ray;
    private RaycastHit hit;
    public float dist = 10.0f;

    void Start(){
        tr = GetComponent<Transform>();
    }

    void Update(){
        ray = new Ray(tr.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * dist, Color.red);
    }
}
