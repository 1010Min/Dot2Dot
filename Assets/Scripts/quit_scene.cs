using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class quit_scene : MonoBehaviour,IGvrPointerHoverHandler,IPointerExitHandler {
    public float time = 0.0f;

    public void OnGvrPointerHover(PointerEventData eventData){
        time+=Time.deltaTime;
        Debug.Log(time);
        if (time > 2.0f){
            quit();
        }
    }

    public void OnPointerExit(PointerEventData eventData){
        time = 0.0f;
    }

    public void quit()
    {
        //ExitGame();
        Application.Quit(); //-> 어플 종료시 수정해야 함
    }

     public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
        #endif
    }
}