using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetExitZonePortal : MonoBehaviour
{
    public Transform portal;
    public GameObject PortalExitPoint;
    Vector3 pointposition;
    private void Awake()
    {
        if(PortalExitPoint != null)
        {
            pointposition = PortalExitPoint.transform.position;
        }
        else
        {
            pointposition = new Vector3(2.0f, 0.0f, 1.0f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            if(PortalExitPoint != null)
            {
                other.transform.position = pointposition;
            }
            else
            {
                other.transform.position = portal.transform.position + pointposition;
            }
            
        }
    }
}
