using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
	CharacterState status;
	CharacterAnimation charaAnimation;
	EnemyMove EnemyMove;
	Transform attackTarget;
	public GameObject hitEffect;

	// ��� �ð��� 2�ʷ� �����Ѵ�.
	public float waitBaseTime = 2.0f;
	// ���� ��� �ð�.
	float waitTime;
	// �̵� ���� 5����.
	public float walkRange = 5.0f;
	// �ʱ� ��ġ�� ������ �� ����.
	public Vector3 basePosition;
	// ������ �������� ������ �� �ִ� �迭�� �Ѵ�.
	public GameObject[] dropItemPrefab;

	// ������Ʈ ����.
	enum State
	{
		Walking,    // Ž��.
		Chasing,    // ����.
		Attacking,  // ����.
		Grogging,       // ���߹��� ���� �ٿ�.
	};

	State state = State.Walking;        // ���� ������Ʈ.
	State nextState = State.Walking;    // ���� ������Ʈ.

	public AudioClip deathSeClip;
	AudioSource deathSeAudio;


	// Use this for initialization
	void Start()
	{
		status = GetComponent<CharacterState>();
		charaAnimation = GetComponent<CharacterAnimation>();
		EnemyMove = GetComponent<EnemyMove>();
		// �ʱ� ��ġ�� �����Ѵ�.
		basePosition = transform.position;
		// ��� �ð�.
		waitTime = waitBaseTime;
	}

	// Update is called once per frame
	void Update()
	{
		switch (state)
		{
			case State.Walking:
				Walking();
				break;
			case State.Chasing:
				Chasing();
				break;
			case State.Attacking:
				//Attacking();
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
				case State.Chasing:
					ChaseStart();
					break;
				case State.Attacking:
					AttackStart();
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
		// ��� �ð��� ���� ���Ҵٸ�.
		if (waitTime > 0.0f)
		{
			// ��� �ð��� ���δ�.
			waitTime -= Time.deltaTime;
			// ��� �ð��� ��������.
			if (waitTime <= 0.0f)
			{
				// ���� ���� ���.
				Vector2 randomValue = Random.insideUnitCircle * walkRange;
				// �̵��� ���� �����Ѵ�.
				Vector3 destinationPosition = basePosition + new Vector3(randomValue.x, 0.0f, randomValue.y);
				// �������� �����Ѵ�.
				SendMessage("SetDestination", destinationPosition);
			}
		}
		else
		{
			// �������� �����Ѵ�.
			if (EnemyMove.Arrived())
			{
				// ��� ���·� ��ȯ�Ѵ�.
				waitTime = Random.Range(waitBaseTime, waitBaseTime * 2.0f);
			}
			// Ÿ���� �߰��ϸ� �����Ѵ�.
			if (attackTarget)
			{
				ChangeState(State.Chasing);
			}
		}
	}
	// ���� ����. 
	void ChaseStart()
	{
		StateStartCommon();
	}
	// ���� ��. 
	void Chasing()
	{
		if (attackTarget == null)
		{
			ChangeState(State.Walking);
			return;
		}
		// �̵��� ���� �÷��̾ �����Ѵ�.
		SendMessage("SetDestination", attackTarget.position);
		// 2���� �̳��� �����ϸ� �����Ѵ�.
		if (Vector3.Distance(attackTarget.position, transform.position) <= 2.0f)
		{
			ChangeState(State.Attacking);
		}
	}

	// ���� ������Ʈ�� ���۵Ǳ� ���� ȣ��ȴ�.
	void AttackStart()
	{
		StateStartCommon();
		status.isAttacking = true;

		// ���� �ִ� �������� ���ƺ���.
		Vector3 targetDirection = (attackTarget.position - transform.position).normalized;
		SendMessage("SetDirection", targetDirection);

		// �̵��� �����.
		SendMessage("StopMove");
	}
	/*
	// ���� �� ó��.
	void Attacking()
	{
		if (charaAnimation.attacked())
			ChangeState(State.Walking);
		// ��� �ð��� �ٽ� �����Ѵ�.
		waitTime = Random.Range(waitBaseTime, waitBaseTime * 2.0f);
		// Ÿ���� �����Ѵ�.
		attackTarget = null;
	}
	*/
	/*
	void dropItem()
	{
		if (dropItemPrefab.Length == 0) { return; }
		GameObject dropItem = dropItemPrefab[Random.Range(0, dropItemPrefab.Length)];
		Instantiate(dropItem, transform.position, Quaternion.identity);
	}
	*/
	void Grogging()
	{
		status.isGrogging = true;
		//dropItem();

		// ����� ���.
		AudioSource.PlayClipAtPoint(deathSeClip, transform.position);
	}
	/*
	void Damage(AttackArea.AttackInfo attackInfo)
	{
		GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity) as GameObject;
		effect.transform.localPosition = transform.position + new Vector3(0.0f, 0.5f, 0.0f);
		Destroy(effect, 0.3f);

		status.HP -= attackInfo.attackPower;
		if (status.HP <= 0)
		{
			status.HP = 0;
			// ü���� 0�̹Ƿ� ��� ������Ʈ�� ��ȯ�Ѵ�.
			ChangeState(State.Died);
		}
	}
	*/
	// ������Ʈ�� ���۵Ǳ� ���� �������ͽ��� �ʱ�ȭ�Ѵ�.
	void StateStartCommon()
	{
		status.isAttacking = false;
		status.isGrogging = false;
	}
	// ���� ����� �����Ѵ�. 
	public void SetAttackTarget(Transform target)
	{
		attackTarget = target;
	}
	public void ResetAttackTarget()
	{
		attackTarget = null;
	}
}
