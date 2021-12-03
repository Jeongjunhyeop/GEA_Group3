using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target; //카메라가 추적하는 대상

    private void Awake()
    {

    }

    void Update()
    {
        //target이 존재하지 않으면 실행 x
        if (target == null) return;
    }

    private void LateUpdate()
    {
        //target이 존재하지 않으면 실행 하지 않는다.
        if (target == null) return;


        transform.position = transform.rotation * new Vector3(0, 0, -10) + target.position;



        Vector3 lookPosition = target.position + Vector3.zero;


    }
}
