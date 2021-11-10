using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
	CharacterState status;
	EnemyAnimation enemyAnimation;
	EnemyMove enemyMove;
	Transform attackTarget;
	public GameObject hitEffect;

	private GameObject player;
	private Ray ray;
	private RaycastHit hit;
	private float maxDistanceToCheck = 6.0f;
	private float currentDistance;
	private Vector3 checkDirection;
	private bool isChasePlayer;
	// Patrol state variables
	public Transform pointA;
	public Transform pointB;
	public UnityEngine.AI.NavMeshAgent navMeshAgent;

	private int currentTarget;
	private float distanceFromTarget;
	private Transform[] waypoints = null;


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
		Patroling,    // Ž��.
		Chasing,    // ����.
		Attacking,  // ����.
		Grogging,       // ���߹��� ���� �ٿ�.
	};

	State state = State.Patroling;        // ���� ������Ʈ.
	State nextState = State.Patroling;    // ���� ������Ʈ.

	public AudioClip deathSeClip;
	AudioSource deathSeAudio;


	// Use this for initialization
	void Start()
	{
		status = GetComponent<CharacterState>();
		enemyAnimation = GetComponent<EnemyAnimation>();
		enemyMove = GetComponent<EnemyMove>();
		// �ʱ� ��ġ�� �����Ѵ�.
		basePosition = transform.position;
		// ��� �ð�.
		waitTime = waitBaseTime;

		player = GameObject.FindWithTag("Player");

		pointA = GameObject.Find("PatrolPoint1").transform;
		pointB = GameObject.Find("PatrolPoint2").transform;
		navMeshAgent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
		waypoints = new Transform[2] {
			pointA,
			pointB
		};
		currentTarget = 0;
		isChasePlayer = false;
		navMeshAgent.SetDestination(waypoints[currentTarget].position);
	}

	// Update is called once per frame
	void Update()
	{
		//First we check distance from the player 
		currentDistance = Vector3.Distance(player.transform.position, transform.position);
		//Then we check for visibility
		checkDirection = player.transform.position - transform.position;
		ray = new Ray(transform.position, checkDirection);
		if (Physics.Raycast(ray, out hit, maxDistanceToCheck))
		{
			if (hit.collider.gameObject == player)
			{
				enemyAnimation.SetIsPlayerVisible(true);
			}
			else
			{
				enemyAnimation.SetIsPlayerVisible(false);
			}
		}
		else
		{
			enemyAnimation.SetIsPlayerVisible(false);
		}
		//Lastly, we get the distance to the next waypoint target
		distanceFromTarget = Vector3.Distance(waypoints[currentTarget].position, transform.position);



		
		switch (state)
		{
			case State.Patroling:
				Patroling();
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
				case State.Patroling:
					PatrolStart();
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

	public void SetNextPoint()
	{
		switch (currentTarget)
		{
			case 0:
				currentTarget = 1;
				break;
			case 1:
				currentTarget = 0;
				break;
		}
		navMeshAgent.SetDestination(waypoints[currentTarget].position);
	}
	// ������Ʈ�� �����Ѵ�.
	void ChangeState(State nextState)
	{
		this.nextState = nextState;
	}

	void PatrolStart()
	{
		StateStartCommon();
	}

	void Patroling()
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
			if (enemyMove.Arrived())
			{
				// ��� ���·� ��ȯ�Ѵ�.
				waitTime = Random.Range(waitBaseTime, waitBaseTime * 2.0f);
			}
			// Ÿ���� �߰��ϸ� �����Ѵ�.
			if (attackTarget)
			{
				navMeshAgent.SetDestination(player.transform.position);
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
			ChangeState(State.Patroling);
			navMeshAgent.SetDestination(waypoints[currentTarget].position);
			return;
		}
		navMeshAgent.SetDestination(player.transform.position);
		// �̵��� ���� �÷��̾ �����Ѵ�.
		//SendMessage("SetDestination", player.transform.position);
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