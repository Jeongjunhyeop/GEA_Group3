using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishPoint : MonoBehaviour
{
    public Text ObjCount;
    public Text ObjCrashCount;

    public int objectCheck;
    public int CrashObject;

    [Header("목표 오브젝트 갯수")]
    [SerializeField]
    private int ObjCheck = 2;

    [Header("파괴해야할 오브젝트 갯수")]
    [SerializeField]
    private int Crash = 2;

    // Update is called once per frame
    void Update()
    {
        ObjCount.text = objectCheck + "/" + ObjCheck;
        ObjCrashCount.text = CrashObject +"/" + Crash;

        if(objectCheck == ObjCheck && CrashObject == Crash && gameObject.name == "FinishPointSt5")
        {
            StartCoroutine("Ending");
        }
        else if(objectCheck == ObjCheck && CrashObject == Crash)
        {
            StartCoroutine("Delay");
            //Debug.Log("Object got"); // 성공 씬 넘어가는 코드 작성
            
        }

        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MissionObj")
        {
            objectCheck += 1;
            Destroy(other);
            GameObject.Find("SoundController").GetComponent <SoundControl>().MissionUp();
        }


    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "MissionObj")
        {
            objectCheck -= 1;
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("ClearScene");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    IEnumerator Ending()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("EndingStory");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
