using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject[] ConnectedButtons;
    public int ButtonGreen = 0;

    public GameObject DoorOpen;
    public GameObject DoorClose;

    // Update is called once per frame
    void Update()
    {
        DoorCtrl();
    }

    public void ButtonSign(int var)
    {
        if (ButtonGreen < 0)
            ButtonGreen = 0;

        ButtonGreen += var;
    }

    void DoorCtrl()
    {
        if (ButtonGreen == ConnectedButtons.Length)
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
