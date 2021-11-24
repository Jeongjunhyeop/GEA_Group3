#pragma warning(disable:8803)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckObject : MonoBehaviour
{
    public float ObjTimer = 0;
    public float GameTimer = 0;

    public bool objectCheck = false;
    public bool Objectin = false;
    public bool gameFail = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameFail)
        {
            GameTimer += Time.deltaTime;
            if(GameTimer > 120)
            {
                gameFail = true;
                Debug.Log("GameFail");//���� �� �Ѿ�� �ڵ� �ۼ�
            }
        }

        if(objectCheck == true)
        {
            ObjTimer += Time.deltaTime;

            if(ObjTimer > 3)
            {
                Objectin = true;
                SceneManager.LoadScene("ClearScene");
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Debug.Log("Object got"); // ���� �� �Ѿ�� �ڵ� �ۼ�
                ObjTimer = 0;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "FinishPoint")
        {
            objectCheck = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "FinishPoint")
        {
            objectCheck = false;
            ObjTimer = 0;
        }
    }
}

