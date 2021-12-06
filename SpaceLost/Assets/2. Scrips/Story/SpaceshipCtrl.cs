using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipCtrl : MonoBehaviour
{
    public float speedX;
    public float speedZ;

    public GameObject explosion;


    private void Update()
    {
        gameObject.transform.position = new Vector3(transform.position.x - speedX*Time.deltaTime, transform.position.y, transform.position.z + speedZ*Time.deltaTime);
    }

    private void OnDestroy()
    {
        if (explosion == null) { return; }
        explosion.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
