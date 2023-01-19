

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.EventSystems;


public class DataReset : MonoBehaviour, IGvrPointerHoverHandler, IPointerExitHandler
{
    public GameObject ending;
    public GameObject reset;

    public float time = 0.0f;

    public void OnGvrPointerHover(PointerEventData eventData)
    {
        time += Time.deltaTime;

        if (time > 3.0f)
        {
            hit();
            //GameObject.Find("Canvas").GetComponent<SceneFadeManager>();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        time = 0.0f;
    }

    public void hit()
    {
        //Normal
        string str = File.ReadAllText(Application.persistentDataPath + "/count_n.json");
        Data_n data1 = JsonUtility.FromJson<Data_n>(str);
        data1.star_normal = 0;
        File.WriteAllText(Application.persistentDataPath + "/count_n.json", JsonUtility.ToJson(data1));

        // string str = File.ReadAllText(Application.persistentDataPath + "/count_n.json");
        //star01.text = data2.star_normal.ToString();
        //star02.text = (3 - data2.star_normal).ToString();

        //Easy
        string str2 = File.ReadAllText(Application.persistentDataPath + "/count_e.json");
        Data_e data2 = JsonUtility.FromJson<Data_e>(str2);
        data2.star_easy = 0;
        File.WriteAllText(Application.persistentDataPath + "/count_e.json", JsonUtility.ToJson(data2));

        // star03.text = data3.star_easy.ToString();
        // star04.text = (2 - data3.star_easy).ToString();

        //Hard
        string str3 = File.ReadAllText(Application.persistentDataPath + "/count_h.json");
        Data_h data3 = JsonUtility.FromJson<Data_h>(str3);
        data3.star_hard = 0;
        File.WriteAllText(Application.persistentDataPath + "/count_h.json", JsonUtility.ToJson(data3));

        // star05.text = data4.star_hard.ToString();
        //  star06.text = (4 - data4.star_hard).ToString();

       ending.SetActive(false);
       reset.SetActive(false);
    }
}
