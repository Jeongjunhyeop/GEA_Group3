using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishPoint : MonoBehaviour
{
    public Text ObjCount;
    public int objectCheck;
    [Header("목표 오브젝트 갯수")]
    [SerializeField]
    private int ObjCheck = 2;

    // Update is called once per frame
    void Update()
    {
        ObjCount.text = objectCheck + "/"+ ObjCheck;

        if(objectCheck == ObjCheck)
        {
            SceneManager.LoadScene("ClearScene");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("Object got"); // 성공 씬 넘어가는 코드 작성
            
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MissionObj")
        {
            objectCheck += 1;
        }


    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "MissionObj")
        {
            objectCheck -= 1;
            
        }
    }
}
