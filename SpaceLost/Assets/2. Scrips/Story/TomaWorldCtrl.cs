using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TomaWorldCtrl : MonoBehaviour
{
    public GameObject[] group;

    [Header("Fade")]
    public Image fadeImage;
    float time = 0;//지속시간
    float fadeTime = 1f;
    private void Start()
    {
        if (group.Length == 0) { return; }
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
        group[0].SetActive(true);
        yield return new WaitForSeconds(29.6f);
        group[1].SetActive(true);
        yield return new WaitForSeconds(28f);
        group[2].SetActive(true);
        yield return new WaitForSeconds(15.9f);

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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
