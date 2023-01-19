using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton :  MonoBehaviour, IGvrPointerHoverHandler, IPointerExitHandler
{
    public float time = 0.0f;
    public GameObject MenuPanel;

    public void OnGvrPointerHover(PointerEventData eventData)
    {
        time += Time.deltaTime;
        if (time > 2.0f)
            MenuPanel.transform.position = new Vector3(MenuPanel.transform.position.x, 4.52f, MenuPanel.transform.position.z);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        time = 0.0f;
    }
}
