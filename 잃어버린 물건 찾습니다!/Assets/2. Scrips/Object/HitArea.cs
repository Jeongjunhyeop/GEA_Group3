using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitArea : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //나중에 공격상태와 따로 스크립트 나눌예정
        transform.SendMessage("Damage");

    }
}
