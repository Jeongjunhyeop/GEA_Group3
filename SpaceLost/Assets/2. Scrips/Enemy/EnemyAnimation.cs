using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    // General state machine variables

    private Animator animator;
    CharacterState status;

    bool isDownfinish = false;
    bool attacked = false;
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        status = gameObject.GetComponent<CharacterState>();

    }

    public bool IsAttacked()
    {
        return attacked;
    }


    void OnAttackCollision()
    {
        Debug.Log("StartAttackHit");
    }

    void EndAttackCollision()
    {
        Debug.Log("EndAttackHit");
    }
    void isDownEnd()
    {
        animator.SetBool("isDownEnd", true);
    }
    void EndAttack()
    {
        attacked = true;
    }

    private void FixedUpdate()
    {
        if (attacked && !status.isAttacking)
        {
            attacked = false;
        }
        animator.SetBool("isAttack", (!attacked && status.isAttacking));
    }

    public void SetIsPlayerVisible(bool onVisible)
    {
        animator.SetBool("isPlayerVisible", onVisible);
    }
    public void SetDistanceFromWayPoint(float distancefromtarget)
    {
        animator.SetFloat("distanceFromWaypoint", distancefromtarget);
    }
    public void SetDistanceFromPlayer(float currentdistance)
    {
        animator.SetFloat("distanceFromPlayer", currentdistance);
    }
    public void StartChasePlayer()
    {
        animator.SetBool("isPlayerChase", true);
    }
    public void EndChasePlayer()
    {
        animator.SetBool("isPlayerChase", false);
    }
    public void StartPatrol()
    {
        animator.SetBool("isPatrol", true);
    }
    public void EndPatrol()
    {
        animator.SetBool("isPatrol", false);
    }

    public void StartIsDown()
    {
        animator.SetBool("isDown", true);
    }
    public void EndIsDown()
    {
        animator.SetBool("isDown", false);
    }
}
