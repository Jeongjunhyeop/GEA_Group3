using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroggingField : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                Debug.Log("Ready");
                StartCoroutine("Bomb", other);
                break;
        }
    }
    IEnumerator Bomb(Collider other)
    {
        yield return new WaitForSecondsRealtime(1.6f);
        Debug.Log("ON");
        other.SendMessage("Exploded");
    }

}
