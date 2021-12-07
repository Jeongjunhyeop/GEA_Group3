using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_4stage : MonoBehaviour
{
    public GameObject door;
    public GameObject police;
    public ObjectStatus key;
    public GameObject portal;
    ObjectStatus objStatus;
    public bool IsDestroy = false;
    // Start is called before the first frame update
    private void Awake()
    {
        if(police != null)
        {
            police.SetActive(false);
        }
        if (door != null)
        {
            door.SetActive(true);
        }
        if (portal != null)
        {
            portal.SetActive(false);
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
            if (objStatus.objectName == key.objectName && key.objectName != null)
            {
                Open();
            }
        }
    }
    // Update is called once per frame
    void Open()
    {
        if(door != null)
        {
            door.SetActive(false);
        }
        if (police != null)
        {
            police.SetActive(true);
        }
        if(IsDestroy)
        {
            if (portal != null)
            {
                portal.SetActive(true);
            }
            Destroy(gameObject);
        }
        
    }
}
