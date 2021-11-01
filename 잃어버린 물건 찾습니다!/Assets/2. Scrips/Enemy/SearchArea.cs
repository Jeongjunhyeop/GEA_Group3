using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchArea : MonoBehaviour
{
	EnemyCtrl enemyCtrl;
	void Start()
	{
		// EnemyCtrl�� �̸� �غ��Ѵ�.
		enemyCtrl = transform.root.GetComponent<EnemyCtrl>();
	}

	void OnTriggerStay(Collider other)
	{
		// Player�±׸� Ÿ������ �Ѵ�.
		if (other.tag == "Player")
			enemyCtrl.SetAttackTarget(other.transform);
	}

	void OnTriggerExit(Collider other)
	{
		// Player�±׸� Ÿ������ �Ѵ�.
		if (other.tag == "Player")
			enemyCtrl.ResetAttackTarget();
	}
}
