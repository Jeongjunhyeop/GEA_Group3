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
        SceneManager.LoadScene("PlayerDemo");
    }

    public void loadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
