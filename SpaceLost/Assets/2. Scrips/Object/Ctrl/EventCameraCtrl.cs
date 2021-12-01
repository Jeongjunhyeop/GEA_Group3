using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCameraCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ActiveCamera");
    }

    IEnumerator ActiveCamera()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }
}
