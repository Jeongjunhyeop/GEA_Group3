using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingToTargetState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyCtrl EnemyCtrl = animator.gameObject.GetComponent<EnemyCtrl>();
        EnemyCtrl.StartMoveToTarget();
    }
}
