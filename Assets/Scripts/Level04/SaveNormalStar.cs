using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;

public class Data_n
{
    public int star_normal;
}

public class SaveNormalStar : MonoBehaviour
{
    public void save()
    {
        Data_n data = new Data_n();
        data.star_normal = load() + 1;
        File.WriteAllText(Application.persistentDataPath + "/count_n.json", JsonUtility.ToJson(data));
        if (data.star_normal > 3)
        {
            data.star_normal = 3;
            File.WriteAllText(Application.persistentDataPath + "/count_n.json", JsonUtility.ToJson(data));
        }
    }
    public int load()
    {
        string str = File.ReadAllText(Application.persistentDataPath + "/count_n.json");
        Data_n data2 = JsonUtility.FromJson<Data_n>(str);
        return data2.star_normal;
    }
}
