using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyEvent : MonoBehaviour
{
    public GameObject destroyCamera;
    CharacterState state;
    public GameObject destoryObject;
    public GameObject snowEffect;

    private void Awake()
    {
        destroyCamera.SetActive(false);
    }
    private void Start()
    {
        //if (destroyCamera == null || destoryObject == null)
        //    return;
        state = FindObjectOfType<CharacterState>();
    }
    private void OnDestroy()
    {
        if(gameObject.name == "MissionBoat")
        {
            Destroy(snowEffect);
            destroyCamera.SetActive(true);
            state.basicMSpeed += 1f;
            destoryObject.SendMessage("ObjectDestroy");

        }
        else
        {
            snowEffect.SetActive(true);
            destroyCamera.SetActive(true);
            state.basicMSpeed += 1f;
            destoryObject.SendMessage("ObjectDestroy");
        }
    }
}
