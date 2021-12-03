using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target; //ī�޶� �����ϴ� ���

    private void Awake()
    {

    }

    void Update()
    {
        //target�� �������� ������ ���� x
        if (target == null) return;
    }

    private void LateUpdate()
    {
        //target�� �������� ������ ���� ���� �ʴ´�.
        if (target == null) return;


        transform.position = transform.rotation * new Vector3(0, 0, -10) + target.position;



        Vector3 lookPosition = target.position + Vector3.zero;


    }
}
