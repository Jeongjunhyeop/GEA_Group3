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


    }
    private void OnDestroy()
    {
        if (gameObject.name == "MissionBoat")
        {
            if (destroyObject == null) { return; }
            if (destroyCamera == null) { return; }
            if (snowEffect == null) { return; }
            snowEffect.SetActive(false);
            destroyCamera.SetActive(true);
            state.basicMSpeed += 1f;
            destroyObject.SendMessage("ObjectDestroy");

        }
        else
        {

            if (destroyObject == null) { return; }
            if (destroyCamera == null) { return; }
            if (snowEffect == null) { return; }
            snowEffect.SetActive(true);
            destroyCamera.SetActive(true);
            state.basicMSpeed += 1f;
            destroyObject.SendMessage("ObjectDestroy");

        }
    }
}
