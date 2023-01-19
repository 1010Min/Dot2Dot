using System.Collections; 
using System.Collections.Generic; 
using System.IO; 
using UnityEngine;
using UnityEngine.EventSystems;

public class Data_h 
{ 
    public int star_hard; 
} 

public class SaveHard : MonoBehaviour
{
    public void save(){
        Data_h data = new Data_h(); 
        data.star_hard = load()+2;  

        File.WriteAllText(Application.persistentDataPath + "/count_h.json", JsonUtility.ToJson(data)); 
        Debug.Log("저장할 별 개수: "+data.star_hard);

        if(data.star_hard >4){
            data.star_hard = 4;
            File.WriteAllText(Application.persistentDataPath + "/count_h.json", JsonUtility.ToJson(data)); 
        }
    }
 
    public int load(){
        string str = File.ReadAllText(Application.persistentDataPath + "/count_h.json"); 
 
        Data_h data2 = JsonUtility.FromJson<Data_h>(str);
        Debug.Log("이미 저장된 별 개수: "+data2.star_hard);

        return data2.star_hard;
    }
}
