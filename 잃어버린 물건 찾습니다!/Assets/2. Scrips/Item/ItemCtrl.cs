using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour
{
    public enum ItemKind
    {
        TimeUp, //게임플레이시간 증가
        SpeedUp, //플레이어 이동속도 일시 증가
        SpeedDown, //적 이동속도 일시 감소
    };
    public ItemKind kind;
    public float rotateSpeed; //아이템 회전속도

    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World); //아이템 회전

    }

    private void OnTriggerEnter(Collider other)
    {
        //플레이어 충동처리
    }
}
