using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StorySt3 : MonoBehaviour
{
    [Header("Fade")]
    public Image fadeImage;
    float time = 0;//���ӽð�
    float fadeTime = 1f;

    [Header("Story")]
    public Text stroyText;
    string text = "���� �����?";
    public GameObject dontDestroy;
    public GameObject godTomato;


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
        text = "��...��...?";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.15f);
        }
        godTomato.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        text = "�丶��� : ...������ ��..... �� ������";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.6f);
        text = "�丶��� : ...�ҷ� ���Ŷ�..";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.1f);
        }
        godTomato.SetActive(false);
        yield return new WaitForSeconds(0.6f);
        text = "��ø���!! ��ø���!!";
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
        SceneManager.LoadScene("3.City", LoadSceneMode.Single);
    }
}
