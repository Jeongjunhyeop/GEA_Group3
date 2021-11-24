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

    public float timer = 0;
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
                Debug.Log("GameFail");//실패 씬 넘어가는 코드 작성
            }
        }

        

        
    }

    


}

