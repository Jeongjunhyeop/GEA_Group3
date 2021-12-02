using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    [SerializeField]
    RespawnPoint[] RPoints;

    int CheckedPointIndex = -1;

    public void RespawnChecked(int index)
    {
        CheckedPointIndex = index;
        OtherPointUncheck(CheckedPointIndex);
    }

    void OtherPointUncheck(int index)
    {
        if(CheckedPointIndex == -1)
        {
            Debug.LogError("리스폰 번호를 다시한번 확인하고 수정 바랍니다.");
            return;
        }
        for(int i = 0; i < RPoints.Length; i++)
        {
            if (i == CheckedPointIndex)
                continue;
            RPoints[i].UnCheck();
        }
    }
}
