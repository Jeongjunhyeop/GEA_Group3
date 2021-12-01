using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ChasingPlayerTest : StateMachineBehaviour
{


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyCtrl EnemyCtrl = animator.gameObject.GetComponent<EnemyCtrl>();
        EnemyCtrl.StartChasePlayer();
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)

    {
        EnemyCtrl EnemyCtrl = animator.gameObject.GetComponent<EnemyCtrl>();
        EnemyCtrl.GetPlayerNav();

    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyCtrl EnemyCtrl = animator.gameObject.GetComponent<EnemyCtrl>();
        EnemyCtrl.EndChasePlayer();
    }
}

