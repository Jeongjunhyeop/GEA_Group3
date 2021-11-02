using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCtrl : MonoBehaviour
{
    ObjectStatus status; //오브젝트 상태

    public GameObject[] dropItemPrefab; //아이템 프리팹저장

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

        GameObject dropItem = dropItemPrefab[Random.Range(0, dropItemPrefab.Length)]; //랜덤 확률 나중에 변경예정
        Instantiate(dropItem, transform.position, Quaternion.identity); //아이템소환
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

        if (status.hp == 0)
        {
            ChangeState(State.Destroy);
            //print("상자부서짐");
        }
    }
}
