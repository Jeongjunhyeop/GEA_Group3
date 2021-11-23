using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTowerCtrl : MonoBehaviour
{
    public GameObject destory;

    private void Start()
    {
        if (destory == null)
            return;
    }
    private void OnDestroy()
    {
      Destroy(destory);
    }
}
