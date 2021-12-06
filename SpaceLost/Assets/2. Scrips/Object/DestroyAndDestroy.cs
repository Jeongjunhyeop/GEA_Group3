using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndDestroy : MonoBehaviour
{
    CharacterState state;
    public GameObject ActiveObject;

    private void OnDestroy()
    {
        if (ActiveObject != null)
        {
            ActiveObject.SetActive(false);
        }
    }
}
