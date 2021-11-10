using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    // General state machine variables

    private Animator animator;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
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

}
