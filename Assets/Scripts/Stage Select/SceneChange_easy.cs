using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneChange_easy : MonoBehaviour,IGvrPointerHoverHandler,IPointerExitHandler
{
    public float time = 0.0f;
    //public static bool played = false;

    public void OnGvrPointerHover(PointerEventData eventData){
        time+=Time.deltaTime;

        if(time > 2.0f){
            hit();
        }
    }

    public void OnPointerExit(PointerEventData eventData){
        time = 0.0f;
    }

    public void hit()
    {
        SceneManager.LoadScene("Five_02");
        Debug.Log("Move to Scene 2");
        //played = true; // 플레이했다면 True로
        time = 0.0f;
    }
}
