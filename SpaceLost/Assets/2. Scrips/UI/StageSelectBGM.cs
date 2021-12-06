using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectBGM : MonoBehaviour
{
    public GameObject audioBGM;
    private void Start()
    {
        audioBGM = GameObject.FindGameObjectWithTag("BGM");
        Destroy(this.audioBGM);
    }
}
