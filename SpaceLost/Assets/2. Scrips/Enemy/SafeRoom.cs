using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeRoom : MonoBehaviour
{
    EnemyCtrl enemyCtrl;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            enemyCtrl = other.gameObject.GetComponent<EnemyCtrl>();

            enemyCtrl.maxDistanceToViewCheck = 0.0f;
            enemyCtrl.maxChaseDistance = 0.0f;
            enemyCtrl.maxDistanceToAnyCheck = 0.0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        enemyCtrl = other.gameObject.GetComponent<EnemyCtrl>();

        enemyCtrl.maxDistanceToViewCheck = 12.0f;
        enemyCtrl.maxChaseDistance = 10.0f;
        enemyCtrl.maxDistanceToAnyCheck = 6.0f; 
    }
}
