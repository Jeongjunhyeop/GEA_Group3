using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActivator : MonoBehaviour
{
    //public GameObject trapCollider;
    TrapCollider trapCollider;


    private void OnEnable()
    {
        trapCollider = FindObjectOfType<TrapCollider>();
    }

    private void OnDestroy()
    {

        trapCollider.trapOpen = true;
    }
}
