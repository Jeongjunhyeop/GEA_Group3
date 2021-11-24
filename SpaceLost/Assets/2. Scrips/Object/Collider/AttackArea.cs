using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    CharacterState characterState;

    private void Start()
    {
        characterState = transform.root.GetComponent<CharacterState>();

    }
    public class AttackInfo
    {
        public int attackPower; // 이 공격의 공격력.
        //public Transform attacker; // 공격자.
    }

    AttackInfo GetAttackInfo()
    {
        AttackInfo attackInfo = new AttackInfo();

        attackInfo.attackPower = characterState.ATC;
        if (characterState.powerBoost)
            attackInfo.attackPower += 100;
        //attackInfo.attacker = transform.root;

        return attackInfo;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "ObjHit")
        {
            other.SendMessage("Damage", GetAttackInfo());
        }
        if (other.tag == "Enemy")
        {
            other.SendMessage("Damage", GetAttackInfo());
        }
    }

}
