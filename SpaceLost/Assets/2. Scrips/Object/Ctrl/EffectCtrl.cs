using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCtrl : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("DestroyEffect");
    }
    IEnumerator DestroyEffect()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
}
