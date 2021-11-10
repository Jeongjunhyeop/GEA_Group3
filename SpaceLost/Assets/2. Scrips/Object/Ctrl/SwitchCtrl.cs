using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCtrl : MonoBehaviour
{
    DoorCtrl door;
    ObjectStatus status;

    
    private void OnEnable()
    {
        door = FindObjectOfType<DoorCtrl>();
        status = GetComponent<ObjectStatus>();
        door.count += 1; //버튼 누를때마다 +1;
        //door.isSwitchPush = true;
    }
    private void OnDestroy() //스위치 파괴 되면 다시 -1;
    {
        door.count -= 1;
    }
}
