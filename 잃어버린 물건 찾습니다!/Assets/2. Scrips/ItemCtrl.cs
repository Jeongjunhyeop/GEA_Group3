using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour
{
    public enum ItemKind
    {
        TimeUp, //�����÷��̽ð� ����
        SpeedUp, //�÷��̾� �̵��ӵ� �Ͻ� ����
        SpeedDown, //�� �̵��ӵ� �Ͻ� ����
    };
    public ItemKind kind;
    public float rotateSpeed; //������ ȸ���ӵ�

    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World); //������ ȸ��

    }

    private void OnTriggerEnter(Collider other)
    {
        //�÷��̾� �浿ó��
    }
}
