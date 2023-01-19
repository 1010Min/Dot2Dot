using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OpeningChange_3 : MonoBehaviour
{
    public float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("Canvas").GetComponent<SceneFadeManager>();
        time += Time.deltaTime;

        if(time > 5.0f)
            SceneManager.LoadScene("opening_04");
    }
}
