using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TomaWorldCtrl : MonoBehaviour
{
    [Header("Fade")]
    public Image fadeImage;
    float time = 0;//지속시간
    float fadeTime = 1f;
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
        time = 0f;
        Color alpha = fadeImage.color;
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(1, 0, time);
            fadeImage.color = alpha;
            yield return null;
        }

        yield return new WaitForSeconds(30f);

        while (alpha.a < 1f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(0, 1, time);
            fadeImage.color = alpha;
            yield return null;
        }
        ClickSkip();
    }
    public void ClickSkip()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
