using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour
{
    inGameUi gameUi;
    //현재 상태
    public bool isAttacking = false;
    public bool isHolding = false;
    public bool isJumping = false;
    public bool isGrogging = false;
    public bool onGround = false;

    //초기 속도
    public float basicMSpeed = 3f;
    //초기 점프력
    public float basicJPower = 5f;
    //초기 공격력
    public int basicATC = 1;

    //현재 속도
    public float moveSpeed = 3f;
    //현재 점프력
    public float jumpPower = 5f;
    //초기 공격력
    public int ATC = 1;
    public bool powerBoost = false;
    public bool speedBoost = false;
    public float speedBoostTime = 0.0f;

    //현재 들고있는 물건
    public GameObject grabbedThing = null;

    // Start is called before the first frame update
    void Start()
    {
        gameUi = FindObjectOfType<inGameUi>();
        //현재 속도와 점프력을 초기화
        moveSpeed = basicMSpeed;
        jumpPower = basicJPower;
        //현재 상태를 초기화
        grabbedThing = null;
        isHolding = false;
        onGround = false;
        isJumping = false;
        isGrogging = false;
    }

    // Update is called once per frame
    void Update()
    {
        //바닥 탐지ray 쏘기
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, new Color(1, 0, 1));
        //ray를 쏴서 맞은 오브젝트 탐지
        if (Physics.Raycast(transform.position, Vector3.down * 0.1f, 0.5f))
        {
            onGround = true;
        }
        if (speedBoostTime > 0.0f)
        {
            moveSpeed = 8.0f;
            speedBoostTime = Mathf.Max(speedBoostTime - Time.deltaTime, 0.0f);
        }
        else
        {
            moveSpeed = basicMSpeed;
        }
    }

    public void GetItem(ItemCtrl.ItemKind itemKind)
    {
        switch (itemKind)
        {
            case ItemCtrl.ItemKind.TimeUp:
                gameUi.limitTime += 5f;
                //게임플레이시간증가
                break;
            case ItemCtrl.ItemKind.SpeedUp:
                speedBoostTime += 5.0f;
                break;
            case ItemCtrl.ItemKind.SpeedDown:
                //적이동속도감소
                break;
        }

    }
}