using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCtrl : MonoBehaviour
{
    Animator anim;
    [Header("이 문과 연결할 스위치 갯수")]
    [SerializeField]
    private int switchNUM;

    public int count; //스위치가 눌린횟수
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(count >= switchNUM) //버튼 누른 횟수가 3 이상이면 open
        {
            anim.SetBool("isOpen", true);
        }
        if(count < switchNUM)
        {
            anim.SetBool("isOpen", false);
        }
    }
}
