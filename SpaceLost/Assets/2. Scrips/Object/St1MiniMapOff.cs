using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class St1MiniMapOff : MonoBehaviour
{
    //��������1���� �ٸ� ��ũ��Ʈ�� �������� �ȸ���
    public GameObject offObj;

    void Off()
    {
        offObj.SetActive(false);
    }

    void MinimapOn()
    {
        offObj.SetActive(true);
    }

    private void OnEnable()
    {
        offObj.transform.position = new Vector3(transform.position.x, offObj.transform.position.y, transform.position.z);

    }
}
