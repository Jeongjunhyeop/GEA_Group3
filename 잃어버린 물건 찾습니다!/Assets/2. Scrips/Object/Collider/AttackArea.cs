using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine("AutoDisable");

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ObjHit")
        {
            other.SendMessage("Damage");
        }
    }

    private IEnumerator AutoDisable()
    {
        //0.1초 후에 오브젝트가 사라지도록 한다.
        yield return new WaitForSeconds(0.5f);

        gameObject.SetActive(false);
    }


}
