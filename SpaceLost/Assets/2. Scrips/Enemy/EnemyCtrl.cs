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
    private int enemyHp = 1;
    // Patrol state variables


    public GameObject[] pointIndex;


    public UnityEngine.AI.NavMeshAgent navMeshAgent;

    int pointIndexLength;
    private int maxPointIndex = 10;
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
        pointIndexLength = pointIndex.Length;
        if (pointIndexLength == 0)
        {
            waypoints = new Transform[1]
            {
                waypoints[0] = this.transform
            };
        }
        else
        {
            waypoints = new Transform[maxPointIndex];
            for (int i = 0; i < pointIndexLength; i++)
            {
                waypoints[i] = pointIndex[i].transform;
            }
        }
        navMeshAgent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
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
    }

    public void StartChasePlayer()
    {
        enemyAnimation.SetChasePlayer(true);
        navMeshAgent.SetDestination(player.transform.position);
    }

    public void EndChasePlayer()
    {
        if(currentDistance > 6.0f)
        {
            StateStartCommon();
        }
    }
    public void StartMoveToTarget()
    {
        StateStartCommon();
        navMeshAgent.SetDestination(waypoints[currentTarget].position);
    }
    public void StartAttackPlayer()
    {
        navMeshAgent.SetDestination(player.transform.position);
    }

    public void EndAttackPlayer()
    {
        enemyAnimation.SetIsattack(false);
        if (distanceFromTarget > 6.0f)
        {
            StateStartCommon();
        }
    }
    public void GetPlayerNav()
    {
        navMeshAgent.SetDestination(player.transform.position);
    }
    public void SetNextPoint()
    {
        if (pointIndex.Length == 0)
        {
            currentTarget = 0;
        }
        if(pointIndexLength == 1)
        {
            currentTarget = 0;
        }
        else
        {
            if (currentTarget == (pointIndexLength - 1))
            {
                currentTarget = 0;
            }
            else
            {
                currentTarget += 1;
            }
        }
        navMeshAgent.SetDestination(waypoints[currentTarget].position);
    }

    void dropItem()
    {
        if (dropItemPrefab.Length == 0) { return; }
        GameObject dropItem = dropItemPrefab[Random.Range(0, dropItemPrefab.Length)];
        Instantiate(dropItem, transform.position, Quaternion.identity);
    }
    public void StartGrogging()
    {
        GetComponent<Collider>().enabled = false;
        navMeshAgent.enabled = false;
        enemyAnimation.SetIsDownEnd(true);
        dropItem();
    }
    public void UpdateGrogging()
    {
        if (enemyAnimation.GetIsDownFinish() == true)
        {
            Invoke("EndGrog", 3f);
        }
    }
    public void EndGrogging()
    {
    }
    void explosionDamage()
    {
        /*GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity) as GameObject;
		effect.transform.localPosition = transform.position + new Vector3(0.0f, 0.5f, 0.0f);
		Destroy(effect, 0.3f);*/
        
        if(enemyAnimation.GetIsDown() == false)
        {
            enemyHp = 0;
            enemyAnimation.StartIsDown();
        }
    }
    void Damage(AttackArea.AttackInfo attackInfo)
    {
        if(attackInfo.attackPower >= 10)
        {
            enemyHp = 0;
            enemyAnimation.StartIsDown();
        }
    }
    void EndGrog()
    {
        navMeshAgent.enabled = true;
        GetComponent<Collider>().enabled = true;
        enemyHp = 1;
        enemyAnimation.EndIsDown();
        enemyAnimation.SetIsDownEnd(false);
        StateStartCommon();
        enemyAnimation.SetPatrol(true);
        
    }
    
    // 스테이트가 시작되기 전에 스테이터스를 초기화한다.
    void StateStartCommon()
    {
        enemyAnimation.SetChasePlayer(false);
        enemyAnimation.SetIsattack(false);
    }

    public void EndPatrol()
    {
        enemyAnimation.SetPatrol(false);
    }
}
