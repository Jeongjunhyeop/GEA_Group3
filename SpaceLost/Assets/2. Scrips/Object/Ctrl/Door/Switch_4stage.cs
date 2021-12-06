using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_4stage : MonoBehaviour
{
    public GameObject door;
    public GameObject police;
    public ObjectStatus key;
    ObjectStatus objStatus;
    // Start is called before the first frame update
    private void Awake()
    {
        if(police != null)
        {
            police.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.gameObject.tag == "ObjHit")
        {
            Debug.Log(true);
            objStatus = other.gameObject.GetComponentInParent<ObjectStatus>();
            Debug.Log(objStatus.objectName);
            if (objStatus.objectName == key.objectName)
            {
                Open();
            }
        }
    }
    // Update is called once per frame
    void Open()
    {
        door.SetActive(false);
        if (police != null)
        {
            police.SetActive(true);
        }
    }
}
