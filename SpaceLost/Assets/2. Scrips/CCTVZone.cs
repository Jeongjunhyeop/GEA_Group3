using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVZone : MonoBehaviour
{
    float inTime = 0.0f;
    public float maxTime = 3.0f;

    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            inTime += Time.deltaTime;
            if(inTime > maxTime)
            {
                other.SendMessage("Respawn");
                inTime = 0.0f;
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        inTime = 0.0f;
    }
}
