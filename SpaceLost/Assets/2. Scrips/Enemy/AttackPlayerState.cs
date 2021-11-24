using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayerState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyCtrl EnemyCtrl = animator.gameObject.GetComponent<EnemyCtrl>();
        EnemyCtrl.StartAttackPlayer();
    }
    /*public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyCtrl EnemyCtrl = animator.gameObject.GetComponent<EnemyCtrl>();

    }*/
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyCtrl EnemyCtrl = animator.gameObject.GetComponent<EnemyCtrl>();
        EnemyCtrl.EndAttackPlayer();
    }
}
