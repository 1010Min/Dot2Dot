using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class Five_01_MoveCtrl : MonoBehaviour
{
    //이동방식 열거형 변수 선언
    public enum MoveType
    {
        five_01,
        LOOK_AT,
        DAYDREAM
    }

    public MoveType moveType = MoveType.five_01; // 이동 방식
    public float speed = 1.0f; //이동 속도
    public float damping = 13.0f; //회전속도

    public Transform[] points;// 모든 웨이포인트를 저장할 배열

    private Transform tr; // Transform 컴포넌트를 저장할 변수
    private int nextIdx = 1; // 다음에 이동해야 할 위치 인덱스 변수

    void Start()
    {
        tr = GetComponent<Transform>();

        GameObject wayPointGroup = GameObject.Find("WayPointGroup");

        if (wayPointGroup != null)
        {
            points = wayPointGroup.GetComponentsInChildren<Transform>();
        }
    }

    void Update()
    {
        switch (moveType)
        {
            case MoveType.five_01:
                
                MoveWayPoint();
                
                break;

            case MoveType.LOOK_AT:
                break;

            case MoveType.DAYDREAM:
                break;
        }
    }

    //웨이포인트 경로로 이동하는 로직
    void MoveWayPoint()
    {
        // 현재 위치에서 다음 웨이포인트로 향하는 벡터 계산
        Vector3 direction = points[nextIdx].position - tr.position;
        
        //산출된 벡터의 회전 각도를 쿼터니언 타입으로 산출
        Quaternion rot = Quaternion.LookRotation(direction);

        //현재 각도에서 회전해야 할 각도까지 부드럽게 회전 처리
        tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * damping);
        
        if (nextIdx == 1) // 처음 구체로 다시 가려고 하면
            tr.Translate(Vector3.zero * Time.deltaTime * speed); // 멈추기

        //전진 방향으로 이동 처리
        else
            tr.Translate(Vector3.forward * Time.deltaTime * speed);
       
    }
    
    private void OnTriggerEnter(Collider coll)
    {
        //웨이포인트에 충돌 여부 판단
        if (coll.CompareTag("five_01"))
        {
            // 맨 마지막 웨이포인트에 도달했을 때 처음 인덱스로 변경
            nextIdx = (++nextIdx >= points.Length) ? 1 : nextIdx;
        }
    }

}
