using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    PlayerStatue statue;
    //CharaAnimation charaAnimation;
    Transform attackTarget;
    Rigidbody rigidbody;

    //오브젝트 탐지 & 공격 가능 범위
    public float HoldnAttackRange = 1.5f;
    //탐지용 레이
    RaycastHit raycast;
    Ray ray;

    //GameRuleCtrl gameRuleCtrl;

    // 스테이트 종류.
    enum State
    {
        Walking,
        Attacking,
        Holding,    //아이템을 든 상태
        Jumping,
        Grogging,   //그로기(폭발에 휘말렸을 때 잠시 멈춤)
    };

    State state = State.Walking;		// 현재 스테이트.
    State nextState = State.Walking;	// 다음 스테이트. 

    // Start is called before the first frame update
    void Start()
    {
        statue = GetComponent<PlayerStatue>();
        //charaAnimation = GetComponent<CharaAnimation>();
        //gameRuleCtrl = FindObjectOfType<GameRuleCtrl>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Walking:
                Walking();
                break;
            case State.Attacking:
                Attacking();
                break;
            case State.Holding:
                ItemHold();
                break;
            case State.Jumping:
                Jumping();
                break;
        }

        if (state != nextState)
        {
            state = nextState;
            switch (state)
            {
                case State.Walking:
                    WalkStart();
                    break;
                case State.Attacking:
                    AttackStart();
                    break;
                case State.Holding:
                    ItemHold();
                    break;
                case State.Jumping:
                    Jumping();
                    break;
                case State.Grogging:
                    Grogging();
                    break;
            }
        }
    }

    // 스테이트를 변경한다. 
    void ChangeState(State nextState)
    {
        this.nextState = nextState;
    }

    void WalkStart()
    {
        StateStartCommon();
    }

    void Walking()
    {
        
    }

    // 공격 스테이트가 시작되기 전에 호출된다. 
    void AttackStart()
    {
        StateStartCommon();
        statue.isAttacking = true;

        // 타깃 방향으로 돌아보게 한다.
        Vector3 targetDirection = (attackTarget.position - transform.position).normalized;
        SendMessage("SetDirection", targetDirection);

        // 이동을 멈춘다.
        SendMessage("StopMove");
    }

    // 공격 중 처리.
    void Attacking()
    {
//        if (charaAnimation.IsAttacked())
//            ChangeState(State.Walking);
    }

    //아이템 잡기가 실행되기 전 호출
    void HoldStart()
    {
        StateStartCommon();
    }

    void ItemHold()
    {

    }

    //점프가 실행되기 전 호출
    void JumpStart()
    {
        StateStartCommon();
    }

    void Jumping()
    {

    }

    void Grogging()
    {

    }

    // 스테이트가 시작되기 전에 스테이터스를 초기화한다.
    void StateStartCommon()
    {
        statue.isAttacking = false;
        statue.isJumping = false;
        statue.isGrogging = false;
    }
}
