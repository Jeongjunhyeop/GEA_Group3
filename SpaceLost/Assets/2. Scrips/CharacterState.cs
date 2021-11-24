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
    }

    public void GetItem(ItemCtrl.ItemKind itemKind){
        switch (itemKind){
            case ItemCtrl.ItemKind.TimeUp:
                gameUi.limitTime += 5f;
                //�����÷��̽ð�����
                break;
            case ItemCtrl.ItemKind.SpeedUp:
                StartCoroutine("PlayerSpeedUp");
                break;
            case ItemCtrl.ItemKind.SpeedDown:
                //���̵��ӵ�����
                break;
            case ItemCtrl.ItemKind.MissionObject:
                //�̼Ǿ�����ȹ��
                break;
            case ItemCtrl.ItemKind.Nav:
                //�̼Ǿ�������ġǥ��
                break;
            case ItemCtrl.ItemKind.Sheild:
                //������ 1ȸ ����
                break;
        }
    }

    IEnumerator PlayerSpeedUp()
    {
        moveSpeed += 5.0f;
        yield return new WaitForSeconds(5.0f);
        moveSpeed = basicMSpeed;
    }
}
