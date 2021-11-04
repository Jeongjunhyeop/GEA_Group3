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
        Empty, //꽝
        Nav, //미션아이템 위치 표시
        Sheild, //공격 1회 막기
        MissionObject, //미션아이템
    };
    public ItemKind kind;
    [SerializeField]
    private float rotateSpeed; //아이템 회전속도

    private void Start()
    {
        if(kind == ItemKind.Empty)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World); //아이템 회전

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") //플레이어와 충돌시
        {
            Destroy(gameObject); //아이템삭제

            switch(kind)
            {
                case ItemKind.TimeUp:
                    print("제한시간증가");
                    break;
                case ItemKind.SpeedUp:
                    print("플레이어이동속도증가");
                    break;
                case ItemKind.SpeedDown:
                    print("적이동속도감소");
                    break;
                case ItemKind.MissionObject:
                    print("미션아이템획득");
                    break;
                case ItemKind.Nav:
                    print("미션아이템위치표시");
                    break;
                case ItemKind.Sheild:
                    print("적공격 1회 막기");
                    break;
            }
        }
    }
}
