using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Audio_Button_On : MonoBehaviour, IGvrPointerHoverHandler, IPointerExitHandler
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
        {
            audio.Stop();
            time = 0.0f;
            sound_on.SetActive(false);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        time = 0.0f;
    }
}
