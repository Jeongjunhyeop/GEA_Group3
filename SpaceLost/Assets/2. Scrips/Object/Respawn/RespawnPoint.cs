using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public GameObject UnChecked;
    public GameObject Checked;
    public GameObject ChangeEffect;
    //리스폰 포인트의 번호. 0부터 시작해서 하나 추가할 때 마다 1 씩 늘려줘야함.
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
