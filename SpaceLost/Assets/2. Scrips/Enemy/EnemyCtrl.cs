using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
	CharacterState status;
	EnemyAnimation enemyAnimation;
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

	// 복수의 아이템을 저장할 수 있는 배열로 한다.
	public GameObject[] dropItemPrefab;

	// 스테이트 종류.
	enum State
	{
		Patroling,    // 탐색.
		Chasing,    // 추적.
		Attacking,  // 공격.
		Grogging,       // 폭발물에 의한 다운.
	};

	State state = State.Patroling;        // 현재 스테이트.
	State nextState = State.Patroling;    // 다음 스테이트.

	public AudioClip deathSeClip;
	AudioSource deathSeAudio;


	// Use this for initialization
	void Start()
	{
		status = GetComponent<CharacterState>();
		enemyAnimation = GetComponent<EnemyAnimation>();

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
		enemyAnimation.SetDistanceFromPlayer(currentDistance);
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
		enemyAnimation.SetDistanceFromWayPoint(distanceFromTarget);


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
	// 스테이트를 변경한다.
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
		// 타겟을 발견하면 추적한다.
		if (player.transform)
		{
			navMeshAgent.SetDestination(player.transform.position);
			ChangeState(State.Chasing);
		}
	}
	// 추적 시작. 
	void ChaseStart()
	{
		StateStartCommon();
	}
	// 추적 중. 
	void Chasing()
	{
		if (Vector3.Distance(player.transform.position, transform.position) >= 6.0f)
		{
			ChangeState(State.Patroling);
			navMeshAgent.SetDestination(waypoints[currentTarget].position);
			return;
		}
		navMeshAgent.SetDestination(player.transform.position);
		// 이동할 곳을 플레이어에 설정한다.
		//SendMessage("SetDestination", player.transform.position);
		// 2미터 이내로 접근하면 공격한다.
		if (Vector3.Distance(player.transform.position, transform.position) <= 2.0f)
		{
			ChangeState(State.Attacking);
		}
	}

	// 공격 스테이트가 시작되기 전에 호출된다.
	void AttackStart()
	{
		StateStartCommon();
		status.isAttacking = true;

		// 적이 있는 방향으로 돌아본다.
		Vector3 targetDirection = (player.transform.position - transform.position).normalized;
	}
	/*
	// 공격 중 처리.
	void Attacking()
	{
		if (charaAnimation.attacked())
			ChangeState(State.Walking);
		// 대기 시간을 다시 설정한다.
		waitTime = Random.Range(waitBaseTime, waitBaseTime * 2.0f);
		// 타겟을 리셋한다.
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

		// 오디오 재생.
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
			// 체력이 0이므로 사망 스테이트로 전환한다.
			ChangeState(State.Died);
		}
	}
	*/
	// 스테이트가 시작되기 전에 스테이터스를 초기화한다.
	void StateStartCommon()
	{
		status.isAttacking = false;
		status.isGrogging = false;
	}
}
