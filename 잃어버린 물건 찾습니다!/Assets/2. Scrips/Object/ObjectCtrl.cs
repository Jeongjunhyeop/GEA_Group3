using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCtrl : MonoBehaviour
{
    ObjectStatus status; //������Ʈ ����

    public GameObject[] dropItemPrefab; //������ ����������
    private MeshRenderer meshRenderer;

    int objNum = 0;

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
        RandomValue();
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
    public int RandomValue() //basic �ڽ� ������ Ȯ�� ���
    {
        int randomValue = Random.Range(0, 100);


        if (randomValue >= 0 && randomValue < 5) //5%
        {
            objNum = 0; //TimeUp
            return objNum;
        }
        if (randomValue >= 5 && randomValue < 10) //5%
        {
            objNum = 1; //SpeedUp
            return objNum;
        }
        if (randomValue >= 10 && randomValue < 15) //5%
        {
            objNum = 2; //SpeedDown
            return objNum;
        }
        if (randomValue >= 25 && randomValue < 100) //75%
        {
            objNum = 3; //Empty
            return objNum;
        }
        if (randomValue >= 15 && randomValue < 20) //5%
        {
            objNum = 4; //Nav
            return objNum;
        }
        if (randomValue >= 20 && randomValue < 25) //5%
        {
            objNum = 5; //Sheild
            return objNum;
        }
        if (randomValue == 100) //1%
        {
            objNum = 6; //Gear
            return objNum;
        }

        else
        {
            objNum = 3;
            return objNum;
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
        if ((gameObject.tag == "Box")) //�ڽ��ϰ��
        {
            GameObject dropItem = dropItemPrefab[objNum]; //������Ȯ�����
            Instantiate(dropItem, transform.position, Quaternion.identity); //�����ۼ�ȯ
        }
        else //�ڽ��� �ƴҰ��
        {
            GameObject dropItem = dropItemPrefab[Random.Range(0,dropItemPrefab.Length)];
            Instantiate(dropItem, transform.position, Quaternion.identity);
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
