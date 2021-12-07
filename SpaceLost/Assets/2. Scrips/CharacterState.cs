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
    float speedBoostSpeed;

    Vector3 playerStartPos;
    //현재 들고있는 물건
    public GameObject grabbedThing = null;
    //애니메이션
    CharacterAnimation animator;
    //리스폰 포인트
    public Transform RespawnPoint;
    //적 외의 충돌을 처리해줄 히트박스
    HitBox HitBox = null;

    public GameObject map;
    public GameObject canvasOff;
    bool mapOpen;

    // Start is called before the first frame update
    void Start()
    {
        RespawnPoint = GameObject.FindGameObjectWithTag("Respawn0").transform;
        if(this.gameObject.tag == "Player")
            HitBox = GetComponent<HitBox>();
        gameUi = FindObjectOfType<inGameUi>();
        animator = GetComponent<CharacterAnimation>();
        //현재 속도와 점프력을 초기화
        moveSpeed = basicMSpeed;
        jumpPower = basicJPower;
        playerStartPos = transform.position;
        //현재 상태를 초기화
        grabbedThing = null;
        isHolding = false;
        onGround = false;
        isJumping = false;
        isGrogging = false;
        mapOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        speedBoostSpeed = basicMSpeed + 3.0f; //아이템속도 업데이트
        //바닥 탐지ray 쏘기
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, new Color(1, 0, 1));
        //ray를 쏴서 맞은 오브젝트 탐지
        if (Physics.Raycast(transform.position, Vector3.down * 0.1f, 0.5f))
        {
            onGround = true;
        }
        if (speedBoostTime > 0.0f)
        {
            moveSpeed = speedBoostSpeed;
            speedBoostTime = Mathf.Max(speedBoostTime - Time.deltaTime, 0.0f);
            animator.Dash();
        }
        else
        {
            moveSpeed = basicMSpeed;
            animator.DashEnd();
        }

        if (Input.GetKeyDown(KeyCode.M) && !mapOpen && Time.timeScale != 0)
        {
            if (map == null) { return; }
            if (canvasOff == null) { return; }
            map.SetActive(true);
            canvasOff.SetActive(false);
            mapOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.M) && mapOpen)
        {
            if (map == null) { return; }
            if (canvasOff == null) { return; }
            map.SetActive(false);
            canvasOff.SetActive(true);
            mapOpen = false;
        }


        if (grabbedThing == null)
            isHolding = false;
    }

    void Respawn()
    {
        if (this.gameObject.tag == "Enemy")
            return;
        this.transform.position = RespawnPoint.transform.position;
        Exploded();
    }

    void Exploded()
    {
        isGrogging = true;
        animator.Groggy();
    }

    void DizzyStart()
    {
        isGrogging = true;
    }

    void DizzyEnd()
    {
        isGrogging = false;
    }
    void Damage(AttackAreaEnemy.AttackInfo attackInfo)
    {
        Respawn();
    }
    public void GetItem(ItemCtrl.ItemKind kind)
    {
        switch (kind)
        {
            case ItemCtrl.ItemKind.TimeUp:
                gameUi.limitTime += 10f;
                //게임플레이시간증가
                break;
            case ItemCtrl.ItemKind.SpeedUp:
                speedBoostTime += 5.0f;
                break;
        }

    }
    void Water()
    {
        Respawn();
    }
}