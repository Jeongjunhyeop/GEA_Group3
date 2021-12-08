using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TomaWorldCtrl : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("Ending");
    }

    private void Update()
    {
        if (Input.anyKey)
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
