using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButtonManager : MonoBehaviour
{

    public void loadStageScene()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void loadTestScene()
    {
        SceneManager.LoadScene("11.11DemoScene");
    }

    public void loadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void loadClearScene()
    {
        SceneManager.LoadScene("ClearScene");
    }

    public void loadFailScene()
    {
        SceneManager.LoadScene("FailScene");
    }

    public void loadStage1Scene()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void loadBeforeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void loadStage2Scene()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void loadStage3Scene()
    {
        SceneManager.LoadScene("3.City");
    }

    public void loadStage4Scene()
    {
        SceneManager.LoadScene("Stage4");
    }

    public void loadStage5Scene()
    {
        SceneManager.LoadScene("BossStage");
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void Update()
    {
        //if (Input.GetKey("escape"))
        //{
        //    Cursor.visible = true;
        //    Cursor.lockState = CursorLockMode.None;
        //    SceneManager.LoadScene("MainScene");
        //}
    }
}
