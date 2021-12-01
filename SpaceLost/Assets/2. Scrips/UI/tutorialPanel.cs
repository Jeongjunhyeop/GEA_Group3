using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialPanel : MonoBehaviour
{
    public GameObject nextPanel;
    public GameObject nowPanel;

    public void nextPage()
    {
        if(nextPanel == null)
        {
            endPage();
            return;
        }
        nowPanel.SetActive(false);
        nextPanel.SetActive(true);
    }

    public void endPage()
    {
        nowPanel.SetActive(false);
        Time.timeScale = 1;
    }

    private void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            nextPage();
        }
    }
}
