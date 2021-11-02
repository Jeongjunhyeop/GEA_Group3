using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitArea : MonoBehaviour
{
    void Damage()
    {
        transform.root.SendMessage("Damage");

    }

    //플레이어가 이 오브젝트를 잡을시
    void Hold()
    {   //피격콜라이더 비활성화
        gameObject.SetActive(false);
    }
    //플레이어가 이 오브젝트를 놓을시
    void HandsOff()
    {
        //피격 콜라이더 활성화
        gameObject.SetActive(true);
    }
}
