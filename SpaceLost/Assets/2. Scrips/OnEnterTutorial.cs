using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterTutorial : MonoBehaviour
{
    public GameObject KeyTutorial;
    public bool OnEnter = false;

    private void Awake()
    {
        if(KeyTutorial != null)
        {
            KeyTutorial.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(OnEnter);
        if(other.tag == "Player")
        {
            if (!OnEnter)
            {
                OnEnter = true;
                Debug.Log(OnEnter);
                KeyTutorial.SetActive(true);
            }
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (OnEnter)
            {
                KeyTutorial.SetActive(false);
            }
        }
        
    }
        
}
