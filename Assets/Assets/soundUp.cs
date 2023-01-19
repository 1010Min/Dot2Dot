using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundUp : MonoBehaviour
{
    public AudioSource thisAudio;
    float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (thisAudio.volume < 80)
        {
            while (t <= 60)
            {
                t += Time.deltaTime * 2;
                thisAudio.volume *= (1 + t);
               
            }
        }

    }
}
