using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCtrl : MonoBehaviour
{
    [Header("확률(%)")]
    public int[] percentage = {
       40, //꽝
       30, //이동속도 증가
       20, //적 이동속도 일시 감소
       10, //게임플레이시간
    };
    [SerializeField]
    private int total;

    [Header("프리팹")]
    public GameObject[] dropItemPrefab; //아이템 프리팹저장

    CharacterState playerState;
    ObjectStatus status; //오브젝트 상태
    private MeshRenderer meshRenderer;
    private int randomNumber;

    public static int crashobject;

    private FinishPoint FinishPoints;

    enum State
    {
        Nomal, //기본상태
        Destroy, //파괴상태
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
    void dropItem() //오브젝트 파괴시 아이템 떨어짐
    {
        if (dropItemPrefab.Length == 0)//아이템프리팹이 안 들어가있을경우
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
    void ObjDestroy() //오브젝트 파괴시
    {
        dropItem(); //아이템떨굼
        Destroy(gameObject); //오브젝트 삭제
        

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
        //1초

        meshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        meshRenderer.material.color = Color.white;
        yield return new WaitForSeconds(0.5f);
        //1초

        meshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        meshRenderer.material.color = Color.white;
        yield return new WaitForSeconds(0.5f);
        //1초
        GameObject.Find("SoundController").GetComponent<SoundControl>().Explosion();
        ChangeState(State.Destroy);
        
    }
}
