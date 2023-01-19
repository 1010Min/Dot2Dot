using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SceneFadeManager : MonoBehaviour {

    public UnityEngine.UI.Image fade;
    float fades = 1.0f;
    float time = 0;

    void Update(){
        //EventSystem.current.IsPointerOverGameObject() = false;
        time += Time.deltaTime;
        if(fades >0.0f && time >=0.2f){
            fades -= 0.1f;
            fade.color = new Color(0,0,0,fades);
            time = 0.0f;
        }
        else if (fades <=0.0f){
            time = 0.0f;
        }
    }   
}
