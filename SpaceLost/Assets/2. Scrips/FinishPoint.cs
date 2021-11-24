using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    public int objectCheck;
    [Header("��ǥ ������Ʈ ����")]
    [SerializeField]
    private int ObjCheck = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
