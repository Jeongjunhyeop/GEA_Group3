using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour
{
    public enum ItemDestoryKind
    {
        DontDestroy,
        Destroy,
    }
    public enum ItemKind
    {
        TimeUp, //게임플레이시간 증가
        SpeedUp, //플레이어 이동속도 일시 증가
        SpeedDown, //적 이동속도 일시 감소
        Empty, //꽝
        Nav, //미션아이템 위치 표시
        Sheild, //공격 1회 막기
    };
    public ItemKind kind;
    public ItemDestoryKind desKind;
    [SerializeField]
    private float rotateSpeed; //아이템 회전속도

    private void Start(){
        if (desKind == ItemDestoryKind.Destroy)
        {
            StartCoroutine("ItemDestroy");
            if (kind == ItemKind.Empty)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (kind == ItemKind.Empty)
            {
                Destroy(gameObject);
            }
        }
    }

    void Update(){
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World); //아이템 회전
    }


    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            CharacterState aStatus = other.GetComponent<CharacterState>();
            aStatus.GetItem(kind);
            Destroy(gameObject); //아이템삭제
        }
    }

    IEnumerator ItemDestroy()
    {
        yield return new WaitForSecondsRealtime(5f);
        Destroy(gameObject);
    }
}
