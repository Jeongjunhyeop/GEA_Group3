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
    Transform RespawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        //RespawnPoint = GameObject.FindGameObjectWithTag("Respawn0").transform;
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
    }

    // Update is called once per frame
    void Update()
    {
        speedBoostSpeed = basicMSpeed + 5.0f; //�����ۼӵ� ������Ʈ
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
        }
        else
        {
            moveSpeed = basicMSpeed;
        }

        if (grabbedThing == null)
            isHolding = false;
    }

    void Respawn()
    {
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
        transform.position = playerStartPos;
    }
    public void GetItem(ItemCtrl.ItemKind itemKind)
    {
        switch (itemKind)
        {
            case ItemCtrl.ItemKind.TimeUp:
                gameUi.limitTime += 5f;
                //�����÷��̽ð�����
                break;
            case ItemCtrl.ItemKind.SpeedUp:
                speedBoostTime += 5.0f;
                break;
        }

    }
    void Water()
    {
        transform.position = playerStartPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
            Respawn();
        if (other.gameObject.tag == "Respawn")
            RespawnPoint = other.transform;
    }
}