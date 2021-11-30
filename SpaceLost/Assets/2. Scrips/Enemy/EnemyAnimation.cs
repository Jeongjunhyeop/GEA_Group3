using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    // General
    //
    //
    // machine variables

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


    public void OnAttackCollision()
    {
    }

    public void EndAttackCollision()
    {
    }
    public void EndAttack()
    {
        animator.SetBool("isAttack", true);
    }
    public void GroggingEnd()
    {
        isDownfinish = true;
    }

    private void FixedUpdate()
    {
    }
    public bool GetIsDownFinish()
    {
        return isDownfinish;
    }
    public bool GetIsDownEnd()
    {
        return animator.GetBool("isDownEnd");
    }
    public void SetIsPlayerVisible(bool onVisible)
    {
        animator.SetBool("isPlayerVisible", onVisible);
    }
    public void SetIsattack(bool onVisible)
    {
        animator.SetBool("isAttack", onVisible);
    }
    public bool GetIsPlayerVisible()
    {
        return animator.GetBool("isPlayerVisible");
    }
    public void SetDistanceFromWayPoint(float distancefromtarget)
    {
        animator.SetFloat("distanceFromWaypoint", distancefromtarget);
    }
    public void SetDistanceFromPlayer(float currentdistance)
    {
        animator.SetFloat("distanceFromPlayer", currentdistance);
    }
    public void SetChasePlayer(bool onVisible)
    {
        animator.SetBool("isPlayerChase", onVisible);
    }
    public bool GetChasePlayer()
    {
        return animator.GetBool("isPlayerChase");
    }
    public void SetPatrol(bool onVisible)
    {
        animator.SetBool("isPatrol", onVisible);
    }
    public void SetIsDownEnd(bool onVisible)
    {
        animator.SetBool("IsDownEnd", onVisible);
    }
    public bool GetIsDown()
    {
       return animator.GetBool("isDown");
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
