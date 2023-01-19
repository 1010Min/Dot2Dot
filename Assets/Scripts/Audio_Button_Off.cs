using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Audio_Button_Off : MonoBehaviour, IGvrPointerHoverHandler, IPointerExitHandler
{
    AudioSource audio;
    public float time;
    public GameObject sound_on;
    public GameObject sound_off;

    void Start()
    {
        time = 0.0f;
        audio = GetComponent<AudioSource>();
    }
    public void OnGvrPointerHover(PointerEventData eventData)
    {
        time += Time.deltaTime;
        if (time > 2.0f)
            sound_on.SetActive(true); 
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        time = 0.0f;
    }
}
