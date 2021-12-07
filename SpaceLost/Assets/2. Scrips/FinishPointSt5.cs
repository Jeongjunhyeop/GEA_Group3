using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishPointSt5 : MonoBehaviour
{
    public Text ObjCount;
    public Text ObjCrashCount;

    public int objectCheck;
    public int CrashObject;

    [Header("��ǥ ������Ʈ ����")]
    [SerializeField]
    private int ObjCheck = 2;

    [Header("�ı��ؾ��� ������Ʈ ����")]
    [SerializeField]
    private int Crash = 2;

    // Update is called once per frame
    void Update()
    {
        ObjCount.text = objectCheck + "/" + ObjCheck;
        ObjCrashCount.text = CrashObject +"/" + Crash;

        
        if (objectCheck == ObjCheck && CrashObject == Crash)
        {
            StartCoroutine("Delay");
            //Debug.Log("Object got"); // ���� �� �Ѿ�� �ڵ� �ۼ�
            
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
        SceneManager.LoadScene("EndingStory");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }
}