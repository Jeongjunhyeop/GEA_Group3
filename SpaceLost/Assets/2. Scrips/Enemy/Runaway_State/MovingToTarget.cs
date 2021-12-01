using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingToTarget : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyRunCtrl EnemyRunCtrl = animator.gameObject.GetComponent<EnemyRunCtrl>();
        EnemyRunCtrl.StartMoveToTarget();
    }
}
