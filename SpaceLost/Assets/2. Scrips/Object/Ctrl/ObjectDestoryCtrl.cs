using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestoryCtrl : MonoBehaviour
{
    private void ObjectDestroy()
    {
        StartCoroutine("DelayDestroy");
    }

    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
    }
}
