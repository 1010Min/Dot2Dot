using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Playermove03 : MonoBehaviour
{
    private Transform tr;
    private Ray ray;
    private RaycastHit hit;
    GraphicRaycaster raycaster;
    public float dist = 10.0f;

    public float time01 = 0.0f;
    public float time02 = 0.0f;
    public float time03 = 0.0f;
    public float time04 = 0.0f;
    public float time05 = 0.0f;

    public GameObject player;
    public GameObject sphere02;
    public GameObject sphere03;
    public GameObject sphere04;
    public GameObject sphere05;
    public GameObject sphere06;

    public GameObject UI02;
    public GameObject UI03;
    public GameObject UI04;
    public GameObject UI05;
    public GameObject UI06;
    public GameObject UI02_2;
    public GameObject UI03_2;
    public GameObject UI04_2;
    public GameObject UI05_2;
    public GameObject UI_true;
    public GameObject UI_false;

    public GameObject moza02;
    public GameObject moza03;
    public GameObject moza04;
    public GameObject moza05;
    public GameObject moza_end;

    public GameObject cube01;
    public GameObject cube02;
    public GameObject cube03;
    public GameObject cube04;
    public GameObject cube05;
    public GameObject cube06;
    public GameObject cube07;

    private bool start = true;
    private bool arrive01 = false;
    private bool arrive02 = false;
    private bool arrive03 = false;
    private bool arrive04 = false;
    private bool arrive05 = false;

    private bool no02 = false;
    private bool no03 = false;
    private bool no04 = false;
    private bool no05 = false;

    private bool select2 = false;
    private bool select3 = false;
    private bool select4 = false;
    private bool select5 = false;

    void Start()
    {
        StageManager.isStopped = true;
        tr = GetComponent<Transform>();

        UI02.SetActive(false);
        UI03.SetActive(false);
        UI04.SetActive(false);
        UI05.SetActive(false);
        UI06.SetActive(false);
        UI02_2.SetActive(false);
        UI03_2.SetActive(false);
        UI04_2.SetActive(false);
        UI05_2.SetActive(false);
        UI_true.SetActive(false);
        UI_false.SetActive(false);
    }

    void Update()
    {
        Vector3 vec = player.GetComponent<Transform>().position - UI02.GetComponent<Transform>().position;
        vec.Normalize();
        Quaternion q = Quaternion.LookRotation(vec);
        UI02.GetComponent<Transform>().rotation = q;

        Vector3 vec03 = player.GetComponent<Transform>().position - UI03.GetComponent<Transform>().position;
        vec03.Normalize();
        Quaternion q03 = Quaternion.LookRotation(vec03);
        UI03.GetComponent<Transform>().rotation = q03;

        Vector3 vec04 = player.GetComponent<Transform>().position - UI04.GetComponent<Transform>().position;
        vec04.Normalize();
        Quaternion q04 = Quaternion.LookRotation(vec04);
        UI04.GetComponent<Transform>().rotation = q04;

        Vector3 vec05 = player.GetComponent<Transform>().position - UI05.GetComponent<Transform>().position;
        vec05.Normalize();
        Quaternion q05 = Quaternion.LookRotation(vec05);
        UI05.GetComponent<Transform>().rotation = q05;

        Vector3 vec06 = player.GetComponent<Transform>().position - UI06.GetComponent<Transform>().position;
        vec06.Normalize();
        Quaternion q06 = Quaternion.LookRotation(vec06);
        UI06.GetComponent<Transform>().rotation = q06;

        Vector3 vec_true = player.GetComponent<Transform>().position - UI_true.GetComponent<Transform>().position;
        vec_true.Normalize();
        Quaternion q_true = Quaternion.LookRotation(vec_true);
        UI_true.GetComponent<Transform>().rotation = q_true;

        Vector3 vec_false = player.GetComponent<Transform>().position - UI_false.GetComponent<Transform>().position;
        vec_false.Normalize();
        Quaternion q_false = Quaternion.LookRotation(vec_false);
        UI_false.GetComponent<Transform>().rotation = q_false;

        Vector3 vec02_2 = player.GetComponent<Transform>().position - UI02_2.GetComponent<Transform>().position;
        vec02_2.Normalize();
        Quaternion q02_2 = Quaternion.LookRotation(vec02_2);
        UI02_2.GetComponent<Transform>().rotation = q02_2;
        
        Vector3 vec03_2 = player.GetComponent<Transform>().position - UI03_2.GetComponent<Transform>().position;
        vec03_2.Normalize();
        Quaternion q03_2 = Quaternion.LookRotation(vec03_2);
        UI03_2.GetComponent<Transform>().rotation = q03_2;

        Vector3 vec04_2 = player.GetComponent<Transform>().position - UI04_2.GetComponent<Transform>().position;
        vec04_2.Normalize();
        Quaternion q04_2 = Quaternion.LookRotation(vec04_2);
        UI04_2.GetComponent<Transform>().rotation = q04_2;

        Vector3 vec05_2 = player.GetComponent<Transform>().position - UI05_2.GetComponent<Transform>().position;
        vec05_2.Normalize();
        Quaternion q05_2 = Quaternion.LookRotation(vec05_2);
        UI05_2.GetComponent<Transform>().rotation = q05_2;

        ray = new Ray(tr.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * dist, Color.red);

        UI02.SetActive(false); 
        UI03.SetActive(false);
        UI04.SetActive(false);
        UI05.SetActive(false);
        UI06.SetActive(false);
        UI02_2.SetActive(false);
        UI03_2.SetActive(false);
        UI04_2.SetActive(false);
        UI05_2.SetActive(false);
        UI_true.SetActive(false);
        UI_false.SetActive(false);

        Color color;
        ColorUtility.TryParseHtmlString("#957745", out color);

        if (Physics.Raycast(ray, out hit, dist, 1 << 9))
        {
            if (((time01 >= 2.0f && start) || (time01 >= 2.0f && arrive02)) && !no02)
            {
                arrive01 = true; arrive02 = false; arrive03 = false; arrive04 = false; arrive05 = false; start = false;
            }

            if (((time02 >= 2.0f && arrive01) || (time02 >= 2.0f && arrive03)) && !no03)
            {
                arrive02 = true; arrive01 = false; arrive03 = false; arrive04 = false; arrive05 = false; start = false;
            }

            if (((time03 >= 2.0f && arrive04) || (time03 >= 2.0f && arrive02)) && !no04)
            {
                arrive03 = true; arrive01 = false; arrive02 = false; arrive04 = false; arrive05 = false; start = false;
            }

            if ((time04 >= 2.0f && start) || (time04 >= 2.0f && arrive03) && !no05)
            {
                arrive04 = true; arrive01 = false; arrive02 = false; arrive03 = false; arrive05 = false; start = false;
            }

            if ((time05 >= 2.0f && arrive04) || (time05 >=2.0f && arrive02))
            {
                arrive05 = true; arrive01 = false; arrive02 = false; arrive03 = false; arrive04 = false; start = false;
            }
            
            GazeButton();

            if(time01 >= 2.0f && start)
            {
                cube01.GetComponent<Renderer>().material.color = color;
                moza02.GetComponent<Renderer>().material.color = Color.blue;
                select2 = true;
            }

            if (time01 >= 2.0f && arrive02)
            {
                cube02.GetComponent<Renderer>().material.color = color;
                moza02.GetComponent<Renderer>().material.color = Color.blue;
                no03 = true;
                select2 = true;
            }

            if (time02 >= 2.0f && arrive01)
            {
                cube02.GetComponent<Renderer>().material.color = color;
                moza03.GetComponent<Renderer>().material.color = Color.blue;
                no02 = true;
                select3 = true;
            }

            if(time02 >= 2.0f && arrive03){
                cube03.GetComponent<Renderer>().material.color = color;
                moza03.GetComponent<Renderer>().material.color = Color.blue;
                no04 = true; 
                select3 = true;
            }

            if (time03 >= 2.0f && arrive02)
            {
                cube03.GetComponent<Renderer>().material.color = color;
                moza04.GetComponent<Renderer>().material.color = Color.blue;
                no03 = true;
                select4 = true;
            }

            if (time03 >= 2.0f && arrive04){
                cube04.GetComponent<Renderer>().material.color = color;
                moza04.GetComponent<Renderer>().material.color = Color.blue;
                no05 = true; 
                select4 = true;
            }

            if (time04 >= 2.0f && arrive03)
            {
                cube04.GetComponent<Renderer>().material.color = color;
                moza05.GetComponent<Renderer>().material.color = Color.blue;
                no04 = true; 
                select5 = true;
            }

            if(time04 >= 2.0f && start){
                cube06.GetComponent<Renderer>().material.color = color;
                moza05.GetComponent<Renderer>().material.color = Color.blue;
                select5 = true;
            }

            if (time05 >= 2.0f && arrive04){
                cube05.GetComponent<Renderer>().material.color = color;
                moza_end.GetComponent<Renderer>().material.color = Color.blue;
                no05 = true;
            }

            if (time05 >= 2.0f && arrive02){
                cube07.GetComponent<Renderer>().material.color = color;
                moza_end.GetComponent<Renderer>().material.color = Color.blue;
            }

        }
        else
        {
            time01 = 0.0f;
            time02 = 0.0f;
            time03 = 0.0f;
            time04 = 0.0f;
            time05 = 0.0f;
        }

        if ((cube01.GetComponent<Renderer>().material.color == color) && (cube02.GetComponent<Renderer>().material.color == color)
            && (cube03.GetComponent<Renderer>().material.color == color) && (cube04.GetComponent<Renderer>().material.color == color)
            && (cube05.GetComponent<Renderer>().material.color == color))
        {
            Debug.Log("성공"); 
            UI_true.SetActive(true);
        }

        if ((cube05.GetComponent<Renderer>().material.color == color)&&(cube06.GetComponent<Renderer>().material.color == color))
        {
            Debug.Log("실패");
            UI_false.SetActive(true);
        }

        if ((cube06.GetComponent<Renderer>().material.color == color)&&(cube04.GetComponent<Renderer>().material.color == color)
            &&(cube03.GetComponent<Renderer>().material.color == color)&&(cube02.GetComponent<Renderer>().material.color == color))
        {
            Debug.Log("실패");
            UI_false.SetActive(true);
        }

        if ((cube06.GetComponent<Renderer>().material.color == color)&&(cube04.GetComponent<Renderer>().material.color == color)
            &&(cube03.GetComponent<Renderer>().material.color == color)&&(cube07.GetComponent<Renderer>().material.color == color))
        {
            Debug.Log("실패");
            UI_false.SetActive(true);
        }

        if ((cube01.GetComponent<Renderer>().material.color == color)&&(cube02.GetComponent<Renderer>().material.color == color)
            &&(cube07.GetComponent<Renderer>().material.color == color))
        {
            Debug.Log("실패");
            UI_false.SetActive(true);
        }

        if (arrive01 && !no02)
        {
            player.GetComponent<Transform>().position = Vector3.MoveTowards(player.GetComponent<Transform>().position, sphere02.GetComponent<Transform>().position, 0.08f);
        }

        if (arrive02 && !no03)
        {
            player.GetComponent<Transform>().position = Vector3.MoveTowards(player.GetComponent<Transform>().position, sphere03.GetComponent<Transform>().position, 0.08f);
        }

        if (arrive03 && !no04)
        {
            player.GetComponent<Transform>().position = Vector3.MoveTowards(player.GetComponent<Transform>().position, sphere04.GetComponent<Transform>().position, 0.08f);
        }

        if (arrive04 && !no05)
        {
            player.GetComponent<Transform>().position = Vector3.MoveTowards(player.GetComponent<Transform>().position, sphere05.GetComponent<Transform>().position, 0.08f);
        }

        if (arrive05)
        {
            player.GetComponent<Transform>().position = Vector3.MoveTowards(player.GetComponent<Transform>().position, sphere06.GetComponent<Transform>().position, 0.08f);
        }
    }

    void GazeButton()
    {
        if (hit.collider.gameObject.tag == "sphere02")
        {
            time01 += Time.deltaTime;
            if(select2)
                UI02.SetActive(true);  
            else
                UI02_2.SetActive(true);
        }

        if (hit.collider.gameObject.tag == "sphere03")
        {
            time02 += Time.deltaTime;
            if(select3)
                UI03.SetActive(true);  
            else
                UI03_2.SetActive(true);
        }

        if (hit.collider.gameObject.tag == "sphere04")
        {
            time03 += Time.deltaTime;
            if(select4)
                UI04.SetActive(true);  
            else
                UI04_2.SetActive(true);
        }

        if (hit.collider.gameObject.tag == "sphere05")
        {
            time04 += Time.deltaTime;
            if(select5)
                UI05.SetActive(true);  
            else
                UI05_2.SetActive(true);
        }

        if (hit.collider.gameObject.tag == "sphere06")
        {
            UI06.SetActive(true);
            time05 += Time.deltaTime;
        }
    }
}