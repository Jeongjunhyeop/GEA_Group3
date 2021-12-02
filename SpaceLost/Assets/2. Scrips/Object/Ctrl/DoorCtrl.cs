using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCtrl : MonoBehaviour
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
    void Update()
    {
        if(count >= switchNUM) //��ư ���� Ƚ���� 3 �̻��̸� open
        {
            anim.SetBool("isOpen", true);
            GameObject.Find("SoundController").GetComponent<SoundControl>().OpenDoor();
            Debug.Log("Open");
            switchNUM = 0;
        }
        if(count < switchNUM)
        {
            anim.SetBool("isOpen", false);
        }
    }
}
