using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public GameObject UnChecked;
    public GameObject Checked;
    public GameObject ChangeEffect;
    //������ ����Ʈ�� ��ȣ. 0���� �����ؼ� �ϳ� �߰��� �� ���� 1 �� �÷������.
    public int RespawnPointIndex = -1;  
    public bool PointChecked;

    RespawnManager manager;

    private void Awake()
    {
        manager = GetComponentInParent<RespawnManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UnChecked.SetActive(false);
            Checked.SetActive(true);
            ChangeEffect.SetActive(true);
            PointChecked = true;
            manager.RespawnChecked(RespawnPointIndex);
        }
    }

    public void UnCheck()
    {
        UnChecked.SetActive(true);
        Checked.SetActive(false);
        ChangeEffect.SetActive(false);
        PointChecked = false;
    }
}
