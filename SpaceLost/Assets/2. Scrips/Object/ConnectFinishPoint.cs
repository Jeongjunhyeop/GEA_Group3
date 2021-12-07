using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectFinishPoint : MonoBehaviour
{
    public ObjectStatus key;
    public FinishPoint finishpoint;
    ObjectStatus objStatus;

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
        finishpoint.objectCheck += 1;
    }
}
