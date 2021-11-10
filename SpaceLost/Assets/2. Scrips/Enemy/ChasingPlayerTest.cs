using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingPlayerTest : StateMachineBehaviour
{


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyAnimation EnemyAnimation = animator.gameObject.GetComponent<EnemyAnimation>();
        EnemyAnimation.StartChasePlayer();
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyAnimation EnemyAnimation = animator.gameObject.GetComponent<EnemyAnimation>();
        EnemyAnimation.EndChasePlayer();
    }
}

