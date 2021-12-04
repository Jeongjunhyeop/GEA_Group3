using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTest : MonoBehaviour
{
    ObjectStatus status;
    public GameObject doorA;

    private void OnEnable()
    {
        if (doorA == null) { return; }
        //doorA = GameObject.FindGameObjectWithTag("Door");
        status = GetComponent<ObjectStatus>();
        doorA.GetComponent<DoorTest>().count -= 1;
        
        //door.count += 1;
    }
    private void OnDestroy()
    {
        if (doorA == null) { return; }
        doorA.GetComponent<DoorTest>().count += 1;
    }


}
