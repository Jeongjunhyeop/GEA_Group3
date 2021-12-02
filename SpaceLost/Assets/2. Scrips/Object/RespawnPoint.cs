using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public GameObject UnChecked;
    public GameObject Checked;
    public GameObject ChangeEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UnChecked.SetActive(false);
            Checked.SetActive(true);
            ChangeEffect.SetActive(true);
        }
    }
}
