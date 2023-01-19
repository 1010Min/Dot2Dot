using System.Collections; 
using System.Collections.Generic; 
using System.IO; 
using UnityEngine;
using UnityEngine.EventSystems;

public class Data_e 
{ 
    public int star_easy; 
} 

public class SaveEasy : MonoBehaviour
{
    public void save(){
        Data_e data = new Data_e(); 
        data.star_easy = load()+2;  

        File.WriteAllText(Application.persistentDataPath + "/count_e.json", JsonUtility.ToJson(data)); 
        Debug.Log("저장할 별 개수: "+data.star_easy);

        if(data.star_easy >2){
            data.star_easy = 2;
            File.WriteAllText(Application.persistentDataPath + "/count_e.json", JsonUtility.ToJson(data)); 
        }
    }
 
    public int load(){
        string str = File.ReadAllText(Application.persistentDataPath + "/count_e.json"); 
 
        Data_e data2 = JsonUtility.FromJson<Data_e>(str);
        Debug.Log("이미 저장된 별 개수: "+data2.star_easy);

        return data2.star_easy;
    }
}
