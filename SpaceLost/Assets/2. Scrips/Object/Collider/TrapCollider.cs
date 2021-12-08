using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCollider : MonoBehaviour
{
    public GameObject[] wall;
    public bool trapOpen = true;
    public bool trapDestory = false;
    private void Update()
    {
        if(!trapOpen)
        {
            for(int ii = 0; ii<wall.Length; ii++)
            {
                wall[ii].SetActive(true);
            }
        }
        if (trapOpen)
        {
            for (int ii = 0; ii < wall.Length; ii++)
            {
                wall[ii].SetActive(false);

            }
        }

        if(trapDestory)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && trapOpen)
        {
            trapOpen = false;
        }       
    }
}
