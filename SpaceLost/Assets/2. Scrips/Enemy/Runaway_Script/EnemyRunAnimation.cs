using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunAnimation : MonoBehaviour
{
    // General
    //
    //
    // machine variables

    private Animator animator;
    CharacterState status;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        status = gameObject.GetComponent<CharacterState>();

    }
    private void FixedUpdate()
    {
    }

    public void SetIsPlayerVisible(bool onVisible)
    {
        animator.SetBool("isPlayerVisible", onVisible);
    }
    public bool GetIsPlayerVisible()
    {
        return animator.GetBool("isPlayerVisible");
    }
    public void SetIsRun(bool onRun)
    {
        animator.SetBool("isRun", onRun);
    }
    public bool GetIsRun()
    {
        return animator.GetBool("isRun");
    }
    public void SetHideOnBase(bool onBase)
    {
        animator.SetBool("isHome", onBase);
    }
    public bool GetHideOnBase()
    {
        return animator.GetBool("isHome");
    }
    public void SetDistanceFromWayPoint(float distancefromtarget)
    {
        animator.SetFloat("distanceFromWaypoint", distancefromtarget);
    }
    public void SetDistanceFromPlayer(float currentdistance)
    {
        animator.SetFloat("distanceFromPlayer", currentdistance);
    }
    public bool GetIsDestroy()
    {
        return animator.GetBool("isDown");
    }
    public void StartIsDestroy()
    {
        animator.SetBool("isDown", true);
    }
}
