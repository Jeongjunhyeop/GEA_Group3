using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRunAI : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyRunCtrl EnemyRunCtrl = animator.gameObject.GetComponent<EnemyRunCtrl>();
        EnemyRunCtrl.StartDestroyed();
    }
}
