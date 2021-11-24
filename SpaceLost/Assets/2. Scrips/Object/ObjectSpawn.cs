using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{ 
	public GameObject objectPrefab; 
	GameObject[] existObjects;
	int maxObject = 1;

	void Start()
	{
		existObjects = new GameObject[maxObject];
		StartCoroutine(Exec());
	}
	IEnumerator Exec()
	{
		while (true)
		{
			Respawn();
			//오브젝트 재생성까지 걸리는시간
			yield return new WaitForSecondsRealtime(20.0f);
		}
	}

	void Respawn()
	{
		for (int objectCount = 0; objectCount < existObjects.Length; ++objectCount)
		{
			if (existObjects[objectCount] == null)
			{
				existObjects[objectCount] = Instantiate(objectPrefab, transform.position, transform.rotation) as GameObject;
				return;
			}
		}
	}
}
