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
        Empty, //��
        Nav, //�̼Ǿ����� ��ġ ǥ��
        Sheild, //���� 1ȸ ����
        MissionObject, //�̼Ǿ�����
    };
    public ItemKind kind;
    [SerializeField]
    private float rotateSpeed; //������ ȸ���ӵ�

    private void Start()
    {
        if(kind == ItemKind.Empty)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World); //������ ȸ��

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") //�÷��̾�� �浹��
        {
            Destroy(gameObject); //�����ۻ���

            switch(kind)
            {
                case ItemKind.TimeUp:
                    print("���ѽð�����");
                    break;
                case ItemKind.SpeedUp:
                    print("�÷��̾��̵��ӵ�����");
                    break;
                case ItemKind.SpeedDown:
                    print("���̵��ӵ�����");
                    break;
                case ItemKind.MissionObject:
                    print("�̼Ǿ�����ȹ��");
                    break;
                case ItemKind.Nav:
                    print("�̼Ǿ�������ġǥ��");
                    break;
                case ItemKind.Sheild:
                    print("������ 1ȸ ����");
                    break;
            }
        }
    }
}
