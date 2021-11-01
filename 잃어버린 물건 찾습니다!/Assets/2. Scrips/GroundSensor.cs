using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    bool isOnGround = false;

    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enter!");
        if(collision.gameObject.layer == 9)
        {
            isOnGround = true;
        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        isOnGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isOnGround = false;
    }

    public bool onGround()
    {
        return isOnGround;
    }
}
