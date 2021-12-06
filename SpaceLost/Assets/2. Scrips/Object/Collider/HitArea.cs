using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitArea : MonoBehaviour
{
    BoxCollider switchCollider;

    private void OnEnable()
    {
        switchCollider = GetComponent<BoxCollider>();
        StartCoroutine("Active");
        switchCollider.enabled = false;
    }
    IEnumerator Active()
    {
        yield return new WaitForSeconds(0.5f);
        switchCollider.enabled = true;
    }
    void Damage(AttackArea.AttackInfo attackInfo)
    {
        transform.GetComponentInParent<ObjectCtrl>().SendMessage("Damage", attackInfo);

    }
    void Explosion()
    {
        transform.GetComponentInParent<ObjectCtrl>().SendMessage("Explosion");
    }
    void ExplosiveServer()
    {
        transform.GetComponentInParent<ObjectCtrl>().SendMessage("ExplosiveServer");
    }


}
