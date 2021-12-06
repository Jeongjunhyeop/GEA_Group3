using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTest : MonoBehaviour
{
    Animator anim;
    [Header("�� ���� ������ ����ġ ����")]
    [SerializeField]
    private int switchNUM;

    public int count; //����ġ�� ����Ƚ��
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
