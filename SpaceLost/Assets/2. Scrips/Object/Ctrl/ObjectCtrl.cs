using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCtrl : MonoBehaviour
{
    [Header("Ȯ��(%)")]
    public int[] percentage = {
       40, //��
       30, //�̵��ӵ� ����
       20, //�� �̵��ӵ� �Ͻ� ����
       10, //�����÷��̽ð�
    };
    [SerializeField]
    private int total;

    [Header("������")]
    public GameObject[] dropItemPrefab; //������ ����������

    CharacterState playerState;
    ObjectStatus status; //������Ʈ ����
    private MeshRenderer meshRenderer;
    private int randomNumber;

    public static int crashobject;

    private FinishPoint FinishPoints;

    enum State
    {
        Nomal, //�⺻����
        Destroy, //�ı�����
    };

    State state = State.Nomal;
    State nextState = State.Nomal;

    private void Start()
    {
        FinishPoints = GameObject.Find("FinishPoint").GetComponent<FinishPoint>();
        status = GetComponent<ObjectStatus>();
        meshRenderer = GetComponent<MeshRenderer>();
        foreach (var item in percentage)
        {
            total += item;

        }

        crashobject = 0;
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
        if (gameObject.tag == "Switch")
        {
            GameObject dropItem = dropItemPrefab[0];
            Instantiate(dropItem, transform.position, transform.rotation);
        }

        else
        {
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
    }
    void ObjDestroy() //������Ʈ �ı���
    {
        dropItem(); //�����۶���
        Destroy(gameObject); //������Ʈ ����
        

    }

    void Damage(AttackArea.AttackInfo attackInfo)
    {
        //status.hp -= 1;
        status.hp -= attackInfo.attackPower;

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

        if(status.hp<=0 && (gameObject.tag == "CrashObject"))
        {
            status.hp = 0;
            FinishPoints.CrashObject += 1;
            GameObject.Find("SoundController2").GetComponent<SoundControl2>().MissionUp();
            ChangeState(State.Destroy);

        }

    }
    void Explosion()
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
        GameObject.Find("SoundController").GetComponent<SoundControl>().Explosion();
        ChangeState(State.Destroy);
        
    }
}
