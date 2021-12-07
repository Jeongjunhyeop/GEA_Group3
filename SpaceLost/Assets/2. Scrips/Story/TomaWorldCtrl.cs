using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TomaWorldCtrl : MonoBehaviour
{
    public GameObject audioBGM;
    private void Start()
    {
        audioBGM = GameObject.FindGameObjectWithTag("BGM");
        if (audioBGM == null) { return; }
        Destroy(this.audioBGM);

        StartCoroutine("Ending");
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("MainScene");
        }
    }

    IEnumerator Ending()
    {
        yield return new WaitForSeconds(30f);
        ClickSkip();
    }
    public void ClickSkip()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
