using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class St1MiniMapOff : MonoBehaviour
{
    //스테이지1전용 다른 스크립트랑 포지션이 안맞음
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
        offObj.transform.position = new Vector3(transform.position.x, offObj.transform.position.y, transform.position.z);

    }
}
