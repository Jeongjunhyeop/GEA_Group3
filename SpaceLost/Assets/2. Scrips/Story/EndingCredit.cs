using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCredit : MonoBehaviour
{
    public GameObject text;
    public float textSpeed;
    void Update()
    {
        text.transform.position = new Vector3(text.transform.position.x, text.transform.position.y+1f*textSpeed, text.transform.position.z);
    }
}
