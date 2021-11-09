using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitArea : MonoBehaviour
{
    void Damage()
    {
        transform.GetComponentInParent<ObjectCtrl>().SendMessage("Damage");

    }
}
