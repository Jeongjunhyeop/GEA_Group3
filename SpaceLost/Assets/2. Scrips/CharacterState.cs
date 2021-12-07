using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour
{
    inGameUi gameUi;
    //���� ����
    public bool isAttacking = false;
    public bool isHolding = false;
    public bool isJumping = false;
    public bool isGrogging = false;
    public bool onGround = false;

    //�ʱ� �ӵ�
    public float basicMSpeed = 3f;
    //�ʱ� ������
    public float basicJPower = 5f;

    //�ʱ� ���ݷ�
    public int basicATC = 1;

    //���� �ӵ�
    public float moveSpeed = 3f;
    //���� ������
    public float jumpPower = 5f;
    //�ʱ� ���ݷ�
    public int ATC = 1;
    public bool powerBoost = false;
    public bool speedBoost = false;
    public float speedBoostTime = 0.0f;
    float speedBoostSpeed;

    Vector3 playerStartPos;
    //���� ����ִ� ����
    public GameObject grabbedThing = null;
    //�ִϸ��̼�
    CharacterAnimation animator;
    //������ ����Ʈ
    public Transform RespawnPoint;
    //�� ���� �浹�� ó������ ��Ʈ�ڽ�
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
        //���� �ӵ��� �������� �ʱ�ȭ
        moveSpeed = basicMSpeed;
        jumpPower = basicJPower;
        playerStartPos = transform.position;
        //���� ���¸� �ʱ�ȭ
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
        speedBoostSpeed = basicMSpeed + 3.0f; //�����ۼӵ� ������Ʈ
        //�ٴ� Ž��ray ���
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, new Color(1, 0, 1));
        //ray�� ���� ���� ������Ʈ Ž��
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
                //�����÷��̽ð�����
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