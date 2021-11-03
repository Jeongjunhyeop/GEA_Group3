using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCtrl : MonoBehaviour
{
    [Header("확률")]
    public int[] percentage = {
       74, //꽝
       5, //이동속도 증가
       5, //적 이동속도 일시 감소
       5, //게임플레이시간
       5, //공격 1회 막기
       5, //미션아이템 위치 표시
       1, //미션 아이템
    };
    [Header("프리팹")]
    public GameObject[] dropItemPrefab; //아이템 프리팹저장

    ObjectStatus status; //오브젝트 상태
    private MeshRenderer meshRenderer;

    int total;
    int randomNumber;


    enum State
    {
        Nomal, //기본상태
        Destroy, //파괴상태
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
    void dropItem() //오브젝트 파괴시 아이템 떨어짐
    {
        if (dropItemPrefab.Length == 0)//아이템프리팹이 안 들어가있을경우
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
    void ObjDestroy() //오브젝트 파괴시
    {
        dropItem(); //아이템떨굼
        Destroy(gameObject); //오브젝트 삭제
    }

    void Damage()
    {
        status.hp -= 1;
        //print("상자 HP -1 ");

        if (status.hp == 0 && !(gameObject.tag == "Explosive"))
        {
            ChangeState(State.Destroy);
            //print("상자부서짐");

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

        ChangeState(State.Destroy);
        
    }

    IEnumerator DestroySwitch()
    {
        yield return new WaitForSeconds(10f); //스위치가 다시 올라오기까지 걸리는 시간
        ChangeState(State.Destroy);
    }
}
