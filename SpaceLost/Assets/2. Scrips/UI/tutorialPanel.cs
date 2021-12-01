using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialPanel : MonoBehaviour
{
    public GameObject nextPanel;
    public GameObject nowPanel;


    public void nextPage()
    {
        nowPanel.SetActive(false);
        nextPanel.SetActive(true);
    }

    public void endPage()
    {
        nowPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            nextPage();
        }
    }
}
