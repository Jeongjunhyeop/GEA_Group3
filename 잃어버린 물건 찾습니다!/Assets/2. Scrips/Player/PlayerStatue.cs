using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatue : MonoBehaviour
{
    //현재 상태
    public bool isAttacking = false;
    public bool isHolding = false;
    public bool isJumping = false;
    public bool isGrogging = false;

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

    //현재 들고있는 물건
    public GameObject grabbedThing = null;

    // Start is called before the first frame update
    void Start()
    {
        //현재 속도와 점프력을 초기화
        moveSpeed = basicMSpeed;
        jumpPower = basicJPower;
        //현재 상태를 초기화
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
