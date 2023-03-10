using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class ToOpening01 : MonoBehaviour, IGvrPointerHoverHandler, IPointerExitHandler
{
    public float time = 0.0f;

    public void OnGvrPointerHover(PointerEventData eventData)
    {
        time += Time.deltaTime;
        if (time > 3.0f)
        {
            hit();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        time = 0.0f;
    }

    public void hit()
    {
        SceneManager.LoadScene("opening_01");
        time = 0.0f;
    }
}
