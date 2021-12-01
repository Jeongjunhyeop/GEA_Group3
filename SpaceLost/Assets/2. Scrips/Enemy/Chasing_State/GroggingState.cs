using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroggingState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyCtrl EnemyCtrl = animator.gameObject.GetComponent<EnemyCtrl>();
        EnemyCtrl.StartGrogging();
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyCtrl EnemyCtrl = animator.gameObject.GetComponent<EnemyCtrl>();
        EnemyCtrl.UpdateGrogging();
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyCtrl EnemyCtrl = animator.gameObject.GetComponent<EnemyCtrl>();
        EnemyCtrl.EndGrogging();
    }
}
