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

            //case "Player":
            //case "Enemy":
            //    other.SendMessage("Grroging");
            //    break;

        }
    }

    IEnumerator Bomb()
    {
        yield return new WaitForSeconds(3.0f);
        GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }

}
