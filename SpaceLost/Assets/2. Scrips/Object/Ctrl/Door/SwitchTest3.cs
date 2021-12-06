using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTest3 : MonoBehaviour
{
    ObjectStatus status;
    public GameObject door;

    private void OnEnable()
    {
        door = GameObject.FindGameObjectWithTag("Door2");
        if (door == null) { return; }
        status = GetComponent<ObjectStatus>();
        door.GetComponent<DoorTest>().count += 1;

    }
    private void OnDestroy()
    {
        if (door == null) { return; }
        door.GetComponent<DoorTest>().count -= 1;
    }
}
