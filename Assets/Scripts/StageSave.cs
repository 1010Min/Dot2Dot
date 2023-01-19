using System.Collections; 
using System.Collections.Generic; 
using System.IO; 
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[System.Serializable] 
public class Data 
{ 
    public string m_nLevel; 
 
    public void printData() 
    { 
        Debug.Log("Level : " + m_nLevel); 
    } 
} 
 
public class StageSave : MonoBehaviour
{ 
    private RaycastHit hit;

   

    public void save(){
        // file save
        Data data3 = new Data(); 
        data3.m_nLevel = SceneManager.GetActiveScene().name;  
 
        File.WriteAllText(Application.persistentDataPath + "/TestJson.json", JsonUtility.ToJson(data3)); 
        Debug.Log("저장된 scene: "+data3.m_nLevel);
    }
 
    public void load(){
        // file load
        string str2 = File.ReadAllText(Application.persistentDataPath + "/TestJson.json"); 
 
        Data data4 = JsonUtility.FromJson<Data>(str2);
        Debug.Log("불러올 scene: "+data4.m_nLevel);
        SceneManager.LoadScene(data4.m_nLevel);
    }
}

// https://scvtwo.tistory.com/18