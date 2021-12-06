using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StorySt2 : MonoBehaviour
{
    public Text stroyText;
    string text = "어......?!";
    public GameObject dontDestroy;


    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine("StroyStart");
        DontDestroyOnLoad(dontDestroy);


        GameObject[] audios = GameObject.FindGameObjectsWithTag("BGM");

        if (audios.Length >= 2)
        {
            Destroy(audios[1]);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RealStart();
        }
        if (Input.GetKey("escape"))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("StageSelect");
        }
    }

    IEnumerator StroyStart()
    {
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.17f);
        }
        yield return new WaitForSeconds(0.6f);
        text = "저것은 토마토맛토성?!?!";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.17f);
        }
        yield return new WaitForSeconds(0.6f);
        text = "아....아직 머쉬룸스톤밖에 못찾았는데...";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.17f);
        }
        yield return new WaitForSeconds(0.6f);
        text = "어?...어?!....어?!!!!";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.12f);
        }
        yield return new WaitForSeconds(0.8f);
        text = "으아아아아악~!!!!";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(2f);

        RealStart();
    }

    void RealStart()
    {

        ClickSkip();

    }

    public void ClickSkip()
    {
        SceneManager.LoadScene("Stage2", LoadSceneMode.Single);
    }
}
