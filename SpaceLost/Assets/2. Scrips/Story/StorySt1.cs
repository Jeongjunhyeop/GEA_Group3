using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StorySt1 : MonoBehaviour
{
    public GameObject canvasObj;
    public Text stroyText;
    string text = " 토마토를 매우 좋아하는 ";
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
        if(Input.GetKeyDown(KeyCode.F))
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

        yield return new WaitForSeconds(2.5f);
        canvasObj.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        text = "토마토성의 토마인들은";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(0.5f);
        text = "토마토를 무작위로 수확하다가";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(0.5f);
        text = " 토마토의 씨가 말라버렸다";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(0.5f);
        text = "그래서 토마토맛토성의 토마인들은";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(0.5f);
        text = " 그들의 성물인 토마토노스톤을 찾기 위해";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(0.5f);
        text = " 지구로 토마토노스톤 수색조장인";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(0.5f);
        text = " 토마인 토마스를 보내기로 했다";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(0.5f);
        text = " 토마인 토마스는 지구로 가는 도중";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(0.5f);
        text = " 토마우주선이 고장나 지구로 불시착 하게 된다";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.14f);
        }
        yield return new WaitForSeconds(0.5f);
        text = " 토마인 토마스는 토마우주선을 고쳐";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.14f);
        }
        yield return new WaitForSeconds(0.5f);
        text = " 무사히 돌아가";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.14f);
        }
        yield return new WaitForSeconds(0.5f);
        text = " 토마토맛토성을 구할 수 있을까?";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.14f);
        }      
        yield return new WaitForSeconds(1.0f);
        RealStart();
    }

    void RealStart()
    {
        ClickSkip();

    }

    public void ClickSkip()
    {
        SceneManager.LoadScene("Stage1", LoadSceneMode.Single);
    }
}
