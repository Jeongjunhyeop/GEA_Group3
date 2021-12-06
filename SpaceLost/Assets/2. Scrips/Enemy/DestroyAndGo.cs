using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndGo : MonoBehaviour
{
    CharacterState state;
    public GameObject[] ActiveObjects;

    private void Awake()
    {
        state = FindObjectOfType<CharacterState>();
        foreach (GameObject ActiveObject in ActiveObjects)
        {
            if (ActiveObjects != null)
            {
                ActiveObject.SetActive(false);
            }
        }
    }
    private void OnDestroy()
    {
        state.basicMSpeed += 1f;
        foreach (GameObject ActiveObject in ActiveObjects)
        {
            if(ActiveObjects != null)
            {
                ActiveObject.SetActive(true);
            }
            
        }


    }
}
