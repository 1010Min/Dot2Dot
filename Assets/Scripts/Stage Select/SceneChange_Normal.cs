using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Data_Normal
{
    public int m_nLevel;
}

public class SceneChange_Normal : MonoBehaviour,IGvrPointerHoverHandler,IPointerExitHandler
{
    public float time = 0.0f; // 사냥꾼의 터 오브젝트 응시 시간
    public static int count01 = 0;
    public static int count02 = 0;
    public static int count03 = 0; // 플레이 횟수
    int random;

    public void OnGvrPointerHover(PointerEventData eventData)
    {
        time += Time.deltaTime;
        if (time > 2.0f) // 사냥꾼의 터 오브젝트 응시 시간이 2초 이상이면
        {
            hit(); // Normal 레벨에서의 랜덤 플레이 구현 함수 호출
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        time = 0.0f;
    }

    public void hit()
    {
        if (count03 == 0) // 첫 번째 플레이
        {
            random = Random.Range(1, 5);
            save(random); // 첫 번째 플레이하는 스테이지 번호 저장
            count03++;
        }
        else if(count03 == 1) // 두 번째 플레이
        {
            count01 = load(); // 첫 번째 플레이한 스테이지 번호 로드
            random = Random.Range(1, 5);
            while (count01 == random) // 첫 번째 플레이한 스테이지 번호와 다른 숫자 나올 때까지
            {
                random = Random.Range(1, 5); // 다시 선택
            }
            save02(random);
            count03++;
        }
        else if(count03 == 2) // 세 번째 플레이
        {
            count01 = load(); // 첫 번째 플레이한 스테이지 번호 로드
            count02 = load02(); // 두 번째 플레이한 스테이지 번호 로드
            random = Random.Range(1, 5);
            while(count01 == random || count02 == random) // 첫 번째, 두 번째 플레이한 스테이지 번호와 다른 숫자 나올 때까지
            {
                random = Random.Range(1, 5); // 다시 선택
            }
        }
        else
        {
            random = 0;
        }
        if (random == 1) // 3번 스테이지 플레이
        {
            SceneManager.LoadScene("Five_03");
            time = 0.0f;
        }
        if(random == 2) // 4번 스테이지 플레이
        {
            SceneManager.LoadScene("Five_04");
            time = 0.0f;
        }
        if(random == 3) // 5번 스테이지 플레이
        {
            SceneManager.LoadScene("Five_05");
            time = 0.0f;
        }
        if(random == 4) // 6번 스테이지 플레이
        {
            SceneManager.LoadScene("Five_06");
            time = 0.0f;
        }
    }

    public void save(int random) // 첫 번째 플레이한 스테이지 번호 저장
    {
        Data_Normal data_1 = new Data_Normal();
        data_1.m_nLevel = random;
        File.WriteAllText(Application.persistentDataPath + "/NormalPlayedStage.json", JsonUtility.ToJson(data_1)); //
    }

    public int load() // 첫 번째 플레이한 스테이지 번호 로드
    {
        string str2 = File.ReadAllText(Application.persistentDataPath + "/NormalPlayedStage.json");
        Data_Normal data_2 = JsonUtility.FromJson<Data_Normal>(str2);
        return data_2.m_nLevel;
    }

    public void save02(int random) // 두 번째 플레이한 스테이지 번호 저장
    {
        Data_Normal data_3 = new Data_Normal();
        data_3.m_nLevel = random;
        File.WriteAllText(Application.persistentDataPath + "/NormalPlayedStage02.json", JsonUtility.ToJson(data_3));
    }

    public int load02() // 두 번째 플레이한 스테이지 번호 로드
    {
        string str4 = File.ReadAllText(Application.persistentDataPath + "/NormalPlayedStage02.json");
        Data_Normal data_4 = JsonUtility.FromJson<Data_Normal>(str4);
        return data_4.m_nLevel;
    }
}

