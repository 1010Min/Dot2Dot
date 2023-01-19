using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Five_01_changeColor : MonoBehaviour
{
    MeshRenderer mesh;


    void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    void OnTriggerEnter(Collider other)
    {
//        GameObject test;

        if (other.gameObject.tag == "Player")
        {
            mesh.material.color = Color.blue;
        }
    }
}
