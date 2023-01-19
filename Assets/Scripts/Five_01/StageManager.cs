using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public enum MoveType
    {
        WP,
        LOOK_AT,
        DAYDREAM
    }


    public float time = 0.0f;
    public MoveType moveType = MoveType.WP; // 이동 방식
    public float speed = 1.0f; //이동 속도
    public float damping = 13.0f; //회전속도

    public static Transform[] points;// 모든 웨이포인트를 저장할 배열

    private static Transform tr; // Transform 컴포넌트를 저장할 변수
    private static int nextIdx = 1; // 다음에 이동해야 할 위치 인덱스 변수

    private CharacterController cc;
    private Transform camTr;

    public static bool isStopped = true;

    void Start()
    {
        tr = GetComponent<Transform>();

        cc = GetComponent<CharacterController>();
        camTr = Camera.main.GetComponent<Transform>();

        GameObject wayPointGroup = GameObject.Find("WayPointGroup");

        if (wayPointGroup != null)
        {
            points = wayPointGroup.GetComponentsInChildren<Transform>();
        }
    }


    void Update()
    {
        if (isStopped) return;
        
        switch (moveType)
        {
            case MoveType.WP:
                
                MoveWayPoint();
                
                break;

            case MoveType.LOOK_AT:
                MoveLookAt(1);
                break;

            case MoveType.DAYDREAM:
                break;
        }
    }

    //웨이포인트 경로로 이동하는 로직
    public static void MoveWayPoint()
    {
        // 현재 위치에서 다음 웨이포인트로 향하는 벡터 계산
        Vector3 direction = points[nextIdx].position - tr.position;
        
        //산출된 벡터의 회전 각도를 쿼터니언 타입으로 산출
        Quaternion rot = Quaternion.LookRotation(direction);

        //현재 각도에서 회전해야 할 각도까지 부드럽게 회전 처리
        tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * 3.0f);
        //Debug.Log(nextIdx);

        if (nextIdx == 1) // 처음 구체로 다시 가려고 하면
            tr.Translate(Vector3.zero * Time.deltaTime * 1.0f); // 멈추기
            

        //전진 방향으로 이동 처리
        else{
            tr.Translate(Vector3.forward * Time.deltaTime * 1.0f);
            }
       
    }

    void MoveLookAt(int facing){
        Vector3 heading = camTr.forward;
        heading.y = 0.0f;
        Debug.DrawRay(tr.position, heading.normalized * 1.0f, Color.red);
        cc.SimpleMove(heading*speed*facing);
    }

     private void OnTriggerEnter(Collider coll)
    {
        //웨이포인트에 충돌 여부 판단
        if (coll.CompareTag("sphere"))
        {
            isStopped = true;
            // 맨 마지막 웨이포인트에 도달했을 때 처음 인덱스로 변경
            //nextIdx = (++nextIdx >= points.Length) ? 1 : nextIdx;
        }
        /*
        if (coll.CompareTag("sphere"))
        {
            //isStopped = true;
        }
        */
    }
    
}
