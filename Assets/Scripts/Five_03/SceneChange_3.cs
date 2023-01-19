using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneChange_3 : MonoBehaviour,IGvrPointerHoverHandler,IPointerExitHandler
{
    public float time = 0.0f;

    public void OnGvrPointerHover(PointerEventData eventData){
        time+=Time.deltaTime;

        if(time > 3.0f){
            hit();
            GameObject.Find("Canvas").GetComponent<SceneFadeManager>();
        }
    }

    public void OnPointerExit(PointerEventData eventData){
        time = 0.0f;
    }

    public void hit()
    {
        SceneManager.LoadScene("Five_03"); // 변경
        time = 0.0f;
    }
}
