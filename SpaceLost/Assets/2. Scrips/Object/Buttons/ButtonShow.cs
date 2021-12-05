using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonShow : MonoBehaviour
{
    public ButtonTogle hitBox;

    public GameObject ButtonOn;
    public GameObject ButtonOff;

    // Update is called once per frame
    void Update()
    {
        if (hitBox.isGreen)
        {
            ButtonOn.SetActive(true);
            ButtonOff.SetActive(false);
        }
        else
        {
            ButtonOff.SetActive(true);
            ButtonOn.SetActive(false);
        }
    }
}
