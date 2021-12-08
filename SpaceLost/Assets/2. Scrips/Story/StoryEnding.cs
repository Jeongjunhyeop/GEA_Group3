using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryEnding : MonoBehaviour
{
    [Header("Fade")]
    public Image fadeImage;
    float time = 0;//지속시간
    float fadeTime = 1f;

    [Header("Story")]
    public Text stroyText;
    string text = "성  공";
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
            Destroy(audios[0]);
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
            SceneManager.LoadScene("MainScene");
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
        stroyText.color = Color.red;
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(0.3f);
        stroyText.color = Color.black;
        text = "황금인간은";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(0.6f);

        text = "갓마토의 도움으로";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(0.6f);

        text = "토마토노스톤을 모아";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(0.6f);

        text = "토마토맛토성으로 돌아간다";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(0.6f);

        stroyText.color = Color.yellow;
        text = "갓마토 : 잘가라 토마인이여";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(0.6f);

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
        SceneManager.LoadScene("TomaWorld", LoadSceneMode.Single);
    }
}
