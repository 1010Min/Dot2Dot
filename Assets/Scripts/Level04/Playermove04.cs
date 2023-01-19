using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Playermove04 : MonoBehaviour
{
    private Transform tr;
    private Ray ray;
    private RaycastHit hit;
    public float dist = 10.0f;

    public float time01 = 0.0f; // 응시 시간
    public float time02 = 0.0f;
    public float time03 = 0.0f;
    public float time04 = 0.0f;
    public float time05 = 0.0f;

    public GameObject player;
    public GameObject sphere02; // 눈사람
    public GameObject sphere03;
    public GameObject sphere04;
    public GameObject sphere05;
    public GameObject sphere06;

    public GameObject UI02; // 눈사람 상단 UI(Check)
    public GameObject UI03;
    public GameObject UI04;
    public GameObject UI05;
    public GameObject UI06;

    public GameObject UI021; // 눈사람 상단 UI(Wait)
    public GameObject UI031;
    public GameObject UI041;
    public GameObject UI051;

    public GameObject Success; // 성공 메세지 Panel
    public GameObject Fail; // 실패 메세지 Panel

    public GameObject cube01; // 철길
    public GameObject cube02;
    public GameObject cube03;
    public GameObject cube04;
    public GameObject cube05;
    public GameObject cube06;
    public GameObject cube07;

    public GameObject moza02; // 눈사람 모자
    public GameObject moza03;
    public GameObject moza04;
    public GameObject moza05;
    public GameObject moza06;

    // 지나온 눈사람으로 되돌아가거나 
    // 철길로 연결되지 않은 눈사람으로 이동하지 못하도록 제한하는 변수
    private bool start = true;  
    private bool arrive01 = false;
    private bool arrive02 = false;
    private bool arrive03 = false;
    private bool arrive04 = false;
    private bool arrive05 = false;
    private bool a01 = false;
    private bool a02 = false;
    private bool a03 = false;
    private bool a04 = false;
    private bool no02 = false;
    private bool no03 = false;
    private bool no04 = false;
    private bool no05 = false;

    void Start()
    {
        StageManager.isStopped = true;
        tr = GetComponent<Transform>();
        UI02.SetActive(false);
        UI03.SetActive(false);
        UI04.SetActive(false);
        UI05.SetActive(false);
        UI06.SetActive(false);
        UI021.SetActive(false);
        UI031.SetActive(false);
        UI041.SetActive(false);
        UI051.SetActive(false);
        Success.SetActive(false);
        Fail.SetActive(false);
    }

    void Update()
    {
        // 눈사람 상단 UI(Check)가 항상 플레이어 시선 방향을 향하도록
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

        Vector3 vec06 = player.GetComponent<Transform>().position - UI06.GetComponent<Transform>().position;
        vec06.Normalize();
        Quaternion q06 = Quaternion.LookRotation(vec06);
        UI06.GetComponent<Transform>().rotation = q06;

        // 눈사람 상단 UI(Wait)가 항상 플레이어 시선 방향을 향하도록
        Vector3 vec07 = player.GetComponent<Transform>().position - UI02.GetComponent<Transform>().position;
        vec07.Normalize();
        Quaternion q07 = Quaternion.LookRotation(vec07);
        UI021.GetComponent<Transform>().rotation = q07;

        Vector3 vec08 = player.GetComponent<Transform>().position - UI03.GetComponent<Transform>().position;
        vec08.Normalize();
        Quaternion q08 = Quaternion.LookRotation(vec08);
        UI031.GetComponent<Transform>().rotation = q08;

        Vector3 vec09 = player.GetComponent<Transform>().position - UI04.GetComponent<Transform>().position;
        vec09.Normalize();
        Quaternion q09 = Quaternion.LookRotation(vec09);
        UI041.GetComponent<Transform>().rotation = q09;

        Vector3 vec10 = player.GetComponent<Transform>().position - UI05.GetComponent<Transform>().position;
        vec10.Normalize();
        Quaternion q10 = Quaternion.LookRotation(vec10);
        UI051.GetComponent<Transform>().rotation = q10;

        // 플레이어 Raycast
        ray = new Ray(tr.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * dist, Color.red);

        // 눈사람 상단 UI 설정
        UI02.SetActive(false);
        UI03.SetActive(false);
        UI04.SetActive(false);
        UI05.SetActive(false);
        UI06.SetActive(false);
        UI021.SetActive(false);
        UI031.SetActive(false);
        UI041.SetActive(false);
        UI051.SetActive(false);

        if (Physics.Raycast(ray, out hit, dist, 1 << 9))
        {
            // 플레이어 이동 로직 구현
            if (((time01 >= 2.0f && start)||(time01 >= 2.0f && arrive02)) && !no02)
            {
                arrive01 = true; arrive02 = false; start = false; arrive05 = false; arrive04 = false; arrive03 = false;
            }
            if (((time02 >= 2.0f && arrive01) || (time02 >= 2.0f && start)) && !no03)
            {
                arrive02 = true; arrive01 = false; arrive03 = false; arrive04 = false; start = false; arrive05 = false;
            }
            if (((time03 >= 2.0f && arrive04) || (time03 >= 2.0f && arrive02)) && !no04)
            {
                arrive03 = true; arrive02 = false; arrive01 = false; arrive04 = false; arrive05 = false;  start = false;
            }
            if (((time04 >= 2.0f && arrive03) || (time04 >= 2.0f && arrive02)) && !no05)
            {
                arrive04 = true; arrive03 = false; arrive02 = false; arrive01 = false; start = false; arrive05 = false;
            }
            if (time05 >= 2.0f && arrive04)
            {
                arrive05 = true; arrive04 = false; arrive03 = false; arrive02 = false; arrive01 = false; start = false;
            }

            GazeButton(); // 눈사람 응시 시간 증가/초기화 및 눈사람 상단 UI 설정

            // 플레이어 이동 이벤트 처리 및 플레이어 이동 로직 구현
            Color color;
            ColorUtility.TryParseHtmlString("#957745", out color);
            if (time01 >= 2.0f && start)
            {
                cube01.GetComponent<Renderer>().material.color = color;
                moza02.GetComponent<Renderer>().material.color = Color.blue;
                a01 = true;
            }
            if (arrive05)
            {
                cube02.GetComponent<Renderer>().material.color = color;
                moza06.GetComponent<Renderer>().material.color = Color.blue;
                
            }
            if (time04 >= 2.0f && arrive02)
            {
                cube03.GetComponent<Renderer>().material.color = color;
                moza05.GetComponent<Renderer>().material.color = Color.blue;
                a04 = true;
            }
            if (time03 >= 2.0f && arrive02)
            {
                cube04.GetComponent<Renderer>().material.color = color;
                moza04.GetComponent<Renderer>().material.color = Color.blue;
                a03 = true;
                no03 = true;
            }
            if (time04 >= 2.0f && arrive03)
            {
                cube05.GetComponent<Renderer>().material.color = color;
                moza05.GetComponent<Renderer>().material.color = Color.blue;
                a04 = true;
                no04 = true;
            }
            if (time03 >= 2.0f && arrive04)
            {
                cube05.GetComponent<Renderer>().material.color = color;
                moza04.GetComponent<Renderer>().material.color = Color.blue;
                a03 = true;
                no05 = true;
            }
            if (time02 >= 2.0f && arrive01)
            {
                no02 = true;
                cube06.GetComponent<Renderer>().material.color = color;
                moza03.GetComponent<Renderer>().material.color = Color.blue;
                a02 = true;
            }
            if (time01 >= 2.0f && arrive02)
            {
                cube06.GetComponent<Renderer>().material.color = color;
                moza02.GetComponent<Renderer>().material.color = Color.blue;
                a01 = true;
                no03 = true;
            }
            if (time02 >= 2.0f && start)
            {
                cube07.GetComponent<Renderer>().material.color = color;
                moza03.GetComponent<Renderer>().material.color = Color.blue;
                a02 = true;
            }

            // 스테이지 성공/실패 여부 판단
            if ((cube01.GetComponent<Renderer>().material.color == color) && (cube06.GetComponent<Renderer>().material.color == color)
                && (cube04.GetComponent<Renderer>().material.color == color) && (cube05.GetComponent<Renderer>().material.color == color)
                && (cube02.GetComponent<Renderer>().material.color == color))
            {
                Success.SetActive(true);
            }
            if ((cube06.GetComponent<Renderer>().material.color == color)&&(cube07.GetComponent<Renderer>().material.color == color))
            {
                Fail.SetActive(true);
            }
            if ((cube07.GetComponent<Renderer>().material.color == color) && (cube03.GetComponent<Renderer>().material.color == color) 
                && (cube05.GetComponent<Renderer>().material.color == color))
            {
                Fail.SetActive(true);
            }
            if ((cube01.GetComponent<Renderer>().material.color == color) && (cube06.GetComponent<Renderer>().material.color == color) 
                && (cube03.GetComponent<Renderer>().material.color == color) && (cube05.GetComponent<Renderer>().material.color == color))
            {
                Fail.SetActive(true);
            }
            if ((cube07.GetComponent<Renderer>().material.color == color) && (cube04.GetComponent<Renderer>().material.color == color)
                && (cube05.GetComponent<Renderer>().material.color == color) && (cube02.GetComponent<Renderer>().material.color == color))
            {
                Fail.SetActive(true);
            }
            if ((cube07.GetComponent<Renderer>().material.color == color) && (cube03.GetComponent<Renderer>().material.color == color) 
                && (cube02.GetComponent<Renderer>().material.color == color))
            {
                Fail.SetActive(true);
            }
            if ((cube01.GetComponent<Renderer>().material.color == color) && (cube06.GetComponent<Renderer>().material.color == color)
                && (cube03.GetComponent<Renderer>().material.color == color) && (cube02.GetComponent<Renderer>().material.color == color))
            {
                Fail.SetActive(true);
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

        // 플레이어 이동 로직 구현
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

    void GazeButton() // 눈사람 응시 시간 증가/초기화 및 눈사람 상단 UI 설정
    {
        if (hit.collider.gameObject.tag == "sphere02")
        {
            if (a01)
                UI02.SetActive(true);
            else
                UI021.SetActive(true);
            time01 += Time.deltaTime;
        }
        if (hit.collider.gameObject.tag == "sphere03")
        {
            if (a02)
                UI03.SetActive(true);
            else
                UI031.SetActive(true);
            time02 += Time.deltaTime;
        }
        if (hit.collider.gameObject.tag == "sphere04")
        {
            if (a03)
                UI04.SetActive(true);
            else
                UI041.SetActive(true);
            time03 += Time.deltaTime;
        }
        if (hit.collider.gameObject.tag == "sphere05")
        {
            if (a04)
                UI05.SetActive(true);
            else
                UI051.SetActive(true);
            time04 += Time.deltaTime;
        }
        if (hit.collider.gameObject.tag == "sphere06")
        {
            UI06.SetActive(true);
            time05 += Time.deltaTime;
        }
    }
}