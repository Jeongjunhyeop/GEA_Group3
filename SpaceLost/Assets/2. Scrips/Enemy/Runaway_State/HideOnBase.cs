using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnBase : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyRunCtrl EnemyRunCtrl = animator.gameObject.GetComponent<EnemyRunCtrl>();
        EnemyRunCtrl.StartHideOnBase();
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyRunCtrl EnemyRunCtrl = animator.gameObject.GetComponent<EnemyRunCtrl>();
        EnemyRunCtrl.UpdateHideOnBase();
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
