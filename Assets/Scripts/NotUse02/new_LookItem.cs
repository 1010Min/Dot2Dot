using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class new_LookItem : MonoBehaviour
{
    public void OnLookItemBox(bool isLookAt){
        Debug.Log(isLookAt);
        new_MoveCtrl.isStopped = isLookAt;
    }
}
