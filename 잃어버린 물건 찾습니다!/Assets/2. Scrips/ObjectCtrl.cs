using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCtrl : MonoBehaviour
{
    ObjectStatus status; //������Ʈ ����

    public GameObject[] dropItemPrefab; //������ ����������

    enum State
    {
        Nomal, //�⺻����
        Attack, //���ݸ��, �Ŀ� ��������
        Destroy, //�ı�����
    };

    State state = State.Nomal;
    State nextState = State.Nomal;

    private void Start()
    {
        status = GetComponent<ObjectStatus>();
    }

    private void Update()
    {
        switch(state)
        {
            case State.Nomal:
                break;

            case State.Destroy:
                ObjDestroy();
                break;
        }
        if (state != nextState)
        {
            state = nextState;
            switch (state)
            {
                case State.Destroy:
                    ObjDestroy();
                    break;
            }
        }
    }
    void ChangeState(State nextState)
    {
        this.nextState = nextState;
    }
    void dropItem() //������Ʈ �ı��� ������ ������
    {
        if (dropItemPrefab.Length == 0)//�������������� �� ���������
            return;

        GameObject dropItem = dropItemPrefab[Random.Range(0, dropItemPrefab.Length)]; //���� Ȯ�� ���߿� ���濹��
        Instantiate(dropItem, transform.position, Quaternion.identity); //�����ۼ�ȯ
    }
    void ObjDestroy() //������Ʈ �ı���
    {
        dropItem(); //�����۶���
        Destroy(gameObject); //������Ʈ ����
    }

    void Damage()
    {
        status.Hp -= 1;
        print("���� HP -1 ");

        if (status.Hp == 0)
        {
            ChangeState(State.Destroy);
            print("���ںμ���");
        }
    }
}
