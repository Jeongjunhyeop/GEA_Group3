using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunCtrl : MonoBehaviour
{
    CharacterState status;
    EnemyRunAnimation enemyRunAnimation;
    public GameObject hitEffect;

    private GameObject player;
    private Ray ray;
    private RaycastHit hit;

    private MeshRenderer meshRenderer;

    public int FieldOfView = 60;

    public float maxDistanceToViewCheck = 10.0f;
    public float maxChaseDistance = 6.0f;
    public float maxDistanceToAnyCheck = 4.0f;

    public bool isChickenAI = false;
    public bool isRunToPlayer = false;

    private float currentDistance;
    private Vector3 checkDirection;

    public int enemyMaxHP = 10;
    public int enemyHp = 10;

    // Patrol state variables
    int layercheker;
    public GameObject[] pointIndex;
    public GameObject homeBasePoint;

    public UnityEngine.AI.NavMeshAgent navMeshAgent;

    private int pointIndexLength;
    private int maxPointIndex = 20;
    public int currentTarget;

    private float distanceFromTarget;
    private float distanceFromHome;
    private float runTimeToPlayer = 0.0f;
    private float runTimeAtHome = 0.0f;
    public float maxTimeToRun = 15.0f;
    public float maxTimeToHome = 15.0f;

    private bool isReturn = false;
    private Transform[] waypoints = null;

    private bool dropitem = true;
    // 복수의 아이템을 저장할 수 있는 배열로 한다.
    public GameObject[] dropItemPrefab;


    public AudioClip deathSeClip;
    AudioSource deathSeAudio;


    // Use this for initialization
    void Start()
    {
        status = GetComponent<CharacterState>();
        enemyRunAnimation = GetComponent<EnemyRunAnimation>();
        layercheker = (1 << 6 | 1 << 7 | 1 << 8 | 1 << 9 | 1 << 11 | 1 << 12);
        player = GameObject.FindWithTag("Player");
        meshRenderer = GetComponentInChildren<MeshRenderer>();
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
        navMeshAgent.speed = status.moveSpeed;
        currentTarget = 0;
        navMeshAgent.SetDestination(waypoints[currentTarget].position);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 height = new Vector3(0.0f, 0.3f, 0.0f);
        //First we check distance from the player 
        currentDistance = Vector3.Distance(player.transform.position + height, transform.position + height);
        enemyRunAnimation.SetDistanceFromPlayer(currentDistance);
        //Then we check for visibility
        checkDirection = (player.transform.position + height) - (transform.position + height);
        ray = new Ray(transform.position, checkDirection);
        if ((Vector3.Angle(checkDirection, transform.forward)) < FieldOfView)
        {
            if (Physics.Raycast(transform.position, checkDirection, out hit, maxDistanceToViewCheck, layercheker))
            {
                if (hit.collider.gameObject == player)
                {
                    enemyRunAnimation.SetIsPlayerVisible(true);
                }
                else
                {
                    enemyRunAnimation.SetIsPlayerVisible(false);
                }
            }
            else
            {
                enemyRunAnimation.SetIsPlayerVisible(false);
            }
        }
        else
        {
            enemyRunAnimation.SetIsPlayerVisible(false);
        }

        if (enemyRunAnimation.GetIsRun() && !enemyRunAnimation.GetIsPlayerVisible())
        {
            runTimeToPlayer += Time.deltaTime;
            if (navMeshAgent.speed <= status.moveSpeed)
            {
                navMeshAgent.speed += 3.0f;
            }
            if (runTimeToPlayer >= maxTimeToRun)
            {
                navMeshAgent.speed = status.moveSpeed;
                enemyRunAnimation.SetIsRun(false);
                runTimeToPlayer = 0.0f;
            }
        }
        else if (enemyRunAnimation.GetIsRun() && enemyRunAnimation.GetIsPlayerVisible())
        {
            runTimeToPlayer = 0.0f;
        }


        Vector3 frontRayPoint = transform.position + (transform.forward * maxDistanceToViewCheck);

        //Approximate perspective visualization
        Vector3 leftRayPoint = frontRayPoint;
        leftRayPoint.x += FieldOfView * 0.5f;

        Vector3 rightRayPoint = frontRayPoint;
        rightRayPoint.x -= FieldOfView * 0.5f;

        Debug.DrawLine(transform.position, frontRayPoint, Color.green);
        Debug.DrawLine(transform.position, leftRayPoint, Color.black);
        Debug.DrawLine(transform.position, rightRayPoint, Color.blue);

        distanceFromTarget = Vector3.Distance(waypoints[currentTarget].position, transform.position);
        enemyRunAnimation.SetDistanceFromWayPoint(distanceFromTarget);
    }

    public void StartMoveToTarget()
    {
        navMeshAgent.SetDestination(waypoints[currentTarget].position);
    }
    public void GetHomeNav()
    {
        if(isChickenAI)
        {
            navMeshAgent.SetDestination(homeBasePoint.transform.position);
        }   
    }
    public void StartRunToPlayer()
    {
        if(!enemyRunAnimation.GetIsRun() && isReturn)
        {
            enemyRunAnimation.SetIsRun(true);

            if (currentTarget == (pointIndexLength - 2))
            {
                isReturn = false;
                currentTarget += 1;
                navMeshAgent.SetDestination(waypoints[currentTarget].position);
            }
            else
            {
                isReturn = false;
                currentTarget += 1;
                navMeshAgent.SetDestination(waypoints[currentTarget].position);
            }
        }

        if (!enemyRunAnimation.GetIsRun() && !isReturn)
        {
            enemyRunAnimation.SetIsRun(true);

            if (currentTarget == 1)
            {
                isReturn = true;
                currentTarget = 0;
                navMeshAgent.SetDestination(waypoints[currentTarget].position);
            }
            else if(currentTarget == 0)
            {
            }
            else
            {
                isReturn = true;
                currentTarget -= 1;
                navMeshAgent.SetDestination(waypoints[currentTarget].position);
            }
        }
        else
        {
        }
    }
    public void StartHideOnBase()
    {

    }
    public void UpdateHideOnBase()
    {
        distanceFromHome = Vector3.Distance(homeBasePoint.transform.position, transform.position);
        if (distanceFromHome <= 0.5f)
        {
            if(navMeshAgent.speed > 0.0f)
            {
                navMeshAgent.speed = 0.0f;
            }
            runTimeAtHome += Time.deltaTime;
            if(runTimeAtHome >= maxTimeToHome)
            {
                enemyRunAnimation.SetIsRun(false);
                enemyRunAnimation.SetHideOnBase(false);
            }
        }
        else
        {
            navMeshAgent.speed = status.moveSpeed;
        }
    }
    public void ExitHideOnBase()
    {
        navMeshAgent.speed = 3.5f;
        runTimeAtHome = 0.0f;
        isReturn = false;
        currentTarget = 0;
        navMeshAgent.SetDestination(waypoints[currentTarget].position);
    }
    public void SetNextPoint()
    {
        if (pointIndex.Length == 0)
        {
            currentTarget = 0;
        }
        if (pointIndexLength == 1)
        {
            currentTarget = 0;
        }
        else
        {
            if (currentTarget == (pointIndexLength - 1) && !isReturn)
            {
                isReturn = true;
                currentTarget--;
            }
            else if(isReturn && currentTarget == 0)
            {
                if(isChickenAI && enemyRunAnimation.GetIsRun())
                {
                    enemyRunAnimation.SetHideOnBase(true);
                    GetHomeNav();
                    return;
                }
                else
                {
                    isReturn = false;
                    currentTarget++;
                }  
            }
            else if (!isReturn && currentTarget == 0)
            {
                if (isChickenAI && enemyRunAnimation.GetIsRun())
                {
                    enemyRunAnimation.SetHideOnBase(true);
                    GetHomeNav();
                    return;
                }
                else
                {
                    currentTarget++;
                }
            }
            else if(isReturn && currentTarget != 0)
            {
                currentTarget--;
            }
            else if(!isReturn && currentTarget != (pointIndexLength - 1))
            {
                currentTarget++;
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
    public void StartDestroyed()
    {
        navMeshAgent.speed = 0.0f;
        StartCoroutine("DestroyRobots");
        if(dropitem)
        {
            dropitem = false;

            dropItem();
        }
        Destroy(gameObject, 3.5f);
    }
    IEnumerator DestroyRobots()
    {

        meshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        meshRenderer.material.color = Color.white;
        yield return new WaitForSeconds(0.5f);
        //1초

        meshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        meshRenderer.material.color = Color.white;
        yield return new WaitForSeconds(0.5f);
        //1초

        meshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        meshRenderer.material.color = Color.white;
        yield return new WaitForSeconds(0.5f);

        //1초

    }
    public void UpdateGrogging()
    {
        
    }
    void explosionDamage()
    {
        /*GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity) as GameObject;
		effect.transform.localPosition = transform.position + new Vector3(0.0f, 0.5f, 0.0f);
		Destroy(effect, 0.3f);*/
        if (enemyRunAnimation.GetIsDestroy() == false)
        {
            enemyHp = 0;
            enemyRunAnimation.StartIsDestroy();
        }
    }
    void Damage_Enemy(AttackArea.AttackInfo attackInfo)
    {
        Debug.Log("damage");
        if(enemyRunAnimation.GetIsDestroy() == false)
        {
            enemyHp = 0;
            enemyRunAnimation.StartIsDestroy();
        }
    }
}
