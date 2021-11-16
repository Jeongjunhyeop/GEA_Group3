using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitArea : MonoBehaviour
{
    BoxCollider switchCollider;

    private void OnEnable()
    {
        switchCollider = GetComponent<BoxCollider>();
        StartCoroutine("Active");
        switchCollider.enabled = false;
    }
    void Damage()
    {
        transform.GetComponentInParent<ObjectCtrl>().SendMessage("Damage");

    }

    IEnumerator Active()
    {
        yield return new WaitForSeconds(0.5f);
        switchCollider.enabled = true;
    }
}
