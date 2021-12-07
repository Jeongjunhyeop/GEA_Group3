using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StorySt2 : MonoBehaviour
{
    [Header("Fade")]
    public Image fadeImage;
    float time = 0;//지속시간
    float fadeTime = 1f;

    [Header("Story")]
    public Text stroyText;
    string text = "어...?!";
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
        time = 0f;
        Color alpha = fadeImage.color;
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(1, 0, time);
            fadeImage.color = alpha;
            yield return null;
        }
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(0.6f);
        text = "저것은 토마토맛토성?!?!";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(0.5f);
        text = "아....아직 머쉬룸스톤밖에 못찾았는데...";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(0.6f);
        text = "어?...어?!....어?!!!!";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.12f);
        }
        yield return new WaitForSeconds(0.6f);
        text = "으아아아아악~!!!!";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.1f);
        }
        time = 0;
        yield return new WaitForSeconds(0.5f);
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(0, 1, time);
            fadeImage.color = alpha;
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);

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
