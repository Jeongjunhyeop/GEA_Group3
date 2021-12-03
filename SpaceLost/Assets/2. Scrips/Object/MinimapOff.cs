using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapOff : MonoBehaviour
{
    public GameObject offObj;
    void Off()
    {
        offObj.SetActive(false);
    }

    void MinimapOn()
    {
        offObj.SetActive(true);
    }

    private void OnEnable()
    {
        offObj.transform.position = gameObject.transform.position;
    }

}
