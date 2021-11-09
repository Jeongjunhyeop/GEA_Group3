using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitArea : MonoBehaviour
{
    ObjectCtrl objectCtrl;

    private void OnEnable()
    {
        objectCtrl = transform.GetComponentInParent<ObjectCtrl>();
    }
    void Damage()
    {
        //transform.root.SendMessage("Damage");
        objectCtrl.SendMessage("Damage");

    }
}
