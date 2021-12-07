using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodToma : MonoBehaviour
{
    public GameObject godToma;



    private void Start()
    {
        StartCoroutine("TransToma");
    }

    IEnumerator TransToma()
    {
        yield return new WaitForSeconds(11f);
        gameObject.SetActive(false);
        godToma.gameObject.SetActive(true);
    }
}
