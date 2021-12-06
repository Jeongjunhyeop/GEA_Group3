using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StorySt1 : MonoBehaviour
{
    public GameObject canvasObj;
    public Text stroyText;
    string text = " �丶�並 �ſ� �����ϴ� ";
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
        text = "�丶�伺�� �丶�ε���";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(0.5f);
        text = "�丶�並 �������� ��Ȯ�ϴٰ�";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(0.5f);
        text = " �丶���� ���� ������ȴ�";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(0.5f);
        text = "�׷��� �丶����伺�� �丶�ε���";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(0.5f);
        text = " �׵��� ������ �丶��뽺���� ã�� ����";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(0.5f);
        text = " ������ �丶��뽺�� ����������";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(0.5f);
        text = " �丶�� �丶���� ������� �ߴ�";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(0.5f);
        text = " �丶�� �丶���� ������ ���� ����";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(0.5f);
        text = " �丶���ּ��� ���峪 ������ �ҽ��� �ϰ� �ȴ�";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.14f);
        }
        yield return new WaitForSeconds(0.5f);
        text = " �丶�� �丶���� �丶���ּ��� ����";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.14f);
        }
        yield return new WaitForSeconds(0.5f);
        text = " ������ ���ư�";
        for (int ii = 0; ii <= text.Length; ii++)
        {
            stroyText.text = text.Substring(0, ii);

            yield return new WaitForSeconds(0.14f);
        }
        yield return new WaitForSeconds(0.5f);
        text = " �丶����伺�� ���� �� ������?";
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
