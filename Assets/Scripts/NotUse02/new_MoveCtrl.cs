using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class new_MoveCtrl : MonoBehaviour
{
    public enum MoveType{
        WAY_POINT, LOOK_AT, DAYDREAM
    }

    public MoveType moveType = MoveType.WAY_POINT;
    public float speed = 10.0f;
    public float damping = 3.0f;
    public Transform[] points;
    public Transform tr;
    private CharacterController cc;
    private Transform camTr;
    private int nextIdx = 1;
    public static bool isStopped = false;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        cc = GetComponent<CharacterController>();
        camTr = Camera.main.GetComponent<Transform>();
        GameObject wayPointGroup = GameObject.Find("WayPointGroup");

        if(wayPointGroup != null){
            points = wayPointGroup.GetComponentsInChildren<Transform>();
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isStopped) return;

        switch(moveType){

            case MoveType.WAY_POINT:
            MoveWayPoint();
            break;

            case MoveType.LOOK_AT:
            MoveLookAt(1);
            break;

            case MoveType.DAYDREAM:
            break;
        }
    }

    void MoveWayPoint(){
        Vector3 direction = points[nextIdx].position - tr.position;
        Quaternion rot = Quaternion.LookRotation(direction);
        tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime*damping);
        //tr.Translate(Vector3.forward * Time.deltaTime * speed);
            
         if (nextIdx == (points.Length-1)){
            tr.Translate(Vector3.zero * Time.deltaTime * speed);
         }
        //전진 방향으로 이동 처리
        else{
            tr.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }

    void MoveLookAt(int facing){
        Vector3 heading = camTr.forward;
        heading.y = 0.0f;
        Debug.DrawRay(tr.position, heading.normalized*1.0f, Color.red);
        cc.SimpleMove(heading*speed*facing);
    }

   private void OnTriggerEnter(Collider coll){

        if(coll.CompareTag("WAY_POINT")){
            nextIdx = (++nextIdx >= points.Length) ? points.Length-1 : nextIdx;
        }
    }
}

