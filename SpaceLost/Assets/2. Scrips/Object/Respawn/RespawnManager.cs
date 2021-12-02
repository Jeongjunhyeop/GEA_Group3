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
            Debug.LogError("������ ��ȣ�� �ٽ��ѹ� Ȯ���ϰ� ���� �ٶ��ϴ�.");
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
