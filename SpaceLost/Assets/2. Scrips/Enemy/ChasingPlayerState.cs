using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingPlayerState : StateMachineBehaviour
{
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyAi EnemyAi = animator.gameObject.GetComponent<EnemyAi>();
        EnemyAi.StartChasePlayer();
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyAi EnemyAi = animator.gameObject.GetComponent<EnemyAi>();
        EnemyAi.EndChasePlayer();
    }
}
