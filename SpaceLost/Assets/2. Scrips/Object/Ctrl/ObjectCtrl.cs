using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCtrl : MonoBehaviour
{
    [Header("Ȯ��")]
    public int[] percentage = {
       35, //��
       25, //�̵��ӵ� ����
       15, //�� �̵��ӵ� �Ͻ� ����
       10, //�����÷��̽ð�
       8, //���� 1ȸ ����
       5, //�̼Ǿ����� ��ġ ǥ��
       2, //�̼� ������
    };
    [SerializeField]
    private int total;

    [Header("������")]
    public GameObject[] dropItemPrefab; //������ ����������

    ObjectStatus status; //������Ʈ ����
    private MeshRenderer meshRenderer;
    private int randomNumber;


    enum State
    {
        Nomal, //�⺻����
        Destroy, //�ı�����
    };

    State state = State.Nomal;
    State nextState = State.Nomal;

    private void Start()
    {
        status = GetComponent<ObjectStatus>();
        meshRenderer = GetComponent<MeshRenderer>();
        foreach (var item in percentage)
        {
            total += item;

        }
    }

    private void Update()
    {
        switch (state)
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
                case State.Nomal:
                    break;
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


        randomNumber = Random.Range(0, total);

        for (int i = 0; i < percentage.Length; i++)
        {
            if (randomNumber <= percentage[i])
            {
                GameObject dropItem = dropItemPrefab[i];
                Instantiate(dropItem, transform.position, transform.rotation);
                return;
            }
            else
            {
                randomNumber -= percentage[i];
            }
        }
    }
    void ObjDestroy() //������Ʈ �ı���
    {
        dropItem(); //�����۶���
        Destroy(gameObject); //������Ʈ ����

    }

    void Damage()
    {
        status.hp -= 2;

        if (status.hp <= 0 && !(gameObject.tag == "Explosive"))
        {
            status.hp = 0;
            ChangeState(State.Destroy);


        }
        if (status.hp <= 0 && gameObject.tag == "Explosive")
        {
            status.hp = 0;
            StartCoroutine("DestroyBomb");
        }

    }

    IEnumerator DestroyBomb()
    {

        meshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        meshRenderer.material.color = Color.white;
        yield return new WaitForSeconds(0.5f);
        //1��

        meshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        meshRenderer.material.color = Color.white;
        yield return new WaitForSeconds(0.5f);
        //1��

        meshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        meshRenderer.material.color = Color.white;
        yield return new WaitForSeconds(0.5f);
        //1��

        ChangeState(State.Destroy);
        
    }
}
