using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatue : MonoBehaviour
{
    //���� ����
    public bool isAttacking = false;
    public bool isHolding = false;
    public bool isJumping = false;
    public bool isGrogging = false;

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
        //���� �ӵ��� �������� �ʱ�ȭ
        moveSpeed = basicMSpeed;
        jumpPower = basicJPower;
        //���� ���¸� �ʱ�ȭ
        grabbedThing = null;
        isHolding = false;
        isJumping = false;
        isGrogging = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
