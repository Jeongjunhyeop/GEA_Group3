using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishPoint : MonoBehaviour
{
    public Text ObjCount;
    public int objectCheck;
    [Header("��ǥ ������Ʈ ����")]
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
            Debug.Log("Object got"); // ���� �� �Ѿ�� �ڵ� �ۼ�
            
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
