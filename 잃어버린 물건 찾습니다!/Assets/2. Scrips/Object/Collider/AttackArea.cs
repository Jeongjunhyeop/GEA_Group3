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

    //플레이어가 이 오브젝트를 잡을시
    void Hold()
    {   //공격콜라이더 활성화
        gameObject.SetActive(true);
    }
    //플레이어가 이 오브젝트를 놓을시
    void HandsOff()
    {
        //공격콜라이더 비활성화
        gameObject.SetActive(false);
    }

}
