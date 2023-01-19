using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackButton : MonoBehaviour, IGvrPointerHoverHandler, IPointerExitHandler
{
    public GameObject MenuPanel;
    public float time = 0.0f;

    void Start()
    {
        time = 0.0f;
    }
    public void OnGvrPointerHover(PointerEventData eventData)
    {
        time += Time.deltaTime;
        if (time > 2.0f)
        {
            MenuPanel.transform.position = new Vector3(MenuPanel.transform.position.x, 80f, MenuPanel.transform.position.z);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        time = 0.0f;
    }

}
