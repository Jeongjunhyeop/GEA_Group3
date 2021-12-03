using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyEvent : MonoBehaviour
{
    public GameObject destroyCamera;
    CharacterState state;
    public GameObject destroyObject;
    public GameObject snowEffect;

    private void Awake()
    {
        state = FindObjectOfType<CharacterState>();
        destroyCamera.SetActive(false);
        if(destroyObject == null) { return; }

        if (destroyCamera == null) { return; }

        if (snowEffect == null) { return; }

    }
    private void OnDestroy()
    {
        if(gameObject.name == "MissionBoat")
        {
            snowEffect.SetActive(false);
            destroyCamera.SetActive(true);
            state.basicMSpeed += 1f;
            destroyObject.SendMessage("ObjectDestroy");

        }
        else
        {
            snowEffect.SetActive(true);
            destroyCamera.SetActive(true);
            state.basicMSpeed += 1f;
            destroyObject.SendMessage("ObjectDestroy");

        }
    }
}
