using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTowerCtrl : MonoBehaviour
{
    CharacterState state;
    public GameObject destory;

    private void Start()
    {
        state = FindObjectOfType<CharacterState>();
        if (destory == null)
            return;
    }
    private void OnDestroy()
    {
      state.basicMSpeed += 1f;
      Destroy(destory);
    }
}
