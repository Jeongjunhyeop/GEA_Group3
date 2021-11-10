using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class inGameUi : MonoBehaviour
{
    public float limitTime = 100;
    private float startTime;
    public Image TargetImage;

    // Start is called before the first frame update
    void Start()
    {
        startTime = limitTime;
    }

    // Update is called once per frame
    void Update()
    {
        limitTime -= Time.deltaTime;
        TargetImage.fillAmount = limitTime / startTime;

        if (limitTime <= 0)
        {
            gameObject.GetComponent<SceneButtonManager>().loadFailScene();
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
