using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    CharacterState state;

    private void Awake()
    {
        state = GetComponentInParent<CharacterState>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car")
        {
            Debug.Log("Car hit!");
            state.SendMessage("Respawn");
        }
        if (other.tag == "Respawn")
        {
            Debug.Log("RespawnUpdate!");
            state.RespawnPoint = other.transform;
        }
    }
}
