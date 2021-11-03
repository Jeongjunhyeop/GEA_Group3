using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCtrl : MonoBehaviour
{
    [Header("Ȯ��")]
    public int[] percentage = {
       74, //��
       5, //�̵��ӵ� ����
       5, //�� �̵��ӵ� �Ͻ� ����
       5, //�����÷��̽ð�
       5, //���� 1ȸ ����
       5, //�̼Ǿ����� ��ġ ǥ��
       1, //�̼� ������
    };
    [Header("������")]
    public GameObject[] dropItemPrefab; //������ ����������

    ObjectStatus status; //������Ʈ ����
    private MeshRenderer meshRenderer;

    int total;
    int randomNumber;


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

        if (gameObject.tag == "Switch")
        {
            StartCoroutine("DestroySwitch");
        }
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

        foreach (var item in percentage)
        {
            total += item;

        }
        randomNumber = Random.Range(0, total);

        for (int i = 0; i < percentage.Length; i++)
        {
            if (randomNumber <= percentage[i])
            {
                GameObject dropItem = dropItemPrefab[i];
                Instantiate(dropItem, transform.position, Quaternion.identity);
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
        status.hp -= 1;
        //print("���� HP -1 ");

        if (status.hp == 0 && !(gameObject.tag == "Explosive"))
        {
            ChangeState(State.Destroy);
            //print("���ںμ���");

        }
        if (status.hp == 0 && gameObject.tag == "Explosive")
        {
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

    IEnumerator DestroySwitch()
    {
        yield return new WaitForSeconds(10f); //����ġ�� �ٽ� �ö������� �ɸ��� �ð�
        ChangeState(State.Destroy);
    }
}
