using System.Collections;
using System.Collections.Generic;
using System.IO; 
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[System.Serializable] 
public class data_hard 
{ 
    public int m_nLevel; 
} 

public class SceneChange_hard : MonoBehaviour,IGvrPointerHoverHandler,IPointerExitHandler
{
    public float time = 0.0f;
    int random;
    int random2;
    int random_first;

    public void OnGvrPointerHover(PointerEventData eventData){
        time+=Time.deltaTime;

        if(time > 2.0f){
            hit();
        }
    }

    public void OnPointerExit(PointerEventData eventData){
        time = 0.0f;
    }

    public void hit()
    {
        if(File.Exists(Application.persistentDataPath + "/scene_hard.json")){
            random2 = Random.Range(1, 3); 

            random_first = load();

            if(random2 == random_first){
                random2 = Random.Range(1,3);
            }

            else if(random2 != random_first){

                if(random2 == 1){
                    SceneManager.LoadScene("Five_07");
                    Debug.Log("Move to Scene 7");
                    time = 0.0f;
                }

                if(random2 == 2){
                    SceneManager.LoadScene("Five_08");
                    Debug.Log("Move to Scene 8");
                    time = 0.0f;
                }

                save(random2);
            }
        }
        else{
            random = Random.Range(1, 3); 
            save(random);
        }
    }

    public void save(int random){
        // file save
        data_hard data_1 = new data_hard(); 
        data_1.m_nLevel = random;  
        Debug.Log("save: "+data_1.m_nLevel);
        File.WriteAllText(Application.persistentDataPath + "/scene_hard.json", JsonUtility.ToJson(data_1));
    }
 
    public int load(){
        // file load
        string str2 = File.ReadAllText(Application.persistentDataPath + "/scene_hard.json"); 
 
        data_hard data_2 = JsonUtility.FromJson<data_hard>(str2);
        Debug.Log("load: "+data_2.m_nLevel);
        return data_2.m_nLevel;
    }
}
