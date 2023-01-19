using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OpeningChange_1 : MonoBehaviour
{
    //public GameObject obj;
    public float time = 0.0f;
    public Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("Canvas").GetComponent<SceneFadeManager>();
        time += Time.deltaTime;

        if(time > 5.0f){
            SceneManager.LoadScene("opening_02");
            /*
            scene = SceneManager.GetSceneByName("opening_02");
            SceneManager.MoveGameObjectToScene(obj, scene);
            */
        }
    }
}
