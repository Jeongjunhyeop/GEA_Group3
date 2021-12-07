using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVZone : MonoBehaviour
{
    float inTime = 0.0f;
    bool In = false;
    public float maxTime = 3.0f;
    public GameObject CCTVTuto;
    public GameObject Police_door;
    public GameObject DestroyCCTV;
    // Start is called before the first frame update
    private void Awake()
    {
        Police_door.SetActive(false);
        DestroyCCTV.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            inTime += Time.deltaTime;
            if(inTime > maxTime)
            {
                other.SendMessage("Respawn");
                if (!In)
                {
                    CCTVTuto.SetActive(true);
                    Police_door.SetActive(true);
                    DestroyCCTV.SetActive(true);
                    In = true;
                }
                inTime = 0.0f;
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        inTime = 0.0f;
    }
}
