using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTest : MonoBehaviour
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
    public void Start()
    {
        count = 0;
    }
    void Update()
    {
        if (count == switchNUM)
        {
            //GameObject.Find("SoundController").GetComponent<SoundControl>().Explosion();
            anim.SetBool("isOpen", true);
            
        }
        if (count < switchNUM)
        {
            anim.SetBool("isOpen", false);
        }
    }

   
}
