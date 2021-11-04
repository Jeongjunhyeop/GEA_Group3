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
        door.count += 1; //��ư ���������� +1;
        //door.isSwitchPush = true;
    }
    private void OnDestroy() //����ġ �ı� �Ǹ� �ٽ� -1;
    {
        door.count -= 1;
    }
}
