using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCol : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("Bomb");

    }
    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "ObjHit":
                other.SendMessage("Damage");
                break;
            case "Switch":
                other.SendMessage("Damage");
                break;

            //case "Player":
            //case "Enemy":
            //    other.SendMessage("Grroging");
            //    break;

        }
    }

    IEnumerator Bomb()
    {
        GetComponent<Collider>().enabled = true;
        yield return new WaitForSecondsRealtime(3.0f);
        Destroy(gameObject);
    }

}