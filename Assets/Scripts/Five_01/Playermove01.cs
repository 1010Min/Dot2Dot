using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Playermove01 : MonoBehaviour
{
    private Transform tr;
    private Ray ray;
    private RaycastHit hit;
    public float dist = 10.0f;

    public float time01 = 0.0f;
    public float time02 = 0.0f;
    public float time03 = 0.0f;
    public float time04 = 0.0f;

    public GameObject player;
    public GameObject sphere02;
    public GameObject sphere03;
    public GameObject sphere04;
    public GameObject sphere05;

    public GameObject on;
    public GameObject off;

    public GameObject UI02;
    public GameObject UI03;
    public GameObject UI04;
    public GameObject UI05;
    public GameObject UI02_2;
    public GameObject UI03_2;
    public GameObject UI04_2;

    public GameObject moza02;
    public GameObject moza03;
    public GameObject moza04;
    public GameObject moza05;

    public GameObject cube01;
    public GameObject cube02;
    public GameObject cube03;
    public GameObject cube04;

    private bool start = true;
    private bool arrive01 = false;
    private bool arrive02 = false;
    private bool arrive03 = false;
    private bool arrive04 = false;

    private bool select2 = false;
    private bool select3 = false;
    private bool select4 = false;

    public GameObject Success;

    void Start()
    {
        tr = GetComponent<Transform>();
        UI02.SetActive(false);
        UI03.SetActive(false);
        UI04.SetActive(false);
        UI05.SetActive(false);
        UI02_2.SetActive(false);
        UI03_2.SetActive(false);
        UI04_2.SetActive(false);

        Success.SetActive(false);
    }

    void Update()
    {
        Vector3 vec02 = player.GetComponent<Transform>().position - UI02.GetComponent<Transform>().position;
        vec02.Normalize();
        Quaternion q02 = Quaternion.LookRotation(vec02);
        UI02.GetComponent<Transform>().rotation = q02;

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

        ray = new Ray(tr.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * dist, Color.red);
        UI02.SetActive(false);
        UI03.SetActive(false);
        UI04.SetActive(false);
        UI05.SetActive(false);
        UI02_2.SetActive(false);
        UI03_2.SetActive(false);
        UI04_2.SetActive(false);

        if (Physics.Raycast(ray, out hit, dist, 1 << 9))
        {
            Color color;
            ColorUtility.TryParseHtmlString("#957745", out color);

            if (time01 >= 2.0f)
            {
                arrive01 = true;
                moza02.GetComponent<Renderer>().material.color = Color.blue;
                cube01.GetComponent<Renderer>().material.color = color;
                select2 = true;
            }

            if (time02 >= 2.0f && arrive01)
            {
                arrive02 = true; arrive01 = false;
                moza03.GetComponent<Renderer>().material.color = Color.blue;
                cube02.GetComponent<Renderer>().material.color = color;
                select3 = true;
            }

            if(time03 >= 2.0f && arrive02)
            {
                arrive03 = true; arrive02 = false; arrive01 = false;
                moza04.GetComponent<Renderer>().material.color = Color.blue;
                cube03.GetComponent<Renderer>().material.color = color;
                select4 = true;
            }

            if(time04 >= 2.0f && arrive03)
            {
                arrive04 = true; arrive03 = false; arrive02 = false; arrive01 = false;
                cube04.GetComponent<Renderer>().material.color = color;
                moza05.GetComponent<Renderer>().material.color = Color.blue;
            }

            GazeButton();

            if ((cube01.GetComponent<Renderer>().material.color == color) && (cube02.GetComponent<Renderer>().material.color == color)
                && (cube03.GetComponent<Renderer>().material.color == color) && (cube04.GetComponent<Renderer>().material.color == color))
            {
                Success.SetActive(true);
            }
        }
        else
        {
            time01 = 0.0f;
            time02 = 0.0f;
            time03 = 0.0f;
            time04 = 0.0f;
        }


        if (arrive01)
        {
            player.GetComponent<Transform>().position = Vector3.MoveTowards(player.GetComponent<Transform>().position, sphere02.GetComponent<Transform>().position, 0.08f);
        }

        if (arrive02)
        {
            player.GetComponent<Transform>().position = Vector3.MoveTowards(player.GetComponent<Transform>().position, sphere03.GetComponent<Transform>().position, 0.08f);
        }

        if (arrive03)
        {
            player.GetComponent<Transform>().position = Vector3.MoveTowards(player.GetComponent<Transform>().position, sphere04.GetComponent<Transform>().position, 0.08f);
        }

        if (arrive04)
        {
            player.GetComponent<Transform>().position = Vector3.MoveTowards(player.GetComponent<Transform>().position, sphere05.GetComponent<Transform>().position, 0.08f);
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

        if (hit.collider.gameObject.tag == "sphere03" && !arrive02)
        {
            time02 += Time.deltaTime;
            if(select3)
                UI03.SetActive(true);  
            else
                UI03_2.SetActive(true);
        }

        if (hit.collider.gameObject.tag == "sphere04" && !arrive03)
        {
            time03 += Time.deltaTime;
            if(select4)
                UI04.SetActive(true);  
            else
                UI04_2.SetActive(true);
        }

        if (hit.collider.gameObject.tag == "sphere05" && !arrive04)
        {
            UI05.SetActive(true);
            time04 += Time.deltaTime;
        }
    }
}