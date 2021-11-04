using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ObjHit")
        {
            other.SendMessage("Damage");
        }
    }

    //�÷��̾ �� ������Ʈ�� ������
    void Hold()
    {   //�����ݶ��̴� Ȱ��ȭ
        gameObject.SetActive(true);
    }
    //�÷��̾ �� ������Ʈ�� ������
    void HandsOff()
    {
        //�����ݶ��̴� ��Ȱ��ȭ
        gameObject.SetActive(false);
    }

}
