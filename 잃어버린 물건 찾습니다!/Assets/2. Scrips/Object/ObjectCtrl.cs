using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCtrl : MonoBehaviour
{
    ObjectStatus status; //오브젝트 상태

    public GameObject[] dropItemPrefab; //아이템 프리팹저장
    private MeshRenderer meshRenderer;

    int objNum = 0;

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
    public int RandomValue() //basic 박스 아이템 확률 계산
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
    void dropItem() //오브젝트 파괴시 아이템 떨어짐
    {
        if (dropItemPrefab.Length == 0)//아이템프리팹이 안 들어가있을경우
            return;
        if ((gameObject.tag == "Box")) //박스일경우
        {
            GameObject dropItem = dropItemPrefab[objNum]; //아이템확률계산
            Instantiate(dropItem, transform.position, Quaternion.identity); //아이템소환
        }
        else //박스가 아닐경우
        {
            GameObject dropItem = dropItemPrefab[Random.Range(0,dropItemPrefab.Length)];
            Instantiate(dropItem, transform.position, Quaternion.identity);
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
