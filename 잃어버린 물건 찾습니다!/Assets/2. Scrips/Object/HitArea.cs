using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitArea : MonoBehaviour
{
    void Damage()
    {
        transform.root.SendMessage("Damage");

    }

    //�÷��̾ �� ������Ʈ�� ������
    void Hold()
    {   //�ǰ��ݶ��̴� ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
    //�÷��̾ �� ������Ʈ�� ������
    void HandsOff()
    {
        //�ǰ� �ݶ��̴� Ȱ��ȭ
        gameObject.SetActive(true);
    }
}
