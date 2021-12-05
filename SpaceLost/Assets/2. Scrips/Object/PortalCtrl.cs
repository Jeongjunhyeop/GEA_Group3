using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCtrl : MonoBehaviour
{
    public Transform portal;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.position = portal.transform.position + new Vector3(2f, 0, 1f);
        }
    }
}
