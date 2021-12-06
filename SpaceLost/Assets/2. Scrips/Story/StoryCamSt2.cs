using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryCamSt2 : MonoBehaviour
{
    public float speed;
    public Transform tomato;
    void Update()
    {
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
        RotateCam();
    }

    void RotateCam()
    {
        Vector3 dir = tomato.position - transform.position;

        transform.localRotation =
            Quaternion.Slerp(transform.localRotation,
            Quaternion.LookRotation(dir), 5 * Time.deltaTime);
    }
}
