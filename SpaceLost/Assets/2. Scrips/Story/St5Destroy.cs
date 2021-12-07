using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class St5Destroy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
