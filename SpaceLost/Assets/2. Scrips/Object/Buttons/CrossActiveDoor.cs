using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossActiveDoor : MonoBehaviour
{
    public CrossActiveButton ConnectedCross;

    public GameObject DoorOpen;
    public GameObject DoorClose;

    // Update is called once per frame
    void Update()
    {
        DoorCtrl();
    }

    void DoorCtrl()
    {
        if (ConnectedCross.isGreen)
        {
            DoorOpen.SetActive(true);
            DoorClose.SetActive(false);
        }
        else
        {
            DoorOpen.SetActive(false);
            DoorClose.SetActive(true);
        }
    }
}
