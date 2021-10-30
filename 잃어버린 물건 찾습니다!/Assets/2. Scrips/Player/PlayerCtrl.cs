using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    PlayerStatue statue;
    //CharaAnimation charaAnimation;
    Transform attackTarget;
    Rigidbody rigidbody;

    //������Ʈ Ž�� & ���� ���� ����
    public float HoldnAttackRange = 1.5f;
    //Ž���� ����
    RaycastHit raycast;
    Ray ray;

    //GameRuleCtrl gameRuleCtrl;

    // ������Ʈ ����.
    enum State
    {
        Walking,
        Attacking,
        Holding,    //�������� �� ����
        Jumping,
        Grogging,   //�׷α�(���߿� �ָ����� �� ��� ����)
    };

    State state = State.Walking;		// ���� ������Ʈ.
    State nextState = State.Walking;	// ���� ������Ʈ. 

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

    // ������Ʈ�� �����Ѵ�. 
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

    // ���� ������Ʈ�� ���۵Ǳ� ���� ȣ��ȴ�. 
    void AttackStart()
    {
        StateStartCommon();
        statue.isAttacking = true;

        // Ÿ�� �������� ���ƺ��� �Ѵ�.
        Vector3 targetDirection = (attackTarget.position - transform.position).normalized;
        SendMessage("SetDirection", targetDirection);

        // �̵��� �����.
        SendMessage("StopMove");
    }

    // ���� �� ó��.
    void Attacking()
    {
//        if (charaAnimation.IsAttacked())
//            ChangeState(State.Walking);
    }

    //������ ��Ⱑ ����Ǳ� �� ȣ��
    void HoldStart()
    {
        StateStartCommon();
    }

    void ItemHold()
    {

    }

    //������ ����Ǳ� �� ȣ��
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

    // ������Ʈ�� ���۵Ǳ� ���� �������ͽ��� �ʱ�ȭ�Ѵ�.
    void StateStartCommon()
    {
        statue.isAttacking = false;
        statue.isJumping = false;
        statue.isGrogging = false;
    }
}
