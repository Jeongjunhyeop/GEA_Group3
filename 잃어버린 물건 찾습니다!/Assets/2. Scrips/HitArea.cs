using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitArea : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //���߿� ���ݻ��¿� ���� ��ũ��Ʈ ��������
        transform.SendMessage("Damage");

    }
}
