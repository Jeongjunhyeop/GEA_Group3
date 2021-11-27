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

    //���� ����ִ� ����
    public GameObject grabbedThing = null;

    // Start is called before the first frame update
    void Start()
    {
        gameUi = FindObjectOfType<inGameUi>();
        //���� �ӵ��� �������� �ʱ�ȭ
        moveSpeed = basicMSpeed;
        jumpPower = basicJPower;
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
        //�ٴ� Ž��ray ���
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, new Color(1, 0, 1));
        //ray�� ���� ���� ������Ʈ Ž��
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
                //�����÷��̽ð�����
                break;
            case ItemCtrl.ItemKind.SpeedUp:
                speedBoostTime += 5.0f;
                break;
            case ItemCtrl.ItemKind.SpeedDown:
                //���̵��ӵ�����
                break;
        }

    }
}