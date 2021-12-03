using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private void LateUpdate()
    {
        if (target == null) return;

        transform.position = transform.rotation * new Vector3(0, 0, -10) + target.position;
    }
}
