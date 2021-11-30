using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAreaEnemy : MonoBehaviour
{
    CharacterState characterState;

    private void Start()
    {
        characterState = transform.root.GetComponent<CharacterState>();
    }
    public class AttackInfo
    {
        public int attackPower; // �� ������ ���ݷ�.
        //public Transform attacker; // ������.
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
        if (other.tag == "Player")
        {
            other.SendMessage("Damage");
        }
    }

}
