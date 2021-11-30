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
                other.SendMessage("Explosion");
                break;
            case "Player":
                other.SendMessage("Exploded");
                break;
            case "Enemy":
                other.SendMessage("explosionDamage");
                break;

        }
    }

    IEnumerator Bomb()
    {
        GetComponent<Collider>().enabled = true;
        yield return new WaitForSecondsRealtime(2.0f);
        Destroy(gameObject);
    }

}
