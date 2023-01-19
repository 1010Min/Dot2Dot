using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class audio_opening : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "Five_01")
        {
            Destroy(gameObject);
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
    }
}
